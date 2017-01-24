using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using surplus_auctioneer_models;
using surplus_auctioneer_webapp.Models;
using surplus_auctioneer_webdata;
using WebGrease.Css.Extensions;
using surplus_auctioneer_decision_engine;
using surplus_auctioneer_webapp.WebHelpers;

namespace surplus_auctioneer_webapp.Controllers
{
    public class AuctionController : Controller
    {
        public ActionResult List()
        {
            ViewBag.Message = "Current Auctions";

            ListViewModel model = new ListViewModel();

            model.Auctions = RetrieveAuctionsFromCache();

            if (model.Auctions == null)
            {
                throw new ApplicationException("No auctions found");
            }

            return View(model);
        }
        public ActionResult Search()
        {
            ViewBag.Message = "Search for auction items here";

            SearchViewModel model = new SearchViewModel();

            model = AddAuctionSources(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Search Results";

                model = AddAuctionSources(model);

                List<Auction> auctions;

                //If we're in DEBUG, don't use the cache, go out and get the results
#if DEBUG
                auctions = Helpers.GetAllAuctions();
#else
                auctions = RetrieveAuctionsFromCache();
#endif
                model.AuctionItems = new List<AuctionItem>();

                foreach (Auction a in auctions)
                {
                    a.AuctionItems.Where(x =>
                                    (x.NextBidRequired >= model.MinPrice && x.NextBidRequired <= model.MaxPrice)).ForEach(model.AuctionItems.Add);
                }

                if (!string.IsNullOrEmpty(model.Keywords) && model.Keywords.Length > 0)
                {
                    string[] items = model.Keywords.ToLower().Split(',');
                    model.AuctionItems = model.AuctionItems.Where(
                            x =>
                                (x.ShortDescription != null && items.Any(x.ShortDescription.ToLower().Contains)) ||
                                (x.FullDescription != null && items.Any(x.FullDescription.ToLower().Contains))).ToList();
                }

                if (model.SelectedAuctionSources != null)
                {
                    List<AuctionItem> tempList = new List<AuctionItem>();
                    foreach (string item in model.SelectedAuctionSources)
                    {
                        tempList = tempList.Concat(model.AuctionItems.Where(x => x.Auction.AuctionSource == item)).ToList();
                    }
                    model.AuctionItems = tempList;
                }

                if (!model.AuctionItems.Any())
                {
                    model.ErrorMessage = "No Results Found";
                }
            }

            return View(model);

        }

        private SearchViewModel AddAuctionSources(SearchViewModel model)
        {
            List<SelectListItem> auctionSources = new List<SelectListItem>();

            auctionSources.Add(new SelectListItem() { Text = "Illinois", Value = "Illinois" });
            auctionSources.Add(new SelectListItem() { Text = "Minnesota", Value = "Minnesota" });
            auctionSources.Add(new SelectListItem() { Text = "Wisconsin", Value = "Wisconsin" });

            model.AuctionSources = new MultiSelectList(auctionSources.OrderBy(x => x.Text), "Value", "Text");

            return model;
        }

        public ActionResult Recommendations()
        {
            RecommendationsViewModel model = new RecommendationsViewModel();
            List<Auction> auctions = RetrieveAuctionsFromCache();

            model.RecommendedAuctionItems = AuctionSuggestions.GetSuggestions(auctions);

            if (!model.RecommendedAuctionItems.Any())
            {
                model.ErrorMessage = "No recommendations found";
            }

            return View(model);
        }

        public ActionResult EndingSoon()
        {
            SearchViewModel model = new SearchViewModel();

            var auctions = RetrieveAuctionsFromCache();

            DateTime central = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                    DateTime.UtcNow, "Central Standard Time");

            foreach (Auction auction in auctions)
            {
                
#if DEBUG
                //Do 5 days if in DEBUG to make sure we get results
                auction.AuctionItems.Where(x => x.EndDateTime <= central.AddDays(5)).ForEach(model.AuctionItems.Add);
#else
                auction.AuctionItems.Where(x => x.EndDateTime <= central.AddDays(1)).ForEach(model.AuctionItems.Add);
#endif

            }

            if (!model.AuctionItems.Any())
            {
                model.ErrorMessage = "No upcoming auctions found";
            }

            return View(model);
        }

        private List<Auction> RetrieveAuctionsFromCache()
        {
            List<Auction> auctions = (List<Auction>)HttpRuntime.Cache["auctionData"];
            int counter = 0;

            while (auctions == null && counter < 5)
            {
                Tools.LoadAuctionCache("auctionData", null, CacheItemRemovedReason.Expired);
                counter++;
            }

            if (auctions == null)
            {
                throw new ApplicationException("No auctions found in cache, cache refresh attempted 5 times");
            }

            return auctions;
        }
    }
}
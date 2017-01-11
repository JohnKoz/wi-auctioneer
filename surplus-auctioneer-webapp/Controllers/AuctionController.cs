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

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Search Results";

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

                if (!model.AuctionItems.Any())
                {
                    model.ErrorMessage = "No Results Found";
                }
            }

            return View(model);

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
                auction.AuctionItems.Where(x => x.EndDateTime <= central.AddDays(1)).ForEach(model.AuctionItems.Add);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using surplus_auctioneer_models;
using surplus_auctioneer_webapp.Models;
using surplus_auctioneer_webdata;
using WebGrease.Css.Extensions;
using surplus_auctioneer_decision_engine;

namespace surplus_auctioneer_webapp.Controllers
{
    public class AuctionController : Controller
    {
        public ActionResult List()
        {
            ViewBag.Message = "Current Auctions";

            ListViewModel model = new ListViewModel();


            model.Auctions = (List<Auction>)HttpRuntime.Cache["auctionData"];

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

            model.AuctionItems = new List<AuctionItem>();

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
                auctions = (List<Auction>) HttpRuntime.Cache["auctionData"];
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
            List<Auction> auctions = (List<Auction>)HttpRuntime.Cache["auctionData"];

            if (auctions == null)
            {
                throw new ApplicationException("No auctions found");
            }

            model.RecommendedAuctionItems = AuctionSuggestions.GetSuggestions(auctions);

            if (!model.RecommendedAuctionItems.Any())
            {
                model.ErrorMessage = "No recommendations found";
            }

            return View(model);
        }
    }
}
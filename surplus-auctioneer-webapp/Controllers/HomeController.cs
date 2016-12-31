using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using surplus_auctioneer_models;
using surplus_auctioneer_webapp.Models;

namespace surplus_auctioneer_webapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Auctions()
        {
            ViewBag.Message = "Current Auctions";

            AuctionViewModel model = new AuctionViewModel();
            

            model.Auctions = (List<Auction>) HttpRuntime.Cache["auctionData"];

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
            ViewBag.Message = "Search Results";

            var auctions = (List<Auction>) HttpRuntime.Cache["auctionData"];

            model.AuctionItems = new List<AuctionItem>();

            foreach (Auction a in auctions)
            {
                model.AuctionItems =
                    model.AuctionItems.Concat(
                        a.AuctionItems.Where(x => (x.CurrentPrice >= model.MinPrice && x.CurrentPrice <= model.MaxPrice) || x.CurrentPrice == 0));
            }

            if (!string.IsNullOrEmpty(model.Keywords) && model.Keywords.Length > 0)
            {
                string[] items = model.Keywords.Split(',');
                model.AuctionItems = model.AuctionItems.Where(x => (x.ShortDescription != null && items.Any(x.ShortDescription.Contains)) || (x.FullDescription != null && items.Any(x.FullDescription.Contains)));
            }

            return View(model);
        }
    }
}
﻿using System;
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


            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
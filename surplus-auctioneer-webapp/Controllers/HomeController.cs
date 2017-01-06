using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using surplus_auctioneer_models;
using surplus_auctioneer_webapp.Models;
using surplus_auctioneer_webdata;
using WebGrease.Css.Extensions;

namespace surplus_auctioneer_webapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
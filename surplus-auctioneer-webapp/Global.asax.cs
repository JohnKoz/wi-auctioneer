using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;
using surplus_auctioneer_webapp.WebHelpers;

namespace surplus_auctioneer_webapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Tools.LoadAuctionCache("auctionData", null, CacheItemRemovedReason.Expired);

        }

        
    }
}

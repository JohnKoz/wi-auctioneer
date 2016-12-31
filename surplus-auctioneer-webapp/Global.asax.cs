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

            IEnumerable<Auction> allAuctions;

            ISurplusAuctionData wiData = new WisconsinAuctionData();

            allAuctions = wiData.GetAllAuctions(false, false, null);

            ISurplusAuctionData ilData = new IllinoisAuctionData();

            allAuctions = allAuctions.Concat(ilData.GetAllAuctions(false, false, null)).ToList<Auction>();

            HttpRuntime.Cache.Insert(
          /* key */                "auctionData",
          /* value */              allAuctions,
          /* dependencies */       null,
          /* absoluteExpiration */ Cache.NoAbsoluteExpiration,
          /* slidingExpiration */  new TimeSpan(0,4,0,0), //Expire cache after 4 hours
          /* priority */           CacheItemPriority.NotRemovable,
          /* onRemoveCallback */   null);

        }
    }
}

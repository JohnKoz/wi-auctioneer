using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using surplus_auctioneer_models;
using surplus_auctioneer_webapp.Helpers;
using surplus_auctioneer_webdata;

namespace surplus_auctioneer_webapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IEnumerable<Auction> allAuctions;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LoadCache("auctionData", null, CacheItemRemovedReason.Expired);

        }

        private void LoadCache(string key, object value, CacheItemRemovedReason reason)
        {
            allAuctions = Tools.GetAllAuctions();

            if (HttpRuntime.Cache[key] != null)
            {

            HttpRuntime.Cache.Remove(key);
            }

            HttpRuntime.Cache.Insert(
              /* key */                key,
              /* value */              allAuctions,
              /* dependencies */       null,
              /* absoluteExpiration */ Cache.NoAbsoluteExpiration,
              /* slidingExpiration */  new TimeSpan(0, 4, 0, 0), //Expire cache after 4 hours
                                                                 /* priority */           CacheItemPriority.NotRemovable,
              /* onRemoveCallback */   LoadCache);
        }
    }
}

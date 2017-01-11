using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;

namespace surplus_auctioneer_webapp.WebHelpers
{
    public static class Tools
    {
        public static void LoadAuctionCache(string key, object value, CacheItemRemovedReason reason)
        {
            IEnumerable<Auction> allAuctions = Helpers.GetAllAuctions();

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
              /* onRemoveCallback */   LoadAuctionCache);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;

namespace surplus_auctioneer_webapp.Helpers
{
    public static class Tools
    {
        public static List<Auction> GetAllAuctions() { 
            ISurplusAuctionData wiData = new WisconsinAuctionData();

            var allAuctions = wiData.GetAllAuctions(false, false, null);
        
            ISurplusAuctionData ilData = new IllinoisAuctionData();

            allAuctions = allAuctions.Concat(ilData.GetAllAuctions(false, false, null)).ToList<Auction>();

            return allAuctions.ToList<Auction>();
        }
    }
}
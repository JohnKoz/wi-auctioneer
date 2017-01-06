using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using surplus_auctioneer_models;

namespace surplus_auctioneer_webapp.Models
{
    public class RecommendationsViewModel
    {
        public Dictionary<string, List<AuctionItem>> RecommendedAuctionItems { get; set; }
    }
}
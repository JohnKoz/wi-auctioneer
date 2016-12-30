using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using surplus_auctioneer_models;

namespace surplus_auctioneer_webapp.Models
{
    public class SearchViewModel
    {
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }

        public string Keywords { get; set; }

        public IEnumerable<AuctionItem> AuctionItems { get; set; }
    }
}
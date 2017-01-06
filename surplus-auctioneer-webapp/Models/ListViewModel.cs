using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using surplus_auctioneer_models;

namespace surplus_auctioneer_webapp.Models
{
    public class ListViewModel
    {
        public List<Auction> Auctions { get; set; }
    }
}
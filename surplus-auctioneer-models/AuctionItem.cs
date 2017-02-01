using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surplus_auctioneer_models
{
    public class AuctionItem
    {
        public int ID { get; set; }

        public Image Picture { get; set; }

        public string AuctionName { get; set; }

        public string ShortDescription { get; set; }

        public Auction Auction { get; set; }

        public string FullDescription { get; set; }

        public string AuctionItemURL { get; set; }

        public int NumberOfBids { get; set; }

        public double CurrentPrice { get; set; }

        public double NextBidRequired { get; set; }

        public string ItemCondition { get; set; }

        public string AuctionCategory { get; set; }

        public DateTime EndDateTime { get; set; }

        public override string ToString()
        {
            return this.Auction.AuctionSource + " - <a href='" + this.AuctionItemURL + "'>" + ShortDescription +
                   "</a> Price: " +
                   this.CurrentPrice.ToString("C") + " " + this.Auction.AuctionEnd + "<br />" + Environment.NewLine;
        }
    }
}

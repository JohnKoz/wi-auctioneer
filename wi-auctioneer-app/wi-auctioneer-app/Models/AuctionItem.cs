using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wi_auctioneer_app.Models
{
    class AuctionItem
    {
        public int ID { get; set; }

        public Image Picture { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public int NumberOfBids { get; set; }

        public double CurrentPrice { get; set; }
    }
}

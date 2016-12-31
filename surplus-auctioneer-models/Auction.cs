using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surplus_auctioneer_models
{
    public class Auction : System.Object
    {
        public string AuctionSource { get; set; }

        public int AuctionID { get; set; }

        public string AuctionName { get; set; }

        public string AuctionEnd { get; set; }

        public DateTime AuctionEndDate { get; set; }

        public IEnumerable<AuctionItem> AuctionItems { get; set; }

        public override string ToString()
        {
            return AuctionName + Environment.NewLine + AuctionEnd;
        }
    }
}

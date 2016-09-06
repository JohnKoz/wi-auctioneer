using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wi_auctioneer_models
{
    public class Auction
    {
        public int AuctionID { get; set; }

        public string AuctionName { get; set; }

        public IEnumerable<AuctionItem> AuctionItems { get; set; }
    }
}

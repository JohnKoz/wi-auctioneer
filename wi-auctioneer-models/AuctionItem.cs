using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wi_auctioneer_models
{
    public class AuctionItem
    {
        private string _fulldescription;

        public int ID { get; set; }

        public Image Picture { get; set; }

        public string AuctionName { get; set; }

        public string ShortDescription { get; set; }

        public Auction Auction { get; set; }

        public string FullDescription
        {
            get { return _fulldescription; }
            set {
                _fulldescription = value;
                if (_fulldescription.Substring(0, _fulldescription.Length).Contains("+/-"))
                {
                    _fulldescription = _fulldescription.Replace("+/-", "");
                }
                    ShortDescription = _fulldescription.Substring(0, _fulldescription.IndexOf('-') == -1 ? _fulldescription.Length : _fulldescription.IndexOf('-'));
                
            }
        }


        public int NumberOfBids { get; set; }

        public double CurrentPrice { get; set; }

        public double NextBidRequired { get; set; }
    }
}

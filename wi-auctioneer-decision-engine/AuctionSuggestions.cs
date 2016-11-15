using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wi_auctioneer_models;

namespace wi_auctioneer_decision_engine
{
    public static class AuctionSuggestions
    {
        public static StringBuilder GetSuggestions(List<AuctionItem> autionItems)
        {
            StringBuilder suggestions = new StringBuilder();
            foreach (AuctionItem auctionItem in autionItems)
            {
                
                if (auctionItem.FullDescription.ToLower().Contains("tool") && auctionItem.CurrentPrice < 100)
                {
                    suggestions.Append(formatAuctionItem(auctionItem));
                }

                if (auctionItem.FullDescription.ToLower().Contains("acre") && auctionItem.CurrentPrice < 1000 && auctionItem.Auction.AuctionEndDate < DateTime.Now.AddHours(24))
                {
                    suggestions.Append(formatAuctionItem(auctionItem));
                }
            }

            return suggestions;
        }

        private static string formatAuctionItem(AuctionItem item)
        {
            return item.Auction.AuctionName + " - " + item.ShortDescription + " Price: " +
                   item.CurrentPrice.ToString("C") + " " + item.Auction.AuctionEnd +"<br />" + Environment.NewLine;
        }
    }
}

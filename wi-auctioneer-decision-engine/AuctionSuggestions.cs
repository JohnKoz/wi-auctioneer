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
                List<string> keywords = new List<string>();

                keywords.AddRange(new string[]{ "tool", "hammer", "drill", "saw"});

                if (keywords.Any(auctionItem.FullDescription.ToLower().Contains) 
                    && auctionItem.CurrentPrice < 100
                    && auctionItem.NextBidRequired < 100)
                {
                    suggestions.Append(formatAuctionItem(auctionItem));
                    continue;
                }

                keywords.Clear();
                keywords.AddRange(new string[] { "acre", "land", "property" });

                if (keywords.Any(auctionItem.FullDescription.ToLower().Contains) 
                    && auctionItem.CurrentPrice < 1000
                    && auctionItem.NextBidRequired < 1000
                    && auctionItem.Auction.AuctionEndDate < DateTime.Now.AddHours(24))
                {
                    suggestions.Append(formatAuctionItem(auctionItem));
                    continue;
                }

                keywords.Clear();
                keywords.AddRange(new string[] { "desktop", "laptop", "ipad" });

                if (keywords.Any(auctionItem.FullDescription.ToLower().Contains) 
                    && auctionItem.CurrentPrice < 200
                    && auctionItem.NextBidRequired < 200)
                {
                    suggestions.Append(formatAuctionItem(auctionItem));
                    continue;
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

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
            bool firstTool = true, firstLand = true, firstTech = true, firstCar = true;
            StringBuilder suggestions = new StringBuilder();
            DateTime central = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                    DateTime.UtcNow, "Central Standard Time");


            foreach (AuctionItem auctionItem in autionItems)
            {
                List<string> keywords = new List<string>();

                keywords.AddRange(new string[]{ "tool", "hammer", "drill", "saw"});

                if (keywords.Any(auctionItem.FullDescription.ToLower().Contains) 
                    && auctionItem.CurrentPrice < 100
                    && auctionItem.NextBidRequired < 100
                    && auctionItem.Auction.AuctionEndDate < central.AddHours(24))
                {
                    if (firstTool)
                    {
                        suggestions.Append("Tools:<br />" + Environment.NewLine);
                        firstTool = false;
                    }
                    suggestions.Append(formatAuctionItem(auctionItem));
                    continue;
                }

                
                keywords.Clear();
                keywords.AddRange(new string[] { "acre", "land", "property" });

                if (keywords.Any(auctionItem.FullDescription.ToLower().Contains) 
                    && auctionItem.CurrentPrice < 1000
                    && auctionItem.NextBidRequired < 1000
                    && auctionItem.Auction.AuctionEndDate < central.AddHours(24))
                {
                    if (firstLand)
                    {
                        suggestions.Append("Property:<br />" + Environment.NewLine);
                        firstLand = false;
                    }
                    suggestions.Append(formatAuctionItem(auctionItem));
                    continue;
                }

                
                keywords.Clear();
                keywords.AddRange(new string[] { "desktop", "laptop", "ipad", "server", "printer", "laserjet" });

                if (keywords.Any(auctionItem.FullDescription.ToLower().Contains) 
                    && auctionItem.CurrentPrice < 200
                    && auctionItem.NextBidRequired < 200
                    && auctionItem.Auction.AuctionEndDate < central.AddHours(24))
                {
                    if (firstTech)
                    {
                        suggestions.Append("Tech:<br />" + Environment.NewLine);
                        firstTech = false;
                    }
                    suggestions.Append(formatAuctionItem(auctionItem));
                    continue;
                }

                
                keywords.Clear();
                keywords.AddRange(new string[] { "truck", "car ", "vehicle", "boat" });

                if (keywords.Any(auctionItem.FullDescription.ToLower().Contains)
                    && auctionItem.CurrentPrice < 500
                    && auctionItem.NextBidRequired < 500
                    && auctionItem.Auction.AuctionEndDate < central.AddHours(24))
                {
                    if (firstCar)
                    {
                        suggestions.Append("Cars:<br />" + Environment.NewLine);
                        firstCar = false;
                    }
                    suggestions.Append(formatAuctionItem(auctionItem));
                    continue;
                }
            }

            return suggestions;
        }

        private static string formatAuctionItem(AuctionItem item)
        {
            return item.Auction.AuctionName + " - <a href='" + item.AuctionItemURL +"'>"+ item.ShortDescription + "</a> Price: " +
                   item.CurrentPrice.ToString("C") + " " + item.Auction.AuctionEnd +"<br />" + Environment.NewLine;
        }
    }
}

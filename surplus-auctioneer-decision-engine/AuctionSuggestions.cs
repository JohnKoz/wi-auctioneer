using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using surplus_auctioneer_models;

namespace surplus_auctioneer_decision_engine
{
    public static class AuctionSuggestions
    {
        public static Dictionary<string, List<AuctionItem>> GetSuggestions(List<Auction> auctions)
        {
            bool firstTool = true, firstLand = true, firstTech = true, firstCar = true;
            StringBuilder suggestions = new StringBuilder();
            DateTime central = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                    DateTime.UtcNow, "Central Standard Time");

            Dictionary<string, List<AuctionItem>> results = new Dictionary<string, List<AuctionItem>>();

            foreach (Auction auction in auctions)
            {
                if (!auction.AuctionName.Contains("AUCTION SUSPENDED"))
                {
                    foreach (AuctionItem auctionItem in auction.AuctionItems)
                    {
                        List<string> keywords = new List<string>();

                        keywords.AddRange(new string[] {"tool", "hammer", "drill", "saw"});

                        if (keywords.Any(auctionItem.FullDescription.ToLower().Contains)
                            && auctionItem.CurrentPrice < 100
                            && auctionItem.NextBidRequired < 100
                            &&
                            (auctionItem.EndDateTime == DateTime.MinValue
                                ? auctionItem.Auction.AuctionEndDate
                                : auctionItem.EndDateTime) < central.AddHours(24))
                        {
                            string category = "Tools";
                            if (!results.ContainsKey(category))
                            {
                                results.Add(category, new List<AuctionItem>());
                            }
                            results[category].Add(auctionItem);
                            continue;
                        }


                        keywords.Clear();
                        keywords.AddRange(new string[] {"acre", "land", "property", "acreage", "vacant lot"});

                        if (keywords.Select(x => (" " + x)).Any(auctionItem.FullDescription.ToLower().Contains)
                            && auctionItem.CurrentPrice < 1000
                            && auctionItem.NextBidRequired < 1000
                            &&
                            (auctionItem.EndDateTime == DateTime.MinValue
                                ? auctionItem.Auction.AuctionEndDate
                                : auctionItem.EndDateTime) < central.AddHours(48))
                        {
                            string category = "Property";
                            if (!results.ContainsKey(category))
                            {
                                results.Add(category, new List<AuctionItem>());
                            }
                            results[category].Add(auctionItem);
                            continue;
                        }


                        keywords.Clear();
                        keywords.AddRange(new string[] {"desktop", "laptop", "ipad", "server", "printer", "laserjet"});

                        if (keywords.Any(auctionItem.FullDescription.ToLower().Contains)
                            && auctionItem.CurrentPrice < 200
                            && auctionItem.NextBidRequired < 200
                            &&
                            (auctionItem.EndDateTime == DateTime.MinValue
                                ? auctionItem.Auction.AuctionEndDate
                                : auctionItem.EndDateTime) < central.AddHours(24))
                        {
                            string category = "Technology";
                            if (!results.ContainsKey(category))
                            {
                                results.Add(category, new List<AuctionItem>());
                            }
                            results[category].Add(auctionItem);
                            continue;
                        }


                        keywords.Clear();
                        keywords.AddRange(new string[] {"truck", "car ", "vehicle", "boat"});

                        if (keywords.Any(auctionItem.FullDescription.ToLower().Contains)
                            && auctionItem.CurrentPrice < 500
                            && auctionItem.NextBidRequired < 500
                            &&
                            (auctionItem.EndDateTime == DateTime.MinValue
                                ? auctionItem.Auction.AuctionEndDate
                                : auctionItem.EndDateTime) < central.AddHours(24))
                        {
                            string category = "Cars";
                            if (!results.ContainsKey(category))
                            {
                                results.Add(category, new List<AuctionItem>());
                            }
                            results[category].Add(auctionItem);
                            continue;
                        }
                    }
                }
            }
            return results;
        }
    }
}

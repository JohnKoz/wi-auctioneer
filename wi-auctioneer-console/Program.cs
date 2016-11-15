using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wi_auctioneer_models;
using wi_auctioneer_webdata;

namespace wi_auctioneer_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var auctions = SurplusAuctionData.GetAllAuctions(false, false, null);
            StringBuilder emailBody = new StringBuilder();
            string password = "";

            if (args.Count() > 0)
            {
                password = args[0]?.ToString();
            }
            

            foreach (Auction auction in auctions)
            {
                Console.WriteLine(auction.AuctionName + " Ending at: "+ auction.AuctionEndDate);
                if (!auction.AuctionName.Contains("AUCTION SUSPENDED"))
                {
                    foreach (AuctionItem auctionItem in auction.AuctionItems)
                    {
                        if (auctionItem.FullDescription.ToLower().Contains("tool") && auctionItem.CurrentPrice < 100)
                        {
                            emailBody.Append("Potential auction find:<br />");
                            emailBody.Append(auctionItem.Auction.AuctionName + " - " + auctionItem.ShortDescription + " Price: " + auctionItem.CurrentPrice.ToString("C") + "<br />");
                        }
                    }
                }

            }

            if (!String.IsNullOrEmpty(password) && emailBody.Length > 0)
            {
                Console.Write("Sending Email");
                EmailService.SendEmail("Potential Auction Finds", emailBody.ToString(), password);
            }

            Console.ReadLine();


        }
    }
}

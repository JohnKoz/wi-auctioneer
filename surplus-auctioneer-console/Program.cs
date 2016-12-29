using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using surplus_auctioneer_decision_engine;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;

namespace surplus_auctioneer_console
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
                if (!auction.AuctionName.Contains("AUCTION SUSPENDED"))
                {
                    emailBody.Append(AuctionSuggestions.GetSuggestions(auction.AuctionItems.ToList()));
                }
            }

#if DEBUG
            Console.WriteLine(emailBody.ToString().Replace("<br />",""));
#endif


            if (!String.IsNullOrEmpty(password) && emailBody.Length > 0)
            {
#if !DEBUG
                DateTime central = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                     DateTime.UtcNow, "Central Standard Time");
                EmailService.SendEmail("Potential Auction Finds for " + central.ToString("d"), "Potential auction finds:<br />" + emailBody.ToString(), password);
#endif
            }

#if DEBUG
            Console.ReadLine();
#endif


        }
    }
}

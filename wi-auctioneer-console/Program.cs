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
            

            foreach (

            Auction auction in auctions)
                {
                    Console.WriteLine(auction.AuctionName + " Ending at: "+ auction.AuctionEndDate);



                    emailBody.Append(auction.AuctionName + "<br />");


                }

                if (!String.IsNullOrEmpty(password))
                {
                    EmailService.SendEmail("Auction Testing", emailBody.ToString(), password);
                }

                Console.ReadLine();


        }
    }
}

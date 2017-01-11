using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;
using HAP = HtmlAgilityPack;

namespace surplus_auctioneer_webdata
{
    public class MinnesotaAuctionData : ISurplusAuctionData
    {
        public IEnumerable<Auction> GetAllAuctions(bool includeImages, bool includeEnded, BackgroundWorker bw)
        {

            List<Auction> auctions = new List<Auction>();
            var doc = new HAP.HtmlDocument();

            var auctionData = Helpers.GetDataFromUrl("https://www.minnbid.org/Mobile/GetLotsDataJs", "POST");

            auctionData = WebUtility.HtmlDecode(auctionData);

            //Clean up the JSON
            auctionData = auctionData.Replace(@"\r\n", "");
            auctionData = auctionData.Replace(@"\""", @"""");
            auctionData = auctionData.Replace(@"\\""", @"\""");
            auctionData = auctionData.Substring(1, auctionData.Length - 2);

            dynamic auctionItemJSON = JObject.Parse(auctionData);

            if (!String.IsNullOrEmpty(auctionData))
            {
                Auction mainAuction = new Auction();

                List<AuctionItem> items = new List<AuctionItem>();

                foreach (var item in auctionItemJSON.Table)
                {
                    AuctionItem itemToAdd = new AuctionItem();

                    itemToAdd.ID = item.LotID;
                    itemToAdd.CurrentPrice = item.CurrentPrice;
                    itemToAdd.EndDateTime = item.ClosingDateTime;
                    itemToAdd.FullDescription = Helpers.StripHTMLTags(item.LotDescription.ToString());
                    itemToAdd.ShortDescription = item.ItemName;
                    itemToAdd.Auction = mainAuction;

                    items.Add(itemToAdd);
                }

                mainAuction.AuctionItems = items;
                mainAuction.AuctionName = "Minnesota Online Auction";
                mainAuction.AuctionSource = "Minnesota";

                auctions.Add(mainAuction);
            }

            return auctions;
        }
    }
}

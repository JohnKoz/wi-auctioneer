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
                    itemToAdd.AuctionItemURL = "https://www.minnbid.org/Mobile/AuctionLot/" + item.LotID;
                    itemToAdd.ShortDescription = item.ItemName;
                    itemToAdd.Auction = mainAuction;

                    //The bidding increment is only stored on the item's page, so load the data from that page then parse out the increment
                    var itemWebData  = Helpers.GetDataFromUrl(itemToAdd.AuctionItemURL);
                    var doc = new HAP.HtmlDocument();
                    doc.LoadHtml(itemWebData);
                    var root = doc.DocumentNode;
                    var increment = root.SelectNodes("//span").Where(x => x.GetAttributeValue("id", "") == "spnIncrement").FirstOrDefault().InnerText;
                    //add the increment to the current price to determine the next bid required
                    itemToAdd.NextBidRequired = itemToAdd.CurrentPrice + double.Parse(increment.Replace("$",""));

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

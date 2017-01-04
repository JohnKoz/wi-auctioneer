using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using surplus_auctioneer_models;
using wi_auctioneer_webdata;
using HAP = HtmlAgilityPack;

namespace surplus_auctioneer_webdata
{
    public class IllinoisAuctionData : ISurplusAuctionData
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");

        public IEnumerable<Auction> GetAllAuctions(bool includeImages, bool includeEnded, BackgroundWorker bw)
        {
            List<Auction> auctions = new List<Auction>();
            var doc = new HAP.HtmlDocument();
            int counter = 0;

            Dictionary<int, String> categories = getCategories();

            bw?.ReportProgress(0, "Retrieving category list");


            foreach (KeyValuePair<int, String> item in categories)
            {
                Auction auction = new Auction();
                List<AuctionItem> auctionItems = new List<AuctionItem>();
                auction.AuctionName = item.Value;
                auction.AuctionSource = "Illinois";

                //Calculate and report back percentage
                int percentage =
                           int.Parse(Math.Round(((counter + 1) / (double)(categories.Count() - 10) * 100)).ToString());

                percentage += 10;

                if (percentage > 100)
                {
                    percentage = 100;
                }

                bw?.ReportProgress(percentage, "Loading " + item.Value);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ibid.illinois.gov/browse.php?id=" + item.Key);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();

                    doc.LoadHtml(data);
                }

                var root = doc.DocumentNode;

                var auctionItemNodes = root.SelectNodes("/html[1]/body[1]/div[2]/div[1]/div[2]/table[2]/tr");

                if (auctionItemNodes != null && auctionItemNodes.Any())
                {
                    int nodeCounter = 0;
                    foreach (HAP.HtmlNode node in auctionItemNodes)
                    {
                        if (nodeCounter == 0)
                        {
                            nodeCounter++;
                            continue;
                        }
                        AuctionItem auctionItem = new AuctionItem();

                        int elemCount = 0;
                        foreach (HAP.HtmlNode auctionItemElems in node.ChildNodes)
                        {
                            switch (elemCount)
                            {
                                case 0:
                                case 1:
                                case 2:
                                    elemCount++;
                                    continue;
                                case 3:
                                    auctionItem.ShortDescription = WebUtility.HtmlDecode(auctionItemElems.InnerText.Trim());
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    auctionItem.CurrentPrice = double.Parse(auctionItemElems.InnerText.Trim().Replace("$ ",""));
                                    if (auctionItem.CurrentPrice == 0)
                                    {
                                        auctionItem.NextBidRequired = auctionItem.CurrentPrice;
                                    }
                                    else
                                    {
                                        auctionItem.NextBidRequired = auctionItem.CurrentPrice + 0.01;
                                    }
                                    break;
                                case 6:
                                    break;
                                case 7:
                                    auctionItem.NumberOfBids = int.Parse(auctionItemElems.InnerText.Trim());
                                    break;
                            }

                            elemCount++;
                        }

                        if (auctionItem.CurrentPrice != 0 &&
                            auctionItem.ShortDescription != null)
                        {
                            auctionItems.Add(auctionItem);
                        }

                        nodeCounter++;
                    }

                    auction.AuctionItems = auctionItems;

                    counter++;
                    auctions.Add(auction);
                }
            }
            
            return auctions;
        }

        private Dictionary<int, string> getCategories()
        {
            //TODO: Change this to scrape categories from iBid homepage
            Dictionary<int, String> categories = new Dictionary<int, String>();

            categories.Add(441, "Agricultural Equipment and Supplies");
            categories.Add(471, "Communication Equipment");
            categories.Add(501, "Electrical and Electronic Equipment and Components");
            categories.Add(531, "Hand Tools & Shop Equipment");
            categories.Add(561, "Jewelry & Exotic Collectibles");
            categories.Add(591, "Miscellaneous");
            categories.Add(691, "Paper money and coins");
            categories.Add(641, "Vehicles");
            categories.Add(451, "Aircraft and Aircraft Parts");
            categories.Add(481, "Computer Equipment and Accessories");
            categories.Add(511, "Fire Trucks and Fire Fighting Equipment");
            categories.Add(541, "Household/Personal");
            categories.Add(571, "Lab Equipment");
            categories.Add(601, "Motorcycles & Bicycles");
            categories.Add(621, "Photographic Equipment");
            categories.Add(461, "Boats and Marine Equipment");
            categories.Add(491, "Construction Equipment");
            categories.Add(521, "Furniture");
            categories.Add(551, "Industrial Machinery");
            categories.Add(581, "Medical, Dental, and Veterinary Equipment and Supplies");
            categories.Add(611, "Office Equipment and Supplies");
            categories.Add(631, "Tractor Trailers and Manufactured Housing");

            return categories;
        }

       }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using surplus_auctioneer_models;
using HAP = HtmlAgilityPack;

namespace surplus_auctioneer_webdata
{
    public class WisconsinAuctionData : ISurplusAuctionData
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");

        public IEnumerable<Auction> GetAllAuctions(bool includeImages, bool includeEnded, BackgroundWorker bw)
        {
            List<Auction> auctions = new List<Auction>();
            var doc = new HAP.HtmlDocument();
            int counter = 0;
            //updateText("Retrieving auction list");

            bw?.ReportProgress(0, "Retrieving auction list");

            //System.Net.ServicePointManager.Expect100Continue = false

            doc.LoadHtml(Helpers.GetDataFromUrl("http://www.maxanet.com/cgi-bin/mncal.cgi?rlust"));

            bw?.ReportProgress(10, "Auction list retrieved, starting auction loads");

            var root = doc.DocumentNode;

            var auctionNodes = root.SelectNodes("//table");

            //var auctionTitles = root.Descendants().Where(n => n.GetAttributeValue("id", "").Equals("auction_title"));

            foreach (HAP.HtmlNode auctionNode in auctionNodes)
            {
                if (auctionNode.InnerText.Contains("Any of the words") ||
                    auctionNode.InnerHtml.Contains("www.auctioneers.org"))
                {
                    continue;
                }

                string auctionTitle =
                    auctionNode.Descendants()
                        .Where(n => n.GetAttributeValue("id", "").Equals("auction_title"))
                        .First()
                        .InnerText;


                 string auctionEnd = auctionNode.InnerText.Replace(auctionTitle, "");

                if (auctionEnd.Contains(')'))
                {
                    auctionEnd = auctionEnd.Remove(auctionEnd.IndexOf(')') + 1);
                }
                else
                {
                    auctionEnd = auctionEnd.Remove(auctionEnd.IndexOf("Central") + 7);
                }

                auctionEnd = auctionEnd.Replace("\n ", "");

                string auctionEndDate = auctionEnd.ToLower().Replace("ends: ", "").Replace(" starting at","");

                if (auctionEndDate.Contains("am"))
                {
                    auctionEndDate = auctionEndDate.Remove(auctionEndDate.IndexOf("am") + 2);
                }
                else
                {
                    auctionEndDate = auctionEndDate.Remove(auctionEndDate.IndexOf("pm") + 2);
                }

                auctionEndDate = auctionEndDate.Replace("-", "");

                if (includeEnded || !auctionTitle.Contains("CLOSED"))
                    {
                        Auction auctionToAdd;

                        auctionToAdd = new Auction();

                        auctionToAdd.AuctionSource = "Wisconsin";

                        auctionToAdd.AuctionEnd = auctionEnd;

                        auctionToAdd.AuctionEndDate = DateTime.Parse(auctionEndDate);

                        auctionToAdd.AuctionID = int.Parse(auctionTitle.Substring(7, 2));
                        
                        auctionToAdd.AuctionName = auctionTitle;

                        int percentage =
                            int.Parse(Math.Round(((counter + 1)/(double) (auctionNodes.Count() - 10)*100)).ToString());

                        percentage += 10;

                        if (percentage > 100)
                        {
                            percentage = 100;
                        }

                        bw?.ReportProgress(percentage, "Loading " + auctionToAdd.AuctionName);

                        auctionToAdd.AuctionItems = GetAuctionItemsByName(auctionToAdd, includeImages);

                        auctions.Add(auctionToAdd);
                    }
                    counter++;
                //}
            }

            return auctions;
        }

        private IEnumerable<AuctionItem> GetAuctionItemsByName(Auction auction, bool includeImages)
        {
            string auctionURL;
            string auctionNumber;
            List<AuctionItem> auctionItems = new List<AuctionItem>();

            //auctionNumber = int.Parse(auction.AuctionName.Substring(7, 2));
            auctionNumber = (System.Convert.ToString(auction.AuctionName.Substring(7, 3))).Trim();
            auctionNumber.Replace(".", "");
            if (System.Convert.ToString(auctionNumber).Contains("-"))
            {
                auctionNumber = auction.AuctionName.Substring(8, 2);
            }
            //Added below foreach loop because we get an error when a single digit auction number is used in the url. This is prefaced with a Zero (ex:03)
            foreach (char auctionnumberCount in auctionNumber)
            {
                if (System.Convert.ToString(auctionNumber).StartsWith("0"))
                {
                    auctionNumber = auctionNumber.Remove(0, 1);
                }
            }

            auctionNumber = auctionNumber.Replace(".", "");
            auctionURL = String.Format("http://www.maxanet.com/cgi-bin/mnlist.cgi?rlust{0}/category/ALL", auctionNumber);

            var doc = new HAP.HtmlDocument();

            string webdata = Helpers.GetDataFromUrl(auctionURL);

            doc.LoadHtml(webdata);

            var root = doc.DocumentNode;

            var auctionRows = root.SelectNodes("//tr").Where(n => n.GetAttributeValue("class", "").Equals("DataRow") && n.GetAttributeValue("id", "") != "PRACTICE");

            foreach (HAP.HtmlNode auctionRow in auctionRows)
            {
                var auctionCells = auctionRow.SelectNodes("td");
                AuctionItem itemToAdd = new AuctionItem();
                int i = 0;
                foreach (HAP.HtmlNode auctionCell in auctionCells)
                {
                    switch (i)
                    {
                        case 0:
                            itemToAdd.ID = int.Parse(digitsOnly.Replace(auctionCell.InnerText, "") == "" ? "0" : digitsOnly.Replace(auctionCell.InnerText, ""));
                            itemToAdd.AuctionItemURL = "http://www.maxanet.com/cgi-bin/mnlist.cgi?rlust" + auctionCell.InnerHtml.Substring((auctionCell.InnerHtml.IndexOf("rlust") + 5), ((auctionCell.InnerHtml.IndexOf("\">")) - ((auctionCell.InnerHtml.IndexOf("rlust") + 5))));
                            break;
                        case 1:

                            if (includeImages)
                                itemToAdd.Picture = Helpers.GetImageFromURL(auctionCell.LastChild.LastChild.Attributes[1].Value);
                            break;
                        case 2:
                            itemToAdd.FullDescription = auctionCell.InnerText;
                            if (itemToAdd.FullDescription.Contains("CONDITION:"))
                            {
                                int ConditionStart = auctionCell.InnerHtml.IndexOf("CONDITION:");

                                int ConditionEnd = auctionCell.InnerHtml.IndexOf("LOCATION:");

                                if (ConditionEnd < 0)
                                {
                                    ConditionEnd = auctionCell.InnerHtml.IndexOf("REMOVAL DEADLINE:");
                                }


                                itemToAdd.ItemCondition = auctionCell.InnerHtml.Substring(ConditionStart + 10, ConditionEnd - (ConditionStart + 10)); 
                                itemToAdd.ItemCondition = itemToAdd.ItemCondition.Replace("<br>  -", "");
                                itemToAdd.ItemCondition = itemToAdd.ItemCondition.Replace("<br> -", "");
                                itemToAdd.ItemCondition = itemToAdd.ItemCondition.Replace("<br>-", "");
                                itemToAdd.ItemCondition = itemToAdd.ItemCondition.Replace("<br>", "");
                                itemToAdd.ItemCondition = itemToAdd.ItemCondition.Replace("</b>", "");
                                itemToAdd.ItemCondition = itemToAdd.ItemCondition.Replace("<b> -", "");
                                
                            }

                            if (itemToAdd.FullDescription.Substring(0, itemToAdd.FullDescription.Length).Contains("+/-"))
                            {
                                itemToAdd.FullDescription = itemToAdd.FullDescription.Replace("+/-", "").Trim();
                            }

                            itemToAdd.ShortDescription = itemToAdd.FullDescription.Substring(0, itemToAdd.FullDescription.IndexOf('-') == -1 ? itemToAdd.FullDescription.Length : itemToAdd.FullDescription.IndexOf('-')).Trim();
                            break;
                        case 3:
                            itemToAdd.NumberOfBids = int.Parse(auctionCell.InnerText.Replace("&nbsp;", "0"));
                            break;
                        case 5:
                            itemToAdd.CurrentPrice = double.Parse(auctionCell.InnerText.Replace("&nbsp;", "0"));
                            break;
                        case 6:
                            itemToAdd.NextBidRequired = double.Parse(auctionCell.InnerText.Replace("&nbsp;", "0"));
                            break;
                    }
                    i++;
                }

                itemToAdd.AuctionName = auction.AuctionName;
                itemToAdd.Auction = auction;

                //Try to prevent practice items from being added
                if (!itemToAdd.FullDescription.Contains("Practice your bidding on this item"))
                {
                    //NextBidRequired == 0 generally means 'WITHDRAWN' so we don't include it
                    if (itemToAdd.NextBidRequired != 0)
                    {
                        auctionItems.Add(itemToAdd);
                    }
                }
            }

            return auctionItems;
        }

       
    }
}

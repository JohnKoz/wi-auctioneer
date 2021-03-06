﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using surplus_auctioneer_models;
using HAP = HtmlAgilityPack;

namespace surplus_auctioneer_webdata
{
    public static class SurplusAuctionData_Test
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");
        public static IEnumerable<Auction> GetAllAuctions(bool includeImages, bool includeEnded, BackgroundWorker bw, string txtTestURL)
        {
            List<Auction> auctions = new List<Auction>();
            var doc = new HAP.HtmlDocument();
            int counter = 0;
            //updateText("Retrieving auction list");

            bw.ReportProgress(0, "Retrieving auction list");

            doc.LoadHtml(new WebClient().DownloadString("http://www.maxanet.com/cgi-bin/mncal.cgi?rlust"));

            bw.ReportProgress(10, "Auction list retrieved, starting auction loads");

            var root = doc.DocumentNode;

            var auctionNodes = root.SelectNodes("//table");

            foreach (HAP.HtmlNode auctionNode in auctionNodes)
            {
                if (auctionNode.InnerHtml.Contains(txtTestURL.Substring(txtTestURL.IndexOf("rlust"),7)))
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

                auctionEnd = auctionEnd.Remove(auctionEnd.IndexOf(')') + 1);

                auctionEnd = auctionEnd.Replace("\n ", "");

                //foreach (HAP.HtmlNode auctionTitle in auctionTitles)
                //{
                if (includeEnded || !auctionTitle.Contains("CLOSED"))
                {
                    Auction auctionToAdd;

                    auctionToAdd = new Auction();

                    auctionToAdd.AuctionEnd = auctionEnd;

                    auctionToAdd.AuctionID = int.Parse(auctionTitle.Substring(7, 2));

                    auctionToAdd.AuctionName = auctionTitle;

                    int percentage =
                        int.Parse(Math.Round(((counter + 1) / (double)(auctionNodes.Count() - 10) * 100)).ToString());

                    percentage += 10;

                    if (percentage > 100)
                    {
                        percentage = 100;
                    }

                    bw.ReportProgress(percentage, "Loading " + auctionToAdd.AuctionName);

                    auctionToAdd.AuctionItems = GetAuctionItemsByName(auctionToAdd, includeImages);

                    auctions.Add(auctionToAdd);
                }
                counter++;
            }
            }

            return auctions;
        }

        public static IEnumerable<AuctionItem> GetAuctionItemsByName(Auction auction, bool includeImages)
        {
            string auctionURL;
            int auctionNumber;
            List<AuctionItem> auctionItems = new List<AuctionItem>();

            auctionNumber = int.Parse(auction.AuctionName.Substring(7, 2));

            auctionURL = String.Format("http://www.maxanet.com/cgi-bin/mnlist.cgi?rlust{0}/category/ALL", auctionNumber);

            var doc = new HAP.HtmlDocument();

            doc.LoadHtml(new WebClient().DownloadString(auctionURL));

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
                                itemToAdd.Picture = GetImageFromURL(auctionCell.LastChild.LastChild.Attributes[1].Value);
                            break;
                        case 2:
                            itemToAdd.FullDescription = auctionCell.InnerText;
                            itemToAdd.ItemCondition = auctionCell.InnerHtml.Substring((auctionCell.InnerHtml.IndexOf("CONDITION:") + 10), ((auctionCell.InnerHtml.IndexOf("LOCATION:")) - (auctionCell.InnerHtml.IndexOf("CONDITION"))));
                            break;
                        case 3:
                            itemToAdd.NumberOfBids = int.Parse(auctionCell.InnerText.Replace("&nbsp;", "0"));
                            break;
                        case 5:
                            itemToAdd.CurrentPrice = double.Parse(auctionCell.InnerText.Replace("&nbsp;", "0"));
                            break;
                    }
                    i++;
                }

                itemToAdd.AuctionName = auction.AuctionName;
                itemToAdd.Auction = auction;

                auctionItems.Add(itemToAdd);
            }

            return auctionItems;
        }

        private static Image GetImageFromURL(string url)
        {
            if (url.ToLower().Contains("none"))
                return null;

            Image img;
            try
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(url);
                MemoryStream ms = new MemoryStream(bytes);
                img = System.Drawing.Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
            return img;
        }    
    }
}




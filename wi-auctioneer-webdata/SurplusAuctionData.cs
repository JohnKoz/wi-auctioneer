using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using wi_auctioneer_models;
using HAP = HtmlAgilityPack;

namespace wi_auctioneer_webdata
{
    public static class SurplusAuctionData
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");

        public static IEnumerable<Auction> GetAllAuctions(bool includeImages)
        {
            List<Auction> auctions = new List<Auction>();
            var doc = new HAP.HtmlDocument();

            doc.LoadHtml(new WebClient().DownloadString("http://www.maxanet.com/cgi-bin/mncal.cgi?rlust"));

            var root = doc.DocumentNode;

            var auctionTitles = root.Descendants().Where(n => n.GetAttributeValue("id", "").Equals("auction_title"));

            foreach (HAP.HtmlNode auctionTitle in auctionTitles)
            {
                Auction auctionToAdd;

                auctionToAdd = new Auction();

                auctionToAdd.AuctionID = int.Parse(auctionTitle.InnerText.Substring(7, 2)); ;
                auctionToAdd.AuctionName = auctionTitle.InnerText;

                auctionToAdd.AuctionItems = GetAuctionItemsByName(auctionToAdd.AuctionName, includeImages);

                auctions.Add(auctionToAdd);
            }

            return auctions;
        }

        public static IEnumerable<AuctionItem> GetAuctionItemsByName(string auctionName, bool includeImages)
        {
            string auctionURL;
            int auctionNumber;
            List<AuctionItem> auctionItems = new List<AuctionItem>();

            auctionNumber = int.Parse(auctionName.Substring(7, 2));

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
                            break;
                        case 1:
                            if(includeImages)
                                itemToAdd.Picture = GetImageFromURL(auctionCell.LastChild.LastChild.Attributes[1].Value);
                            break;
                        case 2:
                            itemToAdd.FullDescription = auctionCell.InnerText;
                            break;
                        case 3:
                            itemToAdd.NumberOfBids = int.Parse(auctionCell.InnerText.Replace("&nbsp;", "0"));
                            break;
                        case 5:
                            itemToAdd.CurrentPrice = double.Parse(auctionCell.InnerText.Replace("&nbsp;", "0"));
                            break;
                    }
                    //MessageBox.Show(auctionCell.InnerText);

                    i++;
                }
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

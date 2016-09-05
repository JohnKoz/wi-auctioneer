using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wi_auctioneer_app.Models;
using HAP = HtmlAgilityPack;


namespace wi_auctioneer_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetAuctions_Click(object sender, EventArgs e)
        {
            var doc = new HAP.HtmlDocument();

            doc.LoadHtml(new WebClient().DownloadString("http://www.maxanet.com/cgi-bin/mncal.cgi?rlust"));

            var root = doc.DocumentNode;

            var auctionTitles = root.Descendants().Where(n => n.GetAttributeValue("id", "").Equals("auction_title"));

            foreach(HAP.HtmlNode auctionTitle in auctionTitles)
            {
                //MessageBox.Show(auctionTitle.InnerText);
                lstAuctionTitles.Items.Add(auctionTitle.InnerText);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGetItems_Click(object sender, EventArgs e)
        {
            var selectedAuction = (string)lstAuctionTitles.SelectedItem;
            string auctionURL;
            int auctionNumber;
            List<AuctionItem> auctionItems = new List<AuctionItem>();

            auctionNumber = int.Parse(selectedAuction.Substring(7, 2));

            auctionURL = String.Format("http://www.maxanet.com/cgi-bin/mnlist.cgi?rlust{0}/category/ALL", auctionNumber);

            var doc = new HAP.HtmlDocument();

            doc.LoadHtml(new WebClient().DownloadString(auctionURL));

            var root = doc.DocumentNode;

            var auctionRows = root.SelectNodes("//tr").Where(n => n.GetAttributeValue("class","").Equals("DataRow") && n.GetAttributeValue("id","") != "PRACTICE");

            foreach (HAP.HtmlNode auctionRow in auctionRows)
            {
                var auctionCells = auctionRow.SelectNodes("td");
                AuctionItem itemToAdd = new AuctionItem();
                int i = 0;
                foreach(HAP.HtmlNode auctionCell in auctionCells)
                {
                    switch (i)
                    {
                        case 0:
                            itemToAdd.ID = int.Parse(auctionCell.InnerText.Replace("morepics",""));
                            break;
                        case 1:
                            itemToAdd.Picture = GetImageFromURL(auctionCell.LastChild.LastChild.Attributes[1].Value);
                            break;
                        case 2:
                            itemToAdd.FullDescription = auctionCell.InnerText;
                            break;
                        case 3:
                            itemToAdd.NumberOfBids = int.Parse(auctionCell.InnerText);
                            break;
                        case 5:
                            itemToAdd.CurrentPrice = double.Parse(auctionCell.InnerText);
                            break;
                    }
                    //MessageBox.Show(auctionCell.InnerText);

                    i++;
                }
                auctionItems.Add(itemToAdd);
                
                //MessageBox.Show(auctionTitle.InnerText);
                //lstAuctionTitles.Items.Add(auctionTitle.InnerText);
            }
            dataGridView1.DataSource = auctionItems;
        }

       public Image GetImageFromURL(string url)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(url);
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }
    }
}

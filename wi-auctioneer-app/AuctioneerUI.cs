using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HAP = HtmlAgilityPack;
using wi_auctioneer_models;
using wi_auctioneer_webdata;


namespace wi_auctioneer_app
{
    public partial class AuctioneerUI : Form
    {
        public AuctioneerUI()
        {
            InitializeComponent();
        }

        private void btnGetItems_Click(object sender, EventArgs e)
        {
            try {
                List<Auction> auctions = SurplusAuctionData.GetAllAuctions(false).ToList();

                BindingSource bs = new BindingSource();

                bs.DataSource = typeof(AuctionItem);

                foreach (Auction auction in auctions)
                {
                    foreach (AuctionItem item in auction.AuctionItems)
                    {
                        bs.Add(item);
                    }
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = bs;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

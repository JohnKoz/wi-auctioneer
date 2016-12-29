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
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;


namespace surplus_auctioneer_app
{
    public partial class AuctioneerUI : Form
    {
        private List<AuctionItem> auctionItems;
        public AuctioneerUI()
        {
            InitializeComponent();
            filterCriteria.Enabled = false;
            auctionItems = new List<AuctionItem>();
        }

        private void btnGetItems_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!chkGetFirstRow.Checked)
                    {
                    List<Auction> auctions = SurplusAuctionData.GetAllAuctions(chkIncludeImages.Checked, chkIncludeEnded.Checked, backgroundWorker1).ToList();
                    foreach (Auction auction in auctions)
                    {
                        foreach (AuctionItem item in auction.AuctionItems)
                        {
                            auctionItems.Add(item);
                        }
                    }
                }
                else
                {
                    List<Auction> auctions = SurplusAuctionData_Test.GetAllAuctions(chkIncludeImages.Checked, chkIncludeEnded.Checked, backgroundWorker1, txtTestURL.Text).ToList();
                    foreach (Auction auction in auctions)
                    {
                        foreach (AuctionItem item in auction.AuctionItems)
                        {
                            auctionItems.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace, "Exception Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;

            txtLoadingText.Text = e.UserState.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void bindData(List<AuctionItem> auctionItems)
        {
            BindingSource bs = new BindingSource();

            bs.DataSource = typeof(AuctionItem);

            foreach (AuctionItem item in auctionItems)
            {
                bs.Add(item);
            }

            if (!chkIncludeImages.Checked)
            {
                dataGridView1.Columns["Picture"].Visible = false;
            }
            else
            {
                dataGridView1.Columns["Picture"].Visible = true;
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bs;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bindData(auctionItems);

            txtLoadingText.Text = "Auctions loaded";

            filterCriteria.Enabled = true;

            this.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            List<AuctionItem> filteredItems = auctionItems;
            if (txtKeywords.Text.Length > 0)
            {
                string[] items = txtKeywords.Text.Split(',');

                if (chkMustContainAll.Checked)
                {

                    filteredItems = filteredItems.Where(x => items.All(x.FullDescription.Contains)).ToList();

                }
                else
                {
                    filteredItems = filteredItems.Where(x => items.Any(x.FullDescription.Contains)).ToList();
                }

            }

            if (txtMinPrice.Text.Length > 0)
            {
                filteredItems = filteredItems.Where(x => x.CurrentPrice >= Double.Parse(txtMinPrice.Text)).ToList();
            }

            if (txtMaxPrice.Text.Length > 0)
            {
                filteredItems = filteredItems.Where(x => x.CurrentPrice <= Double.Parse(txtMaxPrice.Text)).ToList();
            }

            if (txtMinBids.Text.Length > 0)
            {
                filteredItems = filteredItems.Where(x => x.NumberOfBids >= int.Parse(txtMinBids.Text)).ToList();
            }

            if (txtMaxBids.Text.Length > 0)
            {
                filteredItems = filteredItems.Where(x => x.NumberOfBids <= int.Parse(txtMaxBids.Text)).ToList();
            }

            bindData(filteredItems);
        }
    }
}

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
        private List<AuctionItem> auctionItems;
        public AuctioneerUI()
        {
            InitializeComponent();

            auctionItems = new List<AuctionItem>();
        }

        private void btnGetItems_Click(object sender, EventArgs e)
        {
            //SplashForm.ShowSplashScreen();
            this.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<Auction> auctions = SurplusAuctionData.GetAllAuctions(chkIncludeImages.Checked, chkIncludeEnded.Checked, backgroundWorker1).ToList();


                foreach (Auction auction in auctions)
                {
                    foreach (AuctionItem item in auction.AuctionItems)
                    {
                        auctionItems.Add(item);
                    }
                }


                //SplashForm.CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;

            txtLoadingText.Text = e.UserState.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindData(auctionItems.Where(x => x.FullDescription.Contains(txtSearch.Text)).ToList());
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

            this.Enabled = true;
        }
    }
}

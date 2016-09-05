namespace wi_auctioneer_app
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetAuctions = new System.Windows.Forms.Button();
            this.lstAuctionTitles = new System.Windows.Forms.ListBox();
            this.btnGetItems = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetAuctions
            // 
            this.btnGetAuctions.Location = new System.Drawing.Point(12, 12);
            this.btnGetAuctions.Name = "btnGetAuctions";
            this.btnGetAuctions.Size = new System.Drawing.Size(94, 23);
            this.btnGetAuctions.TabIndex = 0;
            this.btnGetAuctions.Text = "Get Auctions";
            this.btnGetAuctions.UseVisualStyleBackColor = true;
            this.btnGetAuctions.Click += new System.EventHandler(this.btnGetAuctions_Click);
            // 
            // lstAuctionTitles
            // 
            this.lstAuctionTitles.FormattingEnabled = true;
            this.lstAuctionTitles.Location = new System.Drawing.Point(12, 41);
            this.lstAuctionTitles.Name = "lstAuctionTitles";
            this.lstAuctionTitles.Size = new System.Drawing.Size(447, 95);
            this.lstAuctionTitles.TabIndex = 2;
            // 
            // btnGetItems
            // 
            this.btnGetItems.Location = new System.Drawing.Point(13, 143);
            this.btnGetItems.Name = "btnGetItems";
            this.btnGetItems.Size = new System.Drawing.Size(75, 23);
            this.btnGetItems.TabIndex = 3;
            this.btnGetItems.Text = "Get Items";
            this.btnGetItems.UseVisualStyleBackColor = true;
            this.btnGetItems.Click += new System.EventHandler(this.btnGetItems_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 173);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(622, 257);
            this.dataGridView1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 442);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGetItems);
            this.Controls.Add(this.lstAuctionTitles);
            this.Controls.Add(this.btnGetAuctions);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAuctions;
        private System.Windows.Forms.ListBox lstAuctionTitles;
        private System.Windows.Forms.Button btnGetItems;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


namespace wi_auctioneer_app
{
    partial class AuctioneerUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuctioneerUI));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGetItems = new System.Windows.Forms.Button();
            this.chkIncludeEnded = new System.Windows.Forms.CheckBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.ShortDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfBids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Picture,
            this.ShortDescription,
            this.FullDescription,
            this.NumberOfBids,
            this.CurrentPrice});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(958, 404);
            this.dataGridView1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 442);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnGetItems);
            this.flowLayoutPanel1.Controls.Add(this.chkIncludeEnded);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(958, 26);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnGetItems
            // 
            this.btnGetItems.Location = new System.Drawing.Point(3, 3);
            this.btnGetItems.Name = "btnGetItems";
            this.btnGetItems.Size = new System.Drawing.Size(132, 23);
            this.btnGetItems.TabIndex = 4;
            this.btnGetItems.Text = "Get All Auction Items";
            this.btnGetItems.UseVisualStyleBackColor = true;
            this.btnGetItems.Click += new System.EventHandler(this.btnGetItems_Click);
            // 
            // chkIncludeEnded
            // 
            this.chkIncludeEnded.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeEnded.AutoSize = true;
            this.chkIncludeEnded.Location = new System.Drawing.Point(141, 6);
            this.chkIncludeEnded.Name = "chkIncludeEnded";
            this.chkIncludeEnded.Size = new System.Drawing.Size(95, 17);
            this.chkIncludeEnded.TabIndex = 5;
            this.chkIncludeEnded.Text = "Include Ended";
            this.chkIncludeEnded.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // Picture
            // 
            this.Picture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Picture.DataPropertyName = "Picture";
            this.Picture.HeaderText = "Picture";
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            this.Picture.Width = 46;
            // 
            // ShortDescription
            // 
            this.ShortDescription.DataPropertyName = "ShortDescription";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ShortDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShortDescription.HeaderText = "Short Description";
            this.ShortDescription.Name = "ShortDescription";
            this.ShortDescription.ReadOnly = true;
            this.ShortDescription.Width = 250;
            // 
            // FullDescription
            // 
            this.FullDescription.DataPropertyName = "FullDescription";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FullDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.FullDescription.HeaderText = "Full Description";
            this.FullDescription.Name = "FullDescription";
            this.FullDescription.ReadOnly = true;
            this.FullDescription.Width = 300;
            // 
            // NumberOfBids
            // 
            this.NumberOfBids.DataPropertyName = "NumberOfBids";
            this.NumberOfBids.HeaderText = "Number of Bids";
            this.NumberOfBids.Name = "NumberOfBids";
            this.NumberOfBids.ReadOnly = true;
            this.NumberOfBids.Width = 78;
            // 
            // CurrentPrice
            // 
            this.CurrentPrice.DataPropertyName = "CurrentPrice";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "-";
            this.CurrentPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.CurrentPrice.HeaderText = "Current Price";
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.ReadOnly = true;
            this.CurrentPrice.Width = 86;
            // 
            // AuctioneerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuctioneerUI";
            this.Text = "WI Auctioneer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnGetItems;
        private System.Windows.Forms.CheckBox chkIncludeEnded;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfBids;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
    }
}


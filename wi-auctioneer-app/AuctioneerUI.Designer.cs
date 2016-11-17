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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuctioneerUI));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuctionDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.ShortDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfBids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGetItems = new System.Windows.Forms.Button();
            this.chkIncludeEnded = new System.Windows.Forms.CheckBox();
            this.chkIncludeImages = new System.Windows.Forms.CheckBox();
            this.chkGetFirstRow = new System.Windows.Forms.CheckBox();
            this.filterCriteria = new System.Windows.Forms.GroupBox();
            this.chkMustContainAll = new System.Windows.Forms.CheckBox();
            this.txtMaxBids = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinBids = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaxPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtLoadingText = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkGetFirstRow = new System.Windows.Forms.CheckBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuctionDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.ShortDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfBids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.filterCriteria.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 773F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.filterCriteria, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1677, 685);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AuctionDetails,
            this.Picture,
            this.ShortDescription,
            this.FullDescription,
            this.NumberOfBids,
            this.CurrentPrice,
            this.URLColumn,
            this.ItemCondition});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 103);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1671, 579);
            this.dataGridView1.TabIndex = 4;
           
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // AuctionDetails
            // 
            this.AuctionDetails.DataPropertyName = "Auction";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AuctionDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.AuctionDetails.HeaderText = "Auction Details";
            this.AuctionDetails.Name = "AuctionDetails";
            this.AuctionDetails.ReadOnly = true;
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ShortDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.ShortDescription.HeaderText = "Short Description";
            this.ShortDescription.Name = "ShortDescription";
            this.ShortDescription.ReadOnly = true;
            this.ShortDescription.Width = 250;
            // 
            // FullDescription
            // 
            this.FullDescription.DataPropertyName = "FullDescription";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FullDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.FullDescription.HeaderText = "Full Description";
            this.FullDescription.Name = "FullDescription";
            this.FullDescription.ReadOnly = true;
            this.FullDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FullDescription.Width = 500;
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
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "-";
            this.CurrentPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.CurrentPrice.HeaderText = "Current Price";
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.ReadOnly = true;
            this.CurrentPrice.Width = 86;
            // 
            // URLColumn
            // 
            this.URLColumn.DataPropertyName = "AuctionItemURL";
            this.URLColumn.HeaderText = "URL";
            this.URLColumn.Name = "URLColumn";
            this.URLColumn.ReadOnly = true;
            this.URLColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.URLColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.URLColumn.Width = 250;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnGetItems);
            this.flowLayoutPanel1.Controls.Add(this.chkIncludeEnded);
            this.flowLayoutPanel1.Controls.Add(this.chkIncludeImages);
            this.flowLayoutPanel1.Controls.Add(this.chkGetFirstRow);
            this.flowLayoutPanel1.Controls.Add(this.txtTestURL);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(898, 94);
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
            // chkIncludeImages
            // 
            this.chkIncludeImages.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeImages.AutoSize = true;
            this.chkIncludeImages.Location = new System.Drawing.Point(242, 6);
            this.chkIncludeImages.Name = "chkIncludeImages";
            this.chkIncludeImages.Size = new System.Drawing.Size(98, 17);
            this.chkIncludeImages.TabIndex = 6;
            this.chkIncludeImages.Text = "Include Images";
            this.chkIncludeImages.UseVisualStyleBackColor = true;
            // 
            // filterCriteria
            // 
            this.filterCriteria.Controls.Add(this.chkMustContainAll);
            this.filterCriteria.Controls.Add(this.txtMaxBids);
            this.filterCriteria.Controls.Add(this.label5);
            this.filterCriteria.Controls.Add(this.txtMinBids);
            this.filterCriteria.Controls.Add(this.label6);
            this.filterCriteria.Controls.Add(this.txtMaxPrice);
            this.filterCriteria.Controls.Add(this.label4);
            this.filterCriteria.Controls.Add(this.txtMinPrice);
            this.filterCriteria.Controls.Add(this.label3);
            this.filterCriteria.Controls.Add(this.txtKeywords);
            this.filterCriteria.Controls.Add(this.label2);
            this.filterCriteria.Controls.Add(this.btnApply);
            this.filterCriteria.Location = new System.Drawing.Point(907, 3);
            this.filterCriteria.Name = "filterCriteria";
            this.filterCriteria.Size = new System.Drawing.Size(767, 94);
            this.filterCriteria.TabIndex = 6;
            this.filterCriteria.TabStop = false;
            this.filterCriteria.Text = "Filter Criteria";
            // 
            // chkMustContainAll
            // 
            this.chkMustContainAll.AutoSize = true;
            this.chkMustContainAll.Location = new System.Drawing.Point(611, 15);
            this.chkMustContainAll.Name = "chkMustContainAll";
            this.chkMustContainAll.Size = new System.Drawing.Size(102, 17);
            this.chkMustContainAll.TabIndex = 12;
            this.chkMustContainAll.Text = "Must Contain All";
            this.chkMustContainAll.UseVisualStyleBackColor = true;
            // 
            // txtMaxBids
            // 
            this.txtMaxBids.Location = new System.Drawing.Point(181, 65);
            this.txtMaxBids.Name = "txtMaxBids";
            this.txtMaxBids.Size = new System.Drawing.Size(76, 20);
            this.txtMaxBids.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max Bids:";
            // 
            // txtMinBids
            // 
            this.txtMinBids.Location = new System.Drawing.Point(63, 65);
            this.txtMinBids.Name = "txtMinBids";
            this.txtMinBids.Size = new System.Drawing.Size(52, 20);
            this.txtMinBids.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Min Bids:";
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.Location = new System.Drawing.Point(181, 39);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(76, 20);
            this.txtMaxPrice.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Price:";
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.Location = new System.Drawing.Point(63, 39);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(52, 20);
            this.txtMinPrice.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Min Price:";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(181, 13);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(423, 20);
            this.txtKeywords.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description (separate by commas):";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(686, 65);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply Filters";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtLoadingText,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1677, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtLoadingText
            // 
            this.txtLoadingText.Name = "txtLoadingText";
            this.txtLoadingText.Size = new System.Drawing.Size(0, 20);
            // 
            // chkGetFirstRow
            // 
            this.chkGetFirstRow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkGetFirstRow.AutoSize = true;
            this.chkGetFirstRow.Location = new System.Drawing.Point(346, 6);
            this.chkGetFirstRow.Name = "chkGetFirstRow";
            this.chkGetFirstRow.Size = new System.Drawing.Size(120, 17);
            this.chkGetFirstRow.TabIndex = 8;
            this.chkGetFirstRow.Text = "Get First Row (Test)";
            this.chkGetFirstRow.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // AuctionDetails
            // 
            this.AuctionDetails.DataPropertyName = "Auction";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AuctionDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.AuctionDetails.HeaderText = "Auction Details";
            this.AuctionDetails.Name = "AuctionDetails";
            this.AuctionDetails.ReadOnly = true;
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ShortDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.ShortDescription.HeaderText = "Short Description";
            this.ShortDescription.Name = "ShortDescription";
            this.ShortDescription.ReadOnly = true;
            this.ShortDescription.Width = 250;
            // 
            // FullDescription
            // 
            this.FullDescription.DataPropertyName = "FullDescription";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FullDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.FullDescription.HeaderText = "Full Description";
            this.FullDescription.Name = "FullDescription";
            this.FullDescription.ReadOnly = true;
            this.FullDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FullDescription.Width = 500;
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
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "-";
            this.CurrentPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.CurrentPrice.HeaderText = "Current Price";
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.ReadOnly = true;
            this.CurrentPrice.Width = 86;
            // 
            // URLColumn
            // 
            this.URLColumn.DataPropertyName = "AuctionItemURL";
            this.URLColumn.HeaderText = "URL";
            this.URLColumn.Name = "URLColumn";
            this.URLColumn.ReadOnly = true;
            this.URLColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.URLColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.URLColumn.Width = 250;
            // 
            // ItemCondition
            // 
            this.ItemCondition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemCondition.DataPropertyName = "ItemCondition";
            this.ItemCondition.HeaderText = "Item Condition";
            this.ItemCondition.Name = "ItemCondition";
            this.ItemCondition.ReadOnly = true;
            this.ItemCondition.Width = 91;
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 19);
            // 
            // AuctioneerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 685);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuctioneerUI";
            this.Text = "WI Auctioneer";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.filterCriteria.ResumeLayout(false);
            this.filterCriteria.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnGetItems;
        private System.Windows.Forms.CheckBox chkIncludeEnded;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtLoadingText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.CheckBox chkIncludeImages;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox filterCriteria;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.TextBox txtMaxBids;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMinBids;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMustContainAll;
        private System.Windows.Forms.CheckBox chkGetFirstRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuctionDetails;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfBids;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
        private System.Windows.Forms.DataGridViewLinkColumn URLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCondition;
        private System.Windows.Forms.TextBox txtTestURL;
    }
}


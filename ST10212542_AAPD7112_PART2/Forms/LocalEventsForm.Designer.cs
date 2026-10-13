namespace ST10212542_AAPD7112_PART_2.Forms
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.lblDateFilter = new System.Windows.Forms.Label();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.chkUseDateFilter = new System.Windows.Forms.CheckBox();
            this.lblGridHint = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.grpRecommendations = new System.Windows.Forms.GroupBox();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.lblRecInfo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnAdminAction = new System.Windows.Forms.Button();
            this.lnkAdminLogout = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.grpRecommendations.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(378, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Local Events and Announcements";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(22, 60);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(66, 18);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSearch.Location = new System.Drawing.Point(94, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 24);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnSearch.Location = new System.Drawing.Point(300, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.AutoSize = true;
            this.lblCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategoryFilter.Location = new System.Drawing.Point(395, 60);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(81, 18);
            this.lblCategoryFilter.TabIndex = 4;
            this.lblCategoryFilter.Text = "Category:";
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(482, 56);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(195, 26);
            this.cmbCategoryFilter.TabIndex = 5;
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);
            // 
            // lblDateFilter
            // 
            this.lblDateFilter.AutoSize = true;
            this.lblDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateFilter.Location = new System.Drawing.Point(22, 100);
            this.lblDateFilter.Name = "lblDateFilter";
            this.lblDateFilter.Size = new System.Drawing.Size(48, 18);
            this.lblDateFilter.TabIndex = 6;
            this.lblDateFilter.Text = "Date:";
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.Enabled = false;
            this.dtpDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFilter.Location = new System.Drawing.Point(94, 97);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.Size = new System.Drawing.Size(130, 24);
            this.dtpDateFilter.TabIndex = 7;
            this.dtpDateFilter.ValueChanged += new System.EventHandler(this.dtpDateFilter_ValueChanged);
            // 
            // chkUseDateFilter
            // 
            this.chkUseDateFilter.AutoSize = true;
            this.chkUseDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.chkUseDateFilter.Location = new System.Drawing.Point(230, 100);
            this.chkUseDateFilter.Name = "chkUseDateFilter";
            this.chkUseDateFilter.Size = new System.Drawing.Size(113, 22);
            this.chkUseDateFilter.TabIndex = 8;
            this.chkUseDateFilter.Text = "Filter by Date";
            this.chkUseDateFilter.UseVisualStyleBackColor = true;
            this.chkUseDateFilter.CheckedChanged += new System.EventHandler(this.chkUseDateFilter_CheckedChanged);
            // 
            // lblGridHint
            // 
            this.lblGridHint.AutoSize = true;
            this.lblGridHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblGridHint.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblGridHint.Location = new System.Drawing.Point(348, 101);
            this.lblGridHint.Name = "lblGridHint";
            this.lblGridHint.Size = new System.Drawing.Size(225, 17);
            this.lblGridHint.TabIndex = 9;
            this.lblGridHint.Text = "(Double-click any event for details)";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnClearFilters.Location = new System.Drawing.Point(582, 95);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(95, 28);
            this.btnClearFilters.TabIndex = 10;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(25, 135);
            this.dgvEvents.MultiSelect = false;
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersVisible = false;
            this.dgvEvents.RowTemplate.Height = 24;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(652, 195);
            this.dgvEvents.TabIndex = 11;
            this.dgvEvents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellDoubleClick);
            // 
            // grpRecommendations
            // 
            this.grpRecommendations.Controls.Add(this.lstRecommendations);
            this.grpRecommendations.Controls.Add(this.lblRecInfo);
            this.grpRecommendations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpRecommendations.Location = new System.Drawing.Point(25, 340);
            this.grpRecommendations.Name = "grpRecommendations";
            this.grpRecommendations.Size = new System.Drawing.Size(652, 115);
            this.grpRecommendations.TabIndex = 12;
            this.grpRecommendations.TabStop = false;
            this.grpRecommendations.Text = "Recommended Events for You (Recommendation Engine)";
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 17;
            this.lstRecommendations.Location = new System.Drawing.Point(12, 45);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(628, 55);
            this.lstRecommendations.TabIndex = 1;
            this.lstRecommendations.DoubleClick += new System.EventHandler(this.lstRecommendations_DoubleClick);
            // 
            // lblRecInfo
            // 
            this.lblRecInfo.AutoSize = true;
            this.lblRecInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblRecInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblRecInfo.Location = new System.Drawing.Point(10, 22);
            this.lblRecInfo.Name = "lblRecInfo";
            this.lblRecInfo.Size = new System.Drawing.Size(431, 17);
            this.lblRecInfo.TabIndex = 0;
            this.lblRecInfo.Text = "Recommendations adapt based on your search history and preferences.";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBack.Location = new System.Drawing.Point(25, 465);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 35);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.Location = new System.Drawing.Point(185, 465);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(165, 35);
            this.btnViewDetails.TabIndex = 14;
            this.btnViewDetails.Text = "View Event Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnAdminAction
            // 
            this.btnAdminAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAdminAction.Location = new System.Drawing.Point(475, 465);
            this.btnAdminAction.Name = "btnAdminAction";
            this.btnAdminAction.Size = new System.Drawing.Size(202, 35);
            this.btnAdminAction.TabIndex = 15;
            this.btnAdminAction.Text = "Admin Portal: Post Event";
            this.btnAdminAction.UseVisualStyleBackColor = true;
            this.btnAdminAction.Click += new System.EventHandler(this.btnAdminAction_Click);
            // 
            // lnkAdminLogout
            // 
            this.lnkAdminLogout.AutoSize = true;
            this.lnkAdminLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lnkAdminLogout.Location = new System.Drawing.Point(365, 474);
            this.lnkAdminLogout.Name = "lnkAdminLogout";
            this.lnkAdminLogout.Size = new System.Drawing.Size(64, 17);
            this.lnkAdminLogout.TabIndex = 16;
            this.lnkAdminLogout.TabStop = true;
            this.lnkAdminLogout.Text = "[Log Out]";
            this.lnkAdminLogout.Visible = false;
            this.lnkAdminLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdminLogout_LinkClicked);
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 510);
            this.Controls.Add(this.lnkAdminLogout);
            this.Controls.Add(this.btnAdminAction);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpRecommendations);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.lblGridHint);
            this.Controls.Add(this.chkUseDateFilter);
            this.Controls.Add(this.dtpDateFilter);
            this.Controls.Add(this.lblDateFilter);
            this.Controls.Add(this.cmbCategoryFilter);
            this.Controls.Add(this.lblCategoryFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events and Announcements";
            this.Load += new System.EventHandler(this.LocalEventsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.grpRecommendations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Label lblDateFilter;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.CheckBox chkUseDateFilter;
        private System.Windows.Forms.Label lblGridHint;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.GroupBox grpRecommendations;
        private System.Windows.Forms.Label lblRecInfo;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnAdminAction;
        private System.Windows.Forms.LinkLabel lnkAdminLogout;
    }
}

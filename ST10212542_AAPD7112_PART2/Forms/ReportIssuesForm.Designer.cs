namespace ST10212542_AAPD7112_PART_2.Forms
{
    partial class ReportIssuesForm
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
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.lblAttachmentName = new System.Windows.Forms.Label();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.lblResolutionTitle = new System.Windows.Forms.Label();
            this.lblResolutionEstimate = new System.Windows.Forms.Label();
            this.lblEngagementMsg = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.ofdAttachment = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Report an Issue";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Location = new System.Drawing.Point(25, 68);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(78, 18);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtLocation.Location = new System.Drawing.Point(140, 65);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(430, 25);
            this.txtLocation.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(25, 112);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(81, 18);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(140, 108);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(430, 28);
            this.cmbCategory.TabIndex = 4;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(25, 155);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(99, 18);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.rtbDescription.Location = new System.Drawing.Point(140, 152);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(430, 110);
            this.rtbDescription.TabIndex = 6;
            this.rtbDescription.Text = "";
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAttachment.Location = new System.Drawing.Point(25, 280);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(97, 18);
            this.lblAttachment.TabIndex = 7;
            this.lblAttachment.Text = "Attachment:";
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAttachFile.Location = new System.Drawing.Point(140, 274);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(100, 30);
            this.btnAttachFile.TabIndex = 8;
            this.btnAttachFile.Text = "Attach File...";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // lblAttachmentName
            // 
            this.lblAttachmentName.AutoSize = true;
            this.lblAttachmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAttachmentName.Location = new System.Drawing.Point(250, 280);
            this.lblAttachmentName.Name = "lblAttachmentName";
            this.lblAttachmentName.Size = new System.Drawing.Size(115, 18);
            this.lblAttachmentName.TabIndex = 9;
            this.lblAttachmentName.Text = "No file attached.";
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRemoveAttachment.Location = new System.Drawing.Point(490, 274);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(80, 30);
            this.btnRemoveAttachment.TabIndex = 10;
            this.btnRemoveAttachment.Text = "Remove";
            this.btnRemoveAttachment.UseVisualStyleBackColor = true;
            this.btnRemoveAttachment.Visible = false;
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // lblResolutionTitle
            // 
            this.lblResolutionTitle.AutoSize = true;
            this.lblResolutionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblResolutionTitle.Location = new System.Drawing.Point(25, 325);
            this.lblResolutionTitle.Name = "lblResolutionTitle";
            this.lblResolutionTitle.Size = new System.Drawing.Size(161, 18);
            this.lblResolutionTitle.TabIndex = 11;
            this.lblResolutionTitle.Text = "Est. Response Time:";
            // 
            // lblResolutionEstimate
            // 
            this.lblResolutionEstimate.AutoSize = true;
            this.lblResolutionEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblResolutionEstimate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResolutionEstimate.Location = new System.Drawing.Point(200, 325);
            this.lblResolutionEstimate.Name = "lblResolutionEstimate";
            this.lblResolutionEstimate.Size = new System.Drawing.Size(184, 18);
            this.lblResolutionEstimate.TabIndex = 12;
            this.lblResolutionEstimate.Text = "Select a category above";
            // 
            // lblEngagementMsg
            // 
            this.lblEngagementMsg.AutoSize = true;
            this.lblEngagementMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblEngagementMsg.ForeColor = System.Drawing.Color.DimGray;
            this.lblEngagementMsg.Location = new System.Drawing.Point(25, 355);
            this.lblEngagementMsg.Name = "lblEngagementMsg";
            this.lblEngagementMsg.Size = new System.Drawing.Size(430, 18);
            this.lblEngagementMsg.TabIndex = 13;
            this.lblEngagementMsg.Text = "Reporting helps municipal response teams prioritize repair dispatches.";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Location = new System.Drawing.Point(460, 395);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(110, 38);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClear.Location = new System.Drawing.Point(340, 395);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 38);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBack.Location = new System.Drawing.Point(25, 395);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 38);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ofdAttachment
            // 
            this.ofdAttachment.Filter = "Files (*.jpg;*.png;*.pdf;*.docx;*.txt)|*.jpg;*.png;*.pdf;*.docx;*.txt|All Files (*" +
    ".*)|*.*";
            this.ofdAttachment.Title = "Select File";
            // 
            // ReportIssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 455);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblEngagementMsg);
            this.Controls.Add(this.lblResolutionEstimate);
            this.Controls.Add(this.lblResolutionTitle);
            this.Controls.Add(this.btnRemoveAttachment);
            this.Controls.Add(this.lblAttachmentName);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportIssuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Issues";
            this.Load += new System.EventHandler(this.ReportIssuesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.Label lblAttachmentName;
        private System.Windows.Forms.Button btnRemoveAttachment;
        private System.Windows.Forms.Label lblResolutionTitle;
        private System.Windows.Forms.Label lblResolutionEstimate;
        private System.Windows.Forms.Label lblEngagementMsg;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.OpenFileDialog ofdAttachment;
    }
}

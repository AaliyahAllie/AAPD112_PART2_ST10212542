using System;
using System.IO;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    public partial class ReportIssuesForm : Form
    {
        private MainMenuForm mainMenu;
        private string selectedFilePath = "";

        public ReportIssuesForm(MainMenuForm menu)
        {
            InitializeComponent();
            mainMenu = menu;
        }

        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
            // Populate ComboBox categories
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("-- Select Category --");
            cmbCategory.Items.Add("Roads and Potholes");
            cmbCategory.Items.Add("Water and Utilities");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Sanitation");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Street Lighting");
            cmbCategory.Items.Add("Public Safety");
            cmbCategory.Items.Add("Parks and Recreation");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedIndex = 0;
            ResetForm();
        }

        // User Engagement Strategy: Resolution Time Estimate & Impact Preview
        private void UpdateResolutionEstimate()
        {
            if (cmbCategory.SelectedIndex <= 0)
            {
                lblResolutionEstimate.Text = "Select a category above";
                lblEngagementMsg.Text = "Reporting helps municipal response teams prioritize repair dispatches.";
                return;
            }

            string selectedCategory = cmbCategory.SelectedItem.ToString();
            string responseTime = "";

            switch (selectedCategory)
            {
                case "Roads and Potholes":
                    responseTime = "~48 Hours (High Road Safety Priority)";
                    break;
                case "Water and Utilities":
                    responseTime = "~24 Hours (Urgent Infrastructure)";
                    break;
                case "Electricity":
                    responseTime = "~12 to 24 Hours (Urgent Power Fault)";
                    break;
                case "Sanitation":
                    responseTime = "~24 Hours (Public Health Priority)";
                    break;
                case "Waste Management":
                    responseTime = "~72 Hours (Scheduled Collection)";
                    break;
                case "Street Lighting":
                    responseTime = "~5 Days (Standard Maintenance)";
                    break;
                case "Public Safety":
                    responseTime = "~6 Hours (High Priority Response)";
                    break;
                case "Parks and Recreation":
                    responseTime = "~7 Days (Standard Maintenance)";
                    break;
                default:
                    responseTime = "~3 to 5 Business Days";
                    break;
            }

            lblResolutionEstimate.Text = responseTime;
            lblEngagementMsg.Text = "Thank you! Clear descriptions help municipal workers resolve issues faster.";
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateResolutionEstimate();
        }

        // OpenFileDialog to attach image or document
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            if (ofdAttachment.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = ofdAttachment.FileName;

                if (File.Exists(selectedFilePath))
                {
                    lblAttachmentName.Text = Path.GetFileName(selectedFilePath);
                    btnRemoveAttachment.Visible = true;
                }
                else
                {
                    MessageBox.Show("The selected file could not be found.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Remove attached file
        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            selectedFilePath = "";
            lblAttachmentName.Text = "No file attached.";
            btnRemoveAttachment.Visible = false;
        }

        // Submit report button click handler
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Validate Location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            // 2. Validate Category
            if (cmbCategory.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select an issue category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            // 3. Validate Description
            if (string.IsNullOrWhiteSpace(rtbDescription.Text) || rtbDescription.Text.Trim().Length < 10)
            {
                MessageBox.Show("Please provide a description of the issue (at least 10 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // Generate unique reference number (MS-0001, MS-0002...)
            string refNumber = "MS-" + Program.IssueCounter.ToString("D4");
            Program.IssueCounter++;

            // Create Issue object
            Issue newIssue = new Issue(
                refNumber,
                txtLocation.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                selectedFilePath
            );

            // Add issue object to List<Issue>
            Program.IssueList.Add(newIssue);

            // Show success confirmation message box
            string confirmText = "Your issue has been successfully reported.\n\n" +
                                "Reference Number: " + newIssue.ReferenceNumber + "\n" +
                                "Location: " + newIssue.Location + "\n" +
                                "Category: " + newIssue.Category + "\n" +
                                "Est. Resolution Time: " + lblResolutionEstimate.Text + "\n" +
                                "Attachment: " + newIssue.GetAttachmentFileName() + "\n\n" +
                                "Thank you for helping improve your community!";

            MessageBox.Show(confirmText, "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form for next entry
            ResetForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.UpdateCounts();
        }

        private void ResetForm()
        {
            txtLocation.Clear();
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
            rtbDescription.Clear();
            selectedFilePath = "";
            lblAttachmentName.Text = "No file attached.";
            btnRemoveAttachment.Visible = false;
            UpdateResolutionEstimate();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                mainMenu.Show();
                mainMenu.UpdateCounts();
            }
        }
    }
}

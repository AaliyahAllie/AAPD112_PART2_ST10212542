using ST10212542_AAPD7112_PART_2;
using ST10212542_AAPD7112_PART_2.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    /// <summary>
    /// ReportIssuesForm handles Part 1 functionality:
    /// Allows citizens to capture municipal issues by entering location, selecting category,
    /// providing a detailed description, and attaching supporting evidence (photos/documents).
    /// Incorporates the User Engagement Strategy: Real-time Resolution Time Estimates.
    /// </summary>
    public partial class ReportIssuesForm : Form
    {
        // Reference back to MainMenuForm to return seamlessly when finished
        private MainMenuForm mainMenu;

        // Stores the full local path of any file selected by the citizen via OpenFileDialog
        private string selectedFilePath = "";

        /// <summary>
        /// Constructor accepting the parent main menu reference.
        /// </summary>
        /// <param name="menu">Reference to MainMenuForm</param>
        public ReportIssuesForm(MainMenuForm menu)
        {
            InitializeComponent();
            mainMenu = menu;
        }

        /// <summary>
        /// Form Load Event: Populates the category dropdown and resets all input controls to their default state.
        /// </summary>
        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
            // Populate ComboBox categories covering typical municipal service domains
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

            // Select default prompt item
            cmbCategory.SelectedIndex = 0;
            ResetForm();
        }

        /// <summary>
        /// USER ENGAGEMENT STRATEGY: Resolution Time Estimate & Turnaround Preview.
        /// When a citizen selects a category, this method calculates and displays an estimated
        /// repair SLA (Service Level Agreement) turnaround time.
        /// Rationale: Transparent turnaround expectations build civic trust and encourage citizen reporting.
        /// </summary>
        private void UpdateResolutionEstimate()
        {
            // If prompt item or nothing selected, prompt user to pick
            if (cmbCategory.SelectedIndex <= 0)
            {
                lblResolutionEstimate.Text = "Select a category above";
                lblEngagementMsg.Text = "Reporting helps municipal response teams prioritize repair dispatches.";
                return;
            }

            string selectedCategory = cmbCategory.SelectedItem.ToString();
            string responseTime = "";

            // Determine estimated resolution turnaround based on municipal service tier
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

            // Update UI labels with calculated turnaround time and community engagement message
            lblResolutionEstimate.Text = responseTime;
            lblEngagementMsg.Text = "Thank you! Clear descriptions help municipal workers resolve issues faster.";
        }

        /// <summary>
        /// Category Selection Changed: Recomputes the resolution estimate dynamically.
        /// </summary>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateResolutionEstimate();
        }

        /// <summary>
        /// Attach File Button Click: Launches OpenFileDialog to let citizens attach a photo or document.
        /// Restricts file types to common image and document formats.
        /// </summary>
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            if (ofdAttachment.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = ofdAttachment.FileName;

                // Validate that the file actually exists on disk
                if (File.Exists(selectedFilePath))
                {
                    // Show just the file name on the UI label
                    lblAttachmentName.Text = Path.GetFileName(selectedFilePath);
                    btnRemoveAttachment.Visible = true;
                }
                else
                {
                    MessageBox.Show("The selected file could not be found.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Remove Attachment Button Click: Clears the attached file if the user changes their mind.
        /// </summary>
        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            selectedFilePath = "";
            lblAttachmentName.Text = "No file attached.";
            btnRemoveAttachment.Visible = false;
        }

        /// <summary>
        /// Submit Button Click:
        /// 1. Validates all inputs (non-empty location, category selected, description >= 10 chars).
        /// 2. Generates an auto-incrementing reference number (e.g., MS-0001).
        /// 3. Instantiates an Issue object and stores it in the global List<Issue>.
        /// 4. Displays a confirmation summary dialog and resets the form.
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Validate Location (Must not be empty or whitespace)
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            // 2. Validate Category (Must not be the default prompt item)
            if (cmbCategory.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select an issue category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            // 3. Validate Description (Must be at least 10 characters for meaningful detail)
            if (string.IsNullOrWhiteSpace(rtbDescription.Text) || rtbDescription.Text.Trim().Length < 10)
            {
                MessageBox.Show("Please provide a description of the issue (at least 10 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // Generate unique sequential reference number formatted with 4 digits (MS-0001, MS-0002...)
            string refNumber = "MS-" + Program.IssueCounter.ToString("D4");
            Program.IssueCounter++;

            // Create new Issue model object with verified inputs
            Issue newIssue = new Issue(
                refNumber,
                txtLocation.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                selectedFilePath
            );

            // Append the new report to the global in-memory issue list
            Program.IssueList.Add(newIssue);

            // Construct friendly confirmation summary for the citizen
            string confirmText = "Your issue has been successfully reported.\n\n" +
                                "Reference Number: " + newIssue.ReferenceNumber + "\n" +
                                "Location: " + newIssue.Location + "\n" +
                                "Category: " + newIssue.Category + "\n" +
                                "Est. Resolution Time: " + lblResolutionEstimate.Text + "\n" +
                                "Attachment: " + newIssue.GetAttachmentFileName() + "\n\n" +
                                "Thank you for helping improve your community!";

            MessageBox.Show(confirmText, "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form fields ready for the next issue
            ResetForm();
        }

        /// <summary>
        /// Clear Button Click: Discards any text typed and resets the form.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Back Button Click: Closes the reporting window and reveals the MainMenuForm.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.UpdateCounts();
        }

        /// <summary>
        /// Resets all inputs, file attachments, and engagement labels back to default blank states.
        /// </summary>
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

        /// <summary>
        /// Ensures the main menu is redisplayed if the user closes the window via the title bar ('X').
        /// </summary>
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

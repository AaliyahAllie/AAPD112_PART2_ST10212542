using ST10212542_AAPD7112_PART_2;
using ST10212542_AAPD7112_PART_2.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    /// <summary>
    /// MainMenuForm serves as the primary dashboard and navigation hub of the application.
    /// Provides access to:
    /// 1. Report Issues (Part 1 - Enabled)
    /// 2. Local Events and Announcements (Part 2 - Enabled)
    /// 3. Service Request Status (Part 3 - Disabled placeholder)
    /// </summary>
    public partial class MainMenuForm : Form
    {
        /// <summary>
        /// Constructor: Initializes WinForms visual components.
        /// </summary>
        public MainMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load Event: Runs immediately when the form appears on screen.
        /// Refreshes the real-time statistics displayed on the dashboard.
        /// </summary>
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            UpdateCounts();
        }

        /// <summary>
        /// Queries the central data stores to update the badge counters:
        /// - Total issues reported by citizens so far
        /// - Total municipal events and announcements currently in memory
        /// </summary>
        public void UpdateCounts()
        {
            // Update reported issues counter from global List<Issue>
            lblTotalReports.Text = "Total Issues Reported: " + Program.IssueList.Count;

            // Calculate total events by summing counts across all date lists in SortedDictionary
            int totalEvents = Program.EventSortedByDate.Values.Sum(list => list.Count);
            lblTotalEvents.Text = "Local Events Available: " + totalEvents;
        }

        /// <summary>
        /// Button 1 Click: Opens the Part 1 Report Issues form.
        /// Hides the main menu until the citizen navigates back.
        /// </summary>
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm(this);
            this.Hide();
            reportForm.Show();
        }

        /// <summary>
        /// Button 2 Click: Opens the Part 2 Local Events and Announcements form.
        /// Allows citizens to search, filter, and view upcoming notices.
        /// </summary>
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm eventsForm = new LocalEventsForm(this);
            this.Hide();
            eventsForm.Show();
        }

        /// <summary>
        /// Exit Button Click: Confirms user intent before gracefully terminating the application.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Handles the window close ('X') button to ensure the entire application closes cleanly.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}

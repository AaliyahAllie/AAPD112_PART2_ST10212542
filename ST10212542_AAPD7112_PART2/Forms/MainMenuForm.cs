using System;
using System.Linq;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            UpdateCounts();
        }

        // Refreshes the issue count and total available local events
        public void UpdateCounts()
        {
            lblTotalReports.Text = "Total Issues Reported: " + Program.IssueList.Count;

            int totalEvents = Program.EventSortedByDate.Values.Sum(list => list.Count);
            lblTotalEvents.Text = "Local Events Available: " + totalEvents;
        }

        // Opens the Report Issues form (Part 1)
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm(this);
            this.Hide();
            reportForm.Show();
        }

        // Opens the Local Events & Announcements form (Part 2)
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm eventsForm = new LocalEventsForm(this);
            this.Hide();
            eventsForm.Show();
        }

        // Exits the application
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

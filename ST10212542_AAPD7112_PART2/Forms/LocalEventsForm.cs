using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    public partial class LocalEventsForm : Form
    {
        private MainMenuForm mainMenu;
        private List<Event> currentRecommendations = new List<Event>();

        public LocalEventsForm(MainMenuForm menu)
        {
            InitializeComponent();
            mainMenu = menu;
        }

        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            PopulateCategories();
            ApplyFilters();
            UpdateAdminControls();
        }

        // Sets up DataGridView columns for clean event display
        private void SetupGridColumns()
        {
            dgvEvents.Columns.Clear();
            dgvEvents.Columns.Add("Title", "Event Title");
            dgvEvents.Columns.Add("Category", "Category");
            dgvEvents.Columns.Add("Date", "Date");
            dgvEvents.Columns.Add("Location", "Location");
            dgvEvents.Columns.Add("Description", "Description");

            dgvEvents.Columns["Title"].Width = 160;
            dgvEvents.Columns["Category"].Width = 110;
            dgvEvents.Columns["Date"].Width = 85;
            dgvEvents.Columns["Location"].Width = 120;
            dgvEvents.Columns["Description"].Width = 170;
        }

        // Populates Category filter dropdown
        private void PopulateCategories()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            cmbCategoryFilter.Items.Add("Water Notices");
            cmbCategoryFilter.Items.Add("Power Maintenance");
            cmbCategoryFilter.Items.Add("Community Meetings");
            cmbCategoryFilter.Items.Add("Health & Safety");
            cmbCategoryFilter.Items.Add("Sports & Youth");

            cmbCategoryFilter.SelectedIndex = 0;
        }

        // Applies search keyword, category, and date filters using SortedDictionary and Dictionary
        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedCategory = cmbCategoryFilter.SelectedItem != null ? cmbCategoryFilter.SelectedItem.ToString() : "All Categories";
            bool filterByDate = chkUseDateFilter.Checked;
            DateTime selectedDate = dtpDateFilter.Value.Date;

            // Track user search history & category search count for Recommendation Engine
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                Program.UserSearchHistory.Add(keyword);
            }

            if (selectedCategory != "All Categories")
            {
                if (Program.CategorySearchCount.ContainsKey(selectedCategory))
                {
                    Program.CategorySearchCount[selectedCategory]++;
                }
            }

            // Gather all events from primary SortedDictionary<DateTime, List<Event>>
            List<Event> allEvents = new List<Event>();
            foreach (var kvp in Program.EventSortedByDate)
            {
                allEvents.AddRange(kvp.Value);
            }

            // Filter by category using Category Dictionary if specific category selected
            if (selectedCategory != "All Categories" && Program.EventByCategory.ContainsKey(selectedCategory))
            {
                allEvents = Program.EventByCategory[selectedCategory];
            }

            // Filter by keyword if entered
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                allEvents = allEvents.Where(ev =>
                    ev.Title.ToLower().Contains(keyword) ||
                    ev.Description.ToLower().Contains(keyword) ||
                    ev.Location.ToLower().Contains(keyword)
                ).ToList();
            }

            // Filter by Date if checkbox is checked
            if (filterByDate)
            {
                allEvents = allEvents.Where(ev => ev.EventDate.Date == selectedDate).ToList();
            }

            // Display filtered results in DataGridView and bind Event object to Row Tag
            dgvEvents.Rows.Clear();
            foreach (var ev in allEvents)
            {
                int rowIndex = dgvEvents.Rows.Add(
                    ev.Title,
                    ev.Category,
                    ev.EventDate.ToString("yyyy-MM-dd"),
                    ev.Location,
                    ev.Description
                );
                dgvEvents.Rows[rowIndex].Tag = ev;
            }

            // Update Recommendations based on user search patterns
            UpdateRecommendations();
        }

        // Recommendation Engine: Displays targeted events based on user search frequency & history
        private void UpdateRecommendations()
        {
            lstRecommendations.Items.Clear();

            // Find citizen's most frequently searched category
            string topCategory = Program.CategorySearchCount
                .OrderByDescending(kvp => kvp.Value)
                .FirstOrDefault().Key;

            int topCount = Program.CategorySearchCount.Values.Max();

            List<Event> recommendedEvents = new List<Event>();

            // If user has actively searched a category, recommend events from that category
            if (!string.IsNullOrEmpty(topCategory) && topCount > 0 && Program.EventByCategory.ContainsKey(topCategory))
            {
                recommendedEvents = Program.EventByCategory[topCategory]
                    .Where(ev => ev.EventDate >= DateTime.Today)
                    .OrderBy(ev => ev.EventDate)
                    .Take(3)
                    .ToList();

                lblRecInfo.Text = "Recommended for you based on your interest in '" + topCategory + "':";
            }
            else
            {
                // Default: Recommend top 3 upcoming events chronologically from SortedDictionary
                foreach (var kvp in Program.EventSortedByDate)
                {
                    foreach (var ev in kvp.Value)
                    {
                        if (ev.EventDate >= DateTime.Today)
                        {
                            recommendedEvents.Add(ev);
                            if (recommendedEvents.Count >= 3) break;
                        }
                    }
                    if (recommendedEvents.Count >= 3) break;
                }

                lblRecInfo.Text = "Upcoming Priority Municipal Announcements & Events:";
            }

            currentRecommendations = recommendedEvents;

            // Add recommended events to ListBox
            if (recommendedEvents.Count > 0)
            {
                foreach (var ev in recommendedEvents)
                {
                    lstRecommendations.Items.Add("⭐ [" + ev.Category + "] " + ev.Title + " on " + ev.EventDate.ToString("yyyy-MM-dd") + " at " + ev.Location);
                }
            }
            else
            {
                lstRecommendations.Items.Add("No upcoming recommendations available at this time.");
            }
        }

        // Opens the full event details modal dialog
        private void ShowEventDetails(Event ev)
        {
            if (ev != null)
            {
                EventDetailsForm detailsForm = new EventDetailsForm(ev);
                detailsForm.ShowDialog(this);
            }
        }

        // Double-click on any event row in the grid opens its full details
        private void dgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvEvents.Rows.Count)
            {
                Event ev = dgvEvents.Rows[e.RowIndex].Tag as Event;
                ShowEventDetails(ev);
            }
        }

        // View Details button opens the currently selected event
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            Event ev = null;
            if (dgvEvents.SelectedRows.Count > 0)
            {
                ev = dgvEvents.SelectedRows[0].Tag as Event;
            }
            else if (dgvEvents.CurrentRow != null)
            {
                ev = dgvEvents.CurrentRow.Tag as Event;
            }

            if (ev != null)
            {
                ShowEventDetails(ev);
            }
            else
            {
                MessageBox.Show("Please select an event from the table to view its full details.", "No Event Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Double-click on a recommended event opens its full details
        private void lstRecommendations_DoubleClick(object sender, EventArgs e)
        {
            int index = lstRecommendations.SelectedIndex;
            if (index >= 0 && index < currentRecommendations.Count)
            {
                ShowEventDetails(currentRecommendations[index]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkUseDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFilter.Enabled = chkUseDateFilter.Checked;
            ApplyFilters();
        }

        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            if (chkUseDateFilter.Checked)
            {
                ApplyFilters();
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            chkUseDateFilter.Checked = false;
            ApplyFilters();
        }

        private void UpdateAdminControls()
        {
            if (Program.IsAdminLoggedIn)
            {
                btnAdminAction.Text = "+ Post Event (Admin)";
                lnkAdminLogout.Visible = true;
            }
            else
            {
                btnAdminAction.Text = "Admin Portal: Post Event";
                lnkAdminLogout.Visible = false;
            }
        }

        private void btnAdminAction_Click(object sender, EventArgs e)
        {
            if (!Program.IsAdminLoggedIn)
            {
                AdminLoginForm loginForm = new AdminLoginForm();
                if (loginForm.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateAdminControls();
                    OpenAddEventDialog();
                }
            }
            else
            {
                OpenAddEventDialog();
            }
        }

        private void OpenAddEventDialog()
        {
            AddEventForm addForm = new AddEventForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                ApplyFilters();
                mainMenu.UpdateCounts();
            }
        }

        private void lnkAdminLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.IsAdminLoggedIn = false;
            UpdateAdminControls();
            MessageBox.Show("Administrator signed out. You are now viewing in resident mode.", "Logged Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.UpdateCounts();
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

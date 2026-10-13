using ST10212542_AAPD7112_PART_2;
using ST10212542_AAPD7112_PART_2.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    /// <summary>
    /// LocalEventsForm implements Part 2: Local Events and Announcements.
    /// Features:
    /// - Chronological event viewing powered by SortedDictionary<DateTime, List<Event>>
    /// - Fast category filtering powered by Dictionary<string, List<Event>>
    /// - Search query tracking via HashSet<string>
    /// - User preference profiling via Dictionary<string, int>
    /// - Dynamic Recommendation Engine displaying tailored upcoming announcements
    /// - Event Detailed View (full popup notice on click/double-click)
    /// - Municipal Admin portal for authentic event creation
    /// </summary>
    public partial class LocalEventsForm : Form
    {
        // Reference to MainMenuForm for returning back
        private MainMenuForm mainMenu;

        // In-memory cache of currently displayed recommended events (for double-click lookups)
        private List<Event> currentRecommendations = new List<Event>();

        /// <summary>
        /// Constructor accepting the parent MainMenuForm instance.
        /// </summary>
        /// <param name="menu">Reference to MainMenuForm</param>
        public LocalEventsForm(MainMenuForm menu)
        {
            InitializeComponent();
            mainMenu = menu;
        }

        /// <summary>
        /// Form Load Event: Sets up grid columns, fills category options,
        /// applies initial filters to populate all events, and sets admin button states.
        /// </summary>
        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            PopulateCategories();
            ApplyFilters();
            UpdateAdminControls();
        }

        /// <summary>
        /// Configures DataGridView columns with appropriate titles and widths.
        /// </summary>
        private void SetupGridColumns()
        {
            dgvEvents.Columns.Clear();
            dgvEvents.Columns.Add("Title", "Event Title");
            dgvEvents.Columns.Add("Category", "Category");
            dgvEvents.Columns.Add("Date", "Date");
            dgvEvents.Columns.Add("Location", "Location");
            dgvEvents.Columns.Add("Description", "Description");

            // Allocate proportional column widths
            dgvEvents.Columns["Title"].Width = 160;
            dgvEvents.Columns["Category"].Width = 110;
            dgvEvents.Columns["Date"].Width = 85;
            dgvEvents.Columns["Location"].Width = 120;
            dgvEvents.Columns["Description"].Width = 170;
        }

        /// <summary>
        /// Populates the Category filter ComboBox dropdown with available municipal categories.
        /// </summary>
        private void PopulateCategories()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            cmbCategoryFilter.Items.Add("Water Notices");
            cmbCategoryFilter.Items.Add("Power Maintenance");
            cmbCategoryFilter.Items.Add("Community Meetings");
            cmbCategoryFilter.Items.Add("Health & Safety");
            cmbCategoryFilter.Items.Add("Sports & Youth");

            // Default to "All Categories"
            cmbCategoryFilter.SelectedIndex = 0;
        }

        /// <summary>
        /// Applies search keyword, category, and date filters to the municipal event dataset.
        /// Uses SortedDictionary and Dictionary for efficient querying.
        /// Updates the recommendation engine based on user interaction patterns.
        /// </summary>
        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedCategory = cmbCategoryFilter.SelectedItem != null ? cmbCategoryFilter.SelectedItem.ToString() : "All Categories";
            bool filterByDate = chkUseDateFilter.Checked;
            DateTime selectedDate = dtpDateFilter.Value.Date;

            // --- 1. Track Search History & Category Frequency ---
            // If the user typed a keyword, store it in the HashSet to track unique search terms
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                Program.UserSearchHistory.Add(keyword);
            }

            // If a specific category was selected, increment its search frequency counter
            if (selectedCategory != "All Categories")
            {
                if (Program.CategorySearchCount.ContainsKey(selectedCategory))
                {
                    Program.CategorySearchCount[selectedCategory]++;
                }
            }

            // --- 2. Retrieve Events from Primary SortedDictionary<DateTime, List<Event>> ---
            // SortedDictionary keeps all events ordered chronologically by date
            List<Event> allEvents = new List<Event>();
            foreach (var kvp in Program.EventSortedByDate)
            {
                allEvents.AddRange(kvp.Value);
            }

            // --- 3. Filter by Category via Dictionary<string, List<Event>> ---
            // If a specific category is chosen, use the category index for O(1) group retrieval
            if (selectedCategory != "All Categories" && Program.EventByCategory.ContainsKey(selectedCategory))
            {
                allEvents = Program.EventByCategory[selectedCategory];
            }

            // --- 4. Filter by Keyword (Matches Title, Description, or Location) ---
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                allEvents = allEvents.Where(ev =>
                    ev.Title.ToLower().Contains(keyword) ||
                    ev.Description.ToLower().Contains(keyword) ||
                    ev.Location.ToLower().Contains(keyword)
                ).ToList();
            }

            // --- 5. Filter by Scheduled Date (if checkbox is enabled) ---
            if (filterByDate)
            {
                allEvents = allEvents.Where(ev => ev.EventDate.Date == selectedDate).ToList();
            }

            // --- 6. Populate DataGridView & Bind Event Object to Row Tag ---
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
                // Store the actual Event object reference in the row's Tag property for instant retrieval
                dgvEvents.Rows[rowIndex].Tag = ev;
            }

            // --- 7. Refresh Personalized Recommendations ---
            UpdateRecommendations();
        }

        /// <summary>
        /// RECOMMENDATION ENGINE:
        /// Analyzes the user's category search counts to determine their primary civic interest.
        /// - If the user has searched a category, recommends upcoming notices in that category.
        /// - Otherwise, defaults to recommending the top 3 upcoming chronological notices from SortedDictionary.
        /// </summary>
        private void UpdateRecommendations()
        {
            lstRecommendations.Items.Clear();

            // Find the category with the highest search count
            string topCategory = Program.CategorySearchCount
                .OrderByDescending(kvp => kvp.Value)
                .FirstOrDefault().Key;

            int topCount = Program.CategorySearchCount.Values.Max();

            List<Event> recommendedEvents = new List<Event>();

            // Condition A: User has demonstrated an active interest in a category
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
                // Condition B: Default recommendations - Top 3 upcoming events chronologically from SortedDictionary
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

            // Cache the list of recommended events for double-click retrieval
            currentRecommendations = recommendedEvents;

            // Display recommended notices in the ListBox
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

        /// <summary>
        /// Helper method to open the EventDetailsForm modal dialog for a given Event.
        /// </summary>
        /// <param name="ev">The target Event to display</param>
        private void ShowEventDetails(Event ev)
        {
            if (ev != null)
            {
                EventDetailsForm detailsForm = new EventDetailsForm(ev);
                detailsForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Cell Double-Click Event on DataGridView:
        /// When a resident double-clicks any row in the events table, opens its full details.
        /// </summary>
        private void dgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvEvents.Rows.Count)
            {
                Event ev = dgvEvents.Rows[e.RowIndex].Tag as Event;
                ShowEventDetails(ev);
            }
        }

        /// <summary>
        /// "View Event Details" Button Click:
        /// Retrieves the currently selected or highlighted event in the grid and displays its full details.
        /// </summary>
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

        /// <summary>
        /// ListBox Double-Click Event on Recommendations:
        /// When a user double-clicks an item in the recommendation list, displays that event's full details.
        /// </summary>
        private void lstRecommendations_DoubleClick(object sender, EventArgs e)
        {
            int index = lstRecommendations.SelectedIndex;
            if (index >= 0 && index < currentRecommendations.Count)
            {
                ShowEventDetails(currentRecommendations[index]);
            }
        }

        /// <summary>
        /// Search Button Click: Triggers filter application based on current keyword.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Category ComboBox Selection Changed: Automatically reapplies filters.
        /// </summary>
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Date Filter Checkbox Changed: Enables or disables the date picker control.
        /// </summary>
        private void chkUseDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFilter.Enabled = chkUseDateFilter.Checked;
            ApplyFilters();
        }

        /// <summary>
        /// Date Picker Value Changed: Re-filters events if date filtering is currently active.
        /// </summary>
        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            if (chkUseDateFilter.Checked)
            {
                ApplyFilters();
            }
        }

        /// <summary>
        /// Clear Filters Button Click: Resets keyword, category, and date filters to defaults.
        /// </summary>
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            chkUseDateFilter.Checked = false;
            ApplyFilters();
        }

        /// <summary>
        /// Updates the visibility and labels of admin controls based on login status.
        /// </summary>
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

        /// <summary>
        /// Admin Action Button Click:
        /// - If not logged in: Opens AdminLoginForm modal to authenticate.
        /// - If already logged in: Directly opens AddEventForm modal dialog.
        /// </summary>
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

        /// <summary>
        /// Opens the AddEventForm modal and re-applies filters if a new event was added.
        /// </summary>
        private void OpenAddEventDialog()
        {
            AddEventForm addForm = new AddEventForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                ApplyFilters();
                mainMenu.UpdateCounts();
            }
        }

        /// <summary>
        /// Admin Logout Link Click: Signs out administrator and returns to resident mode.
        /// </summary>
        private void lnkAdminLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.IsAdminLoggedIn = false;
            UpdateAdminControls();
            MessageBox.Show("Administrator signed out. You are now viewing in resident mode.", "Logged Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Back Button Click: Closes the events view and reveals the MainMenuForm.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
            mainMenu.UpdateCounts();
        }

        /// <summary>
        /// Form Closing Event: Ensures MainMenuForm is shown if user clicks window 'X' button.
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

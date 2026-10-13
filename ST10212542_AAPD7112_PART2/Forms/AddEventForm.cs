using ST10212542_AAPD7112_PART_2;
using System;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    /// <summary>
    /// AddEventForm allows authorized municipal staff to compose and publish
    /// new official announcements and community events.
    /// Newly added events are inserted in real time into both the
    /// SortedDictionary (chronological store) and Dictionary (category index).
    /// </summary>
    public partial class AddEventForm : Form
    {
        /// <summary>
        /// Flag indicating if an event was successfully created during this session.
        /// </summary>
        public bool EventAdded { get; private set; }

        /// <summary>
        /// Constructor: Initializes form components.
        /// </summary>
        public AddEventForm()
        {
            InitializeComponent();
            EventAdded = false;
        }

        /// <summary>
        /// Form Load Event: Populates the category selector and sets a sensible default date (tomorrow).
        /// </summary>
        private void AddEventForm_Load(object sender, EventArgs e)
        {
            // Populate category options matching system taxonomy
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Water Notices");
            cmbCategory.Items.Add("Power Maintenance");
            cmbCategory.Items.Add("Community Meetings");
            cmbCategory.Items.Add("Health & Safety");
            cmbCategory.Items.Add("Sports & Youth");

            cmbCategory.SelectedIndex = 0;

            // Default event scheduled date to tomorrow
            dtpEventDate.Value = DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// Save Button Click:
        /// 1. Validates title, location, and description fields.
        /// 2. Creates a new Event model instance.
        /// 3. Injects the event into the central in-memory data structures.
        /// 4. Closes the dialog with DialogResult.OK.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Title
            if (string.IsNullOrWhiteSpace(txtEventTitle.Text))
            {
                MessageBox.Show("Please enter an event or announcement title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEventTitle.Focus();
                return;
            }

            // 2. Validate Location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please specify the location or affected suburb.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            // 3. Validate Description (at least 5 characters for meaningful notice)
            if (string.IsNullOrWhiteSpace(rtbDescription.Text) || rtbDescription.Text.Trim().Length < 5)
            {
                MessageBox.Show("Please provide a detailed description (at least 5 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // Generate a random unique integer ID for this event
            int nextId = new Random().Next(100, 9999);

            // Construct new Event object
            Event newEvent = new Event(
                nextId,
                txtEventTitle.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                dtpEventDate.Value.Date,
                txtLocation.Text.Trim(),
                rtbDescription.Text.Trim()
            );

            // Synchronously insert the new event into both SortedDictionary and Dictionary
            Program.AddEventToDataStructures(newEvent);

            EventAdded = true;

            // Display confirmation summary
            MessageBox.Show("Announcement successfully verified and posted to municipal channels:\n\n" +
                            "Title: " + newEvent.Title + "\n" +
                            "Category: " + newEvent.Category + "\n" +
                            "Date: " + newEvent.EventDate.ToString("yyyy-MM-dd") + "\n" +
                            "Location: " + newEvent.Location,
                            "Official Notice Published",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // Return DialogResult.OK to signal success to calling parent form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Cancel Button Click: Discards inputs and closes dialog without saving.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

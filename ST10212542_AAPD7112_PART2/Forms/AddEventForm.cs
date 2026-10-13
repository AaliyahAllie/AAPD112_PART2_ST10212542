using System;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    public partial class AddEventForm : Form
    {
        public bool EventAdded { get; private set; }

        public AddEventForm()
        {
            InitializeComponent();
            EventAdded = false;
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Water Notices");
            cmbCategory.Items.Add("Power Maintenance");
            cmbCategory.Items.Add("Community Meetings");
            cmbCategory.Items.Add("Health & Safety");
            cmbCategory.Items.Add("Sports & Youth");

            cmbCategory.SelectedIndex = 0;
            dtpEventDate.Value = DateTime.Today.AddDays(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Input Validation
            if (string.IsNullOrWhiteSpace(txtEventTitle.Text))
            {
                MessageBox.Show("Please enter an event or announcement title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEventTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please specify the location or affected suburb.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text) || rtbDescription.Text.Trim().Length < 5)
            {
                MessageBox.Show("Please provide a detailed description (at least 5 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // Generate next Event ID
            int nextId = new Random().Next(100, 9999);

            Event newEvent = new Event(
                nextId,
                txtEventTitle.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                dtpEventDate.Value.Date,
                txtLocation.Text.Trim(),
                rtbDescription.Text.Trim()
            );

            // Add to SortedDictionary & Category Dictionary data structures
            Program.AddEventToDataStructures(newEvent);

            EventAdded = true;

            MessageBox.Show("Announcement successfully verified and posted to municipal channels:\n\n" +
                            "Title: " + newEvent.Title + "\n" +
                            "Category: " + newEvent.Category + "\n" +
                            "Date: " + newEvent.EventDate.ToString("yyyy-MM-dd") + "\n" +
                            "Location: " + newEvent.Location,
                            "Official Notice Published", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

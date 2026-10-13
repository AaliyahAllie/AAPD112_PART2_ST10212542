using ST10212542_AAPD7112_PART_2;
using System;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    /// <summary>
    /// EventDetailsForm displays the full information of a selected municipal event or announcement.
    /// Triggered when a resident double-clicks an event row, clicks "View Event Details",
    /// or double-clicks an item in the Recommended Events list.
    /// Displays complete title, category, long-form date, location, and full text notice.
    /// </summary>
    public partial class EventDetailsForm : Form
    {
        /// <summary>
        /// Constructor accepting the target Event to display.
        /// </summary>
        /// <param name="ev">The selected Event model object</param>
        public EventDetailsForm(Event ev)
        {
            InitializeComponent();
            PopulateDetails(ev);
        }

        /// <summary>
        /// Fills the modal dialog controls with the selected event information.
        /// Formats dates in a citizen-friendly long date string (e.g., Tuesday, 20 October 2026).
        /// </summary>
        /// <param name="ev">Event object containing announcement details</param>
        private void PopulateDetails(Event ev)
        {
            if (ev == null)
            {
                return;
            }

            // Display bold announcement title
            lblTitleValue.Text = ev.Title;

            // Display category name
            lblCategoryValue.Text = ev.Category;

            // Format date nicely as full day of week, day, month, and year
            lblDateValue.Text = ev.EventDate.ToString("dddd, dd MMMM yyyy");

            // Display venue or affected municipal zone
            lblLocationValue.Text = ev.Location;

            // Display the full multi-line description text inside the read-only box
            rtbDescription.Text = ev.Description;
        }

        /// <summary>
        /// Close Button Click: Closes the details dialog and returns focus to the events list.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

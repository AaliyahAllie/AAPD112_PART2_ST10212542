using System;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    public partial class EventDetailsForm : Form
    {
        public EventDetailsForm(Event ev)
        {
            InitializeComponent();
            PopulateDetails(ev);
        }

        // Fills the modal dialog controls with the selected event information
        private void PopulateDetails(Event ev)
        {
            if (ev == null)
            {
                return;
            }

            lblTitleValue.Text = ev.Title;
            lblCategoryValue.Text = ev.Category;
            lblDateValue.Text = ev.EventDate.ToString("dddd, dd MMMM yyyy");
            lblLocationValue.Text = ev.Location;
            rtbDescription.Text = ev.Description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

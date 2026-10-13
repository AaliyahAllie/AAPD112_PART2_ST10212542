using System;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    public partial class AdminLoginForm : Form
    {
        public bool LoginSuccessful { get; private set; }

        public AdminLoginForm()
        {
            InitializeComponent();
            LoginSuccessful = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Simple verification for municipal administrators
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin123")
            {
                Program.IsAdminLoggedIn = true;
                LoginSuccessful = true;
                MessageBox.Show("Administrator authenticated successfully.\nYou may now post verified municipal events and announcements.",
                    "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid administrator username or password.\nResidents cannot post announcements directly.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

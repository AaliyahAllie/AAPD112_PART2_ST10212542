using ST10212542_AAPD7112_PART_2;
using System;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2.Forms
{
    /// <summary>
    /// AdminLoginForm provides an authentication gate for municipal officials.
    /// Purpose: Allows municipal staff to post verified public announcements while
    /// preventing ordinary residents from publishing fake or unverified notices.
    /// Non-mandatory on startup: Residents can browse notices freely without ever logging in.
    /// </summary>
    public partial class AdminLoginForm : Form
    {
        /// <summary>
        /// Property indicating whether the administrator was successfully authenticated.
        /// </summary>
        public bool LoginSuccessful { get; private set; }

        /// <summary>
        /// Constructor: Initializes authentication dialog components.
        /// </summary>
        public AdminLoginForm()
        {
            InitializeComponent();
            LoginSuccessful = false;
        }

        /// <summary>
        /// Login Button Click:
        /// Compares supplied username and password against authorized municipal staff credentials.
        /// Sets Program.IsAdminLoggedIn to true upon success.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Verification check for authorized municipal officials
            // Demo credentials: username: "admin", password: "admin123"
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin123")
            {
                // Set global session state to indicate verified admin access
                Program.IsAdminLoggedIn = true;
                LoginSuccessful = true;

                MessageBox.Show(
                    "Administrator authenticated successfully.\nYou may now post verified municipal events and announcements.",
                    "Access Granted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Return OK result to caller and close modal dialog
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Display informative access denial message
                MessageBox.Show(
                    "Invalid administrator username or password.\nResidents cannot post announcements directly.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Clear password input and refocus
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        /// <summary>
        /// Cancel Button Click: Closes the login dialog without modifying administrative state.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

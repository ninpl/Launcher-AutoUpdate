using System;
using System.Windows.Forms;

namespace SharpUpdate
{
    /// <summary>
    /// Form to show details about the update
    /// </summary>
    public partial class SharpUpdateInfoForm : Form
    {
        /// <summary>
        /// Creates a new SharpUpdateInfoForm
        /// </summary>
        internal SharpUpdateInfoForm(ISharpUpdate applicationInfo,SharpUpdateXml updateInfo)
        {
            InitializeComponent();

            // Sets the icon if its not null
            if (applicationInfo.ApplicationIcon != null)
            {
                this.Icon = applicationInfo.ApplicationIcon;
            }

            //Fill in the UI
            this.Text = applicationInfo.ApplicationName + " . Update Info";
            this.lblVersions.Text = string.Format("Current Version: {0}\nUpdate Version: {1}",applicationInfo.ApplicationAssembly.GetName().Version.ToString(),
                updateInfo.Version.ToString());
            this.txtDescription.Text = updateInfo.Description;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            // Only allow Cntrl - C to copy test
            if (!(e.Control && e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}

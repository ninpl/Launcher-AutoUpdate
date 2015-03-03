using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpUpdate;

namespace LauncherAplicacion
{
    public partial class LauncherApp : Form ,ISharpUpdate
    {
        private string nameApp = "Launcher APP";
        private string idApp = "Launcher APP";
        private string uriApp = "";

        public LauncherApp()
        {
            InitializeComponent();

            this.lbl_Version.Text = this.ApplicationAssembly.GetName().Version.ToString();
        }

        private void BtnCheckUpdate_Click(object sender, EventArgs e)
        {

        }

        public string ApplicationName
        {
            get { return nameApp; }
        }

        public string ApplicationID
        {
            get { return idApp; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri(uriApp); }
        }

        public Form context
        {
            get { return this; }
        }
    }
}

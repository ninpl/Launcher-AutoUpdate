using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SharpUpdate
{
    /// <summary>
    /// Provides application update support in C#
    /// </summary>
    public class SharpUpdater
    {
        /// <summary>
        /// Holds the program-to-updates info
        /// </summary>
        private ISharpUpdate applicationInfo;

        /// <summary>
        /// Thread to find update
        /// </summary>
        private BackgroundWorker bgWorker;

        /// <summary>
        /// Creates a new SharpUpdate object
        /// </summary>
        public SharpUpdater(ISharpUpdate applicationInfo)
        {
            this.applicationInfo = applicationInfo;

            // Color backgroundWorker
            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        }

        /// <summary>
        /// Checks for an update for the program passed.
        /// If there is a update, a dialog asking to download will appear
        /// </summary>
        public void DoUpdate()
        {
            if (!this.bgWorker.IsBusy)
            {
                this.bgWorker.RunWorkerAsync(this.applicationInfo);
            }
        }

        /// <summary>
        /// Checks for/parse update.xml on server
        /// </summary>
        private void bgWorker_DoWork(Object sender, DoWorkEventArgs e)
        {
            ISharpUpdate application = (ISharpUpdate)e.Argument;

            if (!SharpUpdateXml.ExistsOnServer(application.UpdateXmlLocation))
            {
                e.Cancel = true;
            }
            else
            {
                e.Result = SharpUpdateXml.Parse(application.UpdateXmlLocation, application.ApplicationID);
            }
        }

        private void bgWorker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                SharpUpdateXml update = (SharpUpdateXml)e.Result;

                if (update != null && update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version))
                {
                    if (new SharpUpdateAcceptForm(this.applicationInfo, update).ShowDialog(this.applicationInfo.context) == DialogResult.Yes)
                    {
                        this.DownloadUpdate(update);
                    }
                }
            }
        }

        private void DownloadUpdate(SharpUpdateXml update)
        {
            SharpUpdateDownloadForm form = new SharpUpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.context);

            if (result == DialogResult.OK)
            {
                string currentPath = this.applicationInfo.ApplicationAssembly.Location;
                string newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;

                UpdateApplication(form.TempFilePatch, currentPath, newPath, update.LaunchArgs);

                Application.Exit();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("The update download was cancelled.\nThis program has not been modified.", "Update Download Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There was a problem downloading the update.\nPlease try again later.", "Update Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateApplication(string tempFilePath, string currentPath, string newPath, string launchArgs)
        {
            string argument = "/C Choise /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & /C Choise /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\" & Start \"\" /D \"{3}\" \"{4}\" {5}";

            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = string.Format(argument, currentPath, tempFilePath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.FileName = "cmd.exe";
            Process.Start(info);
        }
    }
}

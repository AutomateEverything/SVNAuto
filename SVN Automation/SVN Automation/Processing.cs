using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SVN_Automation
{
    public partial class Processing : Form
    {

        clsVerification objVerify;
        public Processing(clsVerification mVerify)
        {
            InitializeComponent();
            this.objVerify = mVerify;                              
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
            objVerify.VerificationLog = txtVerificationLog.Text;
            var reports = new frmReportEntry(objVerify);
            reports.Show();
            this.Hide();            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();             
            Close();
        }

        private void Processing_Load(object sender, EventArgs e)
        {
            string strLogSummary="";

            rtbStatus.SelectionColor = Color.DarkSeaGreen;
            rtbStatus.SelectedText = " Pre-Request > User Inputs > ";
            rtbStatus.SelectionColor = Color.Black;
            rtbStatus.SelectedText = "Find Diff";
            rtbStatus.SelectionColor = Color.DarkSeaGreen;
            rtbStatus.SelectedText = " > Generate Report";
            rtbStatus.Refresh();

                #region Create User
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nTrying to create User: " + objVerify.UserName;
                strLogSummary = "\nTrying to create User: " + objVerify.UserName;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdCreateUser();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.CreateUser;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Create Repo
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nCreating temporary repository: " + objVerify.RepoName;
                strLogSummary += "\nCreating temporary repository: " + objVerify.RepoName;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdCreateRepo();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.CreateRepo;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Give Access
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nProviding access to: " + objVerify.RepoName + "\n";
                strLogSummary += "\nProviding access to: " + objVerify.RepoName + "\n";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdGiveAccess();

                #endregion

                #region GetURL
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nGetting SVN Repository URL of: " + objVerify.RepoName;
                strLogSummary += "\nGetting SVN Repository URL of: " + objVerify.RepoName;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdGetUrl();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.GetURLCmd;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.GetURL;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Checkout Live
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nChecking-out files from Live SVN Server for the date: " + objVerify.BackupDate;
                strLogSummary += "\nChecking-out files from Live SVN Server for the date: " + objVerify.BackupDate;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdChkLive();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ChkLiveCmd;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ChkLive;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Checkout BackUp
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nChecking-out files from Backup SVN Server for the same date...";
                strLogSummary += "\nChecking-out files from Backup SVN Server for the same date...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdChkBack();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ChkBackCmd;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ChkBack;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Import Live
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nImporting Live repository files into Temp Local SVN Server...";
                strLogSummary += "\nImporting Live repository files into Temp Local SVN Server...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdImpLive();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ImpLiveCmd;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ImpLive;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Import Backup
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nImporting Backup repository files into Temp Local SVN Server...";
                strLogSummary += "\nImporting Backup repository files into Temp Local SVN Server...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdImpBack();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ImpBackCmd;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ImpBack;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Find Diff
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nFinding the Differences between both the repositories...";
                strLogSummary += "\nFinding the Differences between both the repositories...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdFindDiff();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.FindDiffCmd;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Red;
                txtVerificationLog.SelectedText = objVerify.FindDiff;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Delete Local Folder
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nDeleting the Temporary local files/ folders...";
                strLogSummary += "\nDeleting the Temporary local files/ folders...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();        

                objVerify.mtdDltLocal();

                #endregion

                #region Delete Temp Repo
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nDeleting the Temporary repository...";
                strLogSummary += "\nDeleting the Temporary repository...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdDltServer();

                #endregion

                txtVerificationLog.SelectedText = "\n---------------- Done ----------------";
                strLogSummary += "\n---------------- Done ----------------";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                //Assign the important steps in log to LogSummary property
                objVerify.LogSummary = strLogSummary;

        }

        private void Processing_Load_1(object sender, EventArgs e)
        {           
            Form.ActiveForm.Cursor = Cursors.WaitCursor;
            Form.ActiveForm.Refresh();
            txtVerificationLog.ScrollToCaret();
        }

        private void Processing_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            
        }

    }
}

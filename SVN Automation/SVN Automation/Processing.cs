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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var reports = new ReportEntry(objVerify);
            reports.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Processing_Load(object sender, EventArgs e)
        {
            //objVerify.execSVNcmd();
            //txtVerificationLog.SelectedRtf = objVerify.Result.SelectedRtf;
            //txtVerificationLog.SelectionColor = objVerify.Result.SelectionColor;    

            //txtVerificationLog.SelectedText = objVerify.Result.Text;

            objVerify.Result.SelectedText = txtVerificationLog.SelectedText;

                #region Create User
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nTrying to create User: " + objVerify.UserName;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdCreateUser();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.CreateUser;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Create Repo
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nCreating temporary repository: " + objVerify.RepoName;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdCreateRepo();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.CreateRepo;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Give Access
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nProviding access to: " + objVerify.RepoName + "\n";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdGiveAccess();

                #endregion

                #region GetURL
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nGetting SVN Repository URL of: " + objVerify.RepoName;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdGetUrl();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.GetURLCmd;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.GetURL;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Checkout Live
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nChecking-out files from Live SVN Server for the date: " + objVerify.BackupDate;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdChkLive();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ChkLiveCmd;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ChkLive;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Checkout BackUp
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nChecking-out files from Backup SVN Server for the same date...";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdChkBack();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ChkBackCmd;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ChkBack;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Import Live
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nImporting Live repository files to Temp Local SVN Server...";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdImpLive();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ImpLiveCmd;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ImpLive;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                #endregion

                #region Import Backup
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nImporting Backup repository files to Temp Local SVN Server...";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdImpBack();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.ImpBackCmd;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Green;
                txtVerificationLog.SelectedText = objVerify.ImpBack;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Find Diff
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nFinding the Differences between two repositories...";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdFindDiff();

                txtVerificationLog.SelectionColor = Color.Gray;
                txtVerificationLog.SelectedText = objVerify.FindDiffCmd;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                txtVerificationLog.SelectionColor = Color.Red;
                txtVerificationLog.SelectedText = objVerify.FindDiff;
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();
                #endregion

                #region Delete Local Folder
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nDeleting Temp Local files/folders...";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();        

                objVerify.mtdDltLocal();

                #endregion

                #region Delete Temp Repo
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "\nDeleting Temporary repository...";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdDltServer();

                #endregion

                txtVerificationLog.SelectedText = "\n---------------- Done ----------------";
                txtVerificationLog.Refresh();
                Processing.ActiveForm.Update();
                txtVerificationLog.ScrollToCaret();
            

        }

        private void Processing_Load_1(object sender, EventArgs e)
        {           
            Form.ActiveForm.Cursor = Cursors.WaitCursor;
            Form.ActiveForm.Refresh();
            txtVerificationLog.ScrollToCaret();
        }
    }
}

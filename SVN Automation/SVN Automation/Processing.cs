using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace SVN_Automation
{
    public partial class Processing : Form
    {
        string strLogSummary = "";
        clsVerification objVerify;
        public Processing(clsVerification mVerify)
        {
            InitializeComponent();
            this.objVerify = mVerify;                              
        }

        private void Processing_Load(object sender, EventArgs e)
        {
            //string strLogSummary = "";
            try
            {

                rtbStatus.SelectionColor = Color.DarkSeaGreen;
                rtbStatus.SelectedText = " Pre-Requisite > User Inputs > ";
                rtbStatus.SelectionColor = Color.Black;
                rtbStatus.SelectedText = "Find Diff";
                rtbStatus.SelectionColor = Color.DarkSeaGreen;
                rtbStatus.SelectedText = " > Generate Report";
                rtbStatus.Refresh();

                #region Create User
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Trying to create User: " + objVerify.UserName;
                strLogSummary = "\n" + DateTime.Now.ToString() + "  >> Trying to create User: " + objVerify.UserName;
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
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Creating temporary repository: " + objVerify.RepoName;
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Creating temporary repository: " + objVerify.RepoName;
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
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Providing access to: " + objVerify.RepoName;
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Providing access to: " + objVerify.RepoName;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdGiveAccess();

                #endregion

                #region GetURL
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Getting SVN Repository URL of: " + objVerify.RepoName;
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Getting SVN Repository URL of: " + objVerify.RepoName;
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
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Checking-out files from Live SVN Server for the date: " + objVerify.BackupDate;
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Checking-out files from Live SVN Server for the date: " + objVerify.BackupDate;
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                Parallel.Invoke(() => objVerify.mtdChkLive(), () => objVerify.mtdChkBack());
                //objVerify.mtdChkLive();

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

                if (String.IsNullOrEmpty(objVerify.ChkLive.Trim()) || objVerify.ChkLive.Contains("revision 0"))
                {
                    MessageBox.Show("The Live Repository is empty", "Check the Live Repository");
                    objVerify.mtdDltLocal();
                    objVerify.mtdDltServer();   
                    this.Hide();
                    var useint = new UserInput();
                    useint.Show();                   
                }

                #endregion

                #region Checkout BackUp
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Checking-out files from Backup SVN Server for the same date...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Checking-out files from Backup SVN Server for the same date...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                //objVerify.mtdChkBack();

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

                if (String.IsNullOrEmpty(objVerify.ChkBack.Trim()) || objVerify.ChkBack.Contains("revision 0"))
                {
                    MessageBox.Show("The Backup Repository is empty", "Check the Backup Repository");
                    objVerify.mtdDltLocal();
                    objVerify.mtdDltServer();                    
                    this.Hide();
                    var useint = new UserInput();
                    useint.Show();                    
                }

                #endregion

                #region Import Live
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Importing Live repository files into Temp Local SVN Server...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Importing Live repository files into Temp Local SVN Server...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                Parallel.Invoke(() => objVerify.mtdImpLive(), () => objVerify.mtdImpBack());
                //objVerify.mtdImpLive();

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
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Importing Backup repository files into Temp Local SVN Server...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Importing Backup repository files into Temp Local SVN Server...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                //objVerify.mtdImpBack();

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
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Finding the Differences between both the repositories...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Finding the Differences between both the repositories...";
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

                //Assign the important steps in log to LogSummary property
                objVerify.LogSummary += strLogSummary;

            }
            catch (Exception loadf)
            { }

        }

        private void Processing_Load_1(object sender, EventArgs e)
        {
            Form.ActiveForm.Cursor = Cursors.WaitCursor;
            Form.ActiveForm.Refresh();
            txtVerificationLog.ScrollToCaret();
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                #region Delete Local Folder
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Deleting the Temporary local files/ folders...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Deleting the Temporary local files/ folders...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdDltLocal();

                #endregion

                #region Delete Temp Repo
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Deleting the Temporary repository...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Deleting the Temporary repository...";
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
            catch (Exception re)
            { }
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

        private void Processing_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                #region Delete Local Folder
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Deleting the Temporary local files/ folders...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Deleting the Temporary local files/ folders...";
                txtVerificationLog.Refresh();
                Application.OpenForms["Processing"].Update();
                txtVerificationLog.ScrollToCaret();

                objVerify.mtdDltLocal();

                #endregion

                #region Delete Temp Repo
                txtVerificationLog.SelectionBackColor = Color.Gainsboro;
                txtVerificationLog.SelectionColor = Color.Black;
                txtVerificationLog.SelectedText = "\n" + DateTime.Now.ToString();
                txtVerificationLog.SelectionBackColor = txtVerificationLog.BackColor;
                txtVerificationLog.SelectionColor = Color.Blue;
                txtVerificationLog.SelectedText = "  >> Deleting the Temporary repository...";
                strLogSummary += "\n" + DateTime.Now.ToString() + "  >> Deleting the Temporary repository...";
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
                objVerify.LogSummary += strLogSummary;

                Application.Exit();
            }
            catch (Exception cl)
            { }
            
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {            

            Thread.Sleep(1000);

            Application.Exit();
            Close();
        }

    }
}

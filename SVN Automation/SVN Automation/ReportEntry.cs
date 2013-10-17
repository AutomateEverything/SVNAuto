using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;

namespace SVN_Automation
{
    public partial class frmReportEntry : Form
    {
        clsVerification objProjData;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportEntry"></param>
        public frmReportEntry(clsVerification reportEntry)
        {
            InitializeComponent();
            this.objProjData = reportEntry;
        }

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            #region Valitaion Input Feilds
            string RequiredFields = string.Empty;
            if (String.IsNullOrEmpty(txtAcName.Text.Trim())) RequiredFields += "* Account Name \r\n";
            if (String.IsNullOrEmpty(txtProjName.Text.Trim())) RequiredFields += "* Project Name \r\n";
            if (String.IsNullOrEmpty(txtGITS.Text.Trim())) RequiredFields += "* GITS Case ID \r\n";
            if (String.IsNullOrEmpty(dtRestored.Text.Trim())) RequiredFields += "* Date of Restored \r\n";
            if (String.IsNullOrEmpty(txtBackupLoc.Text.Trim())) RequiredFields += "* Backup Location \r\n";
            if (String.IsNullOrEmpty(txtCLName.Text.Trim())) RequiredFields += "* CL Name \r\n";    

            if (!String.IsNullOrEmpty(RequiredFields))
            {
                lblDescription.Text = "Please enter the following mandatory fields: \r\n";
                lblDescription.Text += RequiredFields;
                return;
            }

            #endregion

            Microsoft.Win32.RegistryKey EasySVNdiff = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("ReportUserDetails");
            EasySVNdiff.SetValue("AccountName", txtAcName.Text);
            EasySVNdiff.SetValue("ProjectName", txtProjName.Text);
            EasySVNdiff.SetValue("CLName", txtCLName.Text);            
            EasySVNdiff.Close();

            clsVerification objReport = new clsVerification();

            objReport.TextFile = "EasySVNdiff_DetailedLog" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "") + ".txt";

            StringBuilder sbReport = new StringBuilder();
            sbReport.Append("<!DOCTYPE html><html lang='en'><head><meta charset='utf-8' /><title>SVN Repository Backup Restoration Verification</title>");
            sbReport.Append("<style type='text/css' media='screen,print'> body {font-family:Segoe UI, arial,verdana; width:900px; margin:0 auto;} .table-header{background:#047CC1;} .column-name{background:#99CCFF;}</style></head>");
            sbReport.Append("<body><tr><td align='left' width='200px'><img src='https://www.csscorp.com/sites/all/themes/csscorp/images/css_corp_logo.jpg'/></td><td align='right'><h2><p align='center' nowrap><font color='#545456'>SVN Repository Backup Restoration Verification</font></p></h2></td></tr></table>");
            sbReport.Append("<table border='0' class='table-header' cellpadding='1' cellspacing='1' width='100%' align='center'><tr height='15'><td colspan='2'><div style='color:#D4FFFF; font-weight:bold'> Project Info:</div></td></tr>");
            sbReport.Append("<tr><td class='column-name' width='50%'> Account Name</td><td bgcolor='white' width='50%'> " + txtAcName.Text + "</td></tr><tr><td bgcolor='#99CCFF'> Project Name</td><td bgcolor='white'> " + txtProjName.Text + "</td></tr>");
            sbReport.Append("<tr><td class='column-name'> Repository URL</td><td bgcolor='white'> " + objProjData.LiveURL + "</td></tr><tr><td bgcolor='#99CCFF'> GITS Case ID</td><td bgcolor='white'> " + txtGITS.Text + "</td></tr>");
            sbReport.Append("<tr><td class='column-name'> Back-Up Date</td><td bgcolor='white'> " + objProjData.BackupDate + "</td></tr><tr><td bgcolor='#99CCFF'> Date of Restoration</td><td bgcolor='white'> " + dtRestored.Value + "</td></tr>");
            sbReport.Append("<tr><td class='column-name'> Date of Verification</td><td bgcolor='white'> " + System.DateTime.Today + "</td></tr><tr><td bgcolor='#99CCFF'> Backup location (including server name) / Local machine path</td><td bgcolor='white'> " + txtBackupLoc.Text + "</td></tr>");
            sbReport.Append("<tr><td class='column-name'> Restored location (including server name) / Local machine path</td><td bgcolor='white'> " + objProjData.BackupURL + "</td></tr><tr><td bgcolor='#99CCFF'> Date of Restoration</td><td bgcolor='white'> " + dtRestored.Value + "</td></tr>");
            sbReport.Append("<tr><td class='column-name'> CL Name (or the person who performs the verification)</td><td bgcolor='white'> " + txtCLName.Text + "</td></tr>");
            sbReport.Append("<tr><td class='column-name'> Tool used to perform the verification</td><td bgcolor='white'> EasySVNdiff</td></tr>");
            sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='100%' align='center'><tr height='15'><td width='100%'><div style='color:#D4FFFF; font-weight:bold'> Verification Log: <a href='" + objReport.TextFile + "' style='color:#D4FFFF; float:right; font-size:10px;'>Detailed log </a> </div></td></tr>");
            sbReport.Append("<tr><td bgcolor='white'><div style='border:1 solid #002776;width:100%;font-family:courier new'> " + objProjData.LogSummary.Replace("\n","<br>") + "</div></td></tr>");
            sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='100%' align='center'><tr><td width='100%' height='15'><div style='color:#D4FFFF; font-weight:bold'> Verification Result:</div></td></tr>");
            sbReport.Append("<tr><td bgcolor='white'>");





            //sbReport.Append("<!DOCTYPE html><html lang='en'><head><meta charset='utf-8' /><title>SVN Repository Backup Restoration Verification</title></head>");
            //sbReport.Append("<body style='font-family:Segoe UI, arial,verdana; width:900px; margin:0 auto;'><table border='0' width='100%'><tr><td align='left'><img src='https://www.csscorp.com/sites/all/themes/csscorp/images/css_corp_logo.jpg'/></td><td align='left'><h2><p align='center' nowrap><font color='#545456'>SVN Repository Backup Restoration Verification</font></p></h2></td></tr></table>");
            //sbReport.Append("<table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='100%' align='center'><tr height='15'><td colspan='2'><div style='color:#D4FFFF; font-weight:bold'> Project Info:</div></td></tr>");
            //sbReport.Append("<tr><td bgcolor='#99CCFF' width='50%'> Account Name</td><td bgcolor='white' width='50%'> " + txtAcName.Text + "</td></tr><tr><td bgcolor='#99CCFF'> Project Name</td><td bgcolor='white'> " + txtProjName.Text + "</td></tr>");
            //sbReport.Append("<tr><td bgcolor='#99CCFF'> Repository URL</td><td bgcolor='white'> " + objProjData.LiveURL + "</td></tr><tr><td bgcolor='#99CCFF'> GITS Case ID</td><td bgcolor='white'> " + txtGITS.Text + "</td></tr>");
            //sbReport.Append("<tr><td bgcolor='#99CCFF'> Back-Up Date</td><td bgcolor='white'> " + objProjData.BackupDate + "</td></tr><tr><td bgcolor='#99CCFF'> Date of Restoration</td><td bgcolor='white'> " + dtRestored.Value + "</td></tr>");
            //sbReport.Append("<tr><td bgcolor='#99CCFF'> Date of Verification</td><td bgcolor='white'> " + System.DateTime.Today + "</td></tr><tr><td bgcolor='#99CCFF'> Backup location (including server name) / Local machine path</td><td bgcolor='white'> " + txtBackupLoc.Text + "</td></tr>");
            //sbReport.Append("<tr><td bgcolor='#99CCFF'> Restored location (including server name) / Local machine path</td><td bgcolor='white'> " + objProjData.BackupURL + "</td></tr><tr><td bgcolor='#99CCFF'> Date of Restoration</td><td bgcolor='white'> " + dtRestored.Value + "</td></tr>");
            //sbReport.Append("<tr><td bgcolor='#99CCFF'> CL Name (or the person who performs the verification)</td><td bgcolor='white'> " + txtCLName.Text + "</td></tr>");
            //sbReport.Append("<tr><td bgcolor='#99CCFF'> Tool used to perform the verification</td><td bgcolor='white'> EasySVNdiff</td></tr>");
            //sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='100%' align='center'><tr height='15'><td width='100%'><div style='color:#D4FFFF; font-weight:bold'> Verification Log: <a href='" + objReport.TextFile + "' style='color:#D4FFFF; float:right; font-size:10px;'>Detailed log </a> </div></td></tr>");
            //sbReport.Append("<tr><td bgcolor='white'><div style='border:1 solid #002776;width:100%;font-family:courier new'> " + objProjData.LogSummary.Replace("\n", "<br>") + "</div></td></tr>");
            //sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='100%' align='center'><tr><td width='100%' height='15'><div style='color:#D4FFFF; font-weight:bold'> Verification Result:</div></td></tr>");
            //sbReport.Append("<tr><td bgcolor='white'>");
            
            if (objProjData.DiffResult==true)
            {
                sbReport.Append("<div style='border:1 solid #002776;width:100%;color:green'><b> Both the following SVN repositories are SAME.</b></div><br>");
            }
            else
            {
                sbReport.Append("<div style='border:1 solid #002776;width:100%;color:red'><b>Both the following SVN repositories are DIFFERENT.</b></div><br>");
            }
            
            sbReport.Append("<table border='1' borderColorLight='#EAEAEE' borderColorDark='#EAEAEE'><tr><td bgcolor='#8cc8ea'>Live Repository URL </td><td><a href='" + objProjData.LiveURL + "'>" + objProjData.LiveURL + "</a></td></tr><tr><td bgcolor='#8cc8ea'>Backup Restored Repository URL </td><td><a href='" + objProjData.BackupURL + "'>" + objProjData.BackupURL + "</a><br>");
            sbReport.Append("</td></tr></table><br></td></tr></table><br><br><hr style='color:gray;height:1px' noshade/><div style='background-color:#666666;color:#c2b497;font-size:11px;text-align:center;line-height:25px;'>This is an auto-generated report by EasySVNdiff tool. &copy; CSS Corp.</div></body></html>");

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\EasySVNdiff_Report" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "") + ".html";
            using (StreamWriter outfile = new StreamWriter(mydocpath))
            {
                outfile.Write(sbReport.ToString());
            }
            
            System.Diagnostics.Process.Start("IExplore.exe", mydocpath);

            //Save the detailed log into a text file.
            if (chkSaveToFile.Checked == true)
            {
                mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\"+ objReport.TextFile;
                using (StreamWriter outfile = new StreamWriter(mydocpath))
                {
                    outfile.WriteLine("EasySVNdiff Detailed Log:");
                    outfile.WriteLine("-------------------------" + System.Environment.NewLine);
                    outfile.WriteLine(objProjData.VerificationLog.Replace("\n",System.Environment.NewLine));
                    outfile.WriteLine("");
                    outfile.WriteLine("Differences found between the Repositories (if any):");
                    outfile.WriteLine("----------------------------------------------------" + System.Environment.NewLine);
                    outfile.WriteLine(objProjData.FindDiff.Replace("\n", System.Environment.NewLine));
                }
                
                MessageBox.Show("The Restoration Verification report and the text file containing detailed log have been placed on your Desktop folder for your future references.", "EasySVNdiff- SVN Repository Verification Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("The Restoration Verification report has been placed on your Desktop folder for your future references.", "EasySVNdiff- SVN Repository Verification Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region FocusIN

        private void txtAcName_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter your Account Name";
            txtAcName.BackColor = Color.LightYellow;
        }
        
        private void txtProjName_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter your Project Name";
            txtProjName.BackColor = Color.LightYellow;
        }

        private void txtGITS_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the GITS Case ID that you might have created for getting your backup/ restored URL.";
            txtGITS.BackColor = Color.LightYellow;
        }

        private void dtRestored_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please select the date on which IT team has restored the backup.";
            dtRestored.BackColor = Color.LightYellow;
        }

        private void txtBackupLoc_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Server location details such as Server Name or IP address(es) etc.";
            txtBackupLoc.BackColor = Color.LightYellow;
        }

        private void txtCLName_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the name of CL or the one who does this process.";
            txtCLName.BackColor = Color.LightYellow;
        }

        private void chkSaveToFile_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please select this option if you want detailed log to be written to a text file for your later references. Because, the HTML report has only the summary of actions carried out during the verification process.";
            chkSaveToFile.BackColor = Color.LightYellow;
        }

        #endregion

        #region FocusOUT

        private void txtAcName_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtAcName.BackColor = Color.White;
        }

        private void txtProjName_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtProjName.BackColor = Color.White;
        }

        private void txtGITS_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtGITS.BackColor = Color.White;
        }

        private void dtRestored_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            dtRestored.BackColor = Color.White;
        }

        private void txtBackupLoc_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtBackupLoc.BackColor = Color.White;
        }

        private void txtCLName_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtCLName.BackColor = Color.White;
        }

        #endregion

        private void frmReportEntry_Load(object sender, EventArgs e)
        {
            rtbStatus.SelectionColor = Color.DarkSeaGreen;
            rtbStatus.SelectedText = " Pre-Requisite > User Inputs > Find Diff > ";
            rtbStatus.SelectionColor = Color.Black;
            rtbStatus.SelectedText = "Generate Report";            
            rtbStatus.Refresh();

            string accName = "HKEY_CURRENT_USER\\ReportUserDetails";
            txtAcName.Text = (string)Registry.GetValue(accName, "AccountName", "");

            string projName = "HKEY_CURRENT_USER\\ReportUserDetails";
            txtProjName.Text = (string)Registry.GetValue(projName, "ProjectName", "");

            string clName = "HKEY_CURRENT_USER\\ReportUserDetails";
            txtCLName.Text = (string)Registry.GetValue(clName, "CLName", "");

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnAbout, "About EasySVNdiff"); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }

        private void frmReportEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();            
            about.Show();
        }

    }
}

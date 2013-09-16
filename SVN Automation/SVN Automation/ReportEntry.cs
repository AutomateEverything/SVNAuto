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
    public partial class frmReportEntry : Form
    {
        clsVerification objProjData;
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
                lblDescription.Text = "Please enter the following fields \r\n";
                lblDescription.Text += RequiredFields;
                return;
            }

            #endregion


            StringBuilder sbReport = new StringBuilder();
            sbReport.Append("<!DOCTYPE html><html lang='en'><head><meta charset='utf-8' /><title>SVN Repository Restoration Verification</title></head>");
            sbReport.Append("<body style='font-family:Segoe UI, arial,verdana;'><h2><p align='center'>SVN Repository Restoration Verification</p></h2>");
            sbReport.Append("<table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='70%' align='center'><tr><td colspan='2'><p style='color:#D4FFFF; font-weight:bold'>Project Info:</p></td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF' width='50%'>Account Name</td><td bgcolor='white' width='50%'>" + txtAcName.Text + "</td></tr><tr><td bgcolor='#99CCFF'>Project Name</td><td bgcolor='white'>"+ txtProjName.Text +"</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Repository URL</td><td bgcolor='white'>" + objProjData.LiveURL +"</td></tr><tr><td bgcolor='#99CCFF'>GITS Case ID</td><td bgcolor='white'>" + txtGITS.Text +"</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Back-Up Date</td><td bgcolor='white'>"+ objProjData.BackupDate +"</td></tr><tr><td bgcolor='#99CCFF'>Date of Restoration</td><td bgcolor='white'>" + dtRestored.Value + "</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Date of Verification</td><td bgcolor='white'>" + System.DateTime.Today + "</td></tr><tr><td bgcolor='#99CCFF'>Backup location (including server name) / Local machine path</td><td bgcolor='white'>" +txtBackupLoc.Text + "</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Restored location (including server name) / Local machine path</td><td bgcolor='white'>" + objProjData.BackupURL + "</td></tr><tr><td bgcolor='#99CCFF'>Date of Restoration</td><td bgcolor='white'>" + dtRestored.Value + "</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>CL Name (or the person who performs the verification)</td><td bgcolor='white'>" + txtCLName.Text + "</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Tool used to perform the verification</td><td bgcolor='white'> CSS EasySVNDiff</td></tr>");
            sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='70%' align='center'><tr><td width='100%'><p style='color:#D4FFFF; font-weight:bold'>Verification Log:</p></td></tr>");
            sbReport.Append("<tr><td bgcolor='white'><div style='border:1 solid #002776;width:100%'>" + objProjData.VerificationLog.Replace("\n","<br>") + "</div></td></tr>");
            sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='70%' align='center'><tr><td width='100%'><p style='color:#D4FFFF; font-weight:bold'>Verification Result:</p></td></tr>");
            sbReport.Append("<tr><td bgcolor='white'><div style='border:1 solid #002776;width:100%'>" + objProjData.FindDiff +"</div></td></tr></table><br/><br/></body></html>");



        }

        #region FocusIN

        private void txtAcName_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Account Name";
            txtAcName.BackColor = Color.LightYellow;
        }
        
        private void txtProjName_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Project Name";
            txtProjName.BackColor = Color.LightYellow;
        }

        private void txtGITS_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the GITS Case ID";
            txtGITS.BackColor = Color.LightYellow;
        }

        private void dtRestored_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please select the Date of Restored";
            dtRestored.BackColor = Color.LightYellow;
        }

        private void txtBackupLoc_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Backup Location";
            txtBackupLoc.BackColor = Color.LightYellow;
        }

        private void txtCLName_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the CL Name";
            txtCLName.BackColor = Color.LightYellow;
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
            rtbStatus.SelectedText = " Pre-Request > User Inputs > Find Diff > ";
            rtbStatus.SelectionColor = Color.Black;
            rtbStatus.SelectedText = "Generate Report";            
            rtbStatus.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

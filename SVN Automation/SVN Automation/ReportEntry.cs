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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            StringBuilder sbReport = new StringBuilder();
            sbReport.Append("<!DOCTYPE html><html lang='en'><head><meta charset='utf-8' /><title>SVN Repository Restoration Verification</title></head>");
            sbReport.Append("<body style='font-family:Segoe UI, arial,verdana;'><h2><p align='center'>SVN Repository Restoration Verification</p></h2>");
            sbReport.Append("<table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='70%' align='center'><tr><td colspan='2'><p style='color:#D4FFFF; font-weight:bold'>Project Info:</p></td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF' width='50%'>Account Name</td><td bgcolor='white' width='50%'></td></tr><tr><td bgcolor='#99CCFF'>Project Name</td><td bgcolor='white'>"+ txtProjName.Text +"</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Repository URL</td><td bgcolor='white'>" + objProjData.repourl +"</td></tr><tr><td bgcolor='#99CCFF'>GITS Case ID</td><td bgcolor='white'>" + txtGITS.Text +"</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Back-Up Date</td><td bgcolor='white'>"+ objProjData.BackupDate +"</td></tr><tr><td bgcolor='#99CCFF'>Date of Restoration</td><td bgcolor='white'>" + dtRestored.Value + "</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Date of Verification</td><td bgcolor='white'>" + System.DateTime.Today + "</td></tr><tr><td bgcolor='#99CCFF'>Backup location (including server name) / Local machine path</td><td bgcolor='white'>" +txtBackupLoc.Text + "</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Restored location (including server name) / Local machine path</td><td bgcolor='white'>" + objProjData.BackupURL + "</td></tr><tr><td bgcolor='#99CCFF'>Date of Restoration</td><td bgcolor='white'>" + + "</td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>CL Name (or the person who performs the verification)</td><td bgcolor='white'></td></tr>");
            sbReport.Append("<tr><td bgcolor='#99CCFF'>Tool used to perform the verification</td><td bgcolor='white'>CSS AutoSVNDiff</td></tr>");
            sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='70%' align='center'><tr><td width='100%'><p style='color:#D4FFFF; font-weight:bold'>Verification Log:</p></td></tr>");
            sbReport.Append("<tr><td bgcolor='white'><div style='border:1 solid #002776;width:100%'>sdf asdfsafs</div></td></tr>");
            sbReport.Append("</table><br/><br/><table border='0' bgcolor='047CC1' cellpadding='1' cellspacing='1' width='70%' align='center'><tr><td width='100%'><p style='color:#D4FFFF; font-weight:bold'>Verification Result:</p></td></tr>");
            sbReport.Append("<tr><td bgcolor='white'><div style='border:1 solid #002776;width:100%'>sf asf sadf</div></td></tr></table><br/><br/></body></html>");
        }
    }
}

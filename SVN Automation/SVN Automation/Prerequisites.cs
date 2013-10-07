using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace SVN_Automation
{
    public partial class Prerequisites : Form
    {
        

        public Prerequisites()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //UserInput.ActiveForm.Show();
            //UserInput.ActiveForm.Activate();
            var userinput = new UserInput();
            userinput.Show();
            this.Hide();          
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            Close();            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void llblPower_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void Prerequisites_Load(object sender, EventArgs e)
        {
            try
            {
                //btnNext.Enabled = false;

                rtbStatus.SelectionColor = Color.Black;
                rtbStatus.SelectedText = " Pre-Requisite";
                rtbStatus.SelectionColor = Color.DarkSeaGreen;
                rtbStatus.SelectedText = " > User Inputs > Find Diff > Generate Report";
                rtbStatus.Refresh();

                LinkLabel.Link linkNet = new LinkLabel.Link();
                linkNet.LinkData = "http://www.microsoft.com/en-us/download/details.aspx?id=17718";
                llblFrame.Links.Add(linkNet);

                LinkLabel.Link linkSVN = new LinkLabel.Link();
                linkSVN.LinkData = "http://www.visualsvn.com/server/download/";
                llblVisual.Links.Add(linkSVN);

                LinkLabel.Link linkTortoise = new LinkLabel.Link();
                linkTortoise.LinkData = "http://tortoisesvn.net/downloads.html";
                llblTortoise.Links.Add(linkTortoise);

                LinkLabel.Link linkPower = new LinkLabel.Link();
                linkPower.LinkData = "http://support.microsoft.com/kb/968929";
                llblPower.Links.Add(linkPower);
            }
            catch (Exception lo)
            { }
        }



        private void Prerequisites_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void Prerequisites_Shown(object sender, EventArgs e)
        {
            try
            {

                string keyName1 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\VisualSVN\\VisualSVN Server";
                string visual = (string)Registry.GetValue(keyName1, "InstallDir", "");

                if (String.IsNullOrEmpty(visual.Trim()))
                {
                    btnNext.Enabled = false;
                }
                else
                {
                    chkboxVisual.Checked = true;
                    llblVisual.Enabled = false;                    
                }

                string keyName2 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\TortoiseSVN";
                string tortoise = (string)Registry.GetValue(keyName2, "ProcPath", "");

                if (String.IsNullOrEmpty(tortoise.Trim()))
                {
                    btnNext.Enabled = false;
                }
                else
                {
                    chkboxTortoise.Checked = true;
                    llblTortoise.Enabled = false;                    
                }

                string keyName3 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\PowerShell\\1\\PowerShellEngine";
                string power = (string)Registry.GetValue(keyName3, "PowerShellVersion", "");

                if (String.IsNullOrEmpty(power.Trim()) || (Convert.ToDouble(power) < 2))
                {
                    btnNext.Enabled = false;
                    
                }
                else
                {
                    chkboxPower.Checked = true;
                    llblPower.Enabled = false;                    
                }

                int frame = Environment.Version.Major;

                if (frame < 4)
                {
                    btnNext.Enabled = false;
                }
                else
                {
                    chkboxFrame.Checked = true;
                    llblFrame.Enabled = false;                    
                }
            }
            catch (Exception check)
            { }
        }




    }
}

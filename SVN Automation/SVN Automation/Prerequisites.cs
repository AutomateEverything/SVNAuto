using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

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



        private void Prerequisites_Load(object sender, EventArgs e)
        {

            rtbStatus.SelectionColor = Color.Black;
            rtbStatus.SelectedText = " Pre-Request";
            rtbStatus.SelectionColor = Color.DarkSeaGreen;
            rtbStatus.SelectedText = " > User Inputs > Find Diff > Generate Report";
            rtbStatus.Refresh();


            LinkLabel.Link linkNet = new LinkLabel.Link();
            linkNet.LinkData = "http://www.microsoft.com/en-us/download/details.aspx?id=17718";
            linkLabel1.Links.Add(linkNet);

            LinkLabel.Link linkSVN = new LinkLabel.Link();
            linkSVN.LinkData = "http://www.visualsvn.com/server/download/";
            linkLabel2.Links.Add(linkSVN);

            LinkLabel.Link linkTortoise = new LinkLabel.Link();
            linkTortoise.LinkData = "http://tortoisesvn.net/downloads.html";
            linkLabel3.Links.Add(linkTortoise);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void Prerequisites_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            
        }


    }
}

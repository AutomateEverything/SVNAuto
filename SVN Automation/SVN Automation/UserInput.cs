using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Design;


namespace SVN_Automation
{
    public partial class UserInput : Form
    {
        public UserInput()
        {
            InitializeComponent();
            lblDescription.Text = "";                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    

                clsVerification objUserData = new clsVerification();

                objUserData.UserName = txtUserName.Text;
                objUserData.Password = txtPassword.Text;
                objUserData.LiveURL = txtLiveURL.Text;
                objUserData.BackupURL = txtBackUpURL.Text;
                objUserData.BackupDate = dtpBackUpDate.Text;
                objUserData.LocalDrive = txtLocalDrive.Text;                

                #region Valitaion Input Feilds
                string RequiredFields = string.Empty;
                if (String.IsNullOrEmpty(txtUserName.Text.Trim())) RequiredFields += "* User Name \r\n";
                if (String.IsNullOrEmpty(txtPassword.Text.Trim())) RequiredFields += "* Password \r\n";
                if (String.IsNullOrEmpty(txtLiveURL.Text.Trim())) RequiredFields += "* Live SVN URL \r\n";
                if (String.IsNullOrEmpty(txtBackUpURL.Text.Trim())) RequiredFields += "* Backup SVN URL \r\n";
                if (String.IsNullOrEmpty(dtpBackUpDate.Text.Trim())) RequiredFields += "* Backup date \r\n";
                if (String.IsNullOrEmpty(txtLocalDrive.Text.Trim())) RequiredFields += "* Temporary Folder \r\n";

                if (!String.IsNullOrEmpty(RequiredFields))
                {
                    lblDescription.Text = "Please enter the following fields \r\n";
                    lblDescription.Text += RequiredFields;
                    return;
                }
                #endregion

                if (objUserData.CheckLogin())
                {
                    var processing = new Processing(objUserData);
                    processing.Show();
                    this.Hide();
                }

                else
                {
                    lblDescription.Text = "Please Check the user name, password and URL enter for comparition";
                }
              
            }
            catch (Exception ex)
            {
            }
        }
      


        #region FocusIN

        private void txtUserName_GotFocus(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the User Name for SVN Server";
            txtUserName.BackColor = Color.AliceBlue;
        }      

        private void txtPassword_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Password for SVN Server";
            txtPassword.BackColor = Color.AliceBlue;
            
        }

        private void txtLiveURL_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Live server URL";
            txtLiveURL.BackColor = Color.AliceBlue;
        }

        private void txtBackUpURL_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Restored server URL";
            txtBackUpURL.BackColor = Color.AliceBlue;
        }

        private void dtpBackUpDate_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please Select the Backup Date of Restoration";
            dtpBackUpDate.BackColor = Color.AliceBlue;
        }

        private void txtLocalDrive_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please Select the Temporary Folder for Comparison from the Drive which has the free space twice the SVN Server";
            txtLocalDrive.BackColor = Color.AliceBlue;
        }

        #endregion

        #region FocusOUT

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtUserName.BackColor = Color.White;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtPassword.BackColor = Color.White;
        }

        private void txtLiveURL_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtLiveURL.BackColor = Color.White;
        }

        private void txtBackUpURL_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtBackUpURL.BackColor = Color.White;
        }

        private void dtpBackUpDate_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            dtpBackUpDate.BackColor = Color.White;
        }

        private void txtLocalDrive_Leave(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            txtLocalDrive.BackColor = Color.White;
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }  

        private void button3_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtLiveURL.Text = "";
            txtBackUpURL.Text = "";
            txtLocalDrive.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog();
            txtLocalDrive.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var prerequest = new Prerequisites();
            prerequest.Show();
            this.Hide();
        }


    }
}

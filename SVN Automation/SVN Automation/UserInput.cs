﻿using System;
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
using Microsoft.Win32;

namespace SVN_Automation
{
    public partial class UserInput : Form
    {
        /// <summary>
        /// User input form is used to get the details from the user to process the verification
        /// </summary>
        public UserInput()
        {
            InitializeComponent();
            lblDescription.Text = "";                  
        }
        /// <summary>
        /// Next button is used to navigate to next form, before that it will validate the inputs given by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            lblDescription.Text = "Please wait...";
            lblDescription.Refresh();
            UserInput.ActiveForm.Update();
            try
            {                    

                clsVerification objUserData = new clsVerification();

                objUserData.UserName = txtUserName.Text.Trim();
                objUserData.Password = txtPassword.Text.Trim();
                objUserData.LiveURL = txtLiveURL.Text.Trim();
                objUserData.BackupURL = txtBackUpURL.Text.Trim();
                objUserData.BackupDate = dtpBackUpDate.Text.Trim();
                objUserData.LocalDrive = txtLocalDrive.Text.Trim();                

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
                    lblDescription.Refresh();
                    UserInput.ActiveForm.Update();
                    return;
                }                

                #endregion

                if (objUserData.CheckLoginLive() && objUserData.CheckLoginBack() && objUserData.CheckPath())
                {
                    Microsoft.Win32.RegistryKey EasySVNdiff = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("RepoUserDetails");
                    EasySVNdiff.SetValue("Name", txtUserName.Text);
                    EasySVNdiff.SetValue("LiveURL", txtLiveURL.Text);                    
                    EasySVNdiff.SetValue("LocalDrive", txtLocalDrive.Text);
                    EasySVNdiff.Close();

                    //RegistryKey rk = Registry.CurrentUser;

                    var processing = new Processing(objUserData);
                    processing.Show();
                    this.Hide();
                }

                else
                {
                    lblDescription.Text = "Please Check the input fields";
                    lblDescription.Refresh();
                    UserInput.ActiveForm.Update();
                }
              
            }
            catch (Exception ex)
            {
            }
        }
      


        #region FocusIN

        private void txtUserName_GotFocus(object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the User Name of your live SVN Server";
            txtUserName.BackColor = Color.LightYellow;
        }      

        private void txtPassword_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the Password of your live SVN Server";
            txtPassword.BackColor = Color.LightYellow;
            
        }

        private void txtLiveURL_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the SVN Server URL of your live repository. " + System.Environment.NewLine + "Example: https://HDC0005254.ad.csscorp.com/svn/LiveRepo/";
            txtLiveURL.BackColor = Color.LightYellow;
        }

        private void txtBackUpURL_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please enter the SVN server URL of the backup-restored repository." + System.Environment.NewLine + "Example: https://HDC0005254.ad.csscorp.com/svn/RestoredRepo/";
            txtBackUpURL.BackColor = Color.LightYellow;
        }

        private void dtpBackUpDate_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please select the Date of Backup data.";
            dtpBackUpDate.BackColor = Color.LightYellow;
        }

        private void txtLocalDrive_GotFocus(Object sender, EventArgs e)
        {
            lblDescription.Text = "Please select any folder path for temporary usage such as getting files from both live and restored repositories for comparison activity. Also, please make sure that the drive has sufficient space." ;
            txtLocalDrive.BackColor = Color.LightYellow;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtLiveURL.Text = "";
            txtBackUpURL.Text = "";
            txtLocalDrive.Text = "";

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog();
            txtLocalDrive.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            var prerequest = new Prerequisites();
            prerequest.Show();
            this.Dispose();            
        }

        private void UserInput_Load(object sender, EventArgs e)
        {
            rtbStatus.SelectionColor = Color.DarkSeaGreen;
            rtbStatus.SelectedText = " Pre-Requisite > ";
            rtbStatus.SelectionColor = Color.Black;
            rtbStatus.SelectedText = "User Inputs";
            rtbStatus.SelectionColor = Color.DarkSeaGreen;
            rtbStatus.SelectedText = " > Find Diff > Generate Report";
            rtbStatus.Refresh();

            string userName = "HKEY_CURRENT_USER\\RepoUserDetails";
            txtUserName.Text = (string)Registry.GetValue(userName, "Name", "");

            string liveURL = "HKEY_CURRENT_USER\\RepoUserDetails";
            txtLiveURL.Text = (string)Registry.GetValue(liveURL, "LiveURL", "");

            string localDrive = "HKEY_CURRENT_USER\\RepoUserDetails";
            txtLocalDrive.Text = (string)Registry.GetValue(localDrive, "LocalDrive", "");

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnAbout, "About EasySVNdiff"); 
        }

        private void UserInput_FormClosing(object sender, FormClosingEventArgs e)
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

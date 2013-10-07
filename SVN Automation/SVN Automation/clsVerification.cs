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
using Microsoft.Win32;

namespace SVN_Automation
{
    /// <summary>
    /// Class file for process
    /// </summary>
    public class clsVerification
    {
        /// <summary>
        /// Property for username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Property for Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Property for Live URL
        /// </summary>
        public string LiveURL { get; set; }
        /// <summary>
        /// Property for Backup URL
        /// </summary>
        public string BackupURL { get; set; }
        /// <summary>
        /// Property for Backup/Restored Date
        /// </summary>
        public string BackupDate { get; set; }
        /// <summary>
        /// Property for Local drive detials
        /// </summary>
        public string LocalDrive { get; set; }
        /// <summary>
        /// Property for repo URL that we are getting run time
        /// </summary>
        public string repourl { get; set; }

        public string VerificationLog { get; set; }

        public string LogSummary { get; set; }

        public string RepoName { get; set; }

        public string CreateUser { get; set; }

        public string CreateRepo { get; set; }

        public string GiveAccess { get; set; }

        public string GetURL { get; set; }

        public string GetURLCmd { get; set; }

        public string ChkLive { get; set; }

        public string ChkLiveCmd { get; set; }

        public string ChkBack { get; set; }

        public string ChkBackCmd { get; set; }

        public string ImpLive { get; set; }

        public string ImpLiveCmd { get; set; }

        public string ImpBack { get; set; }

        public string ImpBackCmd { get; set; }

        public string FindDiff { get; set; }

        public string FindDiffCmd { get; set; }

        public string DltLocal { get; set; }

        public string DltServer { get; set; }

        public string Error { get; set; }

        public string RepoPath { get; set; }

        public bool DiffResult { get; set; }

        public string TextFile { get; set; }       

        public void execSVNcmd()
        {
            setEvnVariable();
            CheckLoginLive();
            CheckLoginBack();
            mtdCreateUser();
            mtdCreateRepo();
            mtdGiveAccess();
            mtdGetUrl();
            mtdChkLive();
            mtdChkBack();
            mtdImpLive();
            mtdImpBack();
            mtdFindDiff();
            mtdDltLocal();
            mtdDltServer();

        }
        /// <summary>
        /// TO set the Environmental variable for SVN to executes its commands.
        /// Input: Finding the visualSVN path by using registry and adding "bin" to that path
        /// Output: Setting the environment for SVN
        /// </summary>
        public void setEvnVariable()
        {
            string keyName1 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\VisualSVN\\VisualSVN Server";
            string rootSVN = (string)Registry.GetValue(keyName1, "InstallDir", "") + "bin";

            Environment.SetEnvironmentVariable("path", rootSVN);
        }
        
        #region Check Login
        /// <summary>
        /// Check whether the user and Live server URL enter is valid or not
        /// Input: User given data Username, password and Live Server URL
        /// Output: Check the given compination of username, password and URL are correct or not
        /// </summary>
        /// <returns></returns>
        public bool CheckLoginLive()
        {
            //System.Threading.Thread.Sleep(1000);
            try
            {
                System.Diagnostics.Process chkLog = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startchkLog = new System.Diagnostics.ProcessStartInfo();
                startchkLog.CreateNoWindow = true;
                startchkLog.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startchkLog.FileName = "cmd.exe";
                startchkLog.Arguments = "/C svn list \"" + LiveURL.Trim() + "\" --username " + UserName.Trim() + " --password " + Password.Trim();
                chkLog.StartInfo = startchkLog;

                chkLog.StartInfo.RedirectStandardOutput = true;
                chkLog.StartInfo.RedirectStandardError = true;
                chkLog.StartInfo.UseShellExecute = false;
                chkLog.Start();      

                StringBuilder ch = new StringBuilder();
                while (!chkLog.HasExited)
                {
                    ch.Append(chkLog.StandardOutput.ReadToEnd());
                    ch.Append(chkLog.StandardError.ReadToEnd());
                }

                String login = ch.ToString().Trim();
                chkLog.WaitForExit();

                chkLog = null;
                startchkLog = null;

                if (login.Contains("E175013") || login.Contains("E155007") || login.Contains("E230001") || login.Contains("E175002") || login.Contains("E731004") || login.Contains("E120171") || login.Contains("E020024"))                
                {
                    MessageBox.Show("User credentials or Live Repository URL is invalid.", "Invalid Input!");
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception login)
            {
                return false;
            }
        }
        /// <summary>
        /// Check whether the user and Backup/Restored server URL enter is valid or not
        /// Input: User given data Username, password and Backup/Restored Server URL
        /// Output: Check the given compination of username, password and URL are correct or not
        /// </summary>
        /// <returns></returns>
        public bool CheckLoginBack()
        {
            //System.Threading.Thread.Sleep(1000);
            try
            {
                System.Diagnostics.Process chkLog = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startchkLog = new System.Diagnostics.ProcessStartInfo();
                startchkLog.CreateNoWindow = true;
                startchkLog.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startchkLog.FileName = "cmd.exe";
                startchkLog.Arguments = "/C svn list \"" + BackupURL.Trim() + "\" --username " + UserName.Trim() + " --password " + Password.Trim();
                chkLog.StartInfo = startchkLog;

                chkLog.StartInfo.RedirectStandardOutput = true;
                chkLog.StartInfo.RedirectStandardError = true;
                chkLog.StartInfo.UseShellExecute = false;
                chkLog.Start();

                StringBuilder ch = new StringBuilder();
                while (!chkLog.HasExited)
                {
                    ch.Append(chkLog.StandardOutput.ReadToEnd());
                    ch.Append(chkLog.StandardError.ReadToEnd());
                }

                String login = ch.ToString().Trim();
                chkLog.WaitForExit();

                chkLog = null;
                startchkLog = null;

                if (login.Contains("E175013") || login.Contains("E155007") || login.Contains("E230001") || login.Contains("E175002") || login.Contains("E731004") || login.Contains("E120171") || login.Contains("E020024"))                
                {
                    MessageBox.Show("User credentials or Backup Repository URL is invalid.", "Invalid Input!");
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception loginback)
            {
                return false;
            }
        }
        #endregion
        /// <summary>
        /// If user doesn't exist, it will create the user in local VisualSVN server.
        /// Input: User given data user name, password
        /// Output: Creating the user in Local Visual SVN server
        /// </summary>
        public void mtdCreateUser()
        {
            try
            {                  

                ManagementClass userClass = new ManagementClass("root\\VisualSVN", "VisualSVN_User", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams =
                    userClass.GetMethodParameters("Create");

                // Add the input parameters.
                inParams["Name"] = UserName;
                inParams["Password"] = Password;

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams =
                    userClass.InvokeMethod("Create", inParams, null);

                CreateUser = "\nUsername '" + UserName + "' created.";
            }
            catch (Exception userex)
            {
                CreateUser = "\nUsername '" + UserName + "' already exists.";
            }
        }

        /// <summary>
        /// Create a temporary Repository for Comparison
        /// Input: Name of the repository which is created at run time
        /// Output: Temporary repository is created
        /// </summary>
        public void mtdCreateRepo()
        {
            string keyName = "HKEY_LOCAL_MACHINE\\SOFTWARE\\VisualSVN\\VisualSVN Server";
            RepoPath = (string)Registry.GetValue(keyName, "RepositoriesRoot", "");

            //var drives = DriveInfo.GetDrives();
            //string dr = string.Empty;
                       
            //foreach (var drive in drives)
            //{

            //    if (drive.DriveType == DriveType.Fixed)
            //    {
            //        dr += drive.Name;                    
            //    }

            //}
            //if (dr.Contains("D:")) RepoPath = "D:\\Repositories";
            //else RepoPath = "C:\\Repositories";            


            //System.Diagnostics.Process CreateRep = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startCreateRepo = new System.Diagnostics.ProcessStartInfo();
            //startCreateRepo.CreateNoWindow = true;
            //startCreateRepo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startCreateRepo.FileName = "cmd.exe";
            //startCreateRepo.Arguments = "/c mkdir " + RepoPath;
            //CreateRep.StartInfo = startCreateRepo;
            //CreateRep.Start();

            ManagementClass repoClass = new ManagementClass("root\\VisualSVN", "VisualSVN_Repository", null);

            // Obtain in-parameters for the method
            ManagementBaseObject oInRepository = repoClass.GetMethodParameters("Create");

            // Add the input parameters.
            //oInRepository["Name"] = RepoPath + "\\Automation_Repo" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
            oInRepository["Name"] = "Automation_Repo" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");

            // Execute the method and obtain the return values.
            ManagementBaseObject oOutRepository = repoClass.InvokeMethod("Create", oInRepository, null);

            //RepoName = new DirectoryInfo("" + oInRepository["Name"]).Name;
            RepoName = "" + oInRepository["Name"];

            CreateRepo = "\nTemp Repository '" + RepoName + "' created.";
        }
        /// <summary>
        /// Providing access to created repository
        /// Input: Repository path where its created at run time
        /// Output: creating the access file to the repository
        /// </summary>
        public void mtdGiveAccess()
        {
            StreamWriter sw;
            sw = File.CreateText(RepoPath + RepoName + "\\conf\\VisualSVN-SvnAuthz.ini");
            sw.WriteLine("[/]");
            sw.WriteLine("*=rw");
            sw.Close();

            //GiveAccess = "Giving Access to Temp Repo " + RepoName + "\n";
        }
        /// <summary>
        /// Get the URL for the created repository
        /// Input: Temporary repository name
        /// Output: URL for that repository
        /// </summary>
        public void mtdGetUrl()
        {
            try
            {
                System.Diagnostics.Process getURL = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startGetURL = new System.Diagnostics.ProcessStartInfo();
                startGetURL.CreateNoWindow = true;
                startGetURL.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startGetURL.FileName = "cmd.exe";
                startGetURL.Arguments = "/c powershell -Command \"& { Get-WmiObject -namespace root\\VisualSVN -class VisualSVN_Repository | Select-Object -expandproperty URL | Select-String -SimpleMatch \"" + RepoName + "\"}\"";
                getURL.StartInfo = startGetURL;

                getURL.StartInfo.RedirectStandardOutput = true;
                getURL.StartInfo.UseShellExecute = false;
                getURL.Start();

                StringBuilder q = new StringBuilder();
                while (!getURL.HasExited)
                {
                    q.Append(getURL.StandardOutput.ReadToEnd());
                }
                repourl = q.ToString().Trim();

                GetURLCmd = "\n" + repourl;
                GetURL = "\nURL of the Temp Repo '" + RepoName + "' is: " + repourl;

                startGetURL = null;
                getURL = null;
            }
            catch (Exception geturl)
            {
                Error = geturl.Message.ToString();
            }
        }
        /// <summary>
        /// Check out the files from Live SVN repository for particular date, here we had used commandprompt command to do so
        /// Input: User details username, password, backup/restored date and live svn server url
        /// Output: Checking out the files from Live SVN repository
        /// </summary>
        public void mtdChkLive()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C svn co -r {\"" + BackupDate + " 23:59:59\"} " + LiveURL.Trim() + " \"" + LocalDrive.Trim() + "\\svn-compare\\checkout\" --username " + UserName.Trim() + " --password " + Password.Trim();
                process.StartInfo = startInfo;

                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                
                StringBuilder proc = new StringBuilder();
                while (!process.HasExited)
                {
                    proc.Append(process.StandardOutput.ReadToEnd());
                }

                ChkLiveCmd = "\n" + startInfo.Arguments.Replace(" --password " + Password, " --password *******");
                ChkLive = "\n" + proc.ToString().Trim();

                startInfo = null;
                process = null;
            }
            catch (Exception chklive)
            { 
                Error = chklive.Message.ToString();
            }
        }
        /// <summary>
        /// Check out the files from Backup/Restored SVN repository for particular date, here we had used commandprompt command to do so
        /// Input: User details username, password, backup/restored date and Backup/Restored svn server url
        /// Output: Checking out the files from Backup/Restored SVN repository
        /// </summary>
        public void mtdChkBack()
        {
            try
            {
                System.Diagnostics.Process chkBackup = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startChkBackup = new System.Diagnostics.ProcessStartInfo();
                startChkBackup.CreateNoWindow = true;
                startChkBackup.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startChkBackup.FileName = "cmd.exe";
                startChkBackup.Arguments = "/C svn co " + BackupURL.Trim() + " \"" + LocalDrive.Trim() + "\\svn-compare\\Backup\" --username " + UserName.Trim() + " --password " + Password.Trim();
                chkBackup.StartInfo = startChkBackup;

                chkBackup.StartInfo.RedirectStandardOutput = true;
                chkBackup.StartInfo.UseShellExecute = false;
                chkBackup.Start();

                StringBuilder chkb = new StringBuilder();
                while (!chkBackup.HasExited)
                {
                    chkb.Append(chkBackup.StandardOutput.ReadToEnd());
                }
                ChkBackCmd = "\n" + startChkBackup.Arguments.Replace(" --password " + Password, " --password *******");
                ChkBack = "\n" + chkb.ToString().Trim();

                startChkBackup = null;
                chkBackup = null;
            }
            catch (Exception chkback)
            {
                Error = chkback.Message.ToString();
            }
        }
        /// <summary>
        /// Importing the check outed live repository file to local VisualSVN server for comparison 
        /// Input: Check out files from live svn repository
        /// Output: File are imported to local repository
        /// </summary>
        public void mtdImpLive()
        {
            try
            {
                System.Diagnostics.Process impLive = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startImpLive = new System.Diagnostics.ProcessStartInfo();
                startImpLive.CreateNoWindow = true;
                startImpLive.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startImpLive.FileName = "cmd.exe";
                startImpLive.Arguments = "/C svn import -m \"Import live files to server\" \"" + LocalDrive + "\\svn-compare\\checkout\" " + repourl + "Checkout --username " + UserName.Trim() + " --password " + Password.Trim();;
                impLive.StartInfo = startImpLive;

                impLive.StartInfo.RedirectStandardOutput = true;
                impLive.StartInfo.UseShellExecute = false;
                impLive.Start();

                StringBuilder impl = new StringBuilder();
                while (!impLive.HasExited)
                {
                    impl.Append(impLive.StandardOutput.ReadToEnd());
                }
                ImpLiveCmd = "\n" + startImpLive.Arguments.Replace(" --password " + Password, " --password *******");
                ImpLive = "\n" + impl.ToString().Trim();
                impLive = null;
                startImpLive = null;
            }
            catch (Exception implive)
            {
                Error = implive.Message.ToString();
            }
        }
        /// <summary>
        /// Importing the check outed backup/restored repository file to local VisualSVN server for comparison 
        /// Input: Check out files from backup/restored svn repository
        /// Output: File are imported to local repository
        /// </summary>
        public void mtdImpBack()
        {
            try
            {
                System.Diagnostics.Process impBackup = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startImpBackup = new System.Diagnostics.ProcessStartInfo();
                startImpBackup.CreateNoWindow = true;
                startImpBackup.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startImpBackup.FileName = "cmd.exe";
                startImpBackup.Arguments = "/C svn import -m \"Import backup files to server\" \"" + LocalDrive + "\\svn-compare\\Backup\" " + repourl + "Backup --username " + UserName.Trim() + " --password " + Password.Trim();;
                impBackup.StartInfo = startImpBackup;
                //impBackup.Start();

                impBackup.StartInfo.RedirectStandardOutput = true;
                impBackup.StartInfo.UseShellExecute = false;
                impBackup.Start();

                StringBuilder impb = new StringBuilder();
                while (!impBackup.HasExited)
                {
                    impb.Append(impBackup.StandardOutput.ReadToEnd());
                }
                ImpBackCmd = "\n" + startImpBackup.Arguments.Replace(" --password " + Password, " --password *******");
                ImpBack = "\n" + impb.ToString().Trim();
                startImpBackup = null;
                impBackup = null;
            }
            catch (Exception impback)
            {
                Error = impback.Message.ToString();
            }
        }
        /// <summary>
        /// Finding the diffrence between two folders in the local repository
        /// Input: Imported files in two folder "Live" and "Backup/Restored"
        /// Output: Getting the difference between this two folders
        /// </summary>
        public void mtdFindDiff()
        {
            try
            {
                System.Diagnostics.Process svnDiff = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startSvnDiff = new System.Diagnostics.ProcessStartInfo();
                startSvnDiff.CreateNoWindow = true;
                startSvnDiff.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startSvnDiff.FileName = "cmd.exe";
                startSvnDiff.Arguments = "/C svn diff " + repourl + "Checkout " + repourl + "Backup";
                svnDiff.StartInfo = startSvnDiff;

                svnDiff.StartInfo.RedirectStandardOutput = true;
                svnDiff.StartInfo.UseShellExecute = false;
                svnDiff.Start();

                StringBuilder d = new StringBuilder();
                while (!svnDiff.HasExited)
                {
                    d.Append(svnDiff.StandardOutput.ReadToEnd());
                }
                FindDiffCmd = "\n" + startSvnDiff.Arguments;
                if (String.IsNullOrEmpty(d.ToString().Trim()))
                {
                    FindDiff = "\nBoth the Repositories are Same";
                    DiffResult = true;
                }
                else
                {
                    FindDiff = "\n" + d.ToString().Trim() + "\n\nBoth the Repositories are Different\n";
                    DiffResult = false;
                }
                startSvnDiff = null;
                svnDiff = null;
            }
            catch (Exception diff)
            {
                FindDiff = diff.Message.ToString();
            }
        }
        /// <summary>
        /// 
        /// Input:
        /// Output:
        /// </summary>
        public void mtdDltLocal()
        {
            try
            {
                System.Diagnostics.Process DltLiveCo = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startDltLiveCo = new System.Diagnostics.ProcessStartInfo();
                startDltLiveCo.CreateNoWindow = true;
                startDltLiveCo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startDltLiveCo.FileName = "cmd.exe";
                startDltLiveCo.Arguments = "/C rmdir \"" + LocalDrive + "\\svn-compare\" /s /q";
                DltLiveCo.StartInfo = startDltLiveCo;
                DltLiveCo.Start();
                startDltLiveCo = null;
                DltLiveCo = null;
            }
            catch (Exception dltlocal)
            {
                
            }
        }
        /// <summary>
        /// 
        /// Input:
        /// Output:
        /// </summary>
        public void mtdDltServer()
        {
            try
            {
                ManagementClass repoClassDelete = new ManagementClass("root\\VisualSVN", "VisualSVN_Repository", null);

                // Obtain in-parameters for the method
                ManagementBaseObject oInRepositoryDelete =
                    repoClassDelete.GetMethodParameters("Delete");

                // Add the input parameters.
                oInRepositoryDelete["Name"] = RepoName;

                // Execute the method and obtain the return values.
                ManagementBaseObject oOutRepositoryDelete =
                    repoClassDelete.InvokeMethod("Delete", oInRepositoryDelete, null);
            }
            catch (Exception dltre)
            { 
            }
        }


        
    }
}


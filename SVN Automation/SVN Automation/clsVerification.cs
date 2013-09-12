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

namespace SVN_Automation
{
    public class clsVerification
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string LiveURL { get; set; }

        public string BackupURL { get; set; }

        public string BackupDate { get; set; }

        public string LocalDrive { get; set; }

        public string repourl { get; set; }

        public RichTextBox Result { get; set; }

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
       

        public void execSVNcmd()
        {
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

        #region Check Login
        public bool CheckLoginLive()
        {
            System.Threading.Thread.Sleep(1000);
            try
            {
                System.Diagnostics.Process chkLog = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startchkLog = new System.Diagnostics.ProcessStartInfo();
                startchkLog.CreateNoWindow = true;
                startchkLog.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startchkLog.FileName = "cmd.exe";
                startchkLog.Arguments = "/C svn list \"" + LiveURL + "\" --username " + UserName + " --password " + Password;
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

                //if (login.Contains("E175013")||string.IsNullOrEmpty(login.Trim()))
                if (login.Contains("E175013"))
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

        public bool CheckLoginBack()
        {
            System.Threading.Thread.Sleep(1000);
            try
            {
                System.Diagnostics.Process chkLog = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startchkLog = new System.Diagnostics.ProcessStartInfo();
                startchkLog.CreateNoWindow = true;
                startchkLog.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startchkLog.FileName = "cmd.exe";
                startchkLog.Arguments = "/C svn list \"" + BackupURL + "\" --username " + UserName + " --password " + Password;
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

                //if (login.Contains("E175013")||string.IsNullOrEmpty(login.Trim()))
                if (login.Contains("E175013"))
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

        public void mtdCreateRepo()
        {
            ManagementClass repoClass = new ManagementClass("root\\VisualSVN", "VisualSVN_Repository", null);

            // Obtain in-parameters for the method
            ManagementBaseObject oInRepository = repoClass.GetMethodParameters("Create");

            // Add the input parameters.
            oInRepository["Name"] = "Automation_Repo" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");

            // Execute the method and obtain the return values.
            ManagementBaseObject oOutRepository = repoClass.InvokeMethod("Create", oInRepository, null);

            RepoName = "" + oInRepository["Name"];

            CreateRepo = "\nTemp Repository '" + RepoName + "' created.";
        }

        public void mtdGiveAccess()
        {
            StreamWriter sw;
            sw = File.CreateText("C:\\Repositories\\" + RepoName + "\\conf\\VisualSVN-SvnAuthz.ini");
            sw.WriteLine("[/]");
            sw.WriteLine("*=rw");
            sw.Close();

            //GiveAccess = "Giving Access to Temp Repo " + RepoName + "\n";
        }

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

        public void mtdChkLive()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C svn co -r {" + BackupDate + "} " + LiveURL + " \"" + LocalDrive + "\\svn-compare\\checkout\" --username " + UserName + " --password " + Password;
                process.StartInfo = startInfo;

                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                
                StringBuilder proc = new StringBuilder();
                while (!process.HasExited)
                {
                    proc.Append(process.StandardOutput.ReadToEnd());
                }

                ChkLiveCmd = "\n" + startInfo.Arguments;
                ChkLive = "\n" + proc.ToString().Trim();
                startInfo = null;
                process = null;
            }
            catch (Exception chklive)
            {
                Error = chklive.Message.ToString();
            }
        }

        public void mtdChkBack()
        {
            try
            {
                System.Diagnostics.Process chkBackup = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startChkBackup = new System.Diagnostics.ProcessStartInfo();
                startChkBackup.CreateNoWindow = true;
                startChkBackup.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startChkBackup.FileName = "cmd.exe";
                startChkBackup.Arguments = "/C svn co " + BackupURL + " \"" + LocalDrive + "\\svn-compare\\Backup\" --username " + UserName + " --password " + Password;
                chkBackup.StartInfo = startChkBackup;

                chkBackup.StartInfo.RedirectStandardOutput = true;
                chkBackup.StartInfo.UseShellExecute = false;
                chkBackup.Start();

                StringBuilder chkb = new StringBuilder();
                while (!chkBackup.HasExited)
                {
                    chkb.Append(chkBackup.StandardOutput.ReadToEnd());
                }
                ChkBackCmd = "\n" + startChkBackup.Arguments;
                ChkBack = "\n" + chkb.ToString().Trim();
                startChkBackup = null;
                chkBackup = null;
            }
            catch (Exception chkback)
            {
                Error = chkback.Message.ToString();
            }
        }

        public void mtdImpLive()
        {
            try
            {
                System.Diagnostics.Process impLive = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startImpLive = new System.Diagnostics.ProcessStartInfo();
                startImpLive.CreateNoWindow = true;
                startImpLive.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startImpLive.FileName = "cmd.exe";
                startImpLive.Arguments = "/C svn import -m \"Import live files to server\" \"" + LocalDrive + "\\svn-compare\\checkout\" " + repourl + "Checkout";
                impLive.StartInfo = startImpLive;

                impLive.StartInfo.RedirectStandardOutput = true;
                impLive.StartInfo.UseShellExecute = false;
                impLive.Start();

                StringBuilder impl = new StringBuilder();
                while (!impLive.HasExited)
                {
                    impl.Append(impLive.StandardOutput.ReadToEnd());
                }
                ImpLiveCmd = "\n" + startImpLive.Arguments;
                ImpLive = "\n" + impl.ToString().Trim();
                impLive = null;
                startImpLive = null;
            }
            catch (Exception implive)
            {
                Error = implive.Message.ToString();
            }
        }

        public void mtdImpBack()
        {
            try
            {
                System.Diagnostics.Process impBackup = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startImpBackup = new System.Diagnostics.ProcessStartInfo();
                startImpBackup.CreateNoWindow = true;
                startImpBackup.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startImpBackup.FileName = "cmd.exe";
                startImpBackup.Arguments = "/C svn import -m \"Import backup files to server\" \"" + LocalDrive + "\\svn-compare\\Backup\" " + repourl + "Backup";
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
                ImpBackCmd = "\n" + startImpBackup.Arguments;
                ImpBack = "\n" + impb.ToString().Trim();
                startImpBackup = null;
                impBackup = null;
            }
            catch (Exception impback)
            {
                Error = impback.Message.ToString();
            }
        }

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
                }
                else
                {
                    FindDiff = "\n" + d.ToString().Trim();
                }
                startSvnDiff = null;
                svnDiff = null;
            }
            catch (Exception diff)
            {
                FindDiff = diff.Message.ToString();
            }
        }

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

        public void mtdDltServer()
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

    }
}


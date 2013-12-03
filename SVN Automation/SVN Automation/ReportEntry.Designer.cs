namespace SVN_Automation
{
    partial class frmReportEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAcName = new System.Windows.Forms.TextBox();
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.txtGITS = new System.Windows.Forms.TextBox();
            this.dtRestored = new System.Windows.Forms.DateTimePicker();
            this.txtBackupLoc = new System.Windows.Forms.TextBox();
            this.txtCLName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.chkSaveToFile = new System.Windows.Forms.CheckBox();
            this.btnAbout = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(32, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(32, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "GITS Case ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(32, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date of Restoration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(32, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Backup Server";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(32, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "CL Name";
            // 
            // txtAcName
            // 
            this.txtAcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcName.Location = new System.Drawing.Point(137, 74);
            this.txtAcName.Name = "txtAcName";
            this.txtAcName.Size = new System.Drawing.Size(328, 20);
            this.txtAcName.TabIndex = 6;
            this.txtAcName.Enter += new System.EventHandler(this.txtAcName_Enter);
            this.txtAcName.Leave += new System.EventHandler(this.txtAcName_Leave);
            // 
            // txtProjName
            // 
            this.txtProjName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjName.Location = new System.Drawing.Point(137, 107);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(328, 20);
            this.txtProjName.TabIndex = 7;
            this.txtProjName.Enter += new System.EventHandler(this.txtProjName_Enter);
            this.txtProjName.Leave += new System.EventHandler(this.txtProjName_Leave);
            // 
            // txtGITS
            // 
            this.txtGITS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGITS.Location = new System.Drawing.Point(135, 142);
            this.txtGITS.Name = "txtGITS";
            this.txtGITS.Size = new System.Drawing.Size(328, 20);
            this.txtGITS.TabIndex = 8;
            this.txtGITS.Enter += new System.EventHandler(this.txtGITS_Enter);
            this.txtGITS.Leave += new System.EventHandler(this.txtGITS_Leave);
            // 
            // dtRestored
            // 
            this.dtRestored.CalendarTitleBackColor = System.Drawing.Color.YellowGreen;
            this.dtRestored.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRestored.Location = new System.Drawing.Point(137, 173);
            this.dtRestored.Name = "dtRestored";
            this.dtRestored.Size = new System.Drawing.Size(117, 20);
            this.dtRestored.TabIndex = 9;
            this.dtRestored.Enter += new System.EventHandler(this.dtRestored_Enter);
            this.dtRestored.Leave += new System.EventHandler(this.dtRestored_Leave);
            // 
            // txtBackupLoc
            // 
            this.txtBackupLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBackupLoc.Location = new System.Drawing.Point(137, 204);
            this.txtBackupLoc.Name = "txtBackupLoc";
            this.txtBackupLoc.Size = new System.Drawing.Size(328, 20);
            this.txtBackupLoc.TabIndex = 10;
            this.txtBackupLoc.Text = "PRIMARYBACKUP";
            this.txtBackupLoc.Enter += new System.EventHandler(this.txtBackupLoc_Enter);
            this.txtBackupLoc.Leave += new System.EventHandler(this.txtBackupLoc_Leave);
            // 
            // txtCLName
            // 
            this.txtCLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCLName.Location = new System.Drawing.Point(137, 237);
            this.txtCLName.Name = "txtCLName";
            this.txtCLName.Size = new System.Drawing.Size(328, 20);
            this.txtCLName.TabIndex = 11;
            this.txtCLName.Enter += new System.EventHandler(this.txtCLName_Enter);
            this.txtCLName.Leave += new System.EventHandler(this.txtCLName_Leave);
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.lblDescription.ForeColor = System.Drawing.Color.DimGray;
            this.lblDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescription.Location = new System.Drawing.Point(135, 269);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(4);
            this.lblDescription.Size = new System.Drawing.Size(338, 81);
            this.lblDescription.TabIndex = 12;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.White;
            this.btnGenerate.BackgroundImage = global::SVN_Automation.Properties.Resources.button;
            this.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Location = new System.Drawing.Point(237, 398);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(139, 23);
            this.btnGenerate.TabIndex = 17;
            this.btnGenerate.Text = "Generate HTML Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImage = global::SVN_Automation.Properties.Resources.button;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(403, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtbStatus
            // 
            this.rtbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.rtbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatus.Location = new System.Drawing.Point(34, 46);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(330, 20);
            this.rtbStatus.TabIndex = 20;
            this.rtbStatus.Text = "";
            // 
            // chkSaveToFile
            // 
            this.chkSaveToFile.AutoSize = true;
            this.chkSaveToFile.BackColor = System.Drawing.Color.White;
            this.chkSaveToFile.Checked = true;
            this.chkSaveToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveToFile.Location = new System.Drawing.Point(137, 361);
            this.chkSaveToFile.Name = "chkSaveToFile";
            this.chkSaveToFile.Size = new System.Drawing.Size(223, 17);
            this.chkSaveToFile.TabIndex = 21;
            this.chkSaveToFile.Text = "Save detailed log information to a Text file";
            this.chkSaveToFile.UseVisualStyleBackColor = false;
            this.chkSaveToFile.Enter += new System.EventHandler(this.chkSaveToFile_Enter);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BackgroundImage = global::SVN_Automation.Properties.Resources.about_1;
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.Location = new System.Drawing.Point(459, 4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(30, 30);
            this.btnAbout.TabIndex = 27;
            this.btnAbout.TabStop = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::SVN_Automation.Properties.Resources.icon_big;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(34, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 37);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::SVN_Automation.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(77, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 29);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // frmReportEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.BackgroundImage = global::SVN_Automation.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(492, 429);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.chkSaveToFile);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtCLName);
            this.Controls.Add(this.txtBackupLoc);
            this.Controls.Add(this.dtRestored);
            this.Controls.Add(this.txtGITS);
            this.Controls.Add(this.txtProjName);
            this.Controls.Add(this.txtAcName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReportEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasySVNdiff: Report Generation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmReportEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAcName;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.TextBox txtGITS;
        private System.Windows.Forms.DateTimePicker dtRestored;
        private System.Windows.Forms.TextBox txtBackupLoc;
        private System.Windows.Forms.TextBox txtCLName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.CheckBox chkSaveToFile;
        private System.Windows.Forms.PictureBox btnAbout;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
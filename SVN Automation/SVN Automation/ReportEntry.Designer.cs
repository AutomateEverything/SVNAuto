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
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "GITS Case ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date of Restoration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Backup Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "CL Name";
            // 
            // txtAcName
            // 
            this.txtAcName.Location = new System.Drawing.Point(135, 114);
            this.txtAcName.Name = "txtAcName";
            this.txtAcName.Size = new System.Drawing.Size(345, 20);
            this.txtAcName.TabIndex = 6;
            // 
            // txtProjName
            // 
            this.txtProjName.Location = new System.Drawing.Point(135, 149);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(345, 20);
            this.txtProjName.TabIndex = 7;
            // 
            // txtGITS
            // 
            this.txtGITS.Location = new System.Drawing.Point(135, 177);
            this.txtGITS.Name = "txtGITS";
            this.txtGITS.Size = new System.Drawing.Size(345, 20);
            this.txtGITS.TabIndex = 8;
            // 
            // dtRestored
            // 
            this.dtRestored.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRestored.Location = new System.Drawing.Point(135, 212);
            this.dtRestored.Name = "dtRestored";
            this.dtRestored.Size = new System.Drawing.Size(117, 20);
            this.dtRestored.TabIndex = 9;
            // 
            // txtBackupLoc
            // 
            this.txtBackupLoc.Location = new System.Drawing.Point(135, 247);
            this.txtBackupLoc.Name = "txtBackupLoc";
            this.txtBackupLoc.Size = new System.Drawing.Size(345, 20);
            this.txtBackupLoc.TabIndex = 10;
            // 
            // txtCLName
            // 
            this.txtCLName.Location = new System.Drawing.Point(135, 276);
            this.txtCLName.Name = "txtCLName";
            this.txtCLName.Size = new System.Drawing.Size(345, 20);
            this.txtCLName.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(12, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(468, 60);
            this.label7.TabIndex = 12;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(192, 11);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(114, 23);
            this.btnGenerate.TabIndex = 13;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(318, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(403, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Location = new System.Drawing.Point(2, 384);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 44);
            this.panel1.TabIndex = 16;
            // 
            // frmReportEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(492, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
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
            this.Name = "frmReportEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSS AutoSVNDiff Report Generation";
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panel1;
    }
}
namespace SVN_Automation
{
    partial class Prerequisites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prerequisites));
            this.llblFrame = new System.Windows.Forms.LinkLabel();
            this.llblVisual = new System.Windows.Forms.LinkLabel();
            this.llblTortoise = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llblPower = new System.Windows.Forms.LinkLabel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkboxVisual = new System.Windows.Forms.CheckBox();
            this.chkboxTortoise = new System.Windows.Forms.CheckBox();
            this.chkboxFrame = new System.Windows.Forms.CheckBox();
            this.chkboxPower = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // llblFrame
            // 
            this.llblFrame.AutoSize = true;
            this.llblFrame.BackColor = System.Drawing.Color.Transparent;
            this.llblFrame.LinkColor = System.Drawing.Color.Red;
            this.llblFrame.Location = new System.Drawing.Point(195, 220);
            this.llblFrame.Name = "llblFrame";
            this.llblFrame.Size = new System.Drawing.Size(105, 13);
            this.llblFrame.TabIndex = 0;
            this.llblFrame.TabStop = true;
            this.llblFrame.Text = ".NET Framework 4.0";
            this.llblFrame.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // llblVisual
            // 
            this.llblVisual.AutoSize = true;
            this.llblVisual.BackColor = System.Drawing.Color.Transparent;
            this.llblVisual.LinkColor = System.Drawing.Color.Red;
            this.llblVisual.Location = new System.Drawing.Point(195, 248);
            this.llblVisual.Name = "llblVisual";
            this.llblVisual.Size = new System.Drawing.Size(57, 13);
            this.llblVisual.TabIndex = 1;
            this.llblVisual.TabStop = true;
            this.llblVisual.Text = "VisualSVN";
            this.llblVisual.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // llblTortoise
            // 
            this.llblTortoise.AutoSize = true;
            this.llblTortoise.BackColor = System.Drawing.Color.Transparent;
            this.llblTortoise.LinkColor = System.Drawing.Color.Red;
            this.llblTortoise.Location = new System.Drawing.Point(195, 277);
            this.llblTortoise.Name = "llblTortoise";
            this.llblTortoise.Size = new System.Drawing.Size(67, 13);
            this.llblTortoise.TabIndex = 2;
            this.llblTortoise.TabStop = true;
            this.llblTortoise.Text = "TortoiseSVN";
            this.llblTortoise.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(147, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please click Next button once you have all the above in your system.";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(32, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(437, 55);
            this.label2.TabIndex = 6;
            this.label2.Text = "Welcome to SVN Automation on Restoration Verification. Please review below softwa" +
    "re requirements before proceeding.";
            // 
            // llblPower
            // 
            this.llblPower.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llblPower.AutoSize = true;
            this.llblPower.BackColor = System.Drawing.Color.Transparent;
            this.llblPower.LinkColor = System.Drawing.Color.Red;
            this.llblPower.Location = new System.Drawing.Point(195, 306);
            this.llblPower.Name = "llblPower";
            this.llblPower.Size = new System.Drawing.Size(125, 13);
            this.llblPower.TabIndex = 7;
            this.llblPower.TabStop = true;
            this.llblPower.Text = "Windows PowerShell 2.0";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.BackgroundImage = global::SVN_Automation.Properties.Resources.button;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(349, 434);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImage = global::SVN_Automation.Properties.Resources.button;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(244, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // rtbStatus
            // 
            this.rtbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.rtbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStatus.Location = new System.Drawing.Point(35, 118);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(330, 20);
            this.rtbStatus.TabIndex = 11;
            this.rtbStatus.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::SVN_Automation.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(106, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 55);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // chkboxVisual
            // 
            this.chkboxVisual.AutoSize = true;
            this.chkboxVisual.Enabled = false;
            this.chkboxVisual.Location = new System.Drawing.Point(174, 248);
            this.chkboxVisual.Name = "chkboxVisual";
            this.chkboxVisual.Size = new System.Drawing.Size(15, 14);
            this.chkboxVisual.TabIndex = 13;
            this.chkboxVisual.UseVisualStyleBackColor = true;
            // 
            // chkboxTortoise
            // 
            this.chkboxTortoise.AutoSize = true;
            this.chkboxTortoise.Enabled = false;
            this.chkboxTortoise.Location = new System.Drawing.Point(174, 277);
            this.chkboxTortoise.Name = "chkboxTortoise";
            this.chkboxTortoise.Size = new System.Drawing.Size(15, 14);
            this.chkboxTortoise.TabIndex = 14;
            this.chkboxTortoise.UseVisualStyleBackColor = true;
            // 
            // chkboxFrame
            // 
            this.chkboxFrame.AutoSize = true;
            this.chkboxFrame.Enabled = false;
            this.chkboxFrame.Location = new System.Drawing.Point(174, 220);
            this.chkboxFrame.Name = "chkboxFrame";
            this.chkboxFrame.Size = new System.Drawing.Size(15, 14);
            this.chkboxFrame.TabIndex = 15;
            this.chkboxFrame.UseVisualStyleBackColor = true;
            // 
            // chkboxPower
            // 
            this.chkboxPower.AutoSize = true;
            this.chkboxPower.Enabled = false;
            this.chkboxPower.Location = new System.Drawing.Point(174, 306);
            this.chkboxPower.Name = "chkboxPower";
            this.chkboxPower.Size = new System.Drawing.Size(15, 14);
            this.chkboxPower.TabIndex = 16;
            this.chkboxPower.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::SVN_Automation.Properties.Resources.icon_big;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(37, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 63);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // Prerequisites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.BackgroundImage = global::SVN_Automation.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(492, 466);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.chkboxPower);
            this.Controls.Add(this.chkboxFrame);
            this.Controls.Add(this.chkboxTortoise);
            this.Controls.Add(this.chkboxVisual);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.llblPower);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llblTortoise);
            this.Controls.Add(this.llblVisual);
            this.Controls.Add(this.llblFrame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Prerequisites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasySVNdiff: Prerequisites";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Prerequisites_FormClosing);
            this.Load += new System.EventHandler(this.Prerequisites_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llblFrame;
        private System.Windows.Forms.LinkLabel llblVisual;
        private System.Windows.Forms.LinkLabel llblTortoise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llblPower;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkboxVisual;
        private System.Windows.Forms.CheckBox chkboxTortoise;
        private System.Windows.Forms.CheckBox chkboxFrame;
        private System.Windows.Forms.CheckBox chkboxPower;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}
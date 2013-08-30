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
    public partial class ReportEntry : Form
    {
        clsVerification objReport;
        public ReportEntry(clsVerification reportEntry)
        {
            InitializeComponent();
            this.objReport = reportEntry;
        }
    }
}

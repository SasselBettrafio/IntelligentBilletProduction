using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentBilletProduction
{
    public partial class frmCuttingAlarm : Form
    {
        public frmCuttingAlarm(string strmsg)
        {
            InitializeComponent();
            lbMessage.Text = strmsg;
        }

        private void ucbtnYes_BtnClick(object sender, EventArgs e)
        {
            AccessibleDescription = "Yes";
            Close();
        }

        private void ucbtnNo_BtnClick(object sender, EventArgs e)
        {
            AccessibleDescription = "No";
            Close();
        }
    }
}

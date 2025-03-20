using kepOpcRW;
using System;
using System.Data;
using System.Windows.Forms;

namespace IntelligentBilletProduction
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            DataTable dtalarms = SqlBase.ExecuteSql4Dt("select top 100 * from SysAlarms");
            if(dtalarms.Rows.Count > 0)
            {
                dgvAlarms.Rows.Clear();
                for (int i = 0; i < dtalarms.Rows.Count; i++)
                {
                    dgvAlarms.Rows.Add();
                    dgvAlarms.Rows[i].Cells[0].Value = dtalarms.Rows[i][0].ToString().Trim();
                    dgvAlarms.Rows[i].Cells[1].Value = dtalarms.Rows[i][1].ToString().Trim();
                    dgvAlarms.Rows[i].Cells[2].Value = dtalarms.Rows[i][2].ToString().Trim();
                }
            }
        }
    }
}

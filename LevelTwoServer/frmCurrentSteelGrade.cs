using kepOpcRW;
using System;
using System.Data;
using System.Windows.Forms;

namespace IntelligentBilletProduction
{
    public partial class frmCurrentSteelGrade : Form
    {
        string[] strvalues = null;
        public frmCurrentSteelGrade(string[] strvalues)
        {
            InitializeComponent();
            this.strvalues = strvalues;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCurrentSteelGrade_Load(object sender, EventArgs e)
        {
            DataTable dtpp = SqlBase.ExecuteSql4Dt("select top 50 * from ProductionPlan order by recordtime desc");
            if (dtpp.Rows.Count > 0)
            {
                gcOrderTable.Rows.Clear();
                for (int i = 0; i < dtpp.Rows.Count; i++)
                {
                    gcOrderTable.Rows.Add();
                    gcOrderTable.Rows[i].Cells[0].Value = dtpp.Rows[i][0].ToString();
                    gcOrderTable.Rows[i].Cells[1].Value = dtpp.Rows[i][1].ToString();
                    gcOrderTable.Rows[i].Cells[2].Value = dtpp.Rows[i][2].ToString();
                    gcOrderTable.Rows[i].Cells[3].Value = dtpp.Rows[i][3].ToString();
                    gcOrderTable.Rows[i].Cells[4].Value = dtpp.Rows[i][4].ToString();
                    gcOrderTable.Rows[i].Cells[5].Value = dtpp.Rows[i][5].ToString();
                    gcOrderTable.Rows[i].Cells[6].Value = dtpp.Rows[i][6].ToString();
                    gcOrderTable.Rows[i].Cells[7].Value = dtpp.Rows[i][7].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmAddWorkPlan frmAddWorkPlan = new frmAddWorkPlan(this.strvalues);
            frmAddWorkPlan.ShowDialog();
            if(frmAddWorkPlan.Tag != null)
            {
                DataTable dtpp = SqlBase.ExecuteSql4Dt("select top 50 * from ProductionPlan order by recordtime desc");
                if(dtpp.Rows.Count > 0 )
                {
                    gcOrderTable.Rows.Clear();
                    for(int i = 0; i < dtpp.Rows.Count; i++)
                    {
                        gcOrderTable.Rows.Add();
                        gcOrderTable.Rows[i].Cells[0].Value = dtpp.Rows[i][1].ToString();
                        gcOrderTable.Rows[i].Cells[1].Value = dtpp.Rows[i][2].ToString();
                        gcOrderTable.Rows[i].Cells[2].Value = dtpp.Rows[i][3].ToString();
                        gcOrderTable.Rows[i].Cells[3].Value = dtpp.Rows[i][4].ToString();
                        gcOrderTable.Rows[i].Cells[4].Value = dtpp.Rows[i][5].ToString();
                        gcOrderTable.Rows[i].Cells[5].Value = dtpp.Rows[i][6].ToString();
                        gcOrderTable.Rows[i].Cells[6].Value = dtpp.Rows[i][7].ToString();
                        gcOrderTable.Rows[i].Cells[7].Value = dtpp.Rows[i][8].ToString();
                        gcOrderTable.Rows[i].Tag = dtpp.Rows[i][0].ToString();
                    }
                }
            }
        }

        private void 修改计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strid = gcOrderTable.SelectedRows[0].Tag.ToString();

        }

        private void 删除计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strhn = gcOrderTable.SelectedRows[0].Cells[0].Value.ToString();
            if(MessageBox.Show("是否删除炉号[" + strhn + "]的计划?","删除计划",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)== DialogResult.Yes)
            {
                string strid = gcOrderTable.SelectedRows[0].Tag.ToString();
                SqlBase.ExecuteSql("delete from ProductionPlan where id = '" + strid + "'");
                gcOrderTable.Rows.Clear();
                frmCurrentSteelGrade_Load(null, null);
            }
        }

        private void btnfg0_Click(object sender, EventArgs e)
        {

        }
    }
}

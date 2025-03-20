using kepOpcRW;
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
    public partial class frmAddWorkPlan : Form
    {
        public frmAddWorkPlan(string[] strvalues)
        {
            InitializeComponent();
            if(strvalues.Length > 0)
            {
                txtSteeltype.Text = strvalues[0];
                txtaimedlength.Text = strvalues[1];
                txtdestination.Text = strvalues[2];
                txtthick.Text = strvalues[3];
                txtwidth.Text = strvalues[4];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtheatno.Text.Trim() == "")
            {
                MessageBox.Show("炉次编号为空，请检查！");
                return;
            }
            if(txtSteeltype.Text.Trim() == "")
            {
                MessageBox.Show("钢种为空，请检查！");
                return;
            }
            if(txtaimedlength.Text.Trim() == "")
            {
                MessageBox.Show("定尺长度为空，请检查！");
                return;
            }
            if (txtdestination.Text.Trim() == "")
            {
                MessageBox.Show("直径为空，请检查！");
                return;
            }
            if (txtthick.Text.Trim() == "")
            {
                MessageBox.Show("厚度为空，请检查！");
                return;
            }
            if (txtwidth.Text.Trim() == "")
            {
                MessageBox.Show("宽度为空，请检查！");
                return;
            }
            DataTable dtone = SqlBase.ExecuteSql4Dt("select * from ProductionPlan where heatno = '" + txtheatno.Text.Trim() + "'");
            if(dtone.Rows.Count > 0)
            {
                MessageBox.Show("炉号[" + txtheatno.Text.Trim() + "]已经存在，请检查！");
                return;
            }
            SqlBase.ExecuteSql("insert into ProductionPlan(heatno,Steeltype,aimedlength,destination,thick,width,state,recordtime) values('" + txtheatno.Text.Trim() + "','" + txtSteeltype.Text.Trim() + "','" + txtaimedlength.Text.Trim() + "','" + txtdestination.Text.Trim() + "','" + txtthick.Text.Trim() + "','" + txtwidth.Text.Trim() + "','301','" + DateTime.Now.ToString() + "')");
            MessageBox.Show("添加成功！");
            Tag = "成功";
        }

        private void frmAddWorkPlan_Load(object sender, EventArgs e)
        {
            List<string> strsteeltypelist = new List<string>();
            DataTable dtsteeltype = SqlBase.ExecuteSql4Dt("select distinct(steelType) from SteelCuttingTime");
            if (dtsteeltype != null && dtsteeltype.Rows.Count > 0)
            {
                for (int i = 0; i < dtsteeltype.Rows.Count; i++)
                {
                    strsteeltypelist.Add(dtsteeltype.Rows[i]["steelType"].ToString().Trim());
                }
                txtSteeltype.AutoCompleteCustomSource.Clear();
                txtSteeltype.AutoCompleteCustomSource.AddRange(strsteeltypelist.ToArray());
                txtSteeltype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSteeltype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            DataTable dtpp = SqlBase.ExecuteSql4Dt("select top 1 * from ProductionPlan order by recordtime desc");
            if (dtpp != null && dtpp.Rows.Count > 0)
            {
                txtheatno.Text = dtpp.Rows[0]["heatno"].ToString();
                txtSteeltype.Text = dtpp.Rows[0]["Steeltype"].ToString();
                txtaimedlength.Text = dtpp.Rows[0]["aimedlength"].ToString();
                txtdestination.Text = dtpp.Rows[0]["destination"].ToString();
                txtthick.Text = dtpp.Rows[0]["thick"].ToString();
                txtwidth.Text = dtpp.Rows[0]["width"].ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtaimedlength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        private void txtdestination_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        private void txtthick_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        private void txtwidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }
    }
}

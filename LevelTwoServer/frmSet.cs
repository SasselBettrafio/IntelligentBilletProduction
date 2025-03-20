using kepOpcRW;
using System;
using System.Data;
using System.Windows.Forms;

namespace IntelligentBilletProduction
{
    public partial class frmSet : Form
    {
        public frmSet()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (gcSteelTypeList.Rows.Count > 0)
            //{
            //    SqlBase.ExecuteSql("delete from SteelCuttingTime");
            //    for (int i = 0; i < gcSteelTypeList.Rows.Count; i++)
            //    {
            //        if (gcSteelTypeList.Rows[i].Cells[0] != null && gcSteelTypeList.Rows[i].Cells[0].Value != null && gcSteelTypeList.Rows[i].Cells[0].Value.ToString().Trim() != "")
            //        {
            //            SqlBase.ExecuteSql("insert into SteelCuttingTime(steelType,thick,width,diameter,cuttingTime) values('" + gcSteelTypeList.Rows[i].Cells[0].Value.ToString().Trim() + "','" + gcSteelTypeList.Rows[i].Cells[1].Value.ToString().Trim() + "','" + gcSteelTypeList.Rows[i].Cells[2].Value.ToString().Trim() + "','" + gcSteelTypeList.Rows[i].Cells[3].Value.ToString().Trim() + "','" + gcSteelTypeList.Rows[i].Cells[4].Value.ToString().Trim() + "')");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("钢种为空，请检查！");
            //    return;
            //}
            if (txtRollerTransportationTime.Text.Trim() == "")
            {
                MessageBox.Show("辊道运输时间为空，请检查！");
                return;
            }
            if (txtSteelTurningTime.Text.Trim() == "")
            {
                MessageBox.Show("翻钢时间为空，请检查！");
                return;
            }
            if(txtReasonableCoolingTime.Text.Trim() == "")
            {
                MessageBox.Show("1轧合理冷却时间为空，请检查！");
                return;
            }
            if (txt4ReasonableCoolingTime.Text.Trim() == "")
            {
                MessageBox.Show("4轧合理冷却时间为空，请检查！");
                return;
            }
            if(txtRollingRollingTime.Text.Trim() == "")
            {
                MessageBox.Show("1轧轧钢时间为空，请检查！");
                return;
            }
            if (txt4RollingRollingTime.Text.Trim() == "")
            {
                MessageBox.Show("4轧轧钢时间为空，请检查！");
                return;
            }
            if(txtSteelCuttingTime.Text.Trim() == "")
            {
                MessageBox.Show("轧钢时间为空，请检查！");
                return;
            }
            if(txtFourRollerTransportationTime.Text.Trim() == "")
            {
                MessageBox.Show("4轧辊道运输时间为空，请检查！");
                return;
            }
            SqlBase.ExecuteSql("update SysSet set RollerTransportationTime = '" + txtRollerTransportationTime.Text.Trim() + "',SteelTurningTime = '" + txtSteelTurningTime.Text.Trim() + "',ReasonableCoolingTime = '" + txtReasonableCoolingTime.Text.Trim() + "',FourReasonableCoolingTime = '" + txt4ReasonableCoolingTime.Text.Trim() + "',RollingRollingTime = '" + txtRollingRollingTime.Text.Trim() + "',FourRollingRollingTime = '" + txt4RollingRollingTime.Text.Trim() + "',SteelCuttingTime = '" + txtSteelCuttingTime.Text.Trim() + "',FourRollerTransportationTime = '" + txtFourRollerTransportationTime.Text.Trim() + "'");
            Tag = "Save";
            MessageBox.Show("保存成功！");
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            //DataTable dt = SqlBase.ExecuteSql4Dt("select * from SteelCuttingTime");
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    gcSteelTypeList.Rows.Clear();
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        gcSteelTypeList.Rows.Add();
            //        gcSteelTypeList.Rows[i].Cells[0].Value = dt.Rows[i]["steelType"].ToString();
            //        gcSteelTypeList.Rows[i].Cells[1].Value = dt.Rows[i]["thick"].ToString();
            //        gcSteelTypeList.Rows[i].Cells[2].Value = dt.Rows[i]["width"].ToString();
            //        gcSteelTypeList.Rows[i].Cells[3].Value = dt.Rows[i]["diameter"].ToString();
            //        gcSteelTypeList.Rows[i].Cells[4].Value = dt.Rows[i]["cuttingTime"].ToString();
            //    }
            //    gcSteelTypeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //}
            DataTable dtsys = SqlBase.ExecuteSql4Dt("select * from SysSet");
            if (dtsys != null && dtsys.Rows.Count > 0)
            {
                if (dtsys.Rows[0]["RollerTransportationTime"] != null && dtsys.Rows[0]["RollerTransportationTime"].ToString().Trim() != "")
                {
                    txtRollerTransportationTime.Text = dtsys.Rows[0]["RollerTransportationTime"].ToString().Trim();
                }
                if (dtsys.Rows[0]["SteelTurningTime"] != null && dtsys.Rows[0]["SteelTurningTime"].ToString().Trim() != "")
                {
                    txtSteelTurningTime.Text = dtsys.Rows[0]["SteelTurningTime"].ToString().Trim();
                }
                if (dtsys.Rows[0]["ReasonableCoolingTime"] != null && dtsys.Rows[0]["ReasonableCoolingTime"].ToString().Trim() != "")
                {
                    txtReasonableCoolingTime.Text = dtsys.Rows[0]["ReasonableCoolingTime"].ToString().Trim();
                }
                if (dtsys.Rows[0]["FourReasonableCoolingTime"] != null && dtsys.Rows[0]["FourReasonableCoolingTime"].ToString().Trim() != "")
                {
                    txt4ReasonableCoolingTime.Text = dtsys.Rows[0]["FourReasonableCoolingTime"].ToString().Trim();
                }
                if (dtsys.Rows[0]["RollingRollingTime"] != null && dtsys.Rows[0]["RollingRollingTime"].ToString().Trim() != "")
                {
                    txtRollingRollingTime.Text = dtsys.Rows[0]["RollingRollingTime"].ToString().Trim();
                }
                if (dtsys.Rows[0]["FourRollingRollingTime"] != null && dtsys.Rows[0]["FourRollingRollingTime"].ToString().Trim() != "")
                {
                    txt4RollingRollingTime.Text = dtsys.Rows[0]["FourRollingRollingTime"].ToString().Trim();
                }
                if (dtsys.Rows[0]["SteelCuttingTime"] != null && dtsys.Rows[0]["SteelCuttingTime"].ToString().Trim() != "")
                {
                    txtSteelCuttingTime.Text = dtsys.Rows[0]["SteelCuttingTime"].ToString().Trim();
                }

                if (dtsys.Rows[0]["FourRollerTransportationTime"] != null && dtsys.Rows[0]["FourRollerTransportationTime"].ToString().Trim() != "")
                {
                    txtFourRollerTransportationTime.Text = dtsys.Rows[0]["FourRollerTransportationTime"].ToString().Trim();
                }

                if (dtsys.Rows[0]["Stand0One"] != null && dtsys.Rows[0]["Stand0One"].ToString().Trim() != "")
                {
                    if(dtsys.Rows[0]["Stand0One"].ToString().Trim() == "1")
                    {
                        rbStand0One1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand0One"].ToString().Trim() == "2")
                    {
                        rbStand0One2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand0One"].ToString().Trim() == "3")
                    {
                        rbStand0One3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand1One"] != null && dtsys.Rows[0]["Stand1One"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand1One"].ToString().Trim() == "1")
                    {
                        rbStand1One1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand1One"].ToString().Trim() == "2")
                    {
                        rbStand1One2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand1One"].ToString().Trim() == "3")
                    {
                        rbStand1One3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand2One"] != null && dtsys.Rows[0]["Stand2One"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand2One"].ToString().Trim() == "1")
                    {
                        rbStand2One1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand2One"].ToString().Trim() == "2")
                    {
                        rbStand2One2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand2One"].ToString().Trim() == "3")
                    {
                        rbStand2One3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand3One"] != null && dtsys.Rows[0]["Stand3One"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand3One"].ToString().Trim() == "1")
                    {
                        rbStand3One1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand3One"].ToString().Trim() == "2")
                    {
                        rbStand3One2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand3One"].ToString().Trim() == "3")
                    {
                        rbStand3One3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand4One"] != null && dtsys.Rows[0]["Stand4One"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand4One"].ToString().Trim() == "1")
                    {
                        rbStand4One1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand4One"].ToString().Trim() == "2")
                    {
                        rbStand4One2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand4One"].ToString().Trim() == "3")
                    {
                        rbStand4One3.Checked = true;
                    }
                }

                if (dtsys.Rows[0]["Stand5One"] != null && dtsys.Rows[0]["Stand5One"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand5One"].ToString().Trim() == "1")
                    {
                        rbStand5One1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand5One"].ToString().Trim() == "2")
                    {
                        rbStand5One2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand5One"].ToString().Trim() == "3")
                    {
                        rbStand5One3.Checked = true;
                    }
                }

                if (dtsys.Rows[0]["Stand6One"] != null && dtsys.Rows[0]["Stand6One"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand6One"].ToString().Trim() == "1")
                    {
                        rbStand6One1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand6One"].ToString().Trim() == "2")
                    {
                        rbStand6One2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand6One"].ToString().Trim() == "3")
                    {
                        rbStand6One3.Checked = true;
                    }
                }

                if (dtsys.Rows[0]["Stand0Two"] != null && dtsys.Rows[0]["Stand0Two"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand0Two"].ToString().Trim() == "1")
                    {
                        rbStand0Two1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand0Two"].ToString().Trim() == "2")
                    {
                        rbStand0Two2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand0Two"].ToString().Trim() == "3")
                    {
                        rbStand0Two3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand1Two"] != null && dtsys.Rows[0]["Stand1Two"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand1Two"].ToString().Trim() == "1")
                    {
                        rbStand1Two1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand1Two"].ToString().Trim() == "2")
                    {
                        rbStand1Two2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand1Two"].ToString().Trim() == "3")
                    {
                        rbStand1Two3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand2Two"] != null && dtsys.Rows[0]["Stand2Two"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand2Two"].ToString().Trim() == "1")
                    {
                        rbStand2Two1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand2Two"].ToString().Trim() == "2")
                    {
                        rbStand2Two2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand2Two"].ToString().Trim() == "3")
                    {
                        rbStand2Two3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand3Two"] != null && dtsys.Rows[0]["Stand3Two"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand3Two"].ToString().Trim() == "1")
                    {
                        rbStand3Two1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand3Two"].ToString().Trim() == "2")
                    {
                        rbStand3Two2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand3Two"].ToString().Trim() == "3")
                    {
                        rbStand3Two3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand4Two"] != null && dtsys.Rows[0]["Stand4Two"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand4Two"].ToString().Trim() == "1")
                    {
                        rbStand4Two1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand4Two"].ToString().Trim() == "2")
                    {
                        rbStand4Two2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand4Two"].ToString().Trim() == "3")
                    {
                        rbStand4Two3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand5Two"] != null && dtsys.Rows[0]["Stand5Two"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand5Two"].ToString().Trim() == "1")
                    {
                        rbStand5Two1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand5Two"].ToString().Trim() == "2")
                    {
                        rbStand5Two2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand5Two"].ToString().Trim() == "3")
                    {
                        rbStand5Two3.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand6Two"] != null && dtsys.Rows[0]["Stand6Two"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand6Two"].ToString().Trim() == "1")
                    {
                        rbStand6Two1.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand6Two"].ToString().Trim() == "2")
                    {
                        rbStand6Two2.Checked = true;
                    }
                    else if (dtsys.Rows[0]["Stand6Two"].ToString().Trim() == "3")
                    {
                        rbStand6Two3.Checked = true;
                    }
                }
                if(dtsys.Rows[0]["IsFixed"] != null && dtsys.Rows[0]["IsFixed"].ToString().Trim() != "")
                {
                    if(dtsys.Rows[0]["IsFixed"].ToString().Trim() == "0")
                    {
                        cbGD.Checked = false;
                    }
                    else if (dtsys.Rows[0]["IsFixed"].ToString().Trim() == "1")
                    {
                        cbGD.Checked = true;
                    }
                }
                if (dtsys.Rows[0]["Stand0Select"] != null && dtsys.Rows[0]["Stand0Select"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand0Select"].ToString().Trim() == "0")
                    {
                        cbSelect0.SelectedIndex = 0;
                    }
                    else if (dtsys.Rows[0]["Stand0Select"].ToString().Trim() == "1")
                    {
                        cbSelect0.SelectedIndex = 1;
                    }
                    else if (dtsys.Rows[0]["Stand0Select"].ToString().Trim() == "2")
                    {
                        cbSelect0.SelectedIndex = 2;
                    }
                }
                if (dtsys.Rows[0]["Stand1Select"] != null && dtsys.Rows[0]["Stand1Select"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand1Select"].ToString().Trim() == "0")
                    {
                        cbSelect1.SelectedIndex = 0;
                    }
                    else if (dtsys.Rows[0]["Stand1Select"].ToString().Trim() == "1")
                    {
                        cbSelect1.SelectedIndex = 1;
                    }
                    else if (dtsys.Rows[0]["Stand1Select"].ToString().Trim() == "2")
                    {
                        cbSelect1.SelectedIndex = 2;
                    }
                }
                if (dtsys.Rows[0]["Stand2Select"] != null && dtsys.Rows[0]["Stand2Select"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand2Select"].ToString().Trim() == "0")
                    {
                        cbSelect2.SelectedIndex = 0;
                    }
                    else if (dtsys.Rows[0]["Stand2Select"].ToString().Trim() == "1")
                    {
                        cbSelect2.SelectedIndex = 1;
                    }
                    else if (dtsys.Rows[0]["Stand2Select"].ToString().Trim() == "2")
                    {
                        cbSelect2.SelectedIndex = 2;
                    }
                }
                if (dtsys.Rows[0]["Stand3Select"] != null && dtsys.Rows[0]["Stand3Select"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand3Select"].ToString().Trim() == "0")
                    {
                        cbSelect3.SelectedIndex = 0;
                    }
                    else if (dtsys.Rows[0]["Stand3Select"].ToString().Trim() == "1")
                    {
                        cbSelect3.SelectedIndex = 1;
                    }
                    else if (dtsys.Rows[0]["Stand3Select"].ToString().Trim() == "2")
                    {
                        cbSelect3.SelectedIndex = 2;
                    }
                }
                if (dtsys.Rows[0]["Stand4Select"] != null && dtsys.Rows[0]["Stand4Select"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand4Select"].ToString().Trim() == "0")
                    {
                        cbSelect4.SelectedIndex = 0;
                    }
                    else if (dtsys.Rows[0]["Stand4Select"].ToString().Trim() == "1")
                    {
                        cbSelect4.SelectedIndex = 1;
                    }
                    else if (dtsys.Rows[0]["Stand4Select"].ToString().Trim() == "2")
                    {
                        cbSelect4.SelectedIndex = 2;
                    }
                }
                if (dtsys.Rows[0]["Stand5Select"] != null && dtsys.Rows[0]["Stand5Select"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand5Select"].ToString().Trim() == "0")
                    {
                        cbSelect5.SelectedIndex = 0;
                    }
                    else if (dtsys.Rows[0]["Stand5Select"].ToString().Trim() == "1")
                    {
                        cbSelect5.SelectedIndex = 1;
                    }
                    else if (dtsys.Rows[0]["Stand5Select"].ToString().Trim() == "2")
                    {
                        cbSelect5.SelectedIndex = 2;
                    }
                }
                if (dtsys.Rows[0]["Stand6Select"] != null && dtsys.Rows[0]["Stand6Select"].ToString().Trim() != "")
                {
                    if (dtsys.Rows[0]["Stand6Select"].ToString().Trim() == "0")
                    {
                        cbSelect6.SelectedIndex = 0;
                    }
                    else if (dtsys.Rows[0]["Stand6Select"].ToString().Trim() == "1")
                    {
                        cbSelect6.SelectedIndex = 1;
                    }
                    else if (dtsys.Rows[0]["Stand6Select"].ToString().Trim() == "2")
                    {
                        cbSelect6.SelectedIndex = 2;
                    }
                }
            }
        }

        private void rbStand0One1_CheckedChanged(object sender, EventArgs e)
        {
            SelectChange(((RadioButton)sender).Parent as GroupBox);
        }

        void SelectChange(GroupBox gb)
        {
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                if (gb.Controls[i] is RadioButton)
                {
                    RadioButton temp = (RadioButton)gb.Controls[i];
                    if (temp.Checked)//判断是否选中
                    {
                        string strupdate = "";
                        if(temp.Name.Trim() == "rbStand0One1")
                        {
                            strupdate = "set Stand0One=1";
                        }
                        else if (temp.Name.Trim() == "rbStand0One2")
                        {
                            strupdate = "set Stand0One=2";
                        }
                        else if (temp.Name.Trim() == "rbStand0One3")
                        {
                            strupdate = "set Stand0One=3";
                        }
                        else if (temp.Name.Trim() == "rbStand0Two1")
                        {
                            strupdate = "set Stand0Two=1";
                        }
                        else if (temp.Name.Trim() == "rbStand0Two2")
                        {
                            strupdate = "set Stand0Two=2";
                        }
                        else if (temp.Name.Trim() == "rbStand0Two3")
                        {
                            strupdate = "set Stand0Two=3";
                        }
                        else if (temp.Name.Trim() == "rbStand1One1") 
                        {
                            strupdate = "set Stand1One=1";
                        }
                        else if (temp.Name.Trim() == "rbStand1One2")
                        {
                            strupdate = "set Stand1One=2";
                        }
                        else if (temp.Name.Trim() == "rbStand1One3")
                        {
                            strupdate = "set Stand1One=3";
                        }
                        else if (temp.Name.Trim() == "rbStand1Two1") 
                        {
                            strupdate = "set Stand1Two=1";
                        }
                        else if (temp.Name.Trim() == "rbStand1Two2")
                        {
                            strupdate = "set Stand1Two=2";
                        }
                        else if (temp.Name.Trim() == "rbStand1Two3")
                        {
                            strupdate = "set Stand1Two=3";
                        }
                        else if (temp.Name.Trim() == "rbStand2One1") 
                        {
                            strupdate = "set Stand2One=1";
                        }
                        else if (temp.Name.Trim() == "rbStand2One2")
                        {
                            strupdate = "set Stand2One=2";
                        }
                        else if (temp.Name.Trim() == "rbStand2One3")
                        {
                            strupdate = "set Stand2One=3";
                        }
                        else if (temp.Name.Trim() == "rbStand2Two1")
                        {
                            strupdate = "set Stand2Two=1";
                        }
                        else if (temp.Name.Trim() == "rbStand2Two2")
                        {
                            strupdate = "set Stand2Two=2";
                        }
                        else if (temp.Name.Trim() == "rbStand2Two3")
                        {
                            strupdate = "set Stand2Two=3";
                        }
                        else if (temp.Name.Trim() == "rbStand3One1")
                        {
                            strupdate = "set Stand3One=1";
                        }
                        else if (temp.Name.Trim() == "rbStand3One2")
                        {
                            strupdate = "set Stand3One=2";
                        }
                        else if (temp.Name.Trim() == "rbStand3One3")
                        {
                            strupdate = "set Stand3One=3";
                        }
                        else if (temp.Name.Trim() == "rbStand3Two1")
                        {
                            strupdate = "set Stand3Two=1";
                        }
                        else if (temp.Name.Trim() == "rbStand3Two2")
                        {
                            strupdate = "set Stand3Two=2";
                        }
                        else if (temp.Name.Trim() == "rbStand3Two3")
                        {
                            strupdate = "set Stand3Two=3";
                        }
                        else if (temp.Name.Trim() == "rbStand4One1")
                        {
                            strupdate = "set Stand4One=1";
                        }
                        else if (temp.Name.Trim() == "rbStand4One2")
                        {
                            strupdate = "set Stand4One=2";
                        }
                        else if (temp.Name.Trim() == "rbStand4One3")
                        {
                            strupdate = "set Stand4One=3";
                        }
                        else if (temp.Name.Trim() == "rbStand4Two1")
                        {
                            strupdate = "set Stand4Two=1";
                        }
                        else if (temp.Name.Trim() == "rbStand4Two2")
                        {
                            strupdate = "set Stand4Two=2";
                        }
                        else if (temp.Name.Trim() == "rbStand4Two3")
                        {
                            strupdate = "set Stand4Two=3";
                        }
                        else if (temp.Name.Trim() == "rbStand5One1")
                        {
                            strupdate = "set Stand5One=1";
                        }
                        else if (temp.Name.Trim() == "rbStand5One2")
                        {
                            strupdate = "set Stand5One=2";
                        }
                        else if (temp.Name.Trim() == "rbStand5One3")
                        {
                            strupdate = "set Stand5One=3";
                        }
                        else if (temp.Name.Trim() == "rbStand5Two1")
                        {
                            strupdate = "set Stand5Two=1";
                        }
                        else if (temp.Name.Trim() == "rbStand5Two2")
                        {
                            strupdate = "set Stand5Two=2";
                        }
                        else if (temp.Name.Trim() == "rbStand5Two3")
                        {
                            strupdate = "set Stand5Two=3";
                        }
                        else if (temp.Name.Trim() == "rbStand6One1")
                        {
                            strupdate = "set Stand6One=1";
                        }
                        else if (temp.Name.Trim() == "rbStand6One2")
                        {
                            strupdate = "set Stand6One=2";
                        }
                        else if (temp.Name.Trim() == "rbStand6One3")
                        {
                            strupdate = "set Stand6One=3";
                        }
                        else if (temp.Name.Trim() == "rbStand6Two1")
                        {
                            strupdate = "set Stand6Two=1";
                        }
                        else if (temp.Name.Trim() == "rbStand6Two2")
                        {
                            strupdate = "set Stand6Two=2";
                        }
                        else if (temp.Name.Trim() == "rbStand6Two3")
                        {
                            strupdate = "set Stand6Two=3";
                        }
                        SqlBase.ExecuteSql("update SysSet " + strupdate);
                    }
                }
            }
        }

        private void btnFixedSave_Click(object sender, EventArgs e)
        {
            if(cbGD.Checked == true)
            {
                SqlBase.ExecuteSql("update SysSet set IsFixed = 1");
            }
            else
            {
                SqlBase.ExecuteSql("update SysSet set  IsFixed = 0");
            }

            if (cbSelect0.Text.Trim() == "1轧") 
            {
                SqlBase.ExecuteSql("update SysSet set  Stand0Select = 0");
            }
            else if (cbSelect0.Text.Trim() == "4轧")
            {
                SqlBase.ExecuteSql("update SysSet set  Stand0Select = 1");
            }
            else if (cbSelect0.Text.Trim() == "冷床")
            {
                SqlBase.ExecuteSql("update SysSet set  Stand0Select = 2");
            }

            if (cbSelect1.Text.Trim() == "1轧")
            {
                SqlBase.ExecuteSql("update SysSet set  Stand1Select = 0");
            }
            else if (cbSelect1.Text.Trim() == "4轧")
            {
                SqlBase.ExecuteSql("update SysSet set  Stand1Select = 1");
            }
            else if (cbSelect1.Text.Trim() == "冷床")
            {
                SqlBase.ExecuteSql("update SysSet set  Stand1Select = 2");
            }

            if (cbSelect2.Text.Trim() == "1轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand2Select = 0");
            }
            else if (cbSelect2.Text.Trim() == "4轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand2Select = 1");
            }
            else if (cbSelect2.Text.Trim() == "冷床")
            {
                SqlBase.ExecuteSql("update SysSet set Stand2Select = 2");
            }

            if (cbSelect3.Text.Trim() == "1轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand3Select = 0");
            }
            else if (cbSelect3.Text.Trim() == "4轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand3Select = 1");
            }
            else if (cbSelect3.Text.Trim() == "冷床")
            {
                SqlBase.ExecuteSql("update SysSet set Stand3Select = 2");
            }

            if (cbSelect4.Text.Trim() == "1轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand4Select = 0");
            }
            else if (cbSelect4.Text.Trim() == "4轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand4Select = 1");
            }
            else if (cbSelect4.Text.Trim() == "冷床")
            {
                SqlBase.ExecuteSql("update SysSet set Stand4Select = 2");
            }

            if (cbSelect5.Text.Trim() == "1轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand5Select = 0");
            }
            else if (cbSelect5.Text.Trim() == "4轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand5Select = 1");
            }
            else if (cbSelect5.Text.Trim() == "冷床")
            {
                SqlBase.ExecuteSql("update SysSet set Stand5Select = 2");
            }

            if (cbSelect6.Text.Trim() == "1轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand6Select = 0");
            }
            else if (cbSelect6.Text.Trim() == "4轧")
            {
                SqlBase.ExecuteSql("update SysSet set Stand6Select = 1");
            }
            else if (cbSelect6.Text.Trim() == "冷床")
            {
                SqlBase.ExecuteSql("update SysSet set Stand6Select = 2");
            }
            MessageBox.Show("保存成功！");
        }
    }
}

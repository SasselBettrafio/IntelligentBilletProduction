using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using GlobalData;
using kepOpcRW;
using OPCAutomation;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using IntelligentBilletProduction;
using System.Reflection;
using HZH_Controls.Controls;
using System.Web;
using System.Media;
using NAudio.Wave;
using System.Windows;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;
using FontStyle = System.Drawing.FontStyle;
using Size = System.Drawing.Size;
using AnimatorNS;

namespace contiCasterLevelTwoServer
{
	public partial class IntelligentBilletProduction : Form
	{
		/// <summary>
		/// 启动服务器
		/// </summary>
		public IntelligentBilletProduction()
		{
			this.InitializeComponent();
        }

        public OPCServer KepServer = (OPCServer)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("28E68F9A-8D75-11D1-8DC3-3C302A000000")));   //初始化kepServer
        private KepOpc kepOpc = new KepOpc();//实例化OPC
        DataSet dsPLCID = XmlHelper.GetXmlData(Application.StartupPath + "\\ServerConfig.xml", "CConfig");   //读取配置文件

        int intM0 = 0;
        private void tStand0_Tick(object sender, EventArgs e)
        {
            intM0++;
            Stand0List.Text = "0流正在切割" + "(" + intM0 + ")";
         
            if (intM0 > intCT)
            {
                gcRunList.Rows.Add();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "0流钢坯切割异常";
                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('0流钢坯切割异常','" + DateTime.Now.ToString() + "')");
                tStand0.Enabled = false;
                bltp[0] = 1;
                blIsRun0 = false;

                plAlarm.Left = 220;
                plAlarm.Top = btn0Continue.Top;
                lbAlarmStr.Text = "0流钢坯切割异常，请检查！";
                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                intalarm[0] = 1;
                waveOut.Play();

                Controls.Remove(Stand0List);
                Stand0List.Dispose();
                Application.DoEvents();
            }
        }

        int intM1 = 0;
        private void tStand1_Tick(object sender, EventArgs e)
        {
            intM1++;
            Stand1List.Text = "1流正在切割" + "(" + intM1 + ")";

          
            if (intM1 > intCT)
            {
                gcRunList.Rows.Add();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "1流钢坯切割异常";
                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('1流钢坯切割异常','" + DateTime.Now.ToString() + "')");
                tStand1.Enabled = false;
                bltp[1] = 1;
                blIsRun1 = false;
                plAlarm.Left = 220;
                plAlarm.Top = btn1Continue.Top;
                lbAlarmStr.Text = "1流钢坯切割异常，请检查！";
                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                intalarm[1] = 1;
                waveOut.Play();

                Stand1List.Tag = null;
                Controls.Remove(Stand1List);
                Stand1List.Dispose();
                Application.DoEvents();
            }
        }

        Button Stand0List;
        Button Stand1List;
        Button Stand2List;
        Button Stand3List;
        Button Stand4List;
        Button Stand5List;
        Button Stand6List;

        
        bool isRun0 = true;
        bool isRun1 = true;
        bool isRun2 = true;
        bool isRun3 = true;
        bool isRun4 = true;
        bool isRun5 = true;
        bool isRun6 = true;

        private void tsSystemSet_Click(object sender, EventArgs e)
        {
            frmSet frmSet = new frmSet();
            frmSet.ShowDialog();
            if(frmSet.Tag != null)
            {
                DataTable dtSteelType = SqlBase.ExecuteSql4Dt("select * from SysSet");
                if (dtSteelType != null && dtSteelType.Rows[0]["RollerTransportationTime"] != null && dtSteelType.Rows[0]["RollerTransportationTime"].ToString().Trim() != "")
                {
                    intGD = int.Parse(dtSteelType.Rows[0]["RollerTransportationTime"].ToString().Trim());
                }
                if (dtSteelType != null && dtSteelType.Rows[0]["SteelTurningTime"] != null && dtSteelType.Rows[0]["SteelTurningTime"].ToString().Trim() != "")
                {
                    intFS = int.Parse(dtSteelType.Rows[0]["SteelTurningTime"].ToString().Trim());
                }
                if (dtSteelType != null && dtSteelType.Rows[0]["ReasonableCoolingTime"] != null && dtSteelType.Rows[0]["ReasonableCoolingTime"].ToString().Trim() != "")
                {
                    intWT = int.Parse(dtSteelType.Rows[0]["ReasonableCoolingTime"].ToString().Trim());
                }
                if (dtSteelType != null && dtSteelType.Rows[0]["RollingRollingTime"] != null && dtSteelType.Rows[0]["RollingRollingTime"].ToString().Trim() != "")
                {
                    intZG = int.Parse(dtSteelType.Rows[0]["RollingRollingTime"].ToString().Trim());
                }
                if (dtSteelType != null && dtSteelType.Rows[0]["FourRollingRollingTime"] != null && dtSteelType.Rows[0]["FourRollingRollingTime"].ToString().Trim() != "")
                {
                    intHL = int.Parse(dtSteelType.Rows[0]["FourRollingRollingTime"].ToString().Trim());
                }
                if (dtSteelType != null && dtSteelType.Rows[0]["FourReasonableCoolingTime"] != null && dtSteelType.Rows[0]["FourReasonableCoolingTime"].ToString().Trim() != "")
                {
                    intFourWT = int.Parse(dtSteelType.Rows[0]["FourReasonableCoolingTime"].ToString().Trim());
                }
                    
            }
        }

        private void tsAutomaticBillet_Click(object sender, EventArgs e)
        {
            if(tsAutomaticBillet.Text.Trim() == "停止自动出坯")
            {
                if(MessageBox.Show("是否停止自动出坯?","停止出坯",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)== DialogResult.Yes)
                {
                    tIsSteelrolling.Enabled = false;
                    Rolling4Run.ConveyorDirection = ConveyorDirection.None;
                    Stand0Run.ConveyorDirection = ConveyorDirection.None;
                    Stand1Run.ConveyorDirection = ConveyorDirection.None;
                    Stand2Run.ConveyorDirection = ConveyorDirection.None;
                    Stand3Run.ConveyorDirection = ConveyorDirection.None;
                    Stand4Run.ConveyorDirection = ConveyorDirection.None;
                    Stand5Run.ConveyorDirection = ConveyorDirection.None;
                    Stand6Run.ConveyorDirection = ConveyorDirection.None;
                    ucsteelrolling.LiquidDirection = LiquidDirection.None;

                    tStand0.Enabled = false;
                    tStand1.Enabled = false;
                    tStand2.Enabled = false;
                    tStand3.Enabled = false;
                    tStand4.Enabled = false;
                    tStand5.Enabled = false;
                    tStand6.Enabled = false;
                    
                    isRun0 = false;
                    isRun1 = false;
                    isRun2 = false;
                    isRun3 = false;
                    isRun4 = false;
                    isRun5 = false;
                    isRun6 = false;
                    tsAutomaticBillet.Text = "开始自动出坯";
                }
            }
            else if(tsAutomaticBillet.Text.Trim() == "开始自动出坯")
            {
                if (MessageBox.Show("是否重启自动出坯?", "开始出坯", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Application.Restart();
                    Process currentProcess;
                    currentProcess = Process.GetCurrentProcess();
                    currentProcess.Kill();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processName"></param>
        public static void KillProcessByName(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
            }
        }

        bool blIsRun0 = false, blIsRun1 = false, blIsRun2 = false, blIsRun3 = false, blIsRun4 = false, blIsRun5 = false, blIsRun6 = false;
        bool blIsSRun0 = true, blIsSRun1 = true, blIsSRun2 = true, blIsSRun3 = true, blIsSRun4 = true, blIsSRun5 = true, blIsSRun6 = true, blIsOSRun = true;
        int intR0 = 0, intS0 = 0;
        bool blcontinue0 = false;
        void getRuns0()
        {
            blcontinue0 = true;
            while (blIsRun0)
            {
                if (isRun0 == true)
                {
                    try
                    {
                        Stand0List.Left += 9;
                        intS0++;
                        if (intS0 == 10)
                        {
                            intS0 = 0;
                            intR0++;
                            string strr = "";
                            if (blonerolling[0] == true)
                            {
                                strr = "1轧";
                            }
                            else if (blstop[0] == true)
                            {
                                strr = "起挡板1轧";
                            }
                            else if (blrolling[0] == true)
                            {
                                strr = strone0;
                            }
                            else if (blcb[0] == true)
                            {
                                strr = strtwo6;
                            }

                            Stand0List.Text = "0流进入[" + strr + "](" + intR0 + ")";

                            if (intR0 > (intGD + 33))
                            {
                                gcRunList.Rows.Add();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "0流辊道运输异常";
                                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('0流辊道运输异常','" + DateTime.Now.ToString() + "')");

                                bltp[0] = 1;
                                blIsRun0 = false;

                                plAlarm.Left = 220;
                                plAlarm.Top = btn0Continue.Top;
                                lbAlarmStr.Text = "0流辊道运输超时，请检查！";
                                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                                intalarm[0] = 1;
                                waveOut.Play();

                                Controls.Remove(Stand0List);
                                Stand0List.Dispose();
                                Application.DoEvents();
                            }
                            else
                            {
                                if (blcontinue0 == true)
                                {
                                    bool flag = this.kepOpc.itemValue[6] == "True";
                                    if (flag)
                                    {
                                        Stand0List.ForeColor = Color.Yellow;
                                        isRun0 = false;
                                        if (blrolling[0] == true || blcb[0] == true)
                                        {
                                            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "0流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }

                                            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "0流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

                                            intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }

                                            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 0);
                                            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 0);
                                            blIsRun0 = false;

                                            isRun0 = false;
                                            Application.DoEvents();
                                        }
                                        blcontinue0 = false;
                                    }
                                }
                                else
                                {
                                    if (intR0 > (25))
                                    {
                                        blIsRun0 = false;
                                        isRun0 = false;
                                        Controls.Remove(Stand0List);
                                        Stand0List.Dispose();
                                    }

                                }
                            }
                        }
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                        blIsRun0 = false;
                        isRun0 = false;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 去一轧倒计时
        /// </summary>
        void getOneSteelRolling()
        {
            try
            {
                WaitingSteelRolling = -1;
                while (true)
                {
                    intsteelrollingsecond++;
                    SteelRollingStand = 99;
                    if (ucsteelrolling.LiquidDirection != LiquidDirection.Forward)
                    {
                        ucsteelrolling.Invoke((MethodInvoker)delegate
                        {
                            ucsteelrolling.LiquidDirection = LiquidDirection.Forward;
                        });
                    }

                    if (intsteelrollingsecond >= intZG)
                    {
                        intsteelrollingsecond = 0;
                        SteelRollingStand = -1;
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        Application.DoEvents();
                    }
                }
            }
            catch(Exception ex)
            {
                System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
            }
        }

        /// <summary>
        /// 获取移钢机位置
        /// </summary>
        void getYGJ()
        {
            while (true)
            {
                try
                {
                    if (this.kepOpc.itemValue[197] != null)
                    {
                        int intLocation = int.Parse(this.kepOpc.itemValue[197].Trim());
                        Invoke((MethodInvoker)delegate
                        {
                            lbTGJ.Top = (intLocation - 3410) / 19 + 45;
                        });
                    }
                    if(this.kepOpc.itemValue[199] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[199] == "True";
                        if(bloneopt == true)
                        {
                            Stand1.ForeColor = Color.Green;
                            Stand1.Text = "1流(强制1轧)";
                        }
                    }
                    if(this.kepOpc.itemValue[204] != null)
                    {
                        bool blfouropt = this.kepOpc.itemValue[204] == "True";
                        if (blfouropt == true)
                        {
                            Stand1.ForeColor = Color.Red;
                            Stand1.Text = "1流(强制4轧)";
                        }
                    }
                    if(this.kepOpc.itemValue[199] != null && this.kepOpc.itemValue[204] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[199] == "True";
                        bool blfouropt = this.kepOpc.itemValue[204] == "True";
                        if(bloneopt == false && blfouropt == false)
                        {
                            Stand1.ForeColor = Color.Black;
                            Stand1.Text = "1流";
                        }
                    }
                    if (this.kepOpc.itemValue[200] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[200] == "True";
                        if (bloneopt == true)
                        {
                            Stand2.ForeColor = Color.Green;
                            Stand2.Text = "2流(强制1轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[205] != null)
                    {
                        bool blfouropt = this.kepOpc.itemValue[205] == "True";
                        if (blfouropt == true)
                        {
                            Stand2.ForeColor = Color.Red;
                            Stand2.Text = "2流(强制4轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[200] != null && this.kepOpc.itemValue[205] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[200] == "True";
                        bool blfouropt = this.kepOpc.itemValue[205] == "True";
                        if (bloneopt == false && blfouropt == false)
                        {
                            Stand2.ForeColor = Color.Black;
                            Stand2.Text = "2流";
                        }
                    }
                    if (this.kepOpc.itemValue[201] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[201] == "True";
                        if (bloneopt == true)
                        {
                            Stand3.ForeColor = Color.Green;
                            Stand3.Text = "3流(强制1轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[206] != null)
                    {
                        bool blfouropt = this.kepOpc.itemValue[206] == "True";
                        if (blfouropt == true)
                        {
                            Stand3.ForeColor = Color.Red;
                            Stand3.Text = "3流(强制4轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[201] != null && this.kepOpc.itemValue[206] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[201] == "True";
                        bool blfouropt = this.kepOpc.itemValue[206] == "True";
                        if (bloneopt == false && blfouropt == false)
                        {
                            Stand3.ForeColor = Color.Black;
                            Stand3.Text = "3流";
                        }
                    }
                    if (this.kepOpc.itemValue[202] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[202] == "True";
                        if (bloneopt == true)
                        {
                            Stand4.ForeColor = Color.Green;
                            Stand4.Text = "4流(强制1轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[207] != null)
                    {
                        bool blfouropt = this.kepOpc.itemValue[207] == "True";
                        if (blfouropt == true)
                        {
                            Stand4.ForeColor = Color.Red;
                            Stand4.Text = "4流(强制4轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[202] != null && this.kepOpc.itemValue[207] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[202] == "True";
                        bool blfouropt = this.kepOpc.itemValue[207] == "True";
                        if (bloneopt == false && blfouropt == false)
                        {
                            Stand4.ForeColor = Color.Black;
                            Stand4.Text = "4流";
                        }
                    }
                    if (this.kepOpc.itemValue[203] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[203] == "True";
                        if (bloneopt == true)
                        {
                            Stand5.ForeColor = Color.Green;
                            Stand5.Text = "5流(强制1轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[208] != null)
                    {
                        bool blfouropt = this.kepOpc.itemValue[208] == "True";
                        if (blfouropt == true)
                        {
                            Stand5.ForeColor = Color.Red;
                            Stand5.Text = "5流(强制4轧)";
                        }
                    }
                    if (this.kepOpc.itemValue[203] != null && this.kepOpc.itemValue[208] != null)
                    {
                        bool bloneopt = this.kepOpc.itemValue[203] == "True";
                        bool blfouropt = this.kepOpc.itemValue[208] == "True";
                        if (bloneopt == false && blfouropt == false)
                        {
                            Stand5.ForeColor = Color.Black;
                            Stand5.Text = "5流";
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
                Application.DoEvents();
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 是否启动
        /// </summary>
        void getStart()
        {
            int intStartRun = 0;
            while (true)
            {
                try
                {
                    bool flag0 = this.kepOpc.itemValue[194] == "True";
                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                    if (flag0 == false && intstart != 0)
                    {
                        this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1RunAuto", 0);
                    }
                    if (flag0 == false && intStartRun == 0)
                    {
                        intStartRun++;
                    }
                    else if (flag0 == true && intStartRun > 0)
                    {
                        Process.Start(Application.StartupPath + "\\ExitApplication.exe");
                    }
                    if (intM0 > 0)
                    {
                        if (Stand0List.IsDisposed == false && Stand0List != null)
                        {
                            using (Brush blueBrush = new SolidBrush(Color.Yellow))
                            {
                                Stand0List.CreateGraphics().FillRectangle(blueBrush, 0, 0, 10, (intM0 * 1.11f));
                            }
                        }
                    }
                    if (intM1 > 0)
                    {
                        if (Stand1List.IsDisposed == false && Stand1List != null)
                        {
                            using (Brush blueBrush = new SolidBrush(Color.Yellow))
                            {
                                Stand1List.CreateGraphics().FillRectangle(blueBrush, 0, 0, 10, (intM1 * 1.11f));
                            }
                        }
                    }
                    if (intM2 > 0)
                    {
                        if (Stand2List.IsDisposed == false && Stand2List != null)
                        {
                            using (Brush blueBrush = new SolidBrush(Color.Yellow))
                            {
                                Stand2List.CreateGraphics().FillRectangle(blueBrush, 0, 0, 10, (intM2 * 1.11f));
                            }
                        }
                    }
                    if (intM3 > 0)
                    {
                        if (Stand3List.IsDisposed == false && Stand3List != null)
                        {
                            using (Brush blueBrush = new SolidBrush(Color.Yellow))
                            {
                                Stand3List.CreateGraphics().FillRectangle(blueBrush, 0, 0, 10, (intM3 * 1.11f));
                            }
                        }
                    }
                    if (intM4 > 0)
                    {
                        if (Stand4List.IsDisposed == false && Stand4List != null)
                        {
                            using (Brush blueBrush = new SolidBrush(Color.Yellow))
                            {
                                Stand4List.CreateGraphics().FillRectangle(blueBrush, 0, 0, 10, (intM4 * 1.11f));
                            }
                        }
                    }
                    if (intM5 > 0)
                    {
                        if (Stand5List.IsDisposed == false && Stand5List != null)
                        {
                            using (Brush blueBrush = new SolidBrush(Color.Yellow))
                            {
                                Stand5List.CreateGraphics().FillRectangle(blueBrush, 0, 0, 10, (intM5 * 1.11f));
                            }
                        }
                    }
                    if (intM6 > 0)
                    {
                        if (Stand6List.IsDisposed == false && Stand6List != null)
                        {
                            using (Brush blueBrush = new SolidBrush(Color.Yellow))
                            {
                                Stand6List.CreateGraphics().FillRectangle(blueBrush, 0, 0, 10, (intM6 * 1.11f));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }


        bool bl1LiftingSteel = true, bl2LiftingSteel = true;
        /// <summary>
        /// 提钢
        /// </summary>
        void getLiftingSteel()
        {
            while(bl1LiftingSteel)
            {
                try
                {
                    if (FlipSteelList.Count > 0)
                    {
                        for (int i = 0; i < FlipSteelList.Count; i++)
                        {
                            bool blisStop = this.kepOpc.itemValue[209] == "True";
                            if (blisStop == true || blfirst == true)
                            {
                                blfirst = false;
                                bliswait = false;
                                if (FlipSteelList[i].Split('_')[1].Trim() == "0")
                                {
                                    int intstands = int.Parse(FlipSteelList[i].Split('_')[0].Trim());
                                    if(intstands == 0)
                                    {
                                        intstands = 7;
                                    }
                                    this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1Take", intstands);
                                    int intn = 0;
                                    while (true)
                                    {
                                        Thread.Sleep(100);
                                        Application.DoEvents();
                                        intn++;
                                        if (intn > 30)
                                        {
                                            break;
                                        }
                                    }
                                    if(intstands == 7)
                                    {
                                        if (Stand0List != null && Stand0List.IsDisposed == false)
                                        {
                                            Controls.Remove(Stand0List);
                                        }
                                    }
                                    else if (intstands == 1)
                                    {
                                        if (Stand1List != null && Stand1List.IsDisposed == false)
                                        {
                                            Controls.Remove(Stand1List);
                                        }
                                    }
                                    else if (intstands == 2)
                                    {
                                        if (Stand2List != null && Stand2List.IsDisposed == false)
                                        {
                                            Controls.Remove(Stand2List);
                                        }
                                    }
                                    else if (intstands == 3)
                                    {
                                        if (Stand3List != null && Stand3List.IsDisposed == false)
                                        {
                                            Controls.Remove(Stand3List);
                                        }
                                    }
                                    else if (intstands == 4)
                                    {
                                        if (Stand4List != null && Stand4List.IsDisposed == false)
                                        {
                                            Controls.Remove(Stand4List);
                                        }
                                    }
                                    else if (intstands == 5)
                                    {
                                        if (Stand5List != null && Stand5List.IsDisposed == false)
                                        {
                                            Controls.Remove(Stand5List);
                                        }
                                    }
                                    else if (intstands == 6)
                                    {
                                        if (Stand6List != null && Stand6List.IsDisposed == false)
                                        {
                                            Controls.Remove(Stand6List);
                                        }
                                    }
                                    FlipSteelList.Remove(FlipSteelList[i]);
                                    i = 0;
                                }
                            }
                            //else if (FlipSteelList[i].Split('_')[0].Trim() == "1")
                            //{

                            //}
                            //FlipSteelList.Remove(FlipSteelList[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
                Thread.Sleep(200);
            }
        }

        List<string> FlipSteelList = new List<string>();
        bool blis0 = false, blis1 = false, blis2 = false, blis3 = false, blis4 = false, blis5 = false, blis6 = false;
        /// <summary>
        /// 翻钢
        /// </summary>
        void getFlipSteeling()
        {
            while (true)
            {
                try
                {
                    bool flag0 = this.kepOpc.itemValue[1] == "True";
                    if (flag0)
                    {
                        if (Stand0List != null)
                        {
                            blis0 = true;
                            intR0++;
                            Stand0List.Text = "0流翻钢中(" + intR0 + ")";
                        }
                    }
                    else
                    {
                        if (blis0 == true)
                        {
                            if (Stand0List != null)
                            {
                                Stand0List.ForeColor = Color.White;
                                intR0++;
                                if (blcb[0] == false)
                                {
                                    if (intR0 <= intFourWT)
                                    {
                                        int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                        if (intstart == 1)
                                        {
                                            if (FlipSteelList.Contains("0_0") == false)
                                                FlipSteelList.Insert(0, "0_0");
                                        }
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "0_0")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand0List.Text = "0流[" + intresult + "] 去[" + strone0 + "](" + intR0 + ")";
                                    }
                                    else if (intR0 > intFourWT)
                                    {
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "0_1")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                            else if (FlipSteelList[i].Trim() == "0_0")
                                            {
                                                FlipSteelList[i] = "0_1";
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand0List.Text = "0流[" + intresult + "] 去[" + strtwo0 + "](" + intR0 + ")";
                                    }
                                }
                                else
                                {
                                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                    if (intstart == 1)
                                    {
                                        if (FlipSteelList.Contains("0_1") == false)
                                            FlipSteelList.Insert(0, "0_1");
                                    }
                                    int intresult = -1;
                                    for (int i = 0; i < FlipSteelList.Count; i++)
                                    {
                                        if (FlipSteelList[i].Trim() == "0_1")
                                        {
                                            intresult = (i + 1);
                                            break;
                                        }
                                    }
                                    Stand0List.Text = "0流[" + intresult + "] 去[" + strtwo0 + "](" + intR0 + ")";
                                }
                            }
                        }
                    }

                    flag0 = this.kepOpc.itemValue[13] == "True";
                    if (flag0)
                    {
                        if (Stand1List != null)
                        {
                            blis1 = true;
                            intR1++;
                            Stand1List.Text = "1流翻钢中(" + intR1 + ")";
                        }
                    }
                    else
                    {
                        if (blis1 == true)
                        {
                            if (Stand1List != null)
                            {
                                Stand1List.ForeColor = Color.White;
                                intR1++;
                                if (blcb[1] == false)
                                {
                                    if (intR1 <= intFourWT)
                                    {
                                        int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                        if (intstart == 1)
                                        {
                                            if (FlipSteelList.Contains("1_0") == false)
                                                FlipSteelList.Insert(0, "1_0");
                                        }
                                        //var indices = FlipSteelList.Select((str, index) => new { str, index }).Where(x => x.str.Contains("1_0")).Select(x => x.index).First();
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "1_0")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand1List.Text = "1流[" + intresult + "] 去[" + strone1 + "](" + intR1 + ")";
                                    }
                                    else if (intR1 > intFourWT)
                                    {
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "1_1")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                            else if (FlipSteelList[i].Trim() == "1_0")
                                            {
                                                FlipSteelList[i] = "1_1";
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand1List.Text = "1流[" + intresult + "] 去[" + strtwo1 + "](" + intR1 + ")";
                                    }
                                }
                                else
                                {
                                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                    if (intstart == 1)
                                    {
                                        if (FlipSteelList.Contains("1_1") == false)
                                            FlipSteelList.Insert(0, "1_1");
                                    }
                                    int intresult = -1;
                                    for (int i = 0; i < FlipSteelList.Count; i++)
                                    {
                                        if (FlipSteelList[i].Trim() == "1_1")
                                        {
                                            intresult = (i + 1);
                                            break;
                                        }
                                    }
                                    Stand1List.Text = "1流[" + intresult + "] 去[" + strtwo1 + "](" + intR1 + ")";
                                }
                            }
                        }
                    }

                    flag0 = this.kepOpc.itemValue[25] == "True";
                    if (flag0)
                    {
                        if (Stand2List != null)
                        {
                            blis2 = true;
                            intR2++;
                            Stand2List.Text = "2流翻钢中(" + intR2 + ")";
                        }
                    }
                    else
                    {
                        if (blis2 == true)
                        {
                            if (Stand2List != null)
                            {
                                Stand2List.ForeColor = Color.White;
                                intR2++;
                                if (blcb[2] == false)
                                {
                                    if (intR2 <= intFourWT)
                                    {
                                        int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                        if (intstart == 1)
                                        {
                                            if (FlipSteelList.Contains("2_0") == false)
                                                FlipSteelList.Insert(0, "2_0");
                                        }
                                        //var indices = FlipSteelList.Select((str, index) => new { str, index }).Where(x => x.str.Contains("2_0")).Select(x => x.index).First();
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "2_0")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand2List.Text = "2流[" + intresult + "] 去[" + strone2 + "](" + intR2 + ")";
                                    }
                                    else if (intR2 > intFourWT)
                                    {
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "2_1")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                            else if (FlipSteelList[i].Trim() == "2_0")
                                            {
                                                FlipSteelList[i] = "2_1";
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand2List.Text = "2流[" + intresult + "] 去[" + strtwo2 + "](" + intR2 + ")";

                                    }
                                }
                                else
                                {
                                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                    if (intstart == 1)
                                    {
                                        if (FlipSteelList.Contains("2_1") == false)
                                            FlipSteelList.Insert(0, "2_1");
                                    }
                                    int intresult = -1;
                                    for (int i = 0; i < FlipSteelList.Count; i++)
                                    {
                                        if (FlipSteelList[i].Trim() == "2_1")
                                        {
                                            intresult = (i + 1);
                                            break;
                                        }
                                    }
                                    Stand2List.Text = "2流[" + intresult + "] 去[" + strtwo2 + "](" + intR2 + ")";
                                }
                            }
                        }
                    }

                    flag0 = this.kepOpc.itemValue[37] == "True";
                    if (flag0)
                    {
                        if (Stand3List != null)
                        {
                            blis3 = true;
                            intR3++;
                            Stand3List.Text = "3流翻钢中(" + intR3 + ")";
                        }
                    }
                    else
                    {
                        if (blis3 == true)
                        {
                            
                            if (Stand3List != null)
                            {
                                Stand3List.ForeColor = Color.White;
                                intR3++;
                                if (blcb[3] == false)
                                {
                                    if (intR3 <= intFourWT)
                                    {
                                        int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                        if (intstart == 1)
                                        {
                                            if (FlipSteelList.Contains("3_0") == false)
                                                FlipSteelList.Insert(0, "3_0");
                                        }
                                        //var indices = FlipSteelList.Select((str, index) => new { str, index }).Where(x => x.str.Contains("3_0")).Select(x => x.index).First();
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "3_0")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand3List.Text = "3流[" + intresult + "] 去[" + strone3 + "](" + intR3 + ")";
                                    }
                                    else if (intR3 > intFourWT)
                                    {
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "3_1")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                            else if (FlipSteelList[i].Trim() == "3_0")
                                            {
                                                FlipSteelList[i] = "3_1";
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand3List.Text = "3流[" + intresult + "] 去[" + strtwo3 + "](" + intR3 + ")";

                                    }
                                }
                                else
                                {
                                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                    if (intstart == 1)
                                    {
                                        if (FlipSteelList.Contains("3_1") == false)
                                            FlipSteelList.Insert(0, "3_1");
                                    }
                                    int intresult = -1;
                                    for (int i = 0; i < FlipSteelList.Count; i++)
                                    {
                                        if (FlipSteelList[i].Trim() == "3_1")
                                        {
                                            intresult = (i + 1);
                                            break;
                                        }
                                    }
                                    Stand3List.Text = "3流[" + intresult + "] 去[" + strtwo3 + "](" + intR3 + ")";
                                }
                            }
                        }
                    }

                    flag0 = this.kepOpc.itemValue[49] == "True";
                    if (flag0)
                    {
                        if (Stand4List != null)
                        {
                            blis4 = true;
                            intR4++;
                            Stand4List.Text = "4流翻钢中(" + intR4 + ")";
                        }
                    }
                    else
                    {
                        if (blis4 == true)
                        {
                            
                            if (Stand4List != null)
                            {
                                Stand4List.ForeColor = Color.White;
                                intR4++;
                                if (blcb[4] == false)
                                {
                                    if (intR4 <= intFourWT)
                                    {
                                        int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                        if (intstart == 1)
                                        {
                                            if (FlipSteelList.Contains("4_0") == false)
                                                FlipSteelList.Insert(0, "4_0");
                                        }
                                        //var indices = FlipSteelList.Select((str, index) => new { str, index }).Where(x => x.str.Contains("4_0")).Select(x => x.index).First();
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "4_0")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand4List.Text = "4流[" + intresult + "] 去[" + strone4 + "](" + intR4 + ")";
                                    }
                                    else if (intR4 > intFourWT)
                                    {
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "4_1")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                            else if (FlipSteelList[i].Trim() == "4_0")
                                            {
                                                FlipSteelList[i] = "4_1";
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }

                                        Stand4List.Text = "4流[" + intresult + "] 去[" + strtwo4 + "](" + intR4 + ")";

                                    }
                                }
                                else
                                {
                                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                    if (intstart == 1)
                                    {
                                        if (FlipSteelList.Contains("4_1") == false)
                                            FlipSteelList.Insert(0, "4_1");
                                    }
                                    int intresult = -1;
                                    for (int i = 0; i < FlipSteelList.Count; i++)
                                    {
                                        if (FlipSteelList[i].Trim() == "4_1")
                                        {
                                            intresult = (i + 1);
                                            break;
                                        }
                                    }
                                    Stand4List.Text = "4流[" + intresult + "] 去[" + strtwo4 + "](" + intR4 + ")";
                                }
                            }
                        }
                    }

                    flag0 = this.kepOpc.itemValue[61] == "True";
                    if (flag0)
                    {
                        if (Stand5List != null)
                        {
                            blis5 = true;
                            intR5++;
                            Stand5List.Text = "5流翻钢中(" + intR5 + ")";
                        }
                    }
                    else
                    {
                        if (blis5 == true)
                        {
                            if (Stand5List != null)
                            {
                                Stand5List.ForeColor = Color.White;
                                intR5++;
                                if (blcb[5] == false)
                                {
                                    if (intR5 <= intFourWT)
                                    {
                                        int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                        if (intstart == 1)
                                        {
                                            if (FlipSteelList.Contains("5_0") == false)
                                                FlipSteelList.Insert(0, "5_0");
                                        }
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "5_0")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand5List.Text = "5流[" + intresult + "] 去[" + strone5 + "](" + intR5 + ")";
                                    }
                                    else if (intR5 > intFourWT)
                                    {
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "5_1")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                            else if (FlipSteelList[i].Trim() == "5_0")
                                            {
                                                FlipSteelList[i] = "5_1";
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand5List.Text = "5流[" + intresult + "] 去[" + strtwo5 + "](" + intR5 + ")";

                                    }
                                }
                               else
                                {
                                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                    if (intstart == 1)
                                    {
                                        if (FlipSteelList.Contains("5_1") == false)
                                            FlipSteelList.Insert(0, "5_1");
                                    }
                                    int intresult = -1;
                                    for (int i = 0; i < FlipSteelList.Count; i++)
                                    {
                                        if (FlipSteelList[i].Trim() == "5_1")
                                        {
                                            intresult = (i + 1);
                                            break;
                                        }
                                    }
                                    Stand5List.Text = "5流[" + intresult + "] 去[" + strtwo5 + "](" + intR5 + ")";
                                }
                            }
                        }
                    }

                    flag0 = this.kepOpc.itemValue[73] == "True";
                    if (flag0)
                    {
                        if (Stand6List != null)
                        {
                            blis6 = true;
                            intR6++;
                            Stand6List.Text = "6流翻钢中(" + intR6 + ")";
                        }
                    }
                    else
                    {
                        if (blis6 == true)
                        {
                            if (Stand6List != null)
                            {
                                Stand6List.ForeColor = Color.White;
                                intR6++;
                                if (blcb[6] == false)
                                {
                                    if (intR6 <= intFourWT)
                                    {
                                        int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                        if (intstart == 1)
                                        {
                                            if (FlipSteelList.Contains("6_0") == false)
                                                FlipSteelList.Insert(0, "6_0");
                                        }
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "6_0")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand6List.Text = "6流[" + intresult + "] 去[" + strone6 + "](" + intR6 + ")";

                                    }
                                    else if (intR6 > intFourWT)
                                    {
                                        int intresult = -1;
                                        for (int i = 0; i < FlipSteelList.Count; i++)
                                        {
                                            if (FlipSteelList[i].Trim() == "6_1")
                                            {
                                                intresult = (i + 1);
                                                break;
                                            }
                                            else if (FlipSteelList[i].Trim() == "6_0")
                                            {
                                                FlipSteelList[i] = "6_1";
                                                intresult = (i + 1);
                                                break;
                                            }
                                        }
                                        Stand6List.Text = "6流[" + intresult + "] 去[" + strtwo6 + "](" + intR6 + ")";

                                    }
                                }
                                else
                                {
                                    int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                                    if (intstart == 1)
                                    {
                                        if (FlipSteelList.Contains("6_1") == false)
                                            FlipSteelList.Insert(0, "6_1");
                                    }
                                    int intresult = -1;
                                    for (int i = 0; i < FlipSteelList.Count; i++)
                                    {
                                        if (FlipSteelList[i].Trim() == "6_1")
                                        {
                                            intresult = (i + 1);
                                            break;
                                        }
                                    }
                                    Stand6List.Text = "6流[" + intresult + "] 去[" + strtwo6 + "](" + intR6 + ")";
                                }
                            }
                        }
                    }

                    if(DateTime.UtcNow.Minute == 59 && DateTime.UtcNow.Second == 59)
                    {
                        GC.Collect();
                    }
                    Thread.Sleep(1000);
                    Application.DoEvents();
                }
                catch(Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }

        void getOneResult()
        {
            bool blis1 = false, blis2 = false, blis3 = false, blis4 = false, blis5 = false;
            while(true)
            {
                bool flag0 = this.kepOpc.itemValue[187] == "True";
                if (flag0)
                {
                    if (blis1 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流收到1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        blis1 = true;
                    }
                }
                else
                {
                    blis1 = false;
                }
                flag0 = this.kepOpc.itemValue[188] == "True";
                if (flag0)
                {
                    if (blis2 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流收到1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        blis2 = true;
                    }
                }
                else
                {
                    blis2 = false;
                }
                flag0 = this.kepOpc.itemValue[189] == "True";
                if (flag0)
                {
                    if (blis3 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流收到1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        blis3 = true;
                    }
                }
                else
                {
                    blis3 = false;
                }
                flag0 = this.kepOpc.itemValue[190] == "True";
                if (flag0)
                {
                    if (blis4 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流收到1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        blis4 = true;
                    }
                }
                else
                {
                    blis4 = false;
                }
                flag0 = this.kepOpc.itemValue[191] == "True";
                if (flag0)
                {
                    if (blis5 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流收到1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        blis5 = true;
                    }
                }
                else
                {
                    blis5 = false;
                }
                Thread.Sleep(1000);
                Application.DoEvents();

                if(Stand1List!=null)
                {
                    if(Stand1List.Text.Length > 10 && Stand1List.Text.Trim().Substring(2,8).Trim() == "进入[1轧]" && Stand1List.AccessibleDescription == null)
                    {
                        Stand1List.AccessibleDescription = "OK";
                        bool flagu = this.kepOpc.itemValue[19] == "True";
                        if (flagu == true)
                        {
                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                            //Thread.Sleep(3000);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                            int intn = 0;
                            while (true)
                            {
                                Thread.Sleep(100);
                                Application.DoEvents();
                                intn++;
                                if (intn > 30)
                                {
                                    break;
                                }
                            }
                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                        }
                    }
                }

                if (Stand2List != null)
                {
                    if (Stand2List.Text.Length > 10 && Stand2List.Text.Trim().Substring(2, 8).Trim() == "进入[1轧]" && Stand2List.AccessibleDescription == null)
                    {
                        Stand2List.AccessibleDescription = "OK";
                        bool flagu = this.kepOpc.itemValue[31] == "True";
                        if (flagu == true)
                        {
                            this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                            //Thread.Sleep(3000);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                            int intn = 0;
                            while (true)
                            {
                                Thread.Sleep(100);
                                Application.DoEvents();
                                intn++;
                                if (intn > 30)
                                {
                                    break;
                                }
                            }
                            this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                        }
                    }
                }

                if (Stand3List != null)
                {
                    if (Stand3List.Text.Length > 10 && Stand3List.Text.Trim().Substring(2, 8).Trim() == "进入[1轧]" && Stand3List.AccessibleDescription == null)
                    {
                        Stand3List.AccessibleDescription = "OK";
                        bool flagu = this.kepOpc.itemValue[43] == "True";
                        if (flagu == true)
                        {
                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                            //Thread.Sleep(3000);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                            int intn = 0;
                            while (true)
                            {
                                Thread.Sleep(100);
                                Application.DoEvents();
                                intn++;
                                if (intn > 30)
                                {
                                    break;
                                }
                            }
                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                        }
                    }
                }

                if (Stand4List != null)
                {
                    if (Stand4List.Text.Length > 10 && Stand4List.Text.Trim().Substring(2, 8).Trim() == "进入[1轧]" && Stand4List.AccessibleDescription == null)
                    {
                        Stand4List.AccessibleDescription = "OK";
                        bool flagu = this.kepOpc.itemValue[55] == "True";
                        if (flagu == true)
                        {
                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                            //Thread.Sleep(3000);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                            int intn = 0;
                            while (true)
                            {
                                Thread.Sleep(100);
                                Application.DoEvents();
                                intn++;
                                if (intn > 30)
                                {
                                    break;
                                }
                            }
                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                        }
                    }
                }

                if (Stand5List != null)
                {
                    if (Stand5List.Text.Length > 10 && Stand5List.Text.Trim().Substring(2, 8).Trim() == "进入[1轧]" && Stand5List.AccessibleDescription == null)
                    {
                        Stand5List.AccessibleDescription = "OK";
                        bool flagu = this.kepOpc.itemValue[67] == "True";
                        if (flagu == true)
                        {
                            this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                            //Thread.Sleep(3000);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                            int intn = 0;
                            while (true)
                            {
                                Thread.Sleep(100);
                                Application.DoEvents();
                                intn++;
                                if (intn > 30)
                                {
                                    break;
                                }
                            }
                            this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                        }
                    }
                }
            }
        }

        void getFourResult()
        {
            bool blis0 = false, blis1 = false, blis2 = false, blis3 = false, blis4 = false, blis5 = false, blis6 = false;
            while (true)
            {
                bool flag0 = this.kepOpc.itemValue[179] == "True";
                if (flag0)
                {
                    if (blis0 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "0流收到翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                        blis0 = true;
                    }
                }
                else
                {
                    blis0 = false;
                }
                flag0 = this.kepOpc.itemValue[180] == "True";
                if (flag0)
                {
                    if (blis1 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "1流收到翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                        blis1 = true;
                    }
                }
                else
                {
                    blis1 = false;
                }
                flag0 = this.kepOpc.itemValue[181] == "True";
                if (flag0)
                {
                    if (blis2 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "2流收到翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                        blis2 = true;
                    }
                }
                else
                {
                    blis2 = false;
                }
                flag0 = this.kepOpc.itemValue[182] == "True";
                if (flag0)
                {
                    if (blis3 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "3流收到翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                        blis3 = true;
                    }
                }
                else
                {
                    blis3 = false;
                }
                flag0 = this.kepOpc.itemValue[183] == "True";
                if (flag0)
                {
                    if (blis4 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "4流收到翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                        blis4 = true;
                    }
                }
                else
                {
                    blis4 = false;
                }
                flag0 = this.kepOpc.itemValue[184] == "True";
                if (flag0)
                {
                    if (blis5 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "5流收到翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                        blis5 = true;
                    }
                }
                else
                {
                    blis5 = false;
                }
                flag0 = this.kepOpc.itemValue[185] == "True";
                if (flag0)
                {
                    if (blis6 == false)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "6流收到翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                        blis6 = true;
                    }
                }
                else
                {
                    blis6 = false;
                }

                if (intalarm[0] == 1)
                {
                    if(btn0Continue.Visible == false)
                    btn0Continue.Visible = true;
                }
                if (intalarm[1] == 1)
                {
                    if (btn1Continue.Visible == false)
                        btn1Continue.Visible = true;
                }
                if (intalarm[2] == 1)
                {
                    if (btn2Continue.Visible == false)
                        btn2Continue.Visible = true;
                }
                if (intalarm[3] == 1)
                {
                    if (btn3Continue.Visible == false)
                        btn3Continue.Visible = true;
                }
                if (intalarm[4] == 1)
                {
                    if (btn4Continue.Visible == false)
                        btn4Continue.Visible = true;
                }
                if (intalarm[5] == 1)
                {
                    if (btn5Continue.Visible == false)
                        btn5Continue.Visible = true;
                }
                if (intalarm[6] == 1)
                {
                    if (btn6Continue.Visible == false)
                        btn6Continue.Visible = true;
                }
                Thread.Sleep(1000);
                Application.DoEvents();
            }
        }

        void getFourSteelRolling()
        {
            while (true)
            {
                bool flag = this.kepOpc.itemValue[210] == "True";
                if (flag)
                {
                    while (true)
                    {
                        intfoursteelrollingsecond++;
                        if (Rolling4Run.ConveyorDirection != ConveyorDirection.Backward)
                        {
                            Rolling4Run.Invoke((MethodInvoker)delegate
                            {
                                Rolling4Run.ConveyorDirection = ConveyorDirection.Backward;
                            });
                        }
                        if (intfoursteelrollingsecond >= intHL)
                        {
                            intfoursteelrollingsecond = 0;
                            break;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Application.DoEvents();
                        }
                    }
                }
                Thread.Sleep(100);
                
            }
        }

        int intR1 = 0,intS1 = 0;
        bool blcontinue1 = false, bloneroll = true;
        void getRuns1()
        {
            blcontinue1 = true;
            while (blIsRun1)
            {
                if (isRun1 == true)
                {
                    try
                    {
                                Stand1List.Left += 9;
                                intS1++;
                                if (intS1 == 10)
                                {
                                    intS1 = 0;
                                    intR1++;
                                    string strr = "";
                                    if (blonerolling[1] == true)
                                    {
                                        Stand1List.BackColor = Color.Green;
                                        strr = "1轧";
                                    }
                                    else if (blstop[1] == true)
                                    {
                                        strr = "起挡板1轧";
                                    }
                                    else if (blrolling[1] == true)
                                    {
                                        strr = strone1;
                                        //准备翻钢
                                        //检查移钢机的位置
                                    }
                                    else if (blcb[1] == true)
                                    {
                                        strr = strtwo1;
                                    }
                                    if (intwait[0] != 0)
                                    {
                                        strr += "(等待" + intwait[0] + "秒)";
                                    }
                                    Stand1List.Text = "1流进入[" + strr + "](" + intR1 + ")";

                            if (intR1 > (intGD + 33))
                            {
                                gcRunList.Rows.Add();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "1流辊道运输异常";
                                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('1流辊道运输异常','" + DateTime.Now.ToString() + "')");

                                if (blonerolling[1] == true)
                                {
                                    SteelRollingStand = -1;
                                    WaitingSteelRolling = -1;
                                }

                                bltp[1] = 1;
                                blIsRun1 = false;
                                plAlarm.Left = 220;
                                plAlarm.Top = btn1Continue.Top;
                                lbAlarmStr.Text = "1流辊道运输超时，请检查！";
                                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                                intalarm[1] = 1;
                                waveOut.Play();

                                Stand1List.Tag = null;
                                Controls.Remove(Stand1List);
                                Stand1List.Dispose();
                                Application.DoEvents();
                            }
                            else
                            {
                                if (blcontinue1 == true)
                                {
                                    bool flag = this.kepOpc.itemValue[18] == "True";
                                    if (flag)
                                    {
                                        Stand1List.ForeColor = Color.Yellow;
                                        if (blonerolling[1] == true)
                                        {
                                            bool blzg = this.kepOpc.itemValue[161] == "True";
                                            if (blzg)
                                            {
                                                if (intwait[0] != 0)
                                                {
                                                    int intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intsteelrollingsecond == 0)
                                                        {
                                                            break;
                                                        }
                                                        else if(bloneroll == false)
                                                        {
                                                            return;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                                    Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                    threadOneSteelRolling.Start();
                                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                    intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intn > 30)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);

                                                    SteelRollingStand = 99;
                                                    intwait[0] = 0;
                                                }
                                                else
                                                {
                                                    bool flagu = this.kepOpc.itemValue[19] == "True";
                                                    if (flagu == true)
                                                    {
                                                        this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                        //Thread.Sleep(3000);
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                        int intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 30)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                                                    }
                                                    else
                                                    {
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                    }
                                                }

                                                blIsRun1 = false;
                                                isRun1 = false;
                                                Stand1List.Tag = null;
                                                Controls.Remove(Stand1List);
                                                Stand1List.Dispose();
                                                Application.DoEvents();
                                            }
                                            else
                                            {
                                                intsteelrollingsecond = 0;
                                                ucsteelrolling.LiquidDirection = LiquidDirection.None;
                                                OneRolling.Text = "1" + Environment.NewLine + "轧";
                                                SteelRollingStand = -1;
                                            }
                                        }
                                        else if (blrolling[1] == true || blcb[1] == true)
                                        {
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "1流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                            //Thread.Sleep(3000);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "1流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                            //Thread.Sleep(3000);
                                            intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 0);
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 0);
                                            blIsRun1 = false;

                                            isRun1 = false;

                                            Stand1List.Tag = null;

                                            Application.DoEvents();

                                        }
                                        blcontinue1 = false;
                                    }
                                }
                                else
                                {
                                    if (intR1 > (intGD - 5))
                                    {
                                        blIsRun1 = false;
                                        isRun1 = false;

                                        Stand1List.Tag = null;
                                        Controls.Remove(Stand1List);
                                        Stand1List.Dispose();
                                        Application.DoEvents();
                                    }

                                }
                            }
                                }

                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                        blIsRun1 = false;
                        isRun1 = false;

                    }
                }
                else
                {
                    break;
                }

            }
        }

        int intR2 = 0, intS2 = 0;
        bool blcontinue2 = false;
        void getRuns2()
        {
            blcontinue2 = true;
            while (blIsRun2)
            {
                    if (isRun2 == true)
                    {
                        try
                        {

                                    Stand2List.Left += 9;
                                    intS2++;
                                    if (intS2 == 10)
                                    {
                                        intS2 = 0;
                                        intR2++;
                                        string strr = "";
                                        if (blonerolling[2] == true)
                                        {
                                            strr = "1轧";
                                            Stand2List.BackColor = Color.Green;
                                        }
                                        else if (blstop[2] == true)
                                        {
                                            strr = "起挡板1轧";
                                        }
                                        else if (blrolling[2] == true)
                                        {
                                            strr = strone2;
                                        }
                                        else if (blcb[2] == true)
                                        {
                                            strr = strtwo2;
                                        }
                                        if (intwait[1] != 0)
                                        {
                                            strr += "(等待" + intwait[1] + "秒)";
                                        }
                                        Stand2List.Text = "2流进入[" + strr + "](" + intR2 + ")";
                         
                                        if (intR2 > (intGD + 33))
                                        {
                                            gcRunList.Rows.Add();
                                            gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                                            gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "2流辊道运输异常";
                                            SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('2流辊道运输异常','" + DateTime.Now.ToString() + "')");

                                            if (blonerolling[2] == true)
                                            {
                                                SteelRollingStand = -1;
                                                WaitingSteelRolling = -1;
                                            }
                                bltp[2] = 1;
                                blIsRun2 = false;
                                plAlarm.Left = 220;
                                plAlarm.Top = btn2Continue.Top;
                                lbAlarmStr.Text = "2流辊道运输超时，请检查！";
                                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                                intalarm[2] = 1;
                                            waveOut.Play();
                                            Stand2List.Tag = null;
                                            Controls.Remove(Stand2List);
                                Stand2List.Dispose();
                                            Application.DoEvents();
                            }
                                        else
                                        {
                                            if (blcontinue2 == true)
                                            {
                                                bool flag = this.kepOpc.itemValue[30] == "True";
                                                if (flag)
                                                {
                                                    Stand2List.ForeColor = Color.Yellow;

                                                    if (blonerolling[2] == true)
                                                    {
                                                        bool blzg = this.kepOpc.itemValue[161] == "True";
                                                        if (blzg)
                                                        {
                                                if (intwait[1] != 0)
                                                {
                                                    int intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intsteelrollingsecond == 0)
                                                        {
                                                            break;
                                                        }
                                                        else if (bloneroll == false)
                                                        {
                                                            return;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                                    Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                    threadOneSteelRolling.Start();
                                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                    intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intn > 30)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                                                    SteelRollingStand = 99;
                                                    intwait[1] = 0;
                                                }
                                                else
                                                {
                                                    bool flagu = this.kepOpc.itemValue[31] == "True";
                                                    if (flagu == true)
                                                    {
                                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                        int intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 30)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                                                    }
                                                    else
                                                    {
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                    }
                                                }
                                                           
                                                blIsRun2 = false;
                                                isRun2 = false;
                                                Stand2List.Tag = null;
                                                Controls.Remove(Stand2List);
                                                Stand2List.Dispose();
                                                Application.DoEvents();
                                            }
                                                        else
                                                        {
                                                            intsteelrollingsecond = 0;
                                                            ucsteelrolling.LiquidDirection = LiquidDirection.None;
                                                            OneRolling.Text = "1" + Environment.NewLine + "轧";
                                                            SteelRollingStand = -1;
                                                        }
                                                    }
                                                    else if (blrolling[2] == true || blcb[2] == true)
                                                    {
                                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 1);
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "2流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                                 
                                                        int intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 20)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 1);
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "2流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                                
                                                        intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 20)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 0);
                                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 0);
                                                        blIsRun2 = false;

                                                        isRun2 = false;

                                                        Stand2List.Tag = null;
                                            Application.DoEvents();
                                            //准备翻钢
                                            //检查移钢机的位置
                                        }
                                                    blcontinue2 = false;
                                                }
                                            }
                                            else
                                            {
                                                if (intR2 > (intGD - 5))
                                                {
                                                    blIsRun2 = false;

                                                    isRun2 = false;
                                                    Stand2List.Tag = null;
                                                    Controls.Remove(Stand2List);
                                        Stand2List.Dispose();
                                        Application.DoEvents();
                                    }
                                            }
                                        }
                                    }
                            Thread.Sleep(100);
                        }
                        catch (Exception ex)
                        {
                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                            blIsRun2 = false;
                            isRun2 = false;
                        }
                    }
                    else
                    {
                        break;
                    }
            }
        }

        int intR3 = 0, intS3 = 0;
        bool blcontinue3 = false;
        void getRuns3()
        {
            blcontinue3 = true;
            while (blIsRun3)
            {
                if (isRun3 == true)
                {
                    try
                    {
                        Stand3List.Left += 9;
                        intS3++;
                        if (intS3 == 10)
                        {
                            intS3 = 0;
                            intR3++;
                            string strr = "";
                            if (blonerolling[3] == true)
                            {
                                strr = "1轧";
                                Stand3List.BackColor = Color.Green;
                            }
                            else if (blstop[3] == true)
                            {
                                strr = "起挡板1轧";
                            }
                            else if (blrolling[3] == true)
                            {
                                strr = strone3;
                            }
                            else if (blcb[3] == true)
                            {
                                strr = strtwo3;
                            }
                            if (intwait[2] != 0)
                            {
                                strr += "(等待" + intwait[2] + "秒)";
                            }
                            Stand3List.Text = "3流进入[" + strr + "](" + intR3 + ")";

                            if (intR3 > (intGD + 33))
                            {
                                gcRunList.Rows.Add();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "3流辊道运输异常";
                                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('3流辊道运输异常','" + DateTime.Now.ToString() + "')");
                                if (blonerolling[3] == true)
                                {
                                    SteelRollingStand = -1;
                                    WaitingSteelRolling = -1;
                                }
                                bltp[3] = 1;
                                blIsRun3 = false;
                                plAlarm.Left = 220;
                                plAlarm.Top = btn3Continue.Top;
                                lbAlarmStr.Text = "3流辊道运输超时，请检查！";
                                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                                intalarm[3] = 1;
                                waveOut.Play();
                                Stand3List.Tag = null;
                                Controls.Remove(Stand3List);
                                Stand3List.Dispose();
                                Application.DoEvents();
                            }
                            else
                            {
                                if (blcontinue3 == true)
                                {
                                    bool flag = this.kepOpc.itemValue[42] == "True";
                                    if (flag)
                                    {
                                        Stand3List.ForeColor = Color.Yellow;
                                        if (blonerolling[3] == true)
                                        {
                                            bool blzg = this.kepOpc.itemValue[161] == "True";
                                            if (blzg)
                                            {
                                                if (intwait[2] != 0)
                                                {
                                                    int intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intsteelrollingsecond == 0)
                                                        {
                                                            break;
                                                        }
                                                        else if (bloneroll == false)
                                                        {
                                                            return;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                                    Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                    threadOneSteelRolling.Start();
                                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                    intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intn > 30)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                                                    SteelRollingStand = 99;
                                                    intwait[2] = 0;
                                                }
                                                else
                                                {
                                                    bool flagu = this.kepOpc.itemValue[43] == "True";
                                                    if (flagu == true)
                                                    {
                                                        this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                        int intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 30)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                                                    }
                                                    else
                                                    {
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                    }
                                                }


                                                blIsRun3 = false;

                                                isRun3 = false;
                                                Stand3List.Tag = null;
                                                Controls.Remove(Stand3List);
                                                Stand3List.Dispose();
                                                Application.DoEvents();
                                            }
                                            else
                                            {
                                                intsteelrollingsecond = 0;
                                                ucsteelrolling.LiquidDirection = LiquidDirection.None;
                                                OneRolling.Text = "1" + Environment.NewLine + "轧";
                                                SteelRollingStand = -1;
                                            }
                                        }
                                        else if (blrolling[3] == true || blcb[3] == true)
                                        {
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "3流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "3流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                            intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 0);
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 0);
                                            blIsRun3 = false;
                                            isRun3 = false;
                                            Stand3List.Tag = null;
                                            Application.DoEvents();
                                        }
                                        blcontinue3 = false;
                                    }
                                }
                                else
                                {
                                    if (intR3 > (intGD - 5))
                                    {
                                        blIsRun3 = false;
                                        isRun3 = false;
                                        Stand3List.Tag = null;
                                        Controls.Remove(Stand3List);
                                        Stand3List.Dispose();
                                    }
                                }
                            }
                        }
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                        blIsRun3 = false;

                        isRun3 = false;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        int intR4 = 0, intS4 = 0;
        bool blcontinue4 = false;
        void getRuns4()
        {
            blcontinue4 = true;
            while (blIsRun4)
            {
                if (isRun4 == true)
                {
                    try
                    {
                        Stand4List.Left += 9;
                        intS4++;
                        if (intS4 == 10)
                        {
                            intS4 = 0;
                            intR4++;
                            string strr = "";
                            if (blonerolling[4] == true)
                            {
                                strr = "1轧";
                                Stand4List.BackColor = Color.Green;
                            }
                            else if (blstop[4] == true)
                            {
                                strr = "起挡板1轧";
                            }
                            else if (blrolling[4] == true)
                            {
                                strr = strone4;
                            }
                            else if (blcb[4] == true)
                            {
                                strr = strtwo4;
                            }
                            if (intwait[3] != 0)
                            {
                                strr += "(等待" + intwait[3] + "秒)";
                            }
                            Stand4List.Text = "4流进入[" + strr + "](" + intR4 + ")";
                            if (intR4 > (intGD + 33))
                            {
                                gcRunList.Rows.Add();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "4流辊道运输异常";
                                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('4流辊道运输异常','" + DateTime.Now.ToString() + "')");
                                if (blonerolling[4] == true)
                                {
                                    SteelRollingStand = -1;
                                    WaitingSteelRolling = -1;
                                }
                                bltp[4] = 1;
                                blIsRun4 = false;
                                plAlarm.Left = 220;
                                plAlarm.Top = btn4Continue.Top;
                                lbAlarmStr.Text = "4流辊道运输超时，请检查！";
                                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                                intalarm[4] = 1;
                                waveOut.Play();
                                Stand4List.Tag = null;
                                Controls.Remove(Stand4List);
                                Stand4List.Dispose();
                                Application.DoEvents();
                            }
                            else
                            {
                                if (blcontinue4 == true)
                                {
                                    bool flag = this.kepOpc.itemValue[54] == "True";
                                    if (flag)
                                    {
                                        Stand4List.ForeColor = Color.Yellow;
                                        if (blonerolling[4] == true)
                                        {
                                            bool blzg = this.kepOpc.itemValue[161] == "True";
                                            if (blzg)
                                            {
                                                if (intwait[3] != 0)
                                                {
                                                    int intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intsteelrollingsecond == 0)
                                                        {
                                                            break;
                                                        }
                                                        else if (bloneroll == false)
                                                        {
                                                            return;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                                    Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                    threadOneSteelRolling.Start();
                                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                    intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intn > 30)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                                                    SteelRollingStand = 99;
                                                    intwait[3] = 0;
                                                }
                                                else
                                                {
                                                    bool flagu = this.kepOpc.itemValue[55] == "True";
                                                    if (flagu == true)
                                                    {
                                                        this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                        int intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 30)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                                                    }
                                                    else
                                                    {
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                    }
                                                }

                                                blIsRun4 = false;

                                                isRun4 = false;
                                                Stand4List.Tag = null;
                                                Controls.Remove(Stand4List);
                                                Stand4List.Dispose();
                                                Application.DoEvents();
                                            }
                                            else
                                            {
                                                intsteelrollingsecond = 0;
                                                ucsteelrolling.LiquidDirection = LiquidDirection.None;
                                                OneRolling.Text = "1" + Environment.NewLine + "轧";
                                                SteelRollingStand = -1;
                                            }
                                        }
                                        else if (blrolling[4] == true || blcb[4] == true)
                                        {
                                            //准备翻钢
                                            //检查移钢机的位置
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "4流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "4流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                            intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 0);
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 0);
                                            blIsRun4 = false;
                                            isRun4 = false;
                                            Stand4List.Tag = null;
                                            Application.DoEvents();
                                        }
                                        blcontinue4 = false;
                                    }
                                }
                                else
                                {
                                    if (intR4 > (intGD - 5))
                                    {
                                        blIsRun4 = false;
                                        isRun4 = false;
                                        Stand4List.Tag = null;
                                        Controls.Remove(Stand4List);
                                        Stand4List.Dispose();
                                        Application.DoEvents();
                                    }
                                }
                            }
                        }
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                        blIsRun4 = false;
                        isRun4 = false;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        int intR5 = 0, intS5 = 0;
        bool blcontinue5 = false;
        void getRuns5()
        { 
            blcontinue5 = true;
            while (blIsRun5)
            {
                    if (isRun5 == true)
                    {
                        try
                        {
                                    Stand5List.Left += 9;
                                    intS5++;
                                    if (intS5 == 10)
                                    {
                                        intS5 = 0;
                                        intR5++;
                                        string strr = "";
                                        if (blonerolling[5] == true)
                                        {
                                            strr = "1轧";
                                            Stand5List.BackColor = Color.Green;
                                        }
                                        else if (blstop[5] == true)
                                        {
                                            strr = "起挡板1轧";
                                        }
                                        else if (blrolling[5] == true)
                                        {
                                            strr = strone5;
                                        }
                                        else if (blcb[5] == true)
                                        {
                                            strr = strtwo5;
                                        }
                                        if (intwait[4] != 0)
                                        {
                                            strr += "(等待" + intwait[4] + "秒)";
                                        }
                                        Stand5List.Text = "5流进入[" + strr + "](" + intR5 + ")";
                                
                                        if (intR5 > (intGD + 33))
                                        {
                                            gcRunList.Rows.Add();
                                            gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                                            gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "5流辊道运输异常";
                                            SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('5流辊道运输异常','" + DateTime.Now.ToString() + "')");
                                            if (blonerolling[5] == true)
                                            {
                                                SteelRollingStand = -1;
                                                WaitingSteelRolling = -1;
                                            }
                                bltp[5] = 1;
                                blIsRun5 = false;
                                plAlarm.Left = 220;
                                plAlarm.Top = btn5Continue.Top;
                                lbAlarmStr.Text = "5流辊道运输超时，请检查！";
                                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                                intalarm[5] = 1;
                                            waveOut.Play();
                                            Stand5List.Tag = null;
                                            Controls.Remove(Stand5List);
                                Stand5List.Dispose();
                                            Application.DoEvents();
                            }
                                        else
                                        {
                                            if (blcontinue5 == true)
                                            {
                                                bool flag = this.kepOpc.itemValue[66] == "True";
                                                if (flag)
                                                {
                                                    Stand5List.ForeColor = Color.Yellow;
                                                    if (blonerolling[5] == true)
                                                    {
                                                        bool blzg = this.kepOpc.itemValue[161] == "True";
                                            if (blzg)
                                            {
                                                if (intwait[4] != 0)
                                                {
                                                    int intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intsteelrollingsecond == 0)
                                                        {
                                                            break;
                                                        }
                                                        else if (bloneroll == false)
                                                        {
                                                            return;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                                    Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                    threadOneSteelRolling.Start();
                                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                    intn = 0;
                                                    while (true)
                                                    {
                                                        Thread.Sleep(100);
                                                        Application.DoEvents();
                                                        intn++;
                                                        if (intn > 30)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                                                    SteelRollingStand = 99;
                                                    intwait[4] = 0;
                                                }
                                                else
                                                {
                                                    bool flagu = this.kepOpc.itemValue[67] == "True";
                                                    if (flagu == true)
                                                    {
                                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                        int intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 30)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                                                    }
                                                    else
                                                    {
                                                        Thread threadOneSteelRolling = new Thread(new ThreadStart(getOneSteelRolling));
                                                        threadOneSteelRolling.Start();
                                                    }
                                                }

                                                blIsRun5 = false;

                                                isRun5 = false;
                                                Stand5List.Tag = null;
                                                Controls.Remove(Stand5List);
                                                Stand5List.Dispose();
                                                Application.DoEvents();
                                            }
                                            else
                                            {
                                                intsteelrollingsecond = 0;
                                                ucsteelrolling.LiquidDirection = LiquidDirection.None;
                                                OneRolling.Text = "1" + Environment.NewLine + "轧";
                                                SteelRollingStand = -1;
                                            }
                                                    }
                                                    else if (blrolling[5] == true || blcb[5] == true)
                                                    {
                                                        //准备翻钢
                                                        //检查移钢机的位置
                                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 1);
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "5流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
          
                                                        int intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 20)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 1);
                                                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "5流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
              
                                                        intn = 0;
                                                        while (true)
                                                        {
                                                            Thread.Sleep(100);
                                                            Application.DoEvents();
                                                            intn++;
                                                            if (intn > 20)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 0);
                                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 0);
                                                        blIsRun5 = false;

                                                        isRun5 = false;

                                                        Stand5List.Tag = null;
                                            Application.DoEvents();
                                        }
                                                    blcontinue5 = false;
                                                }
                                            }
                                            else
                                            {
                                                if (intR5 > (intGD - 5))
                                                {
                                                    blIsRun5 = false;

                                                    isRun5 = false;
                                                    Stand5List.Tag = null;
                                                    Controls.Remove(Stand5List);
                                        Stand5List.Dispose();
                                        Application.DoEvents();
                                    }

                                            }
                                        }
                                    }
                            Thread.Sleep(100);
                        }
                        catch (Exception ex)
                        {
                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                            blIsRun5 = false;

                            isRun5 = false;
                        }
                    }
                    else
                    {
                        break;
                    }
            }
        }

        int intR6 = 0, intS6 = 0;
        bool blcontinue6 = false;
        void getRuns6()
        {
            blcontinue6 = true;
            while (blIsRun6)
            {
                if (isRun6 == true)
                {
                    try
                    {
                        // intR6++;
                        //Stand6List.Invoke(new Action(() =>
                        //    {
                        Stand6List.Left += 9;
                        intS6++;
                        if (intS6 == 10)
                        {
                            intS6 = 0;
                            intR6++;
                            string strr = "";
                            if (blonerolling[6] == true)
                            {
                                strr = "1轧";
                            }
                            else if (blstop[6] == true)
                            {
                                strr = "起挡板1轧";
                            }
                            else if (blrolling[6] == true)
                            {
                                strr = strone6;
                            }
                            else if (blcb[6] == true)
                            {
                                strr = strtwo6;
                            }

                            Stand6List.Text = "6流进入[" + strr + "](" + intR6 + ")";

                            if (intR6 > (intGD + 33))
                            {
                                gcRunList.Rows.Add();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "6流辊道运输异常";
                                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('6流辊道运输异常','" + DateTime.Now.ToString() + "')");

                                bltp[6] = 1;
                                blIsRun6 = false;
                                plAlarm.Left = 220;
                                plAlarm.Top = btn6Continue.Top;
                                lbAlarmStr.Text = "6流辊道运输超时，请检查！";
                                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                                intalarm[6] = 1;
                                waveOut.Play();
                                Stand6List.Tag = null;
                                Controls.Remove(Stand6List);
                                Stand6List.Dispose();
                                Application.DoEvents();
                            }
                            else
                            {
                                if (blcontinue6 == true)
                                {
                                    bool flag = this.kepOpc.itemValue[78] == "True";
                                    if (flag)
                                    {
                                        Stand6List.ForeColor = Color.Yellow;
                                        isRun6 = false;
                                        if (blrolling[6] == true || blcb[6] == true)
                                        {
                                            //准备翻钢
                                            //检查移钢机的位置
                                            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "6流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                            //Thread.Sleep(3000);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }

                                            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "6流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                                            //Thread.Sleep(3000);
                                            intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 20)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 0);
                                            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 0);

                                            blIsRun6 = false;
                                            isRun6 = false;
                                            Stand6List.Tag = null;
                                            Application.DoEvents();
                                        }
                                        blcontinue6 = false;

                                    }
                                }
                                else
                                {
                                    if (intR6 > (intGD - 5))
                                    {
                                        blIsRun6 = false;
                                        isRun6 = false;
                                        Stand6List.Tag = null;
                                        Controls.Remove(Stand6List);
                                        Stand6List.Dispose();
                                        Application.DoEvents();
                                    }
                                }
                            }
                        }
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                        blIsRun6 = false;
                        isRun6 = false;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        List<int> fslist = new List<int>();
        public static int SteelRollingStand = -1, WaitingSteelRolling = -1;
        int ReturnFurnaceStand = -1, WaitingReturnFurnace = -1;
        bool[] blonerolling = new bool[7];
        bool[] blstop = new bool[7];
        bool[] blrolling = new bool[7];
        bool[] blcb = new bool[7];
        double[] points = new double[11];
        int[] intwait = new int[5];
        // int intfour = 0;

        void STWait(int intStand)
        {
            try
            {
                int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
                if (intstart == 1)
                {
                    if (FlipSteelList != null && FlipSteelList.Count == 0 && bliswait == false)
                    {
                        if (intStand == 0)
                        {
                            intStand = 7;
                        }
                        bliswait = true;
                        this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1Wait", intStand);
                    }
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
            }
        }

        bool bliswait = false;
        void GenerateProcess(int intStand)
        {
            try
            {
                blonerolling[intStand] = false;
                blstop[intStand] = false;
                blrolling[intStand] = false;
                blcb[intStand] = false;

                if (intgo4 > 0)
                {
                    STWait(intStand);
                    ReturnFurnaceStand = intStand;
                    WaitingReturnFurnace = intStand;
                    blrolling[intStand] = true;
                    bltp[intStand] = 1;
                    intgo4--;
                    txtGo4.Text = intgo4.ToString();
                    return;
                }
                if(intgocold > 0)
                {
                    ReturnFurnaceStand = intStand;
                    WaitingReturnFurnace = intStand;
                    blcb[intStand] = true;
                    bltp[intStand] = 2;
                    intgocold--;
                    txtGoCold.Text = intgocold.ToString();
                    return;
                }
                if (bltp[intStand] == 1)
                {
                    STWait(intStand);
                    ReturnFurnaceStand = intStand;
                    WaitingReturnFurnace = intStand;
                    blrolling[intStand] = true;
                    return;
                }
                else if (bltp[intStand] == 2)
                {
                    ReturnFurnaceStand = intStand;
                    WaitingReturnFurnace = intStand;
                    blcb[intStand] = true;
                    return;
                }
                bool bloneopt = false, blfouropt = false;
                if (intStand == 1)
                {
                    bloneopt = this.kepOpc.itemValue[199] == "True";
                    if (bloneopt == true)
                    {
                        WaitingSteelRolling = intStand;
                        blonerolling[intStand] = true;
                        this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        int intn = 0;
                        while (true)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();
                            intn++;
                            if (intn > 30)
                            {
                                break;
                            }
                        }
                        this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                        return;
                    }
                    blfouropt = this.kepOpc.itemValue[204] == "True";
                    if (blfouropt == true)
                    {
                        STWait(intStand);
                        ReturnFurnaceStand = intStand;
                        WaitingReturnFurnace = intStand;
                        blrolling[intStand] = true;
                        return;
                    }
                }
                if (intStand == 2)
                {
                    bloneopt = this.kepOpc.itemValue[200] == "True";
                    if (bloneopt == true)
                    {
                        WaitingSteelRolling = intStand;
                        blonerolling[intStand] = true;
                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        int intn = 0;
                        while (true)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();
                            intn++;
                            if (intn > 30)
                            {
                                break;
                            }
                        }
                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                        return;
                    }
                    blfouropt = this.kepOpc.itemValue[205] == "True";
                    if (blfouropt == true)
                    {
                        STWait(intStand);
                        ReturnFurnaceStand = intStand;
                        WaitingReturnFurnace = intStand;
                        blrolling[intStand] = true;
                        return;
                    }
                }
                if (intStand == 3)
                {
                    bloneopt = this.kepOpc.itemValue[201] == "True";
                    if (bloneopt == true)
                    {
                        WaitingSteelRolling = intStand;
                        blonerolling[intStand] = true;
                        this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        int intn = 0;
                        while (true)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();
                            intn++;
                            if (intn > 30)
                            {
                                break;
                            }
                        }
                        this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                        return;
                    }
                    blfouropt = this.kepOpc.itemValue[206] == "True";
                    if (blfouropt == true)
                    {
                        STWait(intStand);
                        ReturnFurnaceStand = intStand;
                        WaitingReturnFurnace = intStand;
                        blrolling[intStand] = true;
                        return;
                    }
                }
                if (intStand == 4)
                {
                    bloneopt = this.kepOpc.itemValue[202] == "True";
                    if (bloneopt == true)
                    {
                        WaitingSteelRolling = intStand;
                        blonerolling[intStand] = true;
                        this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        int intn = 0;
                        while (true)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();
                            intn++;
                            if (intn > 30)
                            {
                                break;
                            }
                        }
                        this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                        return;
                    }
                    blfouropt = this.kepOpc.itemValue[207] == "True";
                    if (blfouropt == true)
                    {
                        STWait(intStand);
                        ReturnFurnaceStand = intStand;
                        WaitingReturnFurnace = intStand;
                        blrolling[intStand] = true;
                        return;
                    }
                }
                if (intStand == 5)
                {
                    bloneopt = this.kepOpc.itemValue[203] == "True";
                    if (bloneopt == true)
                    {
                        WaitingSteelRolling = intStand;
                        blonerolling[intStand] = true;
                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                        System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                        int intn = 0;
                        while (true)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();
                            intn++;
                            if (intn > 30)
                            {
                                break;
                            }
                        }
                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                        return;
                    }
                    blfouropt = this.kepOpc.itemValue[208] == "True";
                    if (blfouropt == true)
                    {
                        STWait(intStand);
                        ReturnFurnaceStand = intStand;
                        WaitingReturnFurnace = intStand;
                        blrolling[intStand] = true;
                        return;
                    }
                }
                if (intStand > 0 && intStand < 6)
                {
                    int intFixed = SqlBase.ExecuteSql4Int("select IsFixed from SysSet");
                    if (intFixed == 1)
                    {
                        bool blflag1 = this.kepOpc.itemValue[161] == "True";
                        bool blflag2 = this.kepOpc.itemValue[163] == "True";
                        if (blflag1 == true && blflag2 == true)
                        {
                            if (intStand == 1)
                            {
                                int intGo1 = SqlBase.ExecuteSql4Int("select Stand1Select from SysSet");
                                if (intGo1 == 0)
                                {
                                    blonerolling[intStand] = true;
                                    this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                    int intn = 0;
                                    while (true)
                                    {
                                        Thread.Sleep(100);
                                        Application.DoEvents();
                                        intn++;
                                        if (intn > 30)
                                        {
                                            break;
                                        }
                                    }
                                    this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                                }
                                else if (intGo1 == 1)
                                {
                                    STWait(intStand);
                                    blrolling[intStand] = true;
                                }
                            }
                            else if (intStand == 2)
                            {
                                int intGo2 = SqlBase.ExecuteSql4Int("select Stand2Select from SysSet");
                                if (intGo2 == 0)
                                {
                                    blonerolling[intStand] = true;
                                    this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                  
                                    int intn = 0;
                                    while (true)
                                    {
                                        Thread.Sleep(100);
                                        Application.DoEvents();
                                        intn++;
                                        if (intn > 30)
                                        {
                                            break;
                                        }
                                    }
                                    this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                                }
                                else if (intGo2 == 1)
                                {
                                    STWait(intStand);
                                    blrolling[intStand] = true;
                                }
                            }
                            else if (intStand == 3)
                            {
                                int intGo3 = SqlBase.ExecuteSql4Int("select Stand3Select from SysSet");
                                if (intGo3 == 0)
                                {
                                    blonerolling[intStand] = true;
                                    this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                    int intn = 0;
                                    while (true)
                                    {
                                        Thread.Sleep(100);
                                        Application.DoEvents();
                                        intn++;
                                        if (intn > 30)
                                        {
                                            break;
                                        }
                                    }
                                    this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                                }
                                else if (intGo3 == 1)
                                {
                                    STWait(intStand);
                                    blrolling[intStand] = true;
                                }
                            }
                            else if (intStand == 4)
                            {
                                int intGo4 = SqlBase.ExecuteSql4Int("select Stand4Select from SysSet");
                                if (intGo4 == 0)
                                {
                                    blonerolling[intStand] = true;
                                    this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                    int intn = 0;
                                    while (true)
                                    {
                                        Thread.Sleep(100);
                                        Application.DoEvents();
                                        intn++;
                                        if (intn > 30)
                                        {
                                            break;
                                        }
                                    }
                                    this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                                }
                                else if (intGo4 == 1)
                                {
                                    STWait(intStand);
                                    blrolling[intStand] = true;
                                }
                            }
                            else if (intStand == 5)
                            {
                                int intGo5 = SqlBase.ExecuteSql4Int("select Stand5Select from SysSet");
                                if (intGo5 == 0)
                                {
                                    blonerolling[intStand] = true;
                                    this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                    System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                    int intn = 0;
                                    while (true)
                                    {
                                        Thread.Sleep(100);
                                        Application.DoEvents();
                                        intn++;
                                        if (intn > 30)
                                        {
                                            break;
                                        }
                                    }
                                    this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                                }
                                else if (intGo5 == 1)
                                {
                                    STWait(intStand);
                                    blrolling[intStand] = true;
                                }
                            }
                        }
                        else if (blflag1 == true && blflag2 == false)
                        {
                            if (intStand == 1)
                            {
                                blonerolling[intStand] = true;
                                this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                int intn = 0;
                                while (true)
                                {
                                    Thread.Sleep(100);
                                    Application.DoEvents();
                                    intn++;
                                    if (intn > 30)
                                    {
                                        break;
                                    }
                                }
                                this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                            }
                            else if (intStand == 2)
                            {
                                blonerolling[intStand] = true;
                                this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                int intn = 0;
                                while (true)
                                {
                                    Thread.Sleep(100);
                                    Application.DoEvents();
                                    intn++;
                                    if (intn > 30)
                                    {
                                        break;
                                    }
                                }
                                this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                            }
                            else if (intStand == 3)
                            {
                                blonerolling[intStand] = true;
                                this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                int intn = 0;
                                while (true)
                                {
                                    Thread.Sleep(100);
                                    Application.DoEvents();
                                    intn++;
                                    if (intn > 30)
                                    {
                                        break;
                                    }
                                }
                                this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                            }
                            else if (intStand == 4)
                            {
                                blonerolling[intStand] = true;
                                this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                int intn = 0;
                                while (true)
                                {
                                    Thread.Sleep(100);
                                    Application.DoEvents();
                                    intn++;
                                    if (intn > 30)
                                    {
                                        break;
                                    }
                                }
                                this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                            }
                            else if (intStand == 5)
                            {
                                blonerolling[intStand] = true;
                                this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                int intn = 0;
                                while (true)
                                {
                                    Thread.Sleep(100);
                                    Application.DoEvents();
                                    intn++;
                                    if (intn > 30)
                                    {
                                        break;
                                    }
                                }
                                this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                            }
                        }
                        else if (blflag1 == false && blflag2 == true)
                        {
                            STWait(intStand);
                            ReturnFurnaceStand = intStand;
                            WaitingReturnFurnace = intStand;
                            blrolling[intStand] = true;
                        }
                        else if (blflag1 == false && blflag2 == false)
                        {
                            STWait(intStand);
                            ReturnFurnaceStand = intStand;
                            WaitingReturnFurnace = intStand;
                            blrolling[intStand] = true;
                        }
                    }
                    else
                    {
                        bool blflag1 = this.kepOpc.itemValue[161] == "True";
                        if (blflag1 == true)
                        {
                            bool blflag2 = this.kepOpc.itemValue[163] == "True";
                            if (blflag2 == true)
                            {
                                if (WaitingSteelRolling == -1)
                                {
                                    if (SteelRollingStand == -1)
                                    {
                                        SteelRollingStand = intStand;
                                        WaitingSteelRolling = intStand;
                                        blonerolling[intStand] = true;
                                        if (intStand == 1)
                                        {
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 2)
                                        {
                                            this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 3)
                                        {
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 4)
                                        {
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 5)
                                        {
                                            this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                                        }
                                        else
                                        {
                                            MessageBox.Show(intStand.ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (intStand == 1)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if(intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}

                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[0] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[0] = intwaits;
                                                    }
                                                    
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                        else if (intStand == 2)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                           
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[1] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[1] = intwaits;
                                                    }
                                                    
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;

                                            }
                                        }
                                        else if (intStand == 3)
                                        {
                                           
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[2] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[2] = intwaits;
                                                    }
                                                    
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                        else if (intStand == 4)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[3] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[3] = intwaits;
                                                    }
                                                    
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                        else if (intStand == 5)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[4] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[4] = intwaits;
                                                    }
                                                    
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    STWait(intStand);
                                    ReturnFurnaceStand = intStand;
                                    WaitingReturnFurnace = intStand;
                                    blrolling[intStand] = true;
                                }
                            }
                            else
                            {
                                if (WaitingSteelRolling == -1)
                                {
                                    if (SteelRollingStand == -1)
                                    {
                                        SteelRollingStand = intStand;
                                        WaitingSteelRolling = intStand;
                                        blonerolling[intStand] = true;
                                        if (intStand == 1)
                                        {
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            // Thread.Sleep(3000);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 2)
                                        {
                                            this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 3)
                                        {
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 4)
                                        {
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                                        }
                                        else if (intStand == 5)
                                        {
                                            this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                            System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                            int intn = 0;
                                            while (true)
                                            {
                                                Thread.Sleep(100);
                                                Application.DoEvents();
                                                intn++;
                                                if (intn > 30)
                                                {
                                                    break;
                                                }
                                            }
                                            this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                                        }
                                    }
                                    else
                                    {
                                        if (intStand == 1)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "1流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }

                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[0] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[0] = intwaits;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                        else if (intStand == 2)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "2流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc02.opc_plc2.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[1] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[1] = intwaits;
                                                    }
                                                    
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                        else if (intStand == 3)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "3流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                //   Thread.Sleep(3000);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc03.opc_plc3.DR_1Z RUN", 0);
                                                // intfour = 0;
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[2] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[2] = intwaits;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                        else if (intStand == 4)
                                        {
                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "4流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc04.opc_plc4.DR_1Z RUN", 0);
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM5 > 0)
                                                        {
                                                            intcutwait = 51 - intM5;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[3] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[3] = intwaits;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                        else if (intStand == 5)
                                        {

                                            if (((intGD) >= (intZG - intsteelrollingsecond)))
                                            {
                                                WaitingSteelRolling = intStand;
                                                blonerolling[intStand] = true;
                                                this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 1);
                                                System.IO.File.AppendAllText(Application.StartupPath + "\\LogDown.txt", "5流去1轧__时间是:" + DateTime.Now + Environment.NewLine);
                           
                                                int intn = 0;
                                                while (true)
                                                {
                                                    Thread.Sleep(100);
                                                    Application.DoEvents();
                                                    intn++;
                                                    if (intn > 30)
                                                    {
                                                        break;
                                                    }
                                                }
                                                this.kepOpc.WriteObj("opc_plc05.opc_plc5.DR_1Z RUN", 0);
                                             
                                            }
                                            else if ((intGD + intWT) > (intZG - intsteelrollingsecond))
                                            {
                                                if (intGD < (intZG - intsteelrollingsecond))
                                                {
                                                    int intwaits = (intZG - intsteelrollingsecond) - intGD;
                                                    if (intwaits >= 5)
                                                    {
                                                        int intcutwait = 0;
                                                        if (intM1 > 0)
                                                        {
                                                            intcutwait = 51 - intM1;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM2 > 0)
                                                        {
                                                            intcutwait = 51 - intM2;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM3 > 0)
                                                        {
                                                            intcutwait = 51 - intM3;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        if (intM4 > 0)
                                                        {
                                                            intcutwait = 51 - intM4;
                                                            int intabs = Math.Abs(intwaits - intcutwait);
                                                            if (intabs < 20)
                                                            {
                                                                STWait(intStand);
                                                                ReturnFurnaceStand = intStand;
                                                                WaitingReturnFurnace = intStand;
                                                                blrolling[intStand] = true;
                                                                return;
                                                            }
                                                        }
                                                        //int intfourtime = (intHL - intfoursteelrollingsecond - intFGD);
                                                        //if (intwaits > intfourtime)
                                                        //{
                                                        //    STWait(intStand);
                                                        //    ReturnFurnaceStand = intStand;
                                                        //    WaitingReturnFurnace = intStand;
                                                        //    blrolling[intStand] = true;
                                                        //    return;
                                                        //}
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[4] = intwaits;
                                                    }
                                                    else
                                                    {
                                                        WaitingSteelRolling = intStand;
                                                        blonerolling[intStand] = true;
                                                        intwait[4] = intwaits;
                                                    }
                                                    
                                                }
                                            }
                                            else
                                            {
                                                STWait(intStand);
                                                ReturnFurnaceStand = intStand;
                                                WaitingReturnFurnace = intStand;
                                                blrolling[intStand] = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    STWait(intStand);
                                    ReturnFurnaceStand = intStand;
                                    WaitingReturnFurnace = intStand;
                                    blrolling[intStand] = true;
                                }
                            }
                        }
                        else
                        {
                            WaitingSteelRolling = -1;
                            STWait(intStand);
                            ReturnFurnaceStand = intStand;
                            WaitingReturnFurnace = intStand;
                            blrolling[intStand] = true;
                        }
                    }
                }
                else
                {
                    STWait(intStand);
                    ReturnFurnaceStand = intStand;
                    WaitingReturnFurnace = intStand;
                    blrolling[intStand] = true;
                }

                if (blonerolling[intStand] == true)
                {
                    if (blFirst() == false)
                    {
                        blonerolling[intStand] = false;
                        blstop[intStand] = false;
                        blrolling[intStand] = false;
                        blcb[intStand] = false;
                        STWait(intStand);
                        ReturnFurnaceStand = intStand;
                        WaitingReturnFurnace = intStand;
                        blrolling[intStand] = true;

                    }
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
            }
        }

        bool blFirst()
        {
            try
            {
                if (Stand1List != null && Stand1List.IsDisposed == false)
                {
                    if (Stand1List.Text.Trim().Contains("1轧") == true)
                    {
                        return false;
                    }
                }

                if (Stand2List != null && Stand2List.IsDisposed == false)
                {
                    if (Stand2List.Text.Trim().Contains("1轧") == true)
                    {
                        return false;
                    }
                }

                if (Stand3List != null && Stand3List.IsDisposed == false)
                {
                    if (Stand3List.Text.Trim().Contains("1轧") == true)
                    {
                        return false;
                    }
                }
                if (Stand4List != null && Stand4List.IsDisposed == false)
                {
                    if (Stand4List.Text.Trim().Contains("1轧") == true)
                    {
                        return false;
                    }
                }
                if (Stand5List != null && Stand5List.IsDisposed == false)
                {
                    if (Stand5List.Text.Trim().Contains("1轧") == true)
                    {
                        return false;
                    }
                }

            }
            catch
            {

            }
            return true;
        }

        /// <summary>
        /// 获取终端挡板
        /// </summary>
        void getBaffle()
        {
            while (true)
            {
                try
                {
                    bool flagu = this.kepOpc.itemValue[7] == "True";
                    if (flagu)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL0.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL0.Height = 0;
                        }));
                    }

                    bool flagd = this.kepOpc.itemValue[8] == "True";
                    if (flagd)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH0.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH0.Height = 0;
                        }));
                    }

                    flagu = this.kepOpc.itemValue[19] == "True";
                    if (flagu)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL1.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL1.Height = 0;
                        }));
                    }

                    flagd = this.kepOpc.itemValue[20] == "True";
                    if (flagd)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH1.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH1.Height = 0;
                        }));
                    }

                    flagu = this.kepOpc.itemValue[31] == "True";
                    if (flagu)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL2.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL2.Height = 0;
                        }));
                    }

                    flagd = this.kepOpc.itemValue[32] == "True";
                    if (flagd)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH2.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH2.Height = 0;
                        }));
                    }

                    flagu = this.kepOpc.itemValue[43] == "True";
                    if (flagu)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL3.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL3.Height = 0;
                        }));
                    }

                    flagd = this.kepOpc.itemValue[44] == "True";
                    if (flagd)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH3.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH3.Height = 0;
                        }));
                    }

                    flagu = this.kepOpc.itemValue[55] == "True";
                    if (flagu)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL4.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL4.Height = 0;
                        }));
                    }

                    flagd = this.kepOpc.itemValue[56] == "True";
                    if (flagd)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH4.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH4.Height = 0;
                        }));
                    }

                    flagu = this.kepOpc.itemValue[67] == "True";
                    if (flagu)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL5.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL5.Height = 0;
                        }));
                    }

                    flagd = this.kepOpc.itemValue[68] == "True";
                    if (flagd)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH5.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH5.Height = 0;
                        }));
                    }

                    flagu = this.kepOpc.itemValue[79] == "True";
                    if (flagu)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL6.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbL6.Height = 0;
                        }));
                    }

                    flagd = this.kepOpc.itemValue[80] == "True";
                    if (flagd)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH6.Height = 50;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            pbH6.Height = 0;
                        }));
                    }
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// 获取有钢信号
        /// </summary>
        void getIsSteel()
        {
            while(true)
            {
                try
                {
                    bool flag0 = this.kepOpc.itemValue[6] == "True";
                    if (flag0)
                    {
                        Stand0Run3.BackColor = Color.Red;
                    }
                    else
                    {
                        Stand0Run3.BackColor = Color.Transparent;
                    }

                    bool flag1 = this.kepOpc.itemValue[18] == "True";
                    if (flag1)
                    {
                        Stand1Run3.BackColor = Color.Red;
                    }
                    else
                    {
                        Stand1Run3.BackColor = Color.Transparent;
                    }

                    bool flag2 = this.kepOpc.itemValue[30] == "True";
                    if (flag2)
                    {
                        Stand2Run3.BackColor = Color.Red;
                    }
                    else
                    {
                        Stand2Run3.BackColor = Color.Transparent;
                    }

                    bool flag3 = this.kepOpc.itemValue[42] == "True";
                    if (flag3)
                    {
                        Stand3Run3.BackColor = Color.Red;
                    }
                    else
                    {
                        Stand3Run3.BackColor = Color.Transparent;
                    }

                    bool flag4 = this.kepOpc.itemValue[54] == "True";
                    if (flag4)
                    {
                        Stand4Run3.BackColor = Color.Red;
                    }
                    else
                    {
                        Stand4Run3.BackColor = Color.Transparent;
                    }

                    bool flag5 = this.kepOpc.itemValue[66] == "True";
                    if (flag5)
                    {
                        Stand5Run3.BackColor = Color.Red;
                    }
                    else
                    {
                        Stand5Run3.BackColor = Color.Transparent;
                    }

                    bool flag6 = this.kepOpc.itemValue[78] == "True";
                    if (flag6)
                    {
                        Stand6Run3.BackColor = Color.Red;
                    }
                    else
                    {
                        Stand6Run3.BackColor = Color.Transparent;
                    }
                }
                catch
                {

                }

                Thread.Sleep(200);
            }
        }

        Thread threadRuns0, threadRuns1, threadRuns2, threadRuns3, threadRuns4, threadRuns5, threadRuns6;
        bool blstand0 = false;
        int intblIsRun0 = -1;
        void getCuts0()
        {
            while (blIsSRun0 == true)
            {
                try
                {
                    if (this.kepOpc.itemValue[0] != null)
                    {
                        bool blr = this.kepOpc.itemValue[0] == "True";
                        if (blr == true)
                        {
                            bool flag = this.kepOpc.itemValue[11] == "True";
                            if (intblIsRun0 == -1)
                            {
                                if (flag == false)
                                {
                                    intblIsRun0 = 0;
                                }
                                else
                                {
                                    intblIsRun0 = 1;
                                }
                            }
                            if (intblIsRun0 == 0)
                            {
                                if (flag)
                                {
                                    if (blstand0 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if(Stand0List!= null)
                                            {
                                                intR0 = 0;
                                                blis0 = false;
                                                if (FlipSteelList.Contains("0_0") == true)
                                                    FlipSteelList.Remove("0_0");
                                                if (FlipSteelList.Contains("0_1") == true)
                                                    FlipSteelList.Remove("0_1");
                                                this.Controls.Remove(Stand0List);
                                                Stand0List.Dispose();
                                            }
                                            Stand0List = new Button();
                                            Stand0List.BackColor = Color.OrangeRed;
                                            Stand0List.FlatStyle = FlatStyle.Popup;
                                            Stand0List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand0List.ForeColor = Color.White;
                                            
                                            Stand0List.Name = "Stand0";
                                            Stand0List.Size = new Size(275, 50);
                                            Stand0List.TabIndex = 29;
                                            Stand0List.Text = "0流正在切割";
                                            
                                            Stand0List.Left = Stand0.Left;
                                            Stand0List.Top = Stand0.Top - Stand0List.Height - 3;
                                            Controls.Add(Stand0List);
                                            Stand0List.BringToFront();
                                            Stand0List.ContextMenuStrip = cmschange;
                                            //Stand0List = (steelbillet);
                                            tStand0.Enabled = true;
                                        }));
                                        blstand0 = true;
                                    }
                                }
                                else if (flag == false && blstand0 == true)
                                {
                                    GenerateProcess(0);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc00.opc_plc0.DRT_BL_EXIST_T", 0);
                                     
                                        tStand0.Enabled = false;
                                        blstand0 = false;
                                        intM0 = 0;
                                        if (bltp[0] != 2)
                                            Stand0List.BackColor = Color.Red;
                                        else
                                            Stand0List.BackColor = endColor;
                                        Stand0List.ForeColor = Color.White;
                                        isRun0 = true;
                                        intS0 = 0;
                                        intR0 = 0;
                                        blIsRun0 = true;
                                       
                                        threadRuns0 = new Thread(new ThreadStart(getRuns0));       //0流钢坯监测
                                        threadRuns0.Start();
                                        if (blonerolling[0] == false)
                                        {
                                            intNum0 = 0;
                                            tColor0.Enabled = false;
                                            if (bltp[0] != 2)
                                                tColor0.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (blstand0 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand0List != null)
                                            {
                                                intR0 = 0;
                                                blis0 = false;
                                                if (FlipSteelList.Contains("0_0") == true)
                                                    FlipSteelList.Remove("0_0");
                                                if (FlipSteelList.Contains("0_1") == true)
                                                    FlipSteelList.Remove("0_1");
                                                this.Controls.Remove(Stand0List);
                                                Stand0List.Dispose();
                                            }
                                            Stand0List = new Button();
                                            Stand0List.BackColor = Color.OrangeRed;
                                            Stand0List.FlatStyle = FlatStyle.Popup;
                                            Stand0List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand0List.ForeColor = Color.White;

                                            Stand0List.Name = "Stand1";
                                            Stand0List.Size = new Size(275, 50);
                                            Stand0List.TabIndex = 29;
                                            Stand0List.Text = "0流正在切割";
                                            Stand0List.UseVisualStyleBackColor = false;
                                            Stand0List.Left = Stand0.Left;
                                            Stand0List.Top = Stand0.Top - Stand0List.Height - 3;
                                            Controls.Add(Stand0List);
                                            Stand0List.ContextMenuStrip = cmschange;
                                            //Stand0List = (steelbillet);
                                            tStand0.Enabled = true;
                                        }));
                                        blstand0 = true;
                                    }
                                }
                                else if (flag == false && blstand0 == true)
                                {
                                    GenerateProcess(0);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc00.opc_plc0.DRT_BL_EXIST_T", 0);
                                    
                                        tStand0.Enabled = false;
                                        blstand0 = false;
                                        intM0 = 0;
                                        if (bltp[0] != 2)
                                            Stand0List.BackColor = Color.Red;
                                        else
                                            Stand0List.BackColor = endColor;
                                        Stand0List.ForeColor = Color.White;
                                        isRun0 = true;
                                        intS0 = 0;
                                        intR0 = 0;
                                        blIsRun0 = true;
                                        threadRuns0 = new Thread(new ThreadStart(getRuns0));       //0流钢坯监测
                                        threadRuns0.Start();
                                        if (blonerolling[0] == false)
                                        {
                                            intNum0 = 0;
                                            tColor0.Enabled = false;
                                            if (bltp[0] != 2)
                                                tColor0.Enabled = true;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
                catch(Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }

        System.Timers.Timer T1;

        bool blstand1 = false;
        int intblIsRun1 = -1;
        void getCuts1()
        {
            while (blIsSRun1 == true)
            {
                try
                {
                    if (this.kepOpc.itemValue[12] != null)
                    {
                      
                        bool blr = this.kepOpc.itemValue[12] == "True";
                        if (blr == true)
                        {
                            bool flag = this.kepOpc.itemValue[23] == "True";
                            if (intblIsRun1 == -1)
                            {
                                if (flag == false)
                                {
                                    intblIsRun1 = 0;
                                }
                                else
                                {
                                    intblIsRun1 = 1;
                                }
                            }
                            if (intblIsRun1 == 0)
                            {
                                if (flag)
                                {
                                    if (blstand1 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand1List != null)
                                            {
                                                intR1 = 0;
                                                blis1 = false;
                                                if (FlipSteelList.Contains("1_0") == true)
                                                    FlipSteelList.Remove("1_0");
                                                if (FlipSteelList.Contains("1_1") == true)
                                                    FlipSteelList.Remove("1_1");
                                                this.Controls.Remove(Stand1List);
                                                Stand1List.Dispose();
                                            }
                                            Stand1List = new Button();
                                            Stand1List.BackColor = Color.OrangeRed;
                                            Stand1List.FlatStyle = FlatStyle.Popup;
                                            Stand1List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand1List.ForeColor = Color.White;
                                            Stand1List.Tag = "Y";

                                            Stand1List.Name = "Stand1";
                                            Stand1List.Size = new Size(275, 50);
                                            Stand1List.TabIndex = 29;
                                            Stand1List.Text = "正在切割";
                                            
                                            Stand1List.Left = Stand1.Left;
                                            Stand1List.Top = Stand1.Top - Stand1List.Height - 3;
                                            Controls.Add(Stand1List);
                                            Stand1List.BringToFront();
                                            Stand1List.ContextMenuStrip = cmschange;
                                          //  Stand1List = (steelbillet);
                                            tStand1.Enabled = true;
                                        }));
                                        blstand1 = true;
                                    }
                                }
                                else if (flag == false && blstand1 == true)
                                {
                                    GenerateProcess(1);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc01.opc_plc1.DRT_BL_EXIST_T", 0);
                                        tStand1.Enabled = false;
                                        blstand1 = false;
                                        intM1 = 0;
                                        if (bltp[1] != 2)
                                            Stand1List.BackColor = Color.Red;
                                        else
                                            Stand1List.BackColor = endColor;
                                        Stand1List.ForeColor = Color.White;
                                        isRun1 = true;
                                        intS1 = 0;
                                        intR1 = 0;
                                        blIsRun1 = true;
                                        threadRuns1 = new Thread(new ThreadStart(getRuns1));       //0流钢坯监测
                                        threadRuns1.Start();
                                        if (blonerolling[1] == false)
                                        {
                                            intNum1 = 0;
                                            tColor1.Enabled = false;
                                            if (bltp[1] != 2)
                                                tColor1.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (blstand1 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand1List != null)
                                            {
                                                intR1 = 0;
                                                blis1 = false;
                                                if (FlipSteelList.Contains("1_0") == true)
                                                    FlipSteelList.Remove("1_0");
                                                if (FlipSteelList.Contains("1_1") == true)
                                                    FlipSteelList.Remove("1_1");
                                                this.Controls.Remove(Stand1List);
                                                Stand1List.Dispose();
                                            }
                                            Stand1List = new Button();
                                            Stand1List.BackColor = Color.OrangeRed;
                                            Stand1List.FlatStyle = FlatStyle.Popup;
                                            Stand1List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand1List.ForeColor = Color.White;

                                            Stand1List.Name = "Stand1";
                                            Stand1List.Size = new Size(275, 50);
                                            Stand1List.TabIndex = 29;
                                            Stand1List.Text = "正在切割";
                                            Stand1List.UseVisualStyleBackColor = false;
                                            Stand1List.Left = Stand1.Left;
                                            Stand1List.Top = Stand1.Top - Stand1List.Height - 3;
                                            Controls.Add(Stand1List);
                                            Stand1List.ContextMenuStrip = cmschange;
                                            //  Stand1List = (steelbillet);
                                            tStand1.Enabled = true;
                                        }));
                                        blstand1 = true;
                                    }
                                }
                                else if (flag == false && blstand1 == true)
                                {
                                    GenerateProcess(1);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc01.opc_plc1.DRT_BL_EXIST_T", 0);
                                     
                                        tStand1.Enabled = false;
                                        blstand1 = false;
                                        intM1 = 0;
                                        if (bltp[1] != 2)
                                            Stand1List.BackColor = Color.Red;
                                        else
                                            Stand1List.BackColor = endColor;
                                        Stand1List.ForeColor = Color.White;
                                        isRun1 = true;
                                        intS1 = 0;
                                        intR1 = 0;
                                        blIsRun1 = true;
                                        threadRuns1 = new Thread(new ThreadStart(getRuns1));       //0流钢坯监测
                                        threadRuns1.Start();
                                        if (blonerolling[1] == false)
                                        {
                                            intNum1 = 0;
                                            tColor1.Enabled = false;
                                            if (bltp[1] != 2)
                                                tColor1.Enabled = true;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }

        bool blstand2 = false;
        int intblIsRun2 = -1;
        void getCuts2()
        {
            while (blIsSRun2 == true)
            {
                try
                {
                    if (this.kepOpc.itemValue[24] != null)
                    {
                        bool blr = this.kepOpc.itemValue[24] == "True";
                        if (blr == true)
                        {
                            bool flag = this.kepOpc.itemValue[35] == "True";
                            if (intblIsRun2 == -1)
                            {
                                if (flag == false)
                                {
                                    intblIsRun2 = 0;
                                }
                                else
                                {
                                    intblIsRun2 = 1;
                                }
                            }
                            if (intblIsRun2 == 0)
                            {
                                if (flag)
                                {
                                    if (blstand2 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand2List != null)
                                            {
                                                intR2 = 0;
                                                blis2 = false;
                                                if (FlipSteelList.Contains("2_0") == true)
                                                    FlipSteelList.Remove("2_0");
                                                if (FlipSteelList.Contains("2_1") == true)
                                                    FlipSteelList.Remove("2_1");
                                                this.Controls.Remove(Stand2List);
                                                Stand2List.Dispose();
                                            }
                                            Stand2List = new Button();
                                            Stand2List.BackColor = Color.OrangeRed;
                                            Stand2List.FlatStyle = FlatStyle.Popup;
                                            Stand2List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand2List.ForeColor = Color.White;
                                            Stand2List.Tag = "Y";

                                            Stand2List.Name = "Stand2";
                                            Stand2List.Size = new Size(275, 50);
                                            Stand2List.TabIndex = 29;
                                            Stand2List.Text = "2流正在切割";
                                            
                                            Stand2List.Left = Stand2.Left;
                                            Stand2List.Top = Stand2.Top - Stand2List.Height - 3;
                                            Controls.Add(Stand2List);
                                            Stand2List.BringToFront();
                                            Stand2List.ContextMenuStrip = cmschange;
                                            //Stand2List = (steelbillet);
                                            tStand2.Enabled = true;
                                        }));
                                        blstand2 = true;
                                    }
                                }
                                else if (flag == false && blstand2 == true)
                                {
                                    GenerateProcess(2);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.DRT_BL_EXIST_T", 0);
                              
                                        tStand2.Enabled = false;
                                        blstand2 = false;
                                        intM2 = 0;
                                        if (bltp[2] != 2)
                                            Stand2List.BackColor = Color.Red;
                                        else
                                            Stand2List.BackColor = endColor;
                                        Stand2List.ForeColor = Color.White;
                                        isRun2 = true;
                                        intS2 = 0;
                                        intR2 = 0;
                                        blIsRun2 = true;
                                        threadRuns2 = new Thread(new ThreadStart(getRuns2));       //2流钢坯监测
                                        threadRuns2.Start();
                                        if (blonerolling[2] == false)
                                        {
                                            intNum2 = 0;
                                            tColor2.Enabled = false;
                                            if (bltp[2] != 2)
                                                tColor2.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (blstand2 == false)
                                    {
                                       
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand2List != null)
                                            {
                                                intR2 = 0;
                                                blis2 = false;
                                                if (FlipSteelList.Contains("2_0") == true)
                                                    FlipSteelList.Remove("2_0");
                                                if (FlipSteelList.Contains("2_1") == true)
                                                    FlipSteelList.Remove("2_1");
                                                this.Controls.Remove(Stand2List);
                                                Stand2List.Dispose();
                                            }
                                            Stand2List = new Button();
                                            Stand2List.BackColor = Color.OrangeRed;
                                            Stand2List.FlatStyle = FlatStyle.Popup;
                                            Stand2List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand2List.ForeColor = Color.White;

                                            Stand2List.Name = "Stand2";
                                            Stand2List.Size = new Size(275, 50);
                                            Stand2List.TabIndex = 29;
                                            Stand2List.Text = "2流正在切割";
                                            Stand2List.UseVisualStyleBackColor = false;
                                            Stand2List.Left = Stand2.Left;
                                            Stand2List.Top = Stand2.Top - Stand2List.Height - 3;
                                            Controls.Add(Stand2List);
                                            Stand2List.ContextMenuStrip = cmschange;
                                           // Stand2List = (steelbillet);
                                            tStand2.Enabled = true;
                                        }));
                                        blstand2 = true;
                                    }
                                }
                                else if (flag == false && blstand2 == true)
                                {
                                    GenerateProcess(2);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc02.opc_plc2.DRT_BL_EXIST_T", 0);
                                     
                                        tStand2.Enabled = false;
                                        blstand2 = false;
                                        intM2 = 0;
                                        if (bltp[2] != 2)
                                            Stand2List.BackColor = Color.Red;
                                        else
                                            Stand2List.BackColor = endColor;
                                        Stand2List.ForeColor = Color.White;
                                        isRun2 = true;
                                        intS2 = 0;
                                        intR2 = 0;
                                        blIsRun2 = true;
                                        threadRuns2 = new Thread(new ThreadStart(getRuns2));       //2流钢坯监测
                                        threadRuns2.Start();
                                        if (blonerolling[2] == false)
                                        {
                                            intNum2 = 0;
                                            tColor2.Enabled = false;
                                            if (bltp[2] != 2)
                                                tColor2.Enabled = true;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }

        bool blstand3 = false;
        int intblIsRun3 = -1;
        void getCuts3()
        {
            while (blIsSRun3 == true)
            {
                try
                {
                    if (this.kepOpc.itemValue[36] != null)
                    {
                        bool blr = this.kepOpc.itemValue[36] == "True";
                        if (blr == true)
                        {
                            bool flag = this.kepOpc.itemValue[47] == "True";

                            if (intblIsRun3 == -1)
                            {
                                if (flag == false)
                                {
                                    intblIsRun3 = 0;
                                }
                                else
                                {
                                    intblIsRun3 = 1;
                                }
                            }

                            if (intblIsRun3 == 0)
                            {
                                if (flag)
                                {
                                    if (blstand3 == false)
                                    {
                                        
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand3List != null)
                                            {
                                                intR3 = 0;
                                                blis3 = false;
                                                if (FlipSteelList.Contains("3_0") == true)
                                                    FlipSteelList.Remove("3_0");
                                                if (FlipSteelList.Contains("3_1") == true)
                                                    FlipSteelList.Remove("3_1");
                                                this.Controls.Remove(Stand3List);
                                                Stand3List.Dispose();
                                            }
                                            Stand3List = new Button();
                                            Stand3List.BackColor = Color.OrangeRed;
                                            Stand3List.FlatStyle = FlatStyle.Popup;
                                            Stand3List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand3List.ForeColor = Color.White;
                                            Stand3List.Tag = "Y";

                                            Stand3List.Name = "Stand3";
                                            Stand3List.Size = new Size(275, 50);
                                            Stand3List.TabIndex = 29;
                                            Stand3List.Text = "3流正在切割";
                                            
                                            Stand3List.Left = Stand3.Left;
                                            Stand3List.Top = Stand3.Top - Stand3List.Height - 3;
                                            Controls.Add(Stand3List);
                                            Stand3List.BringToFront();
                                            Stand3List.ContextMenuStrip = cmschange;
                                            //Stand3List = (steelbillet);
                                            tStand3.Enabled = true;
                                        }));
                                        blstand3 = true;
                                    }
                                }
                                else if (flag == false && blstand3 == true)
                                {
                                    GenerateProcess(3);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc03.opc_plc3.DRT_BL_EXIST_T", 0);
                             
                                        tStand3.Enabled = false;
                                        blstand3 = false;
                                        intM3 = 0;
                                        if (bltp[3] != 2)
                                            Stand3List.BackColor = Color.Red;
                                        else
                                            Stand3List.BackColor = endColor;
                                        Stand3List.ForeColor = Color.White;
                                        isRun3 = true;
                                        intS3 = 0;
                                        intR3 = 0;
                                        blIsRun3 = true;
                                        threadRuns3 = new Thread(new ThreadStart(getRuns3));       //0流钢坯监测
                                        threadRuns3.Start();
                                        if (blonerolling[3] == false)
                                        {
                                            intNum3 = 0;
                                            tColor3.Enabled = false;
                                            if (bltp[3] != 2)
                                                tColor3.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (blstand3 == false)
                                    {
                                        
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand3List != null)
                                            {
                                                intR3 = 0;
                                                blis3 = false;
                                                if (FlipSteelList.Contains("3_0") == true)
                                                    FlipSteelList.Remove("3_0");
                                                if (FlipSteelList.Contains("3_1") == true)
                                                    FlipSteelList.Remove("3_1");
                                                this.Controls.Remove(Stand3List);
                                                Stand3List.Dispose();
                                            }
                                            Stand3List = new Button();
                                            Stand3List.BackColor = Color.OrangeRed;
                                            Stand3List.FlatStyle = FlatStyle.Popup;
                                            Stand3List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand3List.ForeColor = Color.White;

                                            Stand3List.Name = "Stand3";
                                            Stand3List.Size = new Size(275, 50);
                                            Stand3List.TabIndex = 29;
                                            Stand3List.Text = "3流正在切割";
                                            Stand3List.UseVisualStyleBackColor = false;
                                            Stand3List.Left = Stand3.Left;
                                            Stand3List.Top = Stand3.Top - Stand3List.Height - 3;
                                            Controls.Add(Stand3List);
                                            Stand3List.ContextMenuStrip = cmschange;
                                            //Stand3List = (steelbillet);
                                            tStand3.Enabled = true;
                                        }));
                                        blstand3 = true;
                                    }
                                }
                                else if (flag == false && blstand3 == true)
                                {
                                    GenerateProcess(3);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc03.opc_plc3.DRT_BL_EXIST_T", 0);
                                     
                                        tStand3.Enabled = false;
                                        blstand3 = false;
                                        intM3 = 0;
                                        if (bltp[3] != 2)
                                            Stand3List.BackColor = Color.Red;
                                        else
                                            Stand3List.BackColor = endColor;
                                        Stand3List.ForeColor = Color.White;
                                        isRun3 = true;
                                        intS3 = 0;
                                        intR3 = 0;
                                        blIsRun3 = true;
                                        threadRuns3 = new Thread(new ThreadStart(getRuns3));       //0流钢坯监测
                                        threadRuns3.Start();
                                        if (blonerolling[3] == false)
                                        {
                                            intNum3 = 0;
                                            tColor3.Enabled = false;
                                            if (bltp[3] != 2)
                                                tColor3.Enabled = true;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }


        bool blstand4 = false;
        int intblIsRun4 = -1;
        void getCuts4()
        {
            while (blIsSRun4 == true)
            {
                try
                {
                    if (this.kepOpc.itemValue[48] != null)
                    {
                        bool blr = this.kepOpc.itemValue[48] == "True";
                        if (blr == true)
                        {
                            bool flag = this.kepOpc.itemValue[59] == "True";
                            if (intblIsRun4 == -1)
                            {
                                if (flag == false)
                                {
                                    intblIsRun4 = 0;
                                }
                                else
                                {
                                    intblIsRun4 = 1;
                                }
                            }
                            if (intblIsRun0 == 0)
                            {
                                if (flag)
                                {
                                    if (blstand4 == false)
                                    {
                                        
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand4List != null)
                                            {
                                                intR4 = 0;
                                                blis4 = false;
                                                if (FlipSteelList.Contains("4_0") == true)
                                                    FlipSteelList.Remove("4_0");
                                                if (FlipSteelList.Contains("4_1") == true)
                                                    FlipSteelList.Remove("4_1");
                                                this.Controls.Remove(Stand4List);
                                                Stand4List.Dispose();
                                            }
                                            Stand4List = new Button();
                                            Stand4List.BackColor = Color.OrangeRed;
                                            Stand4List.FlatStyle = FlatStyle.Popup;
                                            Stand4List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand4List.ForeColor = Color.White;

                                            Stand4List.Tag = "Y";
                                            Stand4List.Name = "Stand4";
                                            Stand4List.Size = new Size(275, 50);
                                            Stand4List.TabIndex = 29;
                                            Stand4List.Text = "4流正在切割";
                                            
                                            Stand4List.Left = Stand4.Left;
                                            Stand4List.Top = Stand4.Top - Stand4List.Height - 3;
                                            Controls.Add(Stand4List);
                                            Stand4List.BringToFront();
                                            Stand4List.ContextMenuStrip = cmschange;
                                            //Stand4List = (steelbillet);
                                            tStand4.Enabled = true;
                                        }));
                                        blstand4 = true;
                                    }
                                }
                                else if (flag == false && blstand4 == true)
                                {
                                    GenerateProcess(4);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc04.opc_plc4.DRT_BL_EXIST_T", 0);
                                  
                                        tStand4.Enabled = false;
                                        blstand4 = false;
                                        intM4 = 0;
                                        if (bltp[4] != 2)
                                            Stand4List.BackColor = Color.Red;
                                        else
                                            Stand4List.BackColor = endColor;
                                        Stand4List.ForeColor = Color.White;
                                        isRun4 = true;
                                        intS4 = 0;
                                        intR4 = 0;
                                        blIsRun4 = true;
                                        threadRuns4 = new Thread(new ThreadStart(getRuns4));       //0流钢坯监测
                                        threadRuns4.Start();
                                        if (blonerolling[4] == false)
                                        {
                                            intNum4 = 0;
                                            tColor4.Enabled = false;
                                            if (bltp[4] != 2)
                                                tColor4.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (blstand4 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand4List != null)
                                            {
                                                intR4 = 0;
                                                blis4 = false;
                                                if (FlipSteelList.Contains("4_0") == true)
                                                    FlipSteelList.Remove("4_0");
                                                if (FlipSteelList.Contains("4_1") == true)
                                                    FlipSteelList.Remove("4_1");
                                                this.Controls.Remove(Stand4List);
                                                Stand4List.Dispose();
                                            }
                                            Stand4List = new Button();
                                            Stand4List.BackColor = Color.OrangeRed;
                                            Stand4List.FlatStyle = FlatStyle.Popup;
                                            Stand4List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand4List.ForeColor = Color.White;

                                            Stand4List.Name = "Stand4";
                                            Stand4List.Size = new Size(275, 50);
                                            Stand4List.TabIndex = 29;
                                            Stand4List.Text = "4流正在切割";
                                            Stand4List.UseVisualStyleBackColor = false;
                                            Stand4List.Left = Stand4.Left;
                                            Stand4List.Top = Stand4.Top - Stand4List.Height - 3;
                                            Controls.Add(Stand4List);
                                            Stand4List.ContextMenuStrip = cmschange;
                                            //Stand4List = (steelbillet);
                                            tStand4.Enabled = true;
                                        }));
                                        blstand4 = true;
                                    }
                                }
                                else if (flag == false && blstand4 == true)
                                {
                                    GenerateProcess(4);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc04.opc_plc4.DRT_BL_EXIST_T", 0);
                           
                                        tStand4.Enabled = false;
                                        blstand4 = false;
                                        intM4 = 0;
                                        if (bltp[4] != 2)
                                            Stand4List.BackColor = Color.Red;
                                        else
                                            Stand4List.BackColor = endColor;
                                        Stand4List.ForeColor = Color.White;
                                        isRun4 = true;
                                        intS4 = 0;
                                        intR4 = 0;
                                        blIsRun4 = true;
                                        threadRuns4 = new Thread(new ThreadStart(getRuns4));       //0流钢坯监测
                                        threadRuns4.Start();
                                        if (blonerolling[4] == false)
                                        {
                                            intNum4 = 0;
                                            tColor4.Enabled = false;
                                            if (bltp[4] != 2)
                                                tColor4.Enabled = true;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }

        bool blstand5 = false;
        int intblIsRun5 = -1;
        void getCuts5()
        {
            while (blIsSRun5 == true)
            {
                try
                {
                    if (this.kepOpc.itemValue[60] != null)
                    {
                        bool blr = this.kepOpc.itemValue[60] == "True";
                        if (blr == true)
                        {
                            bool flag = this.kepOpc.itemValue[71] == "True";

                            if (intblIsRun5 == -1)
                            {
                                if (flag == false)
                                {
                                    intblIsRun5 = 0;
                                }
                                else
                                {
                                    intblIsRun5 = 1;
                                }
                            }

                            if (intblIsRun5 == 0)
                            {
                                if (flag)
                                {
                                    if (blstand5 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand5List != null)
                                            {
                                                intR5 = 0;
                                                blis5 = false;
                                                if (FlipSteelList.Contains("5_0") == true)
                                                    FlipSteelList.Remove("5_0");
                                                if (FlipSteelList.Contains("5_1") == true)
                                                    FlipSteelList.Remove("5_1");
                                                this.Controls.Remove(Stand5List);
                                                Stand5List.Dispose();
                                            }
                                            Stand5List = new Button();
                                            Stand5List.BackColor = Color.OrangeRed;
                                            Stand5List.FlatStyle = FlatStyle.Popup;
                                            Stand5List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand5List.ForeColor = Color.White;

                                            Stand5List.Tag = "Y";
                                            Stand5List.Name = "Stand5";
                                            Stand5List.Size = new Size(275, 50);
                                            Stand5List.TabIndex = 29;
                                            Stand5List.Text = "5流正在切割";
                                            
                                            Stand5List.Left = Stand5.Left;
                                            Stand5List.Top = Stand5.Top - Stand5List.Height - 3;
                                            Controls.Add(Stand5List);
                                            Stand5List.BringToFront();
                                            Stand5List.ContextMenuStrip = cmschange;
                                            //Stand5List = (steelbillet);
                                            tStand5.Enabled = true;
                                        }));
                                        blstand5 = true;
                                    }
                                }
                                else if (flag == false && blstand5 == true)
                                {
                                    GenerateProcess(5);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.DRT_BL_EXIST_T", 0);
                                    
                                        tStand5.Enabled = false;
                                        blstand5 = false;
                                        intM5 = 0;
                                        if (bltp[5] != 2)
                                            Stand5List.BackColor = Color.Red;
                                        else
                                            Stand5List.BackColor = endColor;
                                        Stand5List.ForeColor = Color.White;
                                        isRun5 = true;
                                        intS5 = 0;
                                        intR5 = 0;
                                        blIsRun5 = true;
                                        threadRuns5 = new Thread(new ThreadStart(getRuns5));       //0流钢坯监测
                                        threadRuns5.Start();
                                        if (blonerolling[5] == false)
                                        {
                                            intNum5 = 0;
                                            tColor5.Enabled = false;
                                            if (bltp[5] != 2)
                                                tColor5.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (blstand5 == false)
                                    {
                                       
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand5List != null)
                                            {
                                                intR5 = 0;
                                                blis5 = false;
                                                if (FlipSteelList.Contains("5_0") == true)
                                                    FlipSteelList.Remove("5_0");
                                                if (FlipSteelList.Contains("5_1") == true)
                                                    FlipSteelList.Remove("5_1");
                                                this.Controls.Remove(Stand5List);
                                                Stand5List.Dispose();
                                            }
                                            Stand5List = new Button();
                                            Stand5List.BackColor = Color.OrangeRed;
                                            Stand5List.FlatStyle = FlatStyle.Popup;
                                            Stand5List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand5List.ForeColor = Color.White;

                                            Stand5List.Name = "Stand5";
                                            Stand5List.Size = new Size(275, 50);
                                            Stand5List.TabIndex = 29;
                                            Stand5List.Text = "5流正在切割";
                                            Stand5List.UseVisualStyleBackColor = false;
                                            Stand5List.Left = Stand5.Left;
                                            Stand5List.Top = Stand5.Top - Stand5List.Height - 3;
                                            Controls.Add(Stand5List);
                                            Stand5List.ContextMenuStrip = cmschange;
                                            //Stand5List = (steelbillet);
                                            tStand5.Enabled = true;
                                        }));
                                        blstand5 = true;
                                    }
                                }
                                else if (flag == false && blstand5 == true)
                                {
                                    GenerateProcess(5);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc05.opc_plc5.DRT_BL_EXIST_T", 0);
                                    
                                        tStand5.Enabled = false;
                                        blstand5 = false;
                                        intM5 = 0;
                                        if (bltp[5] != 2)
                                            Stand5List.BackColor = Color.Red;
                                        else
                                            Stand5List.BackColor = endColor;
                                        Stand5List.ForeColor = Color.White;
                                        isRun5 = true;
                                        intS5 = 0;
                                        intR5 = 0;
                                        blIsRun5 = true;
                                        threadRuns5 = new Thread(new ThreadStart(getRuns5));       //0流钢坯监测
                                        threadRuns5.Start();
                                        if (blonerolling[5] == false)
                                        {
                                            intNum5 = 0;
                                            tColor5.Enabled = false;
                                            if (bltp[5] != 2)
                                                tColor5.Enabled = true;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }

        private void btn0Continue_Click(object sender, EventArgs e)
        {
            bltp[0] = 0;
            btn0Continue.Visible = false;
            intR0 = 0;
            intalarm[0] = 0;
            blIsRun0 = true;
            animator.HideSync(plAlarm, true, Animation.HorizBlind);
        }

        private void btn1Continue_Click(object sender, EventArgs e)
        {
            bltp[1] = 0;
            btn1Continue.Visible = false;
            intR1 = 0;
            intalarm[1] = 0;
            blIsRun1 = true;
            animator.HideSync(plAlarm, true, Animation.HorizBlind);
        }

        private void btn2Continue_Click(object sender, EventArgs e)
        {
            bltp[2] = 0;
            btn2Continue.Visible = false;
            intR2 = 0;
            intalarm[2] = 0;
            blIsRun2 = true;
            animator.HideSync(plAlarm, true, Animation.HorizBlind);
        }

        private void btn3Continue_Click(object sender, EventArgs e)
        {
            bltp[3] = 0;
            btn3Continue.Visible = false;
            intR3 = 0;
            intalarm[3] = 0;
            blIsRun3 = true;
            animator.HideSync(plAlarm, true, Animation.HorizBlind);
        }

        private void btn4Continue_Click(object sender, EventArgs e)
        {
            bltp[4] = 0;
            btn4Continue.Visible = false;
            intR4 = 0;
            intalarm[4] = 0;
            blIsRun4 = true;
            animator.HideSync(plAlarm, true, Animation.HorizBlind);
        }

        private void Stand0Run2_MouseEnter(object sender, EventArgs e)
        {
            if (float.Parse(S0.Text.Trim()) > 0)
            {
                animator.ShowSync(btnOpt0, true, Animation.Transparent);
                animator.ShowSync(btnOpt0Right, true, Animation.Transparent);

                animator.ShowSync(btnFlipSteeling0, true, Animation.Transparent);
                animator.ShowSync(btnLiftingSteel0, true, Animation.Transparent);
            }
        }

        private void btnOpt0_MouseLeave(object sender, EventArgs e)
        {
            if (btnOpt0.Text.Trim() == "去[4轧]")
                animator.HideSync(btnOpt0, true, Animation.Transparent);
            if (btnOpt0Right.Text.Trim() == "去[冷床]")
                animator.HideSync(btnOpt0Right, true, Animation.Transparent);
        }

        private void btnOpt1_MouseLeave(object sender, EventArgs e)
        {
            if (btnOpt1.Text.Trim() == "去[4轧]")
                animator.HideSync(btnOpt1, true, Animation.Transparent);
            if (btnOpt1Right.Text.Trim() == "去[冷床]")
                animator.HideSync(btnOpt1Right, true, Animation.Transparent);
        }

        private void btnOpt2_MouseLeave(object sender, EventArgs e)
        {
            if (btnOpt2.Text.Trim() == "去[4轧]")
                animator.HideSync(btnOpt2, true, Animation.Transparent);
            if (btnOpt2Right.Text.Trim() == "去[冷床]")
                animator.HideSync(btnOpt2Right, true, Animation.Transparent);
        }

        private void btnOpt3_MouseLeave(object sender, EventArgs e)
        {
            if (btnOpt3.Text.Trim() == "去[4轧]")
                animator.HideSync(btnOpt3, true, Animation.Transparent);
            if (btnOpt3Right.Text.Trim() == "去[冷床]")
                animator.HideSync(btnOpt3Right, true, Animation.Transparent);
        }

        private void btnOpt4_MouseLeave(object sender, EventArgs e)
        {
            if (btnOpt4.Text.Trim() == "去[4轧]")
                animator.HideSync(btnOpt4, true, Animation.Transparent);
            if (btnOpt4Right.Text.Trim() == "去[冷床]")
                animator.HideSync(btnOpt4Right, true, Animation.Transparent);
        }

        private void btnOpt5_MouseLeave(object sender, EventArgs e)
        {
            if (btnOpt5.Text.Trim() == "去[4轧]")
                animator.HideSync(btnOpt5, true, Animation.Transparent);
            if (btnOpt5Right.Text.Trim() == "去[冷床]")
                animator.HideSync(btnOpt5Right, true, Animation.Transparent);
        }

        private void btnOpt6_MouseLeave(object sender, EventArgs e)
        {
            if (btnOpt6.Text.Trim() == "去[4轧]")
                animator.HideSync(btnOpt6, true, Animation.Transparent);
            if (btnOpt6Right.Text.Trim() == "去[冷床]")
                animator.HideSync(btnOpt6Right, true, Animation.Transparent);
        }

        private void Stand1Run2_MouseEnter(object sender, EventArgs e)
        {
            if (float.Parse(S1.Text.Trim()) > 0)
            {
                animator.ShowSync(btnOpt1, true, Animation.Transparent);
                animator.ShowSync(btnOpt1Right, true, Animation.Transparent);

                animator.ShowSync(btnFlipSteeling1, true, Animation.Transparent);
                animator.ShowSync(btnLiftingSteel1, true, Animation.Transparent);
            }
        }

        private void Stand2Run2_MouseEnter(object sender, EventArgs e)
        {
            if (float.Parse(S2.Text.Trim()) > 0)
            {
                animator.ShowSync(btnOpt2, true, Animation.Transparent);
                animator.ShowSync(btnOpt2Right, true, Animation.Transparent);

                animator.ShowSync(btnFlipSteeling2, true, Animation.Transparent);
                animator.ShowSync(btnLiftingSteel2, true, Animation.Transparent);
            }
        }

        private void Stand3Run2_MouseEnter(object sender, EventArgs e)
        {
            if (float.Parse(S3.Text.Trim()) > 0)
            {
                animator.ShowSync(btnOpt3, true, Animation.Transparent);
                animator.ShowSync(btnOpt3Right, true, Animation.Transparent);

                animator.ShowSync(btnFlipSteeling3, true, Animation.Transparent);
                animator.ShowSync(btnLiftingSteel3, true, Animation.Transparent);
            }
        }

        private void Stand4Run2_MouseEnter(object sender, EventArgs e)
        {
            if (float.Parse(S4.Text.Trim()) > 0)
            {
                animator.ShowSync(btnOpt4, true, Animation.Transparent);
                animator.ShowSync(btnOpt4Right, true, Animation.Transparent);

                animator.ShowSync(btnFlipSteeling4, true, Animation.Transparent);
                animator.ShowSync(btnLiftingSteel4, true, Animation.Transparent);
            }
        }

        private void Stand5Run2_MouseEnter(object sender, EventArgs e)
        {
            if (float.Parse(S5.Text.Trim()) > 0)
            {
                animator.ShowSync(btnOpt5, true, Animation.Transparent);
                animator.ShowSync(btnOpt5Right, true, Animation.Transparent);

                animator.ShowSync(btnFlipSteeling5, true, Animation.Transparent);
                animator.ShowSync(btnLiftingSteel5, true, Animation.Transparent);
            }
        }

        private void Stand6Run2_MouseEnter(object sender, EventArgs e)
        {
            if (float.Parse(S6.Text.Trim()) > 0)
            {
                animator.ShowSync(btnOpt6, true, Animation.Transparent);
                animator.ShowSync(btnOpt6Right, true, Animation.Transparent);

                animator.ShowSync(btnFlipSteeling6, true, Animation.Transparent);
                animator.ShowSync(btnLiftingSteel6, true, Animation.Transparent);
            }
        }
        int[] bltp = new int[7];
        private void btnOpt0_Click(object sender, EventArgs e)
        {
            if(btnOpt0.Text.Trim() == "去[4轧]")
            {
                bltp[0] = 1;
                btnOpt0.Text = "结束限制";
            }
            else
            {
                bltp[0] = 0;
                btnOpt0.Text = "去[4轧]";
            }
        }

        private void btnOpt0Right_Click(object sender, EventArgs e)
        {
            if (btnOpt0Right.Text.Trim() == "去[冷床]")
            {
                bltp[0] = 2;
                btnOpt0Right.Text = "结束限制";
            }
            else
            {
                bltp[0] = 0;
                btnOpt0Right.Text = "去[冷床]";
            }
        }

        private void btnOpt1_Click(object sender, EventArgs e)
        {
            if (btnOpt1.Text.Trim() == "去[4轧]")
            {
                btnOpt1.Text = "结束限制";
                bltp[1] = 1;
            }
            else
            {
                bltp[1] = 0;
                btnOpt1.Text = "去[4轧]";
            }
        }

        private void btnOpt1Right_Click(object sender, EventArgs e)
        {
            if (btnOpt1Right.Text.Trim() == "去[冷床]")
            {
                bltp[1] = 2;
                btnOpt1Right.Text = "结束限制";
            }
            else
            {
                bltp[1] = 0;
                btnOpt1Right.Text = "去[冷床]";
            }
        }

        private void btnOpt2_Click(object sender, EventArgs e)
        {
            if (btnOpt2.Text.Trim() == "去[4轧]")
            {
                bltp[2] = 1;
                btnOpt2.Text = "结束限制";
            }
            else
            {
                bltp[2] = 0;
                btnOpt2.Text = "去[4轧]";
            }
        }

        private void btnOpt2Right_Click(object sender, EventArgs e)
        {
            if (btnOpt2Right.Text.Trim() == "去[冷床]")
            {
                bltp[2] = 2;
                btnOpt2Right.Text = "结束限制";
            }
            else
            {
                bltp[2] = 0;
                btnOpt2Right.Text = "去[冷床]";
            }
        }

        private void btnOpt3_Click(object sender, EventArgs e)
        {
            if (btnOpt3.Text.Trim() == "去[4轧]")
            {
                btnOpt3.Text = "结束限制";
                bltp[3] = 1;
            }
            else
            {
                btnOpt3.Text = "去[4轧]";
                bltp[3] = 0;
            }
        }

        private void btnOpt3Right_Click(object sender, EventArgs e)
        {
            if (btnOpt3Right.Text.Trim() == "去[冷床]")
            {
                bltp[3] = 2;
                btnOpt3Right.Text = "结束限制";
            }
            else
            {
                bltp[3] = 0;
                btnOpt3Right.Text = "去[冷床]";
            }
        }

        private void btnOpt4_Click(object sender, EventArgs e)
        {
            if (btnOpt4.Text.Trim() == "去[4轧]")
            {
                btnOpt4.Text = "结束限制";
                bltp[4] = 1;
            }
            else
            {
                btnOpt4.Text = "去[4轧]";
                bltp[4] = 0;
            }
        }

        private void btnOpt4Right_Click(object sender, EventArgs e)
        {
            if (btnOpt4Right.Text.Trim() == "去[冷床]")
            {
                bltp[4] = 2;
                btnOpt4Right.Text = "结束限制";
            }
            else
            {
                bltp[4] = 0;
                btnOpt4Right.Text = "去[冷床]";
            }
        }

        private void btnOpt5_Click(object sender, EventArgs e)
        {
            if (btnOpt5.Text.Trim() == "去[4轧]")
            {
                btnOpt5.Text = "结束限制";
                bltp[5] = 1;
            }
            else
            {
                btnOpt5.Text = "去[4轧]";
                bltp[5] = 0;
            }
        }

        private void btnOpt5Right_Click(object sender, EventArgs e)
        {
            if (btnOpt5Right.Text.Trim() == "去[冷床]")
            {
                bltp[5] = 2;
                btnOpt5Right.Text = "结束限制";
            }
            else
            {
                bltp[5] = 0;
                btnOpt5Right.Text = "去[冷床]";
            }
        }

        private void btnOpt6_Click(object sender, EventArgs e)
        {
            if (btnOpt6.Text.Trim() == "去[4轧]")
            {
                btnOpt6.Text = "结束限制";
                bltp[6] = 1;
            }
            else
            {
                btnOpt6.Text = "去[4轧]";
                bltp[6] = 0;
            }
        }

        private void btnOpt6Right_Click(object sender, EventArgs e)
        {
            if (btnOpt6Right.Text.Trim() == "去[冷床]")
            {
                bltp[6] = 2;
                btnOpt6Right.Text = "结束限制";
            }
            else
            {
                bltp[6] = 0;
                btnOpt6Right.Text = "去[冷床]";
            }
        }

        private void btn5Continue_Click(object sender, EventArgs e)
        {
            bltp[5] = 0;
            btn5Continue.Visible = false;
            intR5 = 0;
            intalarm[5] = 0;
            blIsRun5 = true;
            animator.HideSync(plAlarm, true, Animation.HorizBlind);
        }

        private void btn6Continue_Click(object sender, EventArgs e)
        {
            bltp[6] = 0;
            btn6Continue.Visible = false;
            intR6 = 0;
            intalarm[6] = 0;
            blIsRun6 = true;
            animator.HideSync(plAlarm, true, Animation.HorizBlind);
        }

        Color startColor = Color.Red, endColor = ColorTranslator.FromHtml("#808080");
        double interval = 0;

        int intNum0 = 0;
        private void tColor0_Tick(object sender, EventArgs e)
        {
            if (Stand0List != null)
            {
                try
                {
                    interval = 1000 * intFourWT;
                    double percentage = (tColor0.Interval * intNum0) / interval;
                    if (percentage >= 1)
                    {
                        tColor0.Enabled = false;
                        Stand0List.BackColor = endColor;

                    }
                    else
                    {
                        Stand0List.BackColor = Color.FromArgb(
                            InterpolateColorChannel(startColor.R, endColor.R, percentage),
                            InterpolateColorChannel(startColor.G, endColor.G, percentage),
                            InterpolateColorChannel(startColor.B, endColor.B, percentage)
                        );
                    }
                    intNum0++;
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
            else
            {
                tColor0.Enabled = false;
            }
        }

        int intNum1 = 0;
        private void tColor1_Tick(object sender, EventArgs e)
        {
            if (Stand1List != null)
            {
                try
                {
                    interval = 1000 * intFourWT;
                    double percentage = (tColor1.Interval * intNum1) / interval;
                    if (percentage >= 1)
                    {
                        tColor1.Enabled = false;
                        Stand1List.BackColor = endColor;

                    }
                    else
                    {
                        Stand1List.BackColor = Color.FromArgb(
                            InterpolateColorChannel(startColor.R, endColor.R, percentage),
                            InterpolateColorChannel(startColor.G, endColor.G, percentage),
                            InterpolateColorChannel(startColor.B, endColor.B, percentage)
                        );
                    }
                    intNum1++;
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
            else
            {
                tColor1.Enabled = false;
            }
        }

        int intNum2 = 0;
        private void ts2SteelMovingMachine_Click(object sender, EventArgs e)
        {
            if (ts2SteelMovingMachine.Text.Trim() == "停止2号移钢机自动")
            {
                if (MessageBox.Show("是否停止2号移钢机自动?", "停止2号移钢机", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    lbTGJ.BackColor = Color.Red;
                    ts2SteelMovingMachine.Text = "开启2号移钢机自动";
                    bl2LiftingSteel = false;
                    this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num2RunAuto", 0);
                }
            }
            else if (ts2SteelMovingMachine.Text.Trim() == "开启2号移钢机自动")
            {
                bool flag0 = this.kepOpc.itemValue[194] == "True";
                if (flag0 == false)
                {
                    MessageBox.Show("全自动按钮未开启,请检查！");
                    return;
                }
                if (MessageBox.Show("是否开启2号移钢机自动?", "开启2号移钢机", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    lbTGJ.BackColor = Color.Yellow;
                    ts2SteelMovingMachine.Text = "停止2号移钢机自动";
                    bl2LiftingSteel = true;
                    this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num2RunAuto", 1);
                }
            }
        }

        private void lbNowSteel_MouseEnter(object sender, EventArgs e)
        {
            txtSpeed.Visible = true;
            if (!String.IsNullOrEmpty(txtSpeed.Text))
            {
                txtSpeed.SelectionStart = 0;
                txtSpeed.SelectionLength = txtSpeed.Text.Length;
                txtSpeed.Select(0, 3);
            }
        }

        private void txtSpeed_MouseLeave(object sender, EventArgs e)
        {
            txtSpeed.Visible = false;
            txtSpeed.Focus();
        }

        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {
            if(txtSpeed.Text.Trim().Length >=2)
            {
                SqlBase.ExecuteSql("update SysSet set RollingRollingTime = '" + txtSpeed.Text.Trim() + "'");
                intZG = int.Parse(txtSpeed.Text.Trim());
            }
        }

        private void txtSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //private void btnFourExit_Click(object sender, EventArgs e)
        //{
        //    if (btnFourExit.Text.Trim() == "去[冷床]")
        //    {
        //        blfourTP = true;
        //        btnFourExit.Text = "结束踢坯";
        //    }
        //    else
        //    {
        //        blfourTP = false;
        //        btnFourExit.Text = "去[冷床]";
        //    }
        //}

        private void tColor2_Tick(object sender, EventArgs e)
        {
            if (Stand2List != null)
            {
                try
                {
                    interval = 1000 * intFourWT;
                    double percentage = (tColor2.Interval * intNum2) / interval;
                    if (percentage >= 1)
                    {
                        tColor2.Enabled = false;
                        Stand2List.BackColor = endColor;

                    }
                    else
                    {
                        Stand2List.BackColor = Color.FromArgb(
                            InterpolateColorChannel(startColor.R, endColor.R, percentage),
                            InterpolateColorChannel(startColor.G, endColor.G, percentage),
                            InterpolateColorChannel(startColor.B, endColor.B, percentage)
                        );
                    }
                    intNum2++;
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
            else
            {
                tColor2.Enabled = false;
            }
        }

        int intNum3 = 0;
        private void tColor3_Tick(object sender, EventArgs e)
        {
            if (Stand3List != null)
            {
                try
                {
                    interval = 1000 * intFourWT;
                    double percentage = (tColor3.Interval * intNum3) / interval;
                    if (percentage >= 1)
                    {
                        tColor3.Enabled = false;
                        Stand3List.BackColor = endColor;

                    }
                    else
                    {
                        Stand3List.BackColor = Color.FromArgb(
                            InterpolateColorChannel(startColor.R, endColor.R, percentage),
                            InterpolateColorChannel(startColor.G, endColor.G, percentage),
                            InterpolateColorChannel(startColor.B, endColor.B, percentage)
                        );
                    }
                    intNum3++;
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
            else
            {
                tColor3.Enabled = false;
            }
        }

        bool blfirst = false;
        private void tsSteelMovingMachine_Click(object sender, EventArgs e)
        {
            if (ts1SteelMovingMachine.Text.Trim() == "停止1号移钢机自动")
            {
                if (MessageBox.Show("是否停止1号移钢机自动?", "停止1号移钢机", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    lbTGJ.BackColor = Color.Red;
                    ts1SteelMovingMachine.Text = "开启1号移钢机自动";
                    bl1LiftingSteel = false;
                    this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1RunAuto", 0);
                }
            }
            else if (ts1SteelMovingMachine.Text.Trim() == "开启1号移钢机自动")
            {
                bool flag0 = this.kepOpc.itemValue[194] == "True";
                if(flag0== false)
                {
                    MessageBox.Show("全自动按钮未开启,请检查！");
                    return;
                }
                if (MessageBox.Show("是否开启1号移钢机自动?", "开启1号移钢机", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    lbTGJ.BackColor = Color.Yellow;
                    ts1SteelMovingMachine.Text = "停止1号移钢机自动";
                    bl1LiftingSteel = true;
                    this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1RunAuto", 1);
                    blfirst = true;
                }
            }
        }

        int intNum4 = 0;

        private void btnLiftingSteel1_Click(object sender, EventArgs e)
        {
            bool flag0 = this.kepOpc.itemValue[194] == "True";
            if (flag0 == false)
            {
                MessageBox.Show("全自动按钮未开启,请检查！");
                return;
            }
            int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
            if (intstart == 0)
            {
                MessageBox.Show("1号移钢机未开启,请检查！");
                return;
            }
            if (FlipSteelList.Contains("1_0") == false)
                FlipSteelList.Insert(0, "1_0");
        }

        private void btnLiftingSteel0_Click(object sender, EventArgs e)
        {
            bool flag0 = this.kepOpc.itemValue[194] == "True";
            if (flag0 == false)
            {
                MessageBox.Show("全自动按钮未开启,请检查！");
                return;
            }
            int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
            if (intstart == 0)
            {
                MessageBox.Show("1号移钢机未开启,请检查！");
                return;
            }
            if (FlipSteelList.Contains("7_0") == false)
                FlipSteelList.Insert(0, "7_0");
        }

        private void btnLiftingSteel2_Click(object sender, EventArgs e)
        {
            bool flag0 = this.kepOpc.itemValue[194] == "True";
            if (flag0 == false)
            {
                MessageBox.Show("全自动按钮未开启,请检查！");
                return;
            }
            int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
            if (intstart == 0)
            {
                MessageBox.Show("1号移钢机未开启,请检查！");
                return;
            }
            if (FlipSteelList.Contains("2_0") == false)
                FlipSteelList.Insert(0, "2_0");
        }

        private void btnLiftingSteel3_Click(object sender, EventArgs e)
        {
            bool flag0 = this.kepOpc.itemValue[194] == "True";
            if (flag0 == false)
            {
                MessageBox.Show("全自动按钮未开启,请检查！");
                return;
            }
            int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
            if (intstart == 0)
            {
                MessageBox.Show("1号移钢机未开启,请检查！");
                return;
            }
            if (FlipSteelList.Contains("3_0") == false)
                FlipSteelList.Insert(0, "3_0");
        }

        private void btnLiftingSteel4_Click(object sender, EventArgs e)
        {
            bool flag0 = this.kepOpc.itemValue[194] == "True";
            if (flag0 == false)
            {
                MessageBox.Show("全自动按钮未开启,请检查！");
                return;
            }
            int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
            if (intstart == 0)
            {
                MessageBox.Show("1号移钢机未开启,请检查！");
                return;
            }
            if (FlipSteelList.Contains("4_0") == false)
                FlipSteelList.Insert(0, "4_0");
        }

        private void btnLiftingSteel5_Click(object sender, EventArgs e)
        {
            bool flag0 = this.kepOpc.itemValue[194] == "True";
            if (flag0 == false)
            {
                MessageBox.Show("全自动按钮未开启,请检查！");
                return;
            }
            int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
            if (intstart == 0)
            {
                MessageBox.Show("1号移钢机未开启,请检查！");
                return;
            }
            if (FlipSteelList.Contains("5_0") == false)
                FlipSteelList.Insert(0, "5_0");
        }

        private void btnLiftingSteel6_Click(object sender, EventArgs e)
        {
            bool flag0 = this.kepOpc.itemValue[194] == "True";
            if (flag0 == false)
            {
                MessageBox.Show("全自动按钮未开启,请检查！");
                return;
            }
            int intstart = int.Parse(this.kepOpc.itemValue[195].ToString().Trim());
            if (intstart == 0)
            {
                MessageBox.Show("1号移钢机未开启,请检查！");
                return;
            }
            if (FlipSteelList.Contains("6_0") == false)
                FlipSteelList.Insert(0, "6_0");
        }

        private void btnFlipSteeling0_Click(object sender, EventArgs e)
        {
            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "0流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

            int intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }

            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "0流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

            intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }

            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 0);
            this.kepOpc.WriteObj("opc_plc00.opc_plc0.SHIFTER_UP_1", 0);
        }

        private void btnFlipSteeling1_Click(object sender, EventArgs e)
        {
            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "1流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
            //Thread.Sleep(3000);
            int intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "1流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
            //Thread.Sleep(3000);
            intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 0);
            this.kepOpc.WriteObj("opc_plc01.opc_plc1.SHIFTER_UP_1", 0);
        }

        private void btnFlipSteeling2_Click(object sender, EventArgs e)
        {
            this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "2流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

            int intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "2流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

            intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 0);
            this.kepOpc.WriteObj("opc_plc02.opc_plc2.SHIFTER_UP_1", 0);
        }

        private void btnFlipSteeling3_Click(object sender, EventArgs e)
        {
            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "3流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

            int intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "3流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
            intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 0);
            this.kepOpc.WriteObj("opc_plc03.opc_plc3.SHIFTER_UP_1", 0);
        }

        private void btnFlipSteeling4_Click(object sender, EventArgs e)
        {
            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "4流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
            int intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "4流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
            intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 0);
            this.kepOpc.WriteObj("opc_plc04.opc_plc4.SHIFTER_UP_1", 0);
        }

        private void btnFlipSteeling5_Click(object sender, EventArgs e)
        {
            this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "5流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

            int intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "5流翻钢__时间是:" + DateTime.Now + Environment.NewLine);

            intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 0);
            this.kepOpc.WriteObj("opc_plc05.opc_plc5.SHIFTER_UP_1", 0);
        }

        private void btnFlipSteeling6_Click(object sender, EventArgs e)
        {
            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "6流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
            //Thread.Sleep(3000);
            int intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }

            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 1);
            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", "6流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
            //Thread.Sleep(3000);
            intn = 0;
            while (true)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                intn++;
                if (intn > 20)
                {
                    break;
                }
            }
            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 0);
            this.kepOpc.WriteObj("opc_plc06.opc_plc6.SHIFTER_UP_1", 0);
        }

        private void btnFlipSteeling0_MouseLeave(object sender, EventArgs e)
        {
            if (btnFlipSteeling0.Text.Trim() == "翻钢")
                animator.HideSync(btnFlipSteeling0, true, Animation.Transparent);
            if (btnLiftingSteel0.Text.Trim() == "提钢")
                animator.HideSync(btnLiftingSteel0, true, Animation.Transparent);
        }

        private void btnFlipSteeling1_MouseLeave(object sender, EventArgs e)
        {
            if (btnFlipSteeling1.Text.Trim() == "翻钢")
                animator.HideSync(btnFlipSteeling1, true, Animation.Transparent);
            if (btnLiftingSteel1.Text.Trim() == "提钢")
                animator.HideSync(btnLiftingSteel1, true, Animation.Transparent);
        }

        private void btnFlipSteeling2_MouseLeave(object sender, EventArgs e)
        {
            if (btnFlipSteeling2.Text.Trim() == "翻钢")
                animator.HideSync(btnFlipSteeling2, true, Animation.Transparent);
            if (btnLiftingSteel2.Text.Trim() == "提钢")
                animator.HideSync(btnLiftingSteel2, true, Animation.Transparent);
        }

        private void btnFlipSteeling3_MouseLeave(object sender, EventArgs e)
        {
            if (btnFlipSteeling3.Text.Trim() == "翻钢")
                animator.HideSync(btnFlipSteeling3, true, Animation.Transparent);
            if (btnLiftingSteel3.Text.Trim() == "提钢")
                animator.HideSync(btnLiftingSteel3, true, Animation.Transparent);
        }

        private void btnFlipSteeling4_MouseLeave(object sender, EventArgs e)
        {
            if (btnFlipSteeling4.Text.Trim() == "翻钢")
                animator.HideSync(btnFlipSteeling4, true, Animation.Transparent);
            if (btnLiftingSteel4.Text.Trim() == "提钢")
                animator.HideSync(btnLiftingSteel4, true, Animation.Transparent);
        }

        private void btnFlipSteeling5_MouseLeave(object sender, EventArgs e)
        {
            if (btnFlipSteeling5.Text.Trim() == "翻钢")
                animator.HideSync(btnFlipSteeling5, true, Animation.Transparent);
            if (btnLiftingSteel5.Text.Trim() == "提钢")
                animator.HideSync(btnLiftingSteel5, true, Animation.Transparent);
        }

        private void btnFlipSteeling6_MouseLeave(object sender, EventArgs e)
        {
            if (btnFlipSteeling6.Text.Trim() == "翻钢")
                animator.HideSync(btnFlipSteeling6, true, Animation.Transparent);
            if (btnLiftingSteel6.Text.Trim() == "提钢")
                animator.HideSync(btnLiftingSteel6, true, Animation.Transparent);
        }

        private void txtGo4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGoCold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tColor4_Tick(object sender, EventArgs e)
        {
            if (Stand4List != null)
            {
                try
                {
                    interval = 1000 * intFourWT;
                    double percentage = (tColor4.Interval * intNum4) / interval;
                    if (percentage >= 1)
                    {
                        tColor4.Enabled = false;
                        Stand4List.BackColor = endColor;

                    }
                    else
                    {
                        Stand4List.BackColor = Color.FromArgb(
                            InterpolateColorChannel(startColor.R, endColor.R, percentage),
                            InterpolateColorChannel(startColor.G, endColor.G, percentage),
                            InterpolateColorChannel(startColor.B, endColor.B, percentage)
                        );
                    }
                    intNum4++;
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
            else
            {
                tColor4.Enabled = false;
            }
        }

        int intgo4 = 0,intgocold = 0;
        private void txtGoCold_TextChanged(object sender, EventArgs e)
        {    if(txtGoCold.Text.Trim()!= "")
                intgocold = int.Parse(txtGoCold.Text.Trim());
        }

        private void txtSpeed_MouseMove(object sender, MouseEventArgs e)
        {
            txtSpeed.Focus();
        }

        private void IntelligentBilletProduction_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1RunAuto", 0);
        }

        private void txtGo4_TextChanged(object sender, EventArgs e)
        {
            if (txtGo4.Text.Trim() != "")
                intgo4 = int.Parse(txtGo4.Text.Trim());
        }

        int intNum5 = 0;
        private void tColor5_Tick(object sender, EventArgs e)
        {
            if (Stand5List != null)
            {
                try
                {
                    interval = 1000 * intFourWT;
                    double percentage = (tColor5.Interval * intNum5) / interval;
                    if (percentage >= 1)
                    {
                        tColor5.Enabled = false;
                        Stand5List.BackColor = endColor;

                    }
                    else
                    {
                        Stand5List.BackColor = Color.FromArgb(
                            InterpolateColorChannel(startColor.R, endColor.R, percentage),
                            InterpolateColorChannel(startColor.G, endColor.G, percentage),
                            InterpolateColorChannel(startColor.B, endColor.B, percentage)
                        );
                    }
                    intNum5++;
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
            else
            {
                tColor5.Enabled = false;
            }
        }

        int intNum6 = 0;
        private void tColor6_Tick(object sender, EventArgs e)
        {
            if (Stand6List != null)
            {
                try
                {
                    interval = 1000 * intFourWT;
                    double percentage = (tColor6.Interval * intNum6) / interval;
                    if (percentage >= 1)
                    {
                        tColor6.Enabled = false;
                        Stand6List.BackColor = endColor;

                    }
                    else
                    {
                        Stand6List.BackColor = Color.FromArgb(
                            InterpolateColorChannel(startColor.R, endColor.R, percentage),
                            InterpolateColorChannel(startColor.G, endColor.G, percentage),
                            InterpolateColorChannel(startColor.B, endColor.B, percentage)
                        );
                    }
                    intNum6++;
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
            else
            {
                tColor6.Enabled = false;
            }
        }

        private int InterpolateColorChannel(int startValue, int endValue, double percentage)
        {
            return (int)(startValue * (1 - percentage) + endValue * percentage);
        }

        int intM2 = 0;

        private void IntelligentBilletProduction_Load(object sender, EventArgs e)
        {
            
        }

        private void tStand2_Tick(object sender, EventArgs e)
        {
            intM2++;
            Stand2List.Text = "2流正在切割" + "(" + intM2 + ")";
          
            if (intM2 > intCT)
            {
                gcRunList.Rows.Add();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "2流钢坯切割异常";
                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('2流钢坯切割异常','" + DateTime.Now.ToString() + "')");
                tStand2.Enabled = false;
                bltp[2] = 1;
                blIsRun2 = false;
                plAlarm.Left = 220;
                plAlarm.Top = btn2Continue.Top;
                lbAlarmStr.Text = "2流钢坯切割异常，请检查！";
                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                intalarm[2] = 1;
                waveOut.Play();
                Stand2List.Tag = null;
                Controls.Remove(Stand2List);
                Stand2List.Dispose();
                Application.DoEvents();
            }
        }

        private void tsSeeTables_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.ShowDialog();
        }

        private void 轧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button btn = cmschange.SourceControl as Button;
            if(btn.Name.Trim() == "Stand0")
            {
                MessageBox.Show("0流无法去1轧,请检查！");
                return;
                //if((intCT - intM0 + intGD) > 9)
                //{

                //}
            }
            else if (btn.Name.Trim() == "Stand1")
            {
                if ((intCT - intM1 + intGD) > 9)
                {

                }
            }
            else if (btn.Name.Trim() == "Stand2")
            {
                if ((intCT - intM2 + intGD) > 9)
                {

                }
            }
            else if (btn.Name.Trim() == "Stand3")
            {
                if ((intCT - intM3 + intGD) > 9)
                {

                }
            }
            else if (btn.Name.Trim() == "Stand4")
            {
                if ((intCT - intM4 + intGD) > 9)
                {

                }
            }
            else if (btn.Name.Trim() == "Stand5")
            {
                if ((intCT - intM5 + intGD) > 9)
                {

                }
            }
            else if (btn.Name.Trim() == "Stand6")
            {
                MessageBox.Show("6流无法去1轧,请检查！");
                return;
                //if ((intCT - intM6 + intGD) > 9)
                //{

                //}
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Button btn = cmschange.SourceControl as Button;
            if (btn != null)
            {
                if(btn.Text.Trim().Contains("等待") == true)
                {
                    string strFG = "", strStand = "",strGo = "";
                    bool blFlag = false;
                    while (true)
                    {
                        if (btn.Name.Trim() == "Stand1")
                        {
                            strFG = "opc_plc01.opc_plc1.SHIFTER_UP_1";
                            strStand = "1";
                            blFlag = this.kepOpc.itemValue[18] == "True";
                            strGo = strone1;
                        }
                        else if (btn.Name.Trim() == "Stand2")
                        {
                            strFG = "opc_plc02.opc_plc2.SHIFTER_UP_1";
                            strStand = "2";
                            blFlag = this.kepOpc.itemValue[30] == "True";
                            strGo = strone2;
                        }
                        else if (btn.Name.Trim() == "Stand3")
                        {
                            strFG = "opc_plc03.opc_plc3.SHIFTER_UP_1";
                            strStand = "3";
                            blFlag = this.kepOpc.itemValue[42] == "True";
                            strGo = strone3;
                        }
                        else if (btn.Name.Trim() == "Stand4")
                        {
                            strFG = "opc_plc04.opc_plc4.SHIFTER_UP_1";
                            strStand = "4";
                            blFlag = this.kepOpc.itemValue[54] == "True";
                            strGo = strone4;
                        }
                        else if (btn.Name.Trim() == "Stand5")
                        {
                            strFG = "opc_plc05.opc_plc5.SHIFTER_UP_1";
                            strStand = "5";
                            blFlag = this.kepOpc.itemValue[66] == "True";
                            strGo = strone5;
                        }
                        if (blFlag == true)
                        {
                            btn.Text = btn.Text.Substring(0,2) + "去[" + strGo + "]";

                            this.kepOpc.WriteObj(strFG, 1);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", strStand + "流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                            int intn = 0;
                            while (true)
                            {
                                Thread.Sleep(100);
                                Application.DoEvents();
                                intn++;
                                if (intn > 20)
                                {
                                    break;
                                }
                            }
                            this.kepOpc.WriteObj(strFG, 1);
                            System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", strStand + "流翻钢__时间是:" + DateTime.Now + Environment.NewLine);
                            intn = 0;
                            while (true)
                            {
                                Thread.Sleep(100);
                                Application.DoEvents();
                                intn++;
                                if (intn > 20)
                                {
                                    break;
                                }
                            }
                            this.kepOpc.WriteObj(strFG, 0);
                            bloneroll = true;
                            break;
                        }
                        Thread.Sleep(200);
                        Application.DoEvents();
                    }
                }
                else
                {
                    MessageBox.Show("当前钢坯无法去4轧，请检查！");
                }
            }
        }

        private void 冷床ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button btn = cmschange.SourceControl as Button;
        }

        int intsteelrollingsecond = 0, intreturnfurnace = 0, intfoursteelrollingsecond = 0;
        private void tIsSteelrolling_Tick(object sender, EventArgs e)
        {
            bool blflag1 = this.kepOpc.itemValue[161] == "True";
            bool blflag4 = this.kepOpc.itemValue[163] == "True";
            string strrun1 = "",strrun4 = "";
            if(blflag1)
            {
                strrun1 = "1轧允许送坯(" + (intZG - intsteelrollingsecond) + ")";
            }
            else
            {
                strrun1 = "1轧停止送坯";
            }
            if (blflag4)
            {
                strrun4 = "4轧允许送坯(" + (intHL - intfoursteelrollingsecond) + ")"; //"4轧允许送坯(" + intfoursteelrollingsecond + ")";
            }
            else
            {
                strrun4 = "4轧停止送坯";
            }
            if (strrun1.Contains("允许") == true)
            {
                lb1Rolling.BackColor = Color.Red;
                lb1Rolling.ForeColor = Color.White;
            }
            else if (strrun1.Contains("停止") == true)
            {
                lb1Rolling.BackColor = Color.Black;
                lb1Rolling.ForeColor = Color.White;
            }

            if (strrun4.Contains("允许") == true)
            {
                lb4Rolling.BackColor = Color.Red;
                lb4Rolling.ForeColor = Color.White;
            }
            else if (strrun4.Contains("停止") == true)
            {
                lb4Rolling.BackColor = Color.Black;
                lb4Rolling.ForeColor = Color.White;
            }
            lb1Rolling.Text = strrun1;
            lb4Rolling.Text = strrun4;
            bool blr = this.kepOpc.itemValue[0] == "True";
            if (blr == true)
            {
                if (this.kepOpc.itemValue[84] != null)
                {
                    string str0 = this.kepOpc.itemValue[84].Trim();
                    if (double.Parse(str0) > 0)
                    {
                        if (Stand0Run.ConveyorDirection != ConveyorDirection.Forward)
                            Stand0Run.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand0Run1.ConveyorDirection != ConveyorDirection.Forward)
                            Stand0Run1.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand0Run2.ConveyorDirection != ConveyorDirection.Forward)
                            Stand0Run2.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand0Run3.ConveyorDirection != ConveyorDirection.Forward)
                            Stand0Run3.ConveyorDirection = ConveyorDirection.Forward;
                    }
                    else
                    {
                        Stand0Run.ConveyorDirection = ConveyorDirection.None;
                        Stand0Run1.ConveyorDirection = ConveyorDirection.None;
                        Stand0Run2.ConveyorDirection = ConveyorDirection.None;
                        Stand0Run3.ConveyorDirection = ConveyorDirection.None;
                    }
                    S0.Text = Math.Round(double.Parse(str0),3).ToString();
                }
            }
            else
            {
                Stand0Run.ConveyorDirection = ConveyorDirection.None;
                Stand0Run1.ConveyorDirection = ConveyorDirection.None;
                Stand0Run2.ConveyorDirection = ConveyorDirection.None;
                Stand0Run3.ConveyorDirection = ConveyorDirection.None;
            }
            blr = this.kepOpc.itemValue[12] == "True";
            if (blr == true)
            {
                if (this.kepOpc.itemValue[87] != null)
                {
                    string str0 = this.kepOpc.itemValue[87].Trim();
                    if (double.Parse(str0) > 0)
                    {
                        if (Stand1Run.ConveyorDirection != ConveyorDirection.Forward)
                            Stand1Run.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand1Run1.ConveyorDirection != ConveyorDirection.Forward)
                            Stand1Run1.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand1Run2.ConveyorDirection != ConveyorDirection.Forward)
                            Stand1Run2.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand1Run3.ConveyorDirection != ConveyorDirection.Forward)
                            Stand1Run3.ConveyorDirection = ConveyorDirection.Forward;
                    }
                    else
                    {
                        Stand1Run.ConveyorDirection = ConveyorDirection.None;
                        Stand1Run1.ConveyorDirection = ConveyorDirection.None;
                        Stand1Run2.ConveyorDirection = ConveyorDirection.None;
                        Stand1Run3.ConveyorDirection = ConveyorDirection.None;
                    }
                    S1.Text = Math.Round(double.Parse(str0), 3).ToString();
                }
            }
            else
            {
                Stand1Run.ConveyorDirection = ConveyorDirection.None;
                Stand1Run1.ConveyorDirection = ConveyorDirection.None;
                Stand1Run2.ConveyorDirection = ConveyorDirection.None;
                Stand1Run3.ConveyorDirection = ConveyorDirection.None;
            }
            blr = this.kepOpc.itemValue[24] == "True";
            if (blr == true)
            {
                if (this.kepOpc.itemValue[90] != null)
                {
                    string str0 = this.kepOpc.itemValue[90].Trim();
                    if (double.Parse(str0) > 0)
                    {
                        if (Stand2Run.ConveyorDirection != ConveyorDirection.Forward)
                            Stand2Run.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand2Run1.ConveyorDirection != ConveyorDirection.Forward)
                            Stand2Run1.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand2Run2.ConveyorDirection != ConveyorDirection.Forward)
                            Stand2Run2.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand2Run3.ConveyorDirection != ConveyorDirection.Forward)
                            Stand2Run3.ConveyorDirection = ConveyorDirection.Forward;
                    }
                    else
                    {
                        Stand2Run.ConveyorDirection = ConveyorDirection.None;
                        Stand2Run1.ConveyorDirection = ConveyorDirection.None;
                        Stand2Run2.ConveyorDirection = ConveyorDirection.None;
                        Stand2Run3.ConveyorDirection = ConveyorDirection.None;
                    }
                    S2.Text = Math.Round(double.Parse(str0), 3).ToString();
                }
            }
            else
            {
                Stand2Run.ConveyorDirection = ConveyorDirection.None;
                Stand2Run1.ConveyorDirection = ConveyorDirection.None;
                Stand2Run2.ConveyorDirection = ConveyorDirection.None;
                Stand2Run3.ConveyorDirection = ConveyorDirection.None;
            }
            blr = this.kepOpc.itemValue[36] == "True";
            if (blr == true)
            {
                if (this.kepOpc.itemValue[93] != null)
                {
                    string str0 = this.kepOpc.itemValue[93].Trim();
                    if (double.Parse(str0) > 0)
                    {
                        if (Stand3Run.ConveyorDirection != ConveyorDirection.Forward)
                            Stand3Run.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand3Run1.ConveyorDirection != ConveyorDirection.Forward)
                            Stand3Run1.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand3Run2.ConveyorDirection != ConveyorDirection.Forward)
                            Stand3Run2.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand3Run3.ConveyorDirection != ConveyorDirection.Forward)
                            Stand3Run3.ConveyorDirection = ConveyorDirection.Forward;
                    }
                    else
                    {
                        Stand3Run.ConveyorDirection = ConveyorDirection.None;
                        Stand3Run1.ConveyorDirection = ConveyorDirection.None;
                        Stand3Run2.ConveyorDirection = ConveyorDirection.None;
                        Stand3Run3.ConveyorDirection = ConveyorDirection.None;
                    }
                    S3.Text = Math.Round(double.Parse(str0), 3).ToString();
                }
            }
            else
            {
                Stand3Run.ConveyorDirection = ConveyorDirection.None;
                Stand3Run1.ConveyorDirection = ConveyorDirection.None;
                Stand3Run2.ConveyorDirection = ConveyorDirection.None;
                Stand3Run3.ConveyorDirection = ConveyorDirection.None;
            }
            blr = this.kepOpc.itemValue[48] == "True";
            if (blr == true)
            {
                if (this.kepOpc.itemValue[96] != null)
                {
                    string str0 = this.kepOpc.itemValue[96].Trim();
                    if (double.Parse(str0) > 0)
                    {
                        if (Stand4Run.ConveyorDirection != ConveyorDirection.Forward)
                            Stand4Run.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand4Run1.ConveyorDirection != ConveyorDirection.Forward)
                            Stand4Run1.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand4Run2.ConveyorDirection != ConveyorDirection.Forward)
                            Stand4Run2.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand4Run3.ConveyorDirection != ConveyorDirection.Forward)
                            Stand4Run3.ConveyorDirection = ConveyorDirection.Forward;
                    }
                    else
                    {
                        Stand4Run.ConveyorDirection = ConveyorDirection.None;
                        Stand4Run1.ConveyorDirection = ConveyorDirection.None;
                        Stand4Run2.ConveyorDirection = ConveyorDirection.None;
                        Stand4Run3.ConveyorDirection = ConveyorDirection.None;
                    }
                    S4.Text = Math.Round(double.Parse(str0), 3).ToString();
                }
            }
            else
            {
                Stand4Run.ConveyorDirection = ConveyorDirection.None;
                Stand4Run1.ConveyorDirection = ConveyorDirection.None;
                Stand4Run2.ConveyorDirection = ConveyorDirection.None;
                Stand4Run3.ConveyorDirection = ConveyorDirection.None;
            }
            blr = this.kepOpc.itemValue[60] == "True";
            if (blr == true)
            {
                if (this.kepOpc.itemValue[99] != null)
                {
                    string str0 = this.kepOpc.itemValue[99].Trim();
                    if (double.Parse(str0) > 0)
                    {
                        if (Stand5Run.ConveyorDirection != ConveyorDirection.Forward)
                            Stand5Run.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand5Run1.ConveyorDirection != ConveyorDirection.Forward)
                            Stand5Run1.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand5Run2.ConveyorDirection != ConveyorDirection.Forward)
                            Stand5Run2.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand5Run3.ConveyorDirection != ConveyorDirection.Forward)
                            Stand5Run3.ConveyorDirection = ConveyorDirection.Forward;
                    }
                    else
                    {
                        Stand5Run.ConveyorDirection = ConveyorDirection.None;
                        Stand5Run1.ConveyorDirection = ConveyorDirection.None;
                        Stand5Run2.ConveyorDirection = ConveyorDirection.None;
                        Stand5Run3.ConveyorDirection = ConveyorDirection.None;
                    }
                    S5.Text = Math.Round(double.Parse(str0), 3).ToString();
                }
            }
            else
            {
                Stand5Run.ConveyorDirection = ConveyorDirection.None;
                Stand5Run1.ConveyorDirection = ConveyorDirection.None;
                Stand5Run2.ConveyorDirection = ConveyorDirection.None;
                Stand5Run3.ConveyorDirection = ConveyorDirection.None;
            }
            blr = this.kepOpc.itemValue[72] == "True";
            if (blr == true)
            {
                if (this.kepOpc.itemValue[102] != null)
                {
                    string str0 = this.kepOpc.itemValue[102].Trim();
                    if (double.Parse(str0) > 0)
                    {
                        if (Stand6Run.ConveyorDirection != ConveyorDirection.Forward)
                            Stand6Run.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand6Run1.ConveyorDirection != ConveyorDirection.Forward)
                            Stand6Run1.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand6Run2.ConveyorDirection != ConveyorDirection.Forward)
                            Stand6Run2.ConveyorDirection = ConveyorDirection.Forward;
                        if (Stand6Run3.ConveyorDirection != ConveyorDirection.Forward)
                            Stand6Run3.ConveyorDirection = ConveyorDirection.Forward;
                    }
                    else
                    {
                        Stand6Run.ConveyorDirection = ConveyorDirection.None;
                        Stand6Run1.ConveyorDirection = ConveyorDirection.None;
                        Stand6Run2.ConveyorDirection = ConveyorDirection.None;
                        Stand6Run3.ConveyorDirection = ConveyorDirection.None;
                    }
                    S6.Text = Math.Round(double.Parse(str0), 3).ToString();
                }
            }
            else
            {
                Stand6Run.ConveyorDirection = ConveyorDirection.None;
                Stand6Run1.ConveyorDirection = ConveyorDirection.None;
                Stand6Run2.ConveyorDirection = ConveyorDirection.None;
                Stand6Run3.ConveyorDirection = ConveyorDirection.None;
            }
            //if (this.kepOpc.itemValue[102] != null)
            //{
            //    string str0 = this.kepOpc.itemValue[102].Trim();
            //    if (double.Parse(str0) > 0)
            //    {
                    if (Rolling4Run.ConveyorDirection != ConveyorDirection.Backward)
                        Rolling4Run.ConveyorDirection = ConveyorDirection.Backward;
            //    }
            //    else
            //    {
            //        Rolling4Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.None;
            //    }
            //}
            if (this.kepOpc.itemValue[86] != null && this.kepOpc.itemValue[85] != null)
            {
                DataTable dtsection = SqlBase.ExecuteSql4Dt("select * from Section where num = '" + this.kepOpc.itemValue[86].Trim() + "'");
                DataTable dtsteeltype = SqlBase.ExecuteSql4Dt("select * from SteelCuttingTime where num = '" + this.kepOpc.itemValue[85].Trim() + "'");
                if (dtsection.Rows.Count > 0 && dtsteeltype.Rows.Count > 0)
                    lbNowSteel.Text = "当前钢种:" + dtsteeltype.Rows[0]["steelType"].ToString().Trim() + "       断面:" + dtsection.Rows[0]["section"].ToString().Trim();
            }
            DataTable dtct = SqlBase.ExecuteSql4Dt("select * from SysSet");
            if (dtct.Rows.Count > 0 && dtct != null && dtct.Rows[0]["SteelCuttingTime"] != null && dtct.Rows[0]["SteelCuttingTime"].ToString().Trim() != "")
            {
                intCT = int.Parse(dtct.Rows[0]["SteelCuttingTime"].ToString().Trim());
            }
        }

        int intM3 = 0;
        private void tStand3_Tick(object sender, EventArgs e)
        {
            intM3++;
            Stand3List.Text = "3流正在切割" + "(" + intM3 + ")";

            if (intM3 > intCT)
            {
                gcRunList.Rows.Add();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "3流钢坯切割异常";
                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('3流钢坯切割异常','" + DateTime.Now.ToString() + "')");
                tStand3.Enabled = false;
                bltp[3] = 1;
                blIsRun3 = false;
                plAlarm.Left = 220;
                plAlarm.Top = btn3Continue.Top;
                lbAlarmStr.Text = "3流钢坯切割异常，请检查！";
                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                intalarm[3] = 1;
                waveOut.Play();
                Stand3List.Tag = null;
                Controls.Remove(Stand3List);
                Stand3List.Dispose();
                Application.DoEvents();
            }
        }

        int intM4 = 0;
        private void tStand4_Tick(object sender, EventArgs e)
        {
            intM4++;
            Stand4List.Text = "4流正在切割" + "(" + intM4 + ")";

            if (intM4 > intCT)
            {
                gcRunList.Rows.Add();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "4流钢坯切割异常";
                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('4流钢坯切割异常','" + DateTime.Now.ToString() + "')");
                tStand4.Enabled = false;
                bltp[4] = 1;
                blIsRun4 = false;
                plAlarm.Left = 220;
                plAlarm.Top = btn4Continue.Top;
                lbAlarmStr.Text = "4流钢坯切割异常，请检查！";
                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                intalarm[4] = 1;
                waveOut.Play();
                Stand4List.Tag = null;
                Controls.Remove(Stand4List);
                Stand4List.Dispose();
                Application.DoEvents();
            }
        }

        int intM5 = 0;
        private void tStand5_Tick(object sender, EventArgs e)
        {
            intM5++;
            Stand5List.Text = "5流正在切割" + "(" + intM5 + ")";

            if (intM5 > intCT)
            {
                gcRunList.Rows.Add();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "5流钢坯切割异常";
                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('5流钢坯切割异常','" + DateTime.Now.ToString() + "')");
                tStand5.Enabled = false;
                bltp[5] = 1;
                blIsRun5 = false;
                plAlarm.Left = 220;
                plAlarm.Top = btn5Continue.Top;
                lbAlarmStr.Text = "5流钢坯切割异常，请检查！";
                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                intalarm[5] = 1;
                waveOut.Play();
                Stand5List.Tag = null;
                Controls.Remove(Stand5List);
                Stand5List.Dispose();
                Application.DoEvents();
            }
        }

        int intM6 = 0;
        private void tStand6_Tick(object sender, EventArgs e)
        {
            intM6++;
            Stand6List.Text = "6流正在切割" + "(" + intM6 + ")";

            if (intM6 > intCT)
            {
                gcRunList.Rows.Add();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToString();
                gcRunList.Rows[gcRunList.Rows.Count - 1].Cells[1].Value = "6流钢坯切割异常";
                SqlBase.ExecuteSql("insert into SysAlarms(alarmmsg,alarmtime) values('6流钢坯切割异常','" + DateTime.Now.ToString() + "')");
                tStand6.Enabled = false;
                bltp[6] = 1;
                blIsRun6 = false;
                plAlarm.Left = 220;
                plAlarm.Top = btn6Continue.Top;
                lbAlarmStr.Text = "6流钢坯切割异常，请检查！";
                animator.ShowSync(plAlarm, true, Animation.HorizBlind);
                intalarm[6] = 1;
                waveOut.Play();
                Stand6List.Tag = null;
                Controls.Remove(Stand6List);
                Stand6List.Dispose();
                Application.DoEvents();
            }
        }

        bool blstand6 = false;
        int intblIsRun6 = -1;
        void getCuts6()
        {
            while (blIsSRun6 == true)
            {
                try
                {
                    if (this.kepOpc.itemValue[72] != null)
                    {
                        bool blr = this.kepOpc.itemValue[72] == "True";
                        if (blr == true)
                        {
                            bool flag = this.kepOpc.itemValue[83] == "True";
                            if (intblIsRun6 == -1)
                            {
                                if (flag == false)
                                {
                                    intblIsRun6 = 0;
                                }
                                else
                                {
                                    intblIsRun6 = 1;
                                }
                            }
                            if (intblIsRun0 == 0)
                            {
                                if (flag)
                                {
                                    if (blstand6 == false)
                                    {
                                        
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand6List != null)
                                            {
                                                intR6 = 0;
                                                blis6 = false;
                                                if (FlipSteelList.Contains("6_0") == true)
                                                    FlipSteelList.Remove("6_0");
                                                if (FlipSteelList.Contains("6_1") == true)
                                                    FlipSteelList.Remove("6_1");
                                                this.Controls.Remove(Stand6List);
                                                Stand6List.Dispose();
                                            }
                                            Stand6List = new Button();
                                            Stand6List.BackColor = Color.OrangeRed;
                                            Stand6List.FlatStyle = FlatStyle.Popup;
                                            Stand6List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand6List.ForeColor = Color.White;
                                            Stand6List.Tag = "Y";
                                            Stand6List.Name = "Stand6";
                                            Stand6List.Size = new Size(275, 50);
                                            Stand6List.TabIndex = 29;
                                            Stand6List.Text = "6流正在切割";
                                           
                                            Stand6List.Left = Stand6.Left;
                                            Stand6List.Top = Stand6.Top - Stand6List.Height - 3;
                                            Controls.Add(Stand6List);
                                            Stand6List.BringToFront();
                                            Stand6List.ContextMenuStrip = cmschange;
                                            //Stand6List = (steelbillet);
                                            tStand6.Enabled = true;
                                        }));
                                        blstand6 = true;
                                    }
                                }
                                else if (flag == false && blstand6 == true)
                                {
                                    GenerateProcess(6);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc06.opc_plc6.DRT_BL_EXIST_T", 0);
                                      
                                        tStand6.Enabled = false;
                                        blstand6 = false;
                                        intM6 = 0;
                                        if (bltp[6] != 2)
                                            Stand6List.BackColor = Color.Red;
                                        else
                                            Stand6List.BackColor = endColor;
                                        Stand6List.ForeColor = Color.White;
                                        isRun6 = true;
                                        intS6 = 0;
                                        intR6 = 0;
                                        blIsRun6 = true;
                                        threadRuns6 = new Thread(new ThreadStart(getRuns6));       //0流钢坯监测
                                        threadRuns6.Start();
                                        if (blonerolling[6] == false)
                                        {
                                            intNum6 = 0;
                                            tColor6.Enabled = false;
                                            if (bltp[6] != 2)
                                                tColor6.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (blstand6 == false)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (Stand6List != null)
                                            {
                                                intR6 = 0;
                                                blis6 = false;
                                                if (FlipSteelList.Contains("6_0") == true)
                                                    FlipSteelList.Remove("6_0");
                                                if (FlipSteelList.Contains("6_1") == true)
                                                    FlipSteelList.Remove("6_1");
                                                this.Controls.Remove(Stand6List);
                                                Stand6List.Dispose();
                                            }
                                            Stand6List = new Button();
                                            Stand6List.BackColor = Color.OrangeRed;
                                            Stand6List.FlatStyle = FlatStyle.Popup;
                                            Stand6List.Font = new Font("微软雅黑", 12.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                                            Stand6List.ForeColor = Color.White;

                                            Stand6List.Name = "Stand6";
                                            Stand6List.Size = new Size(275, 50);
                                            Stand6List.TabIndex = 29;
                                            Stand6List.Text = "6流正在切割";
                                            Stand6List.UseVisualStyleBackColor = false;
                                            Stand6List.Left = Stand6.Left;
                                            Stand6List.Top = Stand6.Top - Stand6List.Height - 3;
                                            Controls.Add(Stand6List);
                                            Stand6List.ContextMenuStrip = cmschange;
                                            //Stand6List = (steelbillet);
                                            tStand6.Enabled = true;
                                        }));
                                        blstand6 = true;
                                    }
                                }
                                else if (flag == false && blstand6 == true)
                                {
                                    GenerateProcess(6);
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.kepOpc.WriteObj("opc_plc06.opc_plc6.DRT_BL_EXIST_T", 0);
                                        
                                        tStand6.Enabled = false;
                                        blstand6 = false;
                                        intM6 = 0;
                                        if (bltp[6] != 2)
                                            Stand6List.BackColor = Color.Red;
                                        else
                                            Stand6List.BackColor = endColor;
                                        Stand6List.ForeColor = Color.White;
                                        isRun6 = true;
                                        intS6 = 0;
                                        intR6 = 0;
                                        blIsRun6 = true;
                                        threadRuns6 = new Thread(new ThreadStart(getRuns6));       //0流钢坯监测
                                        threadRuns6.Start();
                                        if (blonerolling[6] == false)
                                        {
                                            intNum6 = 0;
                                            tColor6.Enabled = false;
                                            if (bltp[6] != 2)
                                                tColor6.Enabled = true;
                                        }
                                    }));
                                }
                            }
                            Thread.Sleep(200);
                            Application.DoEvents();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.StackTrace + Environment.NewLine);
                    System.IO.File.AppendAllText(Application.StartupPath + "\\Log.txt", ex.Message + Environment.NewLine);
                }
            }
        }
        
        string strone0 = "", strone1 = "", strone2 = "", strone3 = "", strone4 = "", strone5 = "", strone6 = "";
        string strtwo0 = "", strtwo1 = "", strtwo2 = "", strtwo3 = "", strtwo4 = "", strtwo5 = "", strtwo6 = "";
        private IWavePlayer waveOut;
        private Mp3FileReader mp3FileReader;
        DataTable dtr = SqlBase.ExecuteSql4Dt("select * from SysSet");

        void MusicPlayer(string fileName)
        {
            waveOut = new WaveOutEvent();
            mp3FileReader = new Mp3FileReader(fileName);
            waveOut.Init(mp3FileReader);
        }

        ///// <summary>
        ///// 改变鼠标样式
        ///// </summary>
        //public static Cursor SetCursor(Form form)
        //{
        //    System.Drawing.Point hotPoint = new System.Drawing.Point(0, 0);
        //    Bitmap cursor = (Bitmap)Bitmap.FromFile(Application.StartupPath + "\\Images\\mycursor.png");
        //    int hotX = hotPoint.X;
        //    int hotY = hotPoint.Y;
        //    Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
        //    Graphics g = Graphics.FromImage(myNewCursor);
        //    g.Clear(Color.FromArgb(0, 0, 0, 0));
        //    g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
        //    cursor.Height);
        //    form.Cursor = new Cursor(myNewCursor.GetHicon());
        //    g.Dispose();
        //    myNewCursor.Dispose();
        //    return form.Cursor;
        //}
        int[] intalarm = new int[7];
        /// <summary>
        /// 功能启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntelligentBilletProduction_Shown(object sender, EventArgs e)
        {
            intwait[0] = 0;
            intwait[1] = 0;
            intwait[2] = 0;
            intwait[3] = 0;
            intwait[4] = 0;
            CheckForIllegalCrossThreadCalls = false;
            MusicPlayer(Application.StartupPath + "\\alarm.mp3");
            if (dtr != null && dtr.Rows.Count > 0)
            {
                if (dtr.Rows[0]["IsFixed"].ToString().Trim() == "0")
                {
                    lbFixed.Text = "不固定";
                }
                else
                {
                    lbFixed.Text = "固定";
                }
                if (dtr.Rows[0]["Stand0One"] != null && dtr.Rows[0]["Stand0One"].ToString().Trim() != "")
                {
                    strone0 = dtr.Rows[0]["Stand0One"].ToString().Trim();
                    if(strone0 == "1")
                    {
                        strone0 = "直送4轧";
                    }
                    else if (strone0 == "2")
                    {
                        strone0 = "步进台架";
                    }
                    else if (strone0 == "3")
                    {
                        strone0 = "往复送4轧";
                    }
                }
                if (dtr.Rows[0]["Stand0Two"] != null && dtr.Rows[0]["Stand0Two"].ToString().Trim() != "")
                {
                    strtwo0 = dtr.Rows[0]["Stand0Two"].ToString().Trim();
                    if (strtwo0 == "1")
                    {
                        strtwo0 = "滑轨";
                    }
                    else if (strtwo0 == "2")
                    {
                        strtwo0 = "冷床";
                    }
                    else if (strtwo0 == "3")
                    {
                        strtwo0 = "尾部推钢";
                    }
                }
                if (dtr.Rows[0]["Stand1One"] != null && dtr.Rows[0]["Stand1One"].ToString().Trim() != "")
                {
                    strone1 = dtr.Rows[0]["Stand1One"].ToString().Trim();
                    if (strone1 == "1")
                    {
                        strone1 = "直送4轧";
                    }
                    else if (strone1 == "2")
                    {
                        strone1 = "步进台架";
                    }
                    else if (strone1 == "3")
                    {
                        strone1 = "往复送4轧";
                    }
                }
                if (dtr.Rows[0]["Stand1Two"] != null && dtr.Rows[0]["Stand1Two"].ToString().Trim() != "")
                {
                    strtwo1 = dtr.Rows[0]["Stand1Two"].ToString().Trim();
                    if (strtwo1 == "1")
                    {
                        strtwo1 = "滑轨";
                    }
                    else if (strtwo1 == "2")
                    {
                        strtwo1 = "冷床";
                    }
                    else if (strtwo1 == "3")
                    {
                        strtwo1 = "尾部推钢";
                    }
                }
                if (dtr.Rows[0]["Stand2One"] != null && dtr.Rows[0]["Stand2One"].ToString().Trim() != "")
                {
                    strone2 = dtr.Rows[0]["Stand2One"].ToString().Trim();
                    if (strone2 == "1")
                    {
                        strone2 = "直送4轧";
                    }
                    else if (strone2 == "2")
                    {
                        strone2 = "步进台架";
                    }
                    else if (strone2 == "3")
                    {
                        strone2 = "往复送4轧";
                    }
                }
                if (dtr.Rows[0]["Stand2Two"] != null && dtr.Rows[0]["Stand2Two"].ToString().Trim() != "")
                {
                    strtwo2 = dtr.Rows[0]["Stand2Two"].ToString().Trim();
                    if (strtwo2 == "1")
                    {
                        strtwo2 = "滑轨";
                    }
                    else if (strtwo2 == "2")
                    {
                        strtwo2 = "冷床";
                    }
                    else if (strtwo2 == "3")
                    {
                        strtwo2 = "尾部推钢";
                    }
                }
                if (dtr.Rows[0]["Stand3One"] != null && dtr.Rows[0]["Stand3One"].ToString().Trim() != "")
                {
                    strone3 = dtr.Rows[0]["Stand3One"].ToString().Trim();
                    if (strone3 == "1")
                    {
                        strone3 = "直送4轧";
                    }
                    else if (strone3 == "2")
                    {
                        strone3 = "步进台架";
                    }
                    else if (strone3 == "3")
                    {
                        strone3 = "往复送4轧";
                    }
                }
                if (dtr.Rows[0]["Stand3Two"] != null && dtr.Rows[0]["Stand3Two"].ToString().Trim() != "")
                {
                    strtwo3 = dtr.Rows[0]["Stand3Two"].ToString().Trim();
                    if (strtwo3 == "1")
                    {
                        strtwo3 = "滑轨";
                    }
                    else if (strtwo3 == "2")
                    {
                        strtwo3 = "冷床";
                    }
                    else if (strtwo3 == "3")
                    {
                        strtwo3 = "尾部推钢";
                    }
                }
                if (dtr.Rows[0]["Stand4One"] != null && dtr.Rows[0]["Stand4One"].ToString().Trim() != "")
                {
                    strone4 = dtr.Rows[0]["Stand4One"].ToString().Trim();
                    if (strone4 == "1")
                    {
                        strone4 = "直送4轧";
                    }
                    else if (strone4 == "2")
                    {
                        strone4 = "步进台架";
                    }
                    else if (strone4 == "3")
                    {
                        strone4 = "往复送4轧";
                    }
                }
                if (dtr.Rows[0]["Stand4Two"] != null && dtr.Rows[0]["Stand4Two"].ToString().Trim() != "")
                {
                    strtwo4 = dtr.Rows[0]["Stand4Two"].ToString().Trim();
                    if (strtwo4 == "1")
                    {
                        strtwo4 = "滑轨";
                    }
                    else if (strtwo4 == "2")
                    {
                        strtwo4 = "冷床";
                    }
                    else if (strtwo4 == "3")
                    {
                        strtwo4 = "尾部推钢";
                    }
                }
                if (dtr.Rows[0]["Stand5One"] != null && dtr.Rows[0]["Stand5One"].ToString().Trim() != "")
                {
                    strone5 = dtr.Rows[0]["Stand5One"].ToString().Trim();
                    if (strone5 == "1")
                    {
                        strone5 = "直送4轧";
                    }
                    else if (strone5 == "2")
                    {
                        strone5 = "步进台架";
                    }
                    else if (strone5 == "3")
                    {
                        strone5 = "往复送4轧";
                    }
                }
                if (dtr.Rows[0]["Stand5Two"] != null && dtr.Rows[0]["Stand5Two"].ToString().Trim() != "")
                {
                    strtwo5 = dtr.Rows[0]["Stand5Two"].ToString().Trim();
                    if (strtwo5 == "1")
                    {
                        strtwo5 = "滑轨";
                    }
                    else if (strtwo5 == "2")
                    {
                        strtwo5 = "冷床";
                    }
                    else if (strtwo5 == "3")
                    {
                        strtwo5 = "尾部推钢";
                    }
                }
                if (dtr.Rows[0]["Stand6One"] != null && dtr.Rows[0]["Stand6One"].ToString().Trim() != "")
                {
                    strone6 = dtr.Rows[0]["Stand6One"].ToString().Trim();
                    if (strone6 == "1")
                    {
                        strone6 = "直送4轧";
                    }
                    else if (strone6 == "2")
                    {
                        strone6 = "步进台架";
                    }
                    else if (strone6 == "3")
                    {
                        strone6 = "往复送4轧";
                    }
                }
                if (dtr.Rows[0]["Stand6Two"] != null && dtr.Rows[0]["Stand6Two"].ToString().Trim() != "")
                {
                    strtwo6 = dtr.Rows[0]["Stand6Two"].ToString().Trim();
                    if (strtwo6 == "1")
                    {
                        strtwo6 = "滑轨";
                    }
                    else if (strtwo6 == "2")
                    {
                        strtwo6 = "冷床";
                    }
                    else if (strtwo6 == "3")
                    {
                        strtwo6 = "尾部推钢";
                    }
                }
            }
            Rolling4Run.Left = 0;
            Rolling4Run.Top = 155;
            Rolling4Run.Width = Width - 20;

            Stand0.Left = 0;
			Stand0.Width = 130;

            Stand1.Left = 0;
            Stand1.Width = 130;

            Stand2.Left = 0;
            Stand2.Width = 130;

            Stand3.Left = 0;
            Stand3.Width = 130;

            Stand4.Left = 0;
            Stand4.Width = 130;

            Stand5.Left = 0;
            Stand5.Width = 130;

            Stand6.Left = 0;
            Stand6.Width = 130;

			int inttop = (int)this.Height - (this.Height / 5) - 30;
			int inth = inttop / 7 -  26;

            Stand0.Top = Height - inttop;
            Stand1.Top = Stand0.Top + inth;
            Stand2.Top = Stand1.Top + inth;
            Stand3.Top = Stand2.Top + inth;
            Stand4.Top = Stand3.Top + inth;
            Stand5.Top = Stand4.Top + inth;
            Stand6.Top = Stand5.Top + inth;

            Stand0Run.Top = Stand0.Top - 3;
            Stand0Run.Left = Stand0.Left + Stand0.Width + 70;
            Stand0Run.Width = this.Width - 1450 - Stand0.Left - Stand0.Width;

            Stand0Run1.Top = Stand0.Top - 3;
            Stand0Run1.Left = Stand0.Left + Stand0.Width + Stand0Run.Left + Stand0Run.Width - 125;
            Stand0Run1.Width = this.Width - 1450 - Stand0.Left - Stand0.Width;

            Stand0Run2.Top = Stand0.Top - 3;
            Stand0Run2.Left = Stand0.Left + Stand0.Width + Stand0Run1.Left + Stand0Run1.Width - 125;
            Stand0Run2.Width = this.Width - 1450 - Stand0.Left - Stand0.Width;

            Stand0Run3.Top = Stand0.Top - 3;
            Stand0Run3.Left = Stand0.Left + Stand0.Width + Stand0Run2.Left + Stand0Run2.Width - 125;
            Stand0Run3.Width = this.Width - 1450 - Stand0.Left - Stand0.Width;

            Stand1Run.Top = Stand1.Top - 3;
            Stand1Run.Left = Stand1.Left + Stand1.Width + 70;
            Stand1Run.Width = this.Width - 1450 - Stand1.Left - Stand1.Width;

            Stand1Run1.Top = Stand1.Top - 3;
            Stand1Run1.Left = Stand1.Left + Stand1.Width + Stand1Run.Left + Stand1Run.Width - 125;
            Stand1Run1.Width = this.Width - 1450 - Stand1.Left - Stand1.Width;

            Stand1Run2.Top = Stand1.Top - 3;
            Stand1Run2.Left = Stand1.Left + Stand1.Width + Stand1Run1.Left + Stand1Run1.Width - 125;
            Stand1Run2.Width = this.Width - 1450 - Stand1.Left - Stand1.Width;

            Stand1Run3.Top = Stand1.Top - 3;
            Stand1Run3.Left = Stand1.Left + Stand1.Width + Stand1Run2.Left + Stand1Run2.Width - 125;
            Stand1Run3.Width = this.Width - 1450 - Stand1.Left - Stand1.Width;

            Stand2Run.Top = Stand2.Top - 3;
            Stand2Run.Left = Stand2.Left + Stand2.Width + 70;
            Stand2Run.Width = this.Width - 1450 - Stand2.Left - Stand2.Width;

            Stand2Run1.Top = Stand2.Top - 3;
            Stand2Run1.Left = Stand2.Left + Stand2.Width + Stand2Run.Left + Stand2Run.Width - 125;
            Stand2Run1.Width = this.Width - 1450 - Stand2.Left - Stand2.Width;

            Stand2Run2.Top = Stand2.Top - 3;
            Stand2Run2.Left = Stand2.Left + Stand2.Width + Stand2Run1.Left + Stand2Run1.Width - 125;
            Stand2Run2.Width = this.Width - 1450 - Stand2.Left - Stand2.Width;

            Stand2Run3.Top = Stand2.Top - 3;
            Stand2Run3.Left = Stand2.Left + Stand2.Width + Stand2Run2.Left + Stand2Run2.Width - 125;
            Stand2Run3.Width = this.Width - 1450 - Stand2.Left - Stand2.Width;

            Stand3Run.Top = Stand3.Top - 3;
            Stand3Run.Left = Stand3.Left + Stand3.Width + 70;
            Stand3Run.Width = this.Width - 1450 - Stand3.Left - Stand3.Width;

            Stand3Run1.Top = Stand3.Top - 3;
            Stand3Run1.Left = Stand3.Left + Stand3.Width + Stand3Run.Left + Stand3Run.Width - 125;
            Stand3Run1.Width = this.Width - 1450 - Stand3.Left - Stand3.Width;

            Stand3Run2.Top = Stand3.Top - 3;
            Stand3Run2.Left = Stand3.Left + Stand3.Width + Stand3Run1.Left + Stand3Run1.Width - 125;
            Stand3Run2.Width = this.Width - 1450 - Stand3.Left - Stand3.Width;

            Stand3Run3.Top = Stand3.Top - 3;
            Stand3Run3.Left = Stand3.Left + Stand3.Width + Stand3Run2.Left + Stand3Run2.Width - 125;
            Stand3Run3.Width = this.Width - 1450 - Stand3.Left - Stand3.Width;

            Stand4Run.Top = Stand4.Top - 3;
            Stand4Run.Left = Stand4.Left + Stand4.Width + 70;
            Stand4Run.Width = this.Width - 1450 - Stand4.Left - Stand4.Width;

            Stand4Run1.Top = Stand4.Top - 3;
            Stand4Run1.Left = Stand4.Left + Stand4.Width + Stand4Run.Left + Stand4Run.Width - 125;
            Stand4Run1.Width = this.Width - 1450 - Stand4.Left - Stand4.Width;

            Stand4Run2.Top = Stand4.Top - 3;
            Stand4Run2.Left = Stand4.Left + Stand4.Width + Stand4Run1.Left + Stand4Run1.Width - 125;
            Stand4Run2.Width = this.Width - 1450 - Stand4.Left - Stand4.Width;

            Stand4Run3.Top = Stand4.Top - 3;
            Stand4Run3.Left = Stand4.Left + Stand4.Width + Stand4Run2.Left + Stand4Run2.Width - 125;
            Stand4Run3.Width = this.Width - 1450 - Stand4.Left - Stand4.Width;

            Stand5Run.Top = Stand5.Top - 3;
            Stand5Run.Left = Stand5.Left + Stand5.Width + 70;
            Stand5Run.Width = this.Width - 1450 - Stand5.Left - Stand5.Width;

            Stand5Run1.Top = Stand5.Top - 3;
            Stand5Run1.Left = Stand5.Left + Stand5.Width + Stand5Run.Left + Stand5Run.Width - 125;
            Stand5Run1.Width = this.Width - 1450 - Stand5.Left - Stand5.Width;

            Stand5Run2.Top = Stand5.Top - 3;
            Stand5Run2.Left = Stand5.Left + Stand5.Width + Stand5Run1.Left + Stand5Run1.Width - 125;
            Stand5Run2.Width = this.Width - 1450 - Stand5.Left - Stand5.Width;

            Stand5Run3.Top = Stand5.Top - 3;
            Stand5Run3.Left = Stand5.Left + Stand5.Width + Stand5Run2.Left + Stand5Run2.Width - 125;
            Stand5Run3.Width = this.Width - 1450 - Stand5.Left - Stand5.Width;

            Stand6Run.Top = Stand6.Top - 3;
            Stand6Run.Left = Stand6.Left + Stand6.Width + 70;
            Stand6Run.Width = this.Width - 1450 - Stand6.Left - Stand6.Width;

            Stand6Run1.Top = Stand6.Top - 3;
            Stand6Run1.Left = Stand6.Left + Stand6.Width + Stand6Run.Left + Stand6Run.Width - 125;
            Stand6Run1.Width = this.Width - 1450 - Stand6.Left - Stand6.Width;

            Stand6Run2.Top = Stand6.Top - 3;
            Stand6Run2.Left = Stand6.Left + Stand6.Width + Stand6Run1.Left + Stand6Run1.Width - 125;
            Stand6Run2.Width = this.Width - 1450 - Stand6.Left - Stand6.Width;

            Stand6Run3.Top = Stand6.Top - 3;
            Stand6Run3.Left = Stand6.Left + Stand6.Width + Stand6Run2.Left + Stand6Run2.Width - 125;
            Stand6Run3.Width = this.Width - 1450 - Stand6.Left - Stand6.Width;

            lbTGJ.Left = Width - lbTGJ.Width - 300;
            lbTGJ.Top = Stand0.Top + ((Stand1.Top - Stand0.Top) / 2);

            gcRunList.Left = 0 + 5;
            gcRunList.Top = Height - gcRunList.Height - 65;
            gcRunList.Width = Width - 1020;

            S0.Left = Stand0.Left + Stand0.Width + 10;
            S0.Top = Stand0.Top + 3;

            S1.Left = Stand1.Left + Stand1.Width + 10;
            S1.Top = Stand1.Top + 3;

            S2.Left = Stand2.Left + Stand2.Width + 10;
            S2.Top = Stand2.Top + 3;

            S3.Left = Stand3.Left + Stand3.Width + 10;
            S3.Top = Stand3.Top + 3;

            S4.Left = Stand4.Left + Stand4.Width + 10;
            S4.Top = Stand4.Top + 3;

            S5.Left = Stand5.Left + Stand5.Width + 10;
            S5.Top = Stand5.Top + 3;

            S6.Left = Stand6.Left + Stand6.Width + 10;
            S6.Top = Stand6.Top + 3;

            btn0Continue.Left = Width / 2 - btn0Continue.Width / 2 - 100;
            btn0Continue.Top = S0.Top - btn0Continue.Height;

            btn1Continue.Left = Width / 2 - btn1Continue.Width / 2 - 100;
            btn1Continue.Top = S1.Top - btn1Continue.Height;

            btn2Continue.Left = Width / 2 - btn2Continue.Width / 2 - 100;
            btn2Continue.Top = S2.Top - btn2Continue.Height;

            btn3Continue.Left = Width / 2 - btn3Continue.Width / 2 - 100;
            btn3Continue.Top = S3.Top - btn3Continue.Height;

            btn4Continue.Left = Width / 2 - btn4Continue.Width / 2 - 100;
            btn4Continue.Top = S4.Top - btn4Continue.Height;

            btn5Continue.Left = Width / 2 - btn5Continue.Width / 2 - 100;
            btn5Continue.Top = S5.Top - btn5Continue.Height;

            btn6Continue.Left = Width / 2 - btn6Continue.Width / 2 - 100;
            btn6Continue.Top = S6.Top - btn6Continue.Height;

            btnOpt0.Left = Stand0Run2.Left + 10;
            btnOpt0.Top = Stand0Run2.Top - 1 - btnOpt0.Height;

            btnOpt0Right.Left = Stand0Run2.Left + btnOpt0Right.Width + 30;
            btnOpt0Right.Top = Stand0Run2.Top - 1 - btnOpt0.Height;

            btnLiftingSteel0.Left = Stand0Run2.Left + btnOpt0Right.Width + 410;
            btnLiftingSteel0.Top = Stand0Run2.Top - 1 - btnOpt0.Height;

            btnFlipSteeling0.Left = Stand0Run2.Left + btnOpt0Right.Width + 210;
            btnFlipSteeling0.Top = Stand0Run2.Top - 1 - btnOpt0.Height;

            btnOpt1.Left = Stand1Run2.Left + 10;
            btnOpt1.Top = Stand1Run2.Top - 1 - btnOpt1.Height;

            btnOpt1Right.Left = Stand1Run2.Left + btnOpt1Right.Width + 30;
            btnOpt1Right.Top = Stand1Run2.Top - 1 - btnOpt1.Height;

            btnLiftingSteel1.Left = Stand1Run2.Left + btnOpt1Right.Width + 410;
            btnLiftingSteel1.Top = Stand1Run2.Top - 1 - btnOpt1.Height;

            btnFlipSteeling1.Left = Stand1Run2.Left + btnOpt1Right.Width + 210;
            btnFlipSteeling1.Top = Stand1Run2.Top - 1 - btnOpt1.Height;

            btnOpt2.Left = Stand2Run2.Left + 10;
            btnOpt2.Top = Stand2Run2.Top - 1 - btnOpt2.Height;

            btnOpt2Right.Left = Stand2Run2.Left + btnOpt2Right.Width + 30;
            btnOpt2Right.Top = Stand2Run2.Top - 1 - btnOpt2.Height;

            btnLiftingSteel2.Left = Stand2Run2.Left + btnOpt2Right.Width + 410;
            btnLiftingSteel2.Top = Stand2Run2.Top - 1 - btnOpt2.Height;

            btnFlipSteeling2.Left = Stand2Run2.Left + btnOpt2Right.Width + 210;
            btnFlipSteeling2.Top = Stand2Run2.Top - 1 - btnOpt2.Height;

            btnOpt3.Left = Stand3Run2.Left + 10;
            btnOpt3.Top = Stand3Run2.Top - 1 - btnOpt3.Height;

            btnOpt3Right.Left = Stand3Run2.Left + btnOpt3Right.Width + 30;
            btnOpt3Right.Top = Stand3Run2.Top - 1 - btnOpt3.Height;

            btnLiftingSteel3.Left = Stand3Run2.Left + btnOpt3Right.Width + 410;
            btnLiftingSteel3.Top = Stand3Run2.Top - 1 - btnOpt3.Height;

            btnFlipSteeling3.Left = Stand3Run2.Left + btnOpt3Right.Width + 210;
            btnFlipSteeling3.Top = Stand3Run2.Top - 1 - btnOpt3.Height;

            btnOpt4.Left = Stand4Run2.Left + 10;
            btnOpt4.Top = Stand4Run2.Top - 1 - btnOpt4.Height;

            btnOpt4Right.Left = Stand4Run2.Left + btnOpt4Right.Width + 30;
            btnOpt4Right.Top = Stand4Run2.Top - 1 - btnOpt4.Height;

            btnLiftingSteel4.Left = Stand4Run2.Left + btnOpt4Right.Width + 410;
            btnLiftingSteel4.Top = Stand4Run2.Top - 1 - btnOpt4.Height;

            btnFlipSteeling4.Left = Stand4Run2.Left + btnOpt4Right.Width + 210;
            btnFlipSteeling4.Top = Stand4Run2.Top - 1 - btnOpt4.Height;

            btnOpt5.Left = Stand5Run2.Left + 10;
            btnOpt5.Top = Stand5Run2.Top - 1 - btnOpt5.Height;

            btnOpt5Right.Left = Stand5Run2.Left + btnOpt5Right.Width + 30;
            btnOpt5Right.Top = Stand5Run2.Top - 1 - btnOpt5.Height;

            btnLiftingSteel5.Left = Stand5Run2.Left + btnOpt5Right.Width + 410;
            btnLiftingSteel5.Top = Stand5Run2.Top - 1 - btnOpt5.Height;

            btnFlipSteeling5.Left = Stand5Run2.Left + btnOpt5Right.Width + 210;
            btnFlipSteeling5.Top = Stand5Run2.Top - 1 - btnOpt5.Height;

            btnOpt6.Left = Stand6Run2.Left + 10;
            btnOpt6.Top = Stand6Run2.Top - 1 - btnOpt6.Height;

            btnOpt6Right.Left = Stand6Run2.Left + btnOpt6Right.Width + 30;
            btnOpt6Right.Top = Stand6Run2.Top - 1 - btnOpt6.Height;

            btnLiftingSteel6.Left = Stand6Run2.Left + btnOpt6Right.Width + 410;
            btnLiftingSteel6.Top = Stand6Run2.Top - 1 - btnOpt6.Height;

            btnFlipSteeling6.Left = Stand6Run2.Left + btnOpt6Right.Width + 210;
            btnFlipSteeling6.Top = Stand6Run2.Top - 1 - btnOpt6.Height;

            uccoldbed.Left = gcRunList.Left + gcRunList.Width + 1;
            uccoldbed.Height = gcRunList.Height;
            uccoldbed.Top = gcRunList.Top;
            uccoldbed.Width = Width - gcRunList.Width - 295;

            label3.Left = uccoldbed.Left + uccoldbed.Width / 2 - label3.Width / 2;
            label3.Top = uccoldbed.Top;

            ucsteelrolling.Left = Width - 200;
            ucsteelrolling.Top = Height / 2 - ucsteelrolling.Height / 2 - 50;

            OneRolling.Left = ucsteelrolling.Left + OneRolling.Width - 100;
            OneRolling.Top = Height / 2 - OneRolling.Height / 2;

            pbL0.Left = Stand0Run3.Left + Stand0Run3.Width;
            pbL0.Top = Stand0Run3.Top - 40;

            pbL1.Left = Stand1Run3.Left + Stand1Run3.Width;
            pbL1.Top = Stand1Run3.Top - 40;

            pbL2.Left = Stand2Run3.Left + Stand2Run3.Width;
            pbL2.Top = Stand2Run3.Top - 40;

            pbL3.Left = Stand3Run3.Left + Stand3Run3.Width;
            pbL3.Top = Stand3Run3.Top - 40;

            pbL4.Left = Stand4Run3.Left + Stand4Run3.Width;
            pbL4.Top = Stand4Run3.Top - 40;

            pbL5.Left = Stand5Run3.Left + Stand5Run3.Width;
            pbL5.Top = Stand5Run3.Top - 40;

            pbL6.Left = Stand6Run3.Left + Stand6Run3.Width;
            pbL6.Top = Stand6Run3.Top - 40;

            pbH0.Left = Stand0Run3.Left + Stand0Run3.Width + 20;
            pbH0.Top = Stand0Run3.Top - 5;

            pbH1.Left = Stand1Run3.Left + Stand1Run3.Width + 20;
            pbH1.Top = Stand1Run3.Top - 5;

            pbH2.Left = Stand2Run3.Left + Stand2Run3.Width + 20;
            pbH2.Top = Stand2Run3.Top - 5;

            pbH3.Left = Stand3Run3.Left + Stand3Run3.Width + 20;
            pbH3.Top = Stand3Run3.Top - 5;

            pbH4.Left = Stand4Run3.Left + Stand4Run3.Width + 20;
            pbH4.Top = Stand4Run3.Top - 5;

            pbH5.Left = Stand5Run3.Left + Stand5Run3.Width + 20;
            pbH5.Top = Stand5Run3.Top - 5;

            pbH6.Left = Stand6Run3.Left + Stand6Run3.Width + 20;
            pbH6.Top = Stand6Run3.Top - 5;

            DataTable dtSteelType = SqlBase.ExecuteSql4Dt("select * from SysSet");
       
            if (dtSteelType != null && dtSteelType.Rows[0]["RollerTransportationTime"] != null && dtSteelType.Rows[0]["RollerTransportationTime"].ToString().Trim() != "")
            {
                intGD = int.Parse(dtSteelType.Rows[0]["RollerTransportationTime"].ToString().Trim());
            }
            if (dtSteelType != null && dtSteelType.Rows[0]["SteelTurningTime"] != null && dtSteelType.Rows[0]["SteelTurningTime"].ToString().Trim() != "")
            {
                intFS = int.Parse(dtSteelType.Rows[0]["SteelTurningTime"].ToString().Trim());
            }
            if (dtSteelType != null && dtSteelType.Rows[0]["ReasonableCoolingTime"] != null && dtSteelType.Rows[0]["ReasonableCoolingTime"].ToString().Trim() != "")
            {
                intWT = int.Parse(dtSteelType.Rows[0]["ReasonableCoolingTime"].ToString().Trim());
            }
            if (dtSteelType != null && dtSteelType.Rows[0]["RollingRollingTime"] != null && dtSteelType.Rows[0]["RollingRollingTime"].ToString().Trim() != "")
            {
                intZG = int.Parse(dtSteelType.Rows[0]["RollingRollingTime"].ToString().Trim());
            }
            if (dtSteelType != null && dtSteelType.Rows[0]["FourRollingRollingTime"] != null && dtSteelType.Rows[0]["FourRollingRollingTime"].ToString().Trim() != "")
            {
                intHL = int.Parse(dtSteelType.Rows[0]["FourRollingRollingTime"].ToString().Trim());
            }
            if (dtSteelType != null && dtSteelType.Rows[0]["SteelCuttingTime"] != null && dtSteelType.Rows[0]["SteelCuttingTime"].ToString().Trim() != "")
            {
                intCT = int.Parse(dtSteelType.Rows[0]["SteelCuttingTime"].ToString().Trim());
            }
            if (dtSteelType != null && dtSteelType.Rows[0]["FourReasonableCoolingTime"] != null && dtSteelType.Rows[0]["FourReasonableCoolingTime"].ToString().Trim() != "")
            {
                intFourWT = int.Parse(dtSteelType.Rows[0]["FourReasonableCoolingTime"].ToString().Trim());
            }
            if (dtSteelType != null && dtSteelType.Rows[0]["FourRollerTransportationTime"] != null && dtSteelType.Rows[0]["FourRollerTransportationTime"].ToString().Trim() != "")
            {
                intFGD = int.Parse(dtSteelType.Rows[0]["FourRollerTransportationTime"].ToString().Trim());
            }
            if (dsPLCID.Tables[0].Rows.Count > 0 && dsPLCID.Tables[0].Rows[0]["Points"] != null && dsPLCID.Tables[0].Rows[0]["Points"].ToString().Trim() != "")
            {
                string[] strpoints = dsPLCID.Tables[0].Rows[0]["Points"].ToString().Trim().Split('|');
                if (strpoints.Length > 0)
                {
                    for (int i = 0; i < strpoints.Length; i++)
                    {
                        points[i] = double.Parse(strpoints[i].Trim());
                    }
                }
            }
            if (dsPLCID.Tables[0].Rows.Count > 0 && dsPLCID.Tables[0].Rows[0]["PLCList"] != null && dsPLCID.Tables[0].Rows[0]["PLCList"].ToString().Trim() != "")
            {
                string[] strplcid = dsPLCID.Tables[0].Rows[0]["PLCList"].ToString().Trim().Split('|');
                if (strplcid.Length > 0)
                {
                    for (int i = 0; i < strplcid.Length; i++)
                    {
                        strplcid[i] = strplcid[i].Trim();
                    }
                    bool flag = !this.kepOpc.connectOpcServer(this.KepServer);   //加载PLC节点
                    if (flag)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        bool flag3 = !this.kepOpc.CreateGroup(this.KepServer, "casterLevelTwoServer", strplcid);  //创建KepServer服务
                        if (flag3)
                        {
                            Application.Exit();
                        }
                        this.kepOpc.WriteObj("opc_plc01.opc_plc1.DR_1Z RUN", 0);
                        this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1Wait", 0);
                        this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1Take", 0);
                        this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1Position", 1);
                        this.kepOpc.WriteObj("opc_Server.opc_Ti Gang.num1RunAuto", 0);

                        threadCuts0 = new Thread(new ThreadStart(getCuts0));       //0流钢坯监测
                        threadCuts0.Start();

                        threadCuts1 = new Thread(new ThreadStart(getCuts1));       //1流钢坯监测
                        threadCuts1.Start();

                        threadCuts2 = new Thread(new ThreadStart(getCuts2));       //2流钢坯监测
                        threadCuts2.Start();

                        threadCuts3 = new Thread(new ThreadStart(getCuts3));       //3流钢坯监测
                        threadCuts3.Start();

                        threadCuts4 = new Thread(new ThreadStart(getCuts4));       //4流钢坯监测
                        threadCuts4.Start();

                        threadCuts5 = new Thread(new ThreadStart(getCuts5));       //5流钢坯监测
                        threadCuts5.Start();

                        threadCuts6 = new Thread(new ThreadStart(getCuts6));       //6流钢坯监测
                        threadCuts6.Start();

                        threadIsSteel = new Thread(new ThreadStart(getIsSteel));
                        threadIsSteel.Start();

                        threadBaffle = new Thread(new ThreadStart(getBaffle));
                        threadBaffle.Start();

                        threadFourSteelRolling = new Thread(new ThreadStart(getFourSteelRolling));
                        threadFourSteelRolling.Start();

                        threadFourResult = new Thread(new ThreadStart(getFourResult));
                        threadFourResult.Start();

                        threadOneResult = new Thread(new ThreadStart(getOneResult));
                        threadOneResult.Start();

                        threadFlipSteeling = new Thread(new ThreadStart(getFlipSteeling));
                        threadFlipSteeling.Start();

                        threadLiftingSteel = new Thread(new ThreadStart(getLiftingSteel));
                        threadLiftingSteel.Start();

                        threadStart = new Thread(new ThreadStart(getStart));
                        threadStart.Start();

                        threadGetYGJ = new Thread(new ThreadStart(getYGJ));
                        threadGetYGJ.Start();
                      //  SetCursor(this);
                    }
                }
            }
            tIsSteelrolling.Enabled = true;
            txtGo4.Text = "0";
            txtGoCold.Text = "0";
        }

        Thread threadCuts0, threadCuts1, threadCuts2, threadCuts3, threadCuts4, threadCuts5, threadCuts6, threadIsSteel, threadBaffle, threadFourSteelRolling,threadFourResult,threadOneResult, threadStart, threadFlipSteeling, threadFlipSteelend, threadLiftingSteel, threadGetYGJ;

        int intCT = 0,intGD = 0,intFS = 0,intWT = 0,intZG = 0,intHL = 0, intCooling = 0,intFourWT = 0, intFGD = 0;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCurrentSteelGrade frmCurrentSteelGrade = new frmCurrentSteelGrade(this.kepOpc.itemValue);
            frmCurrentSteelGrade.ShowDialog();
      
        }
    }
}

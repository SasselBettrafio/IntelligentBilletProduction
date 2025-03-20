namespace contiCasterLevelTwoServer
{
	// Token: 0x02000006 RID: 6
	public partial class IntelligentBilletProduction : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003C RID: 60 RVA: 0x0000FBB8 File Offset: 0x0000DDB8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000FBF0 File Offset: 0x0000DDF0
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            AnimatorNS.Animation animation1 = new AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntelligentBilletProduction));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsconnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Stand0 = new HZH_Controls.Controls.UCSplitLabel();
            this.Stand1 = new HZH_Controls.Controls.UCSplitLabel();
            this.Stand2 = new HZH_Controls.Controls.UCSplitLabel();
            this.Stand3 = new HZH_Controls.Controls.UCSplitLabel();
            this.Stand4 = new HZH_Controls.Controls.UCSplitLabel();
            this.Stand5 = new HZH_Controls.Controls.UCSplitLabel();
            this.Stand6 = new HZH_Controls.Controls.UCSplitLabel();
            this.lbTGJ = new System.Windows.Forms.Label();
            this.OneRolling = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.Label();
            this.Rolling4Run = new HZH_Controls.Controls.UCConveyor();
            this.Stand0Run = new HZH_Controls.Controls.UCConveyor();
            this.Stand1Run = new HZH_Controls.Controls.UCConveyor();
            this.Stand2Run = new HZH_Controls.Controls.UCConveyor();
            this.Stand3Run = new HZH_Controls.Controls.UCConveyor();
            this.Stand4Run = new HZH_Controls.Controls.UCConveyor();
            this.Stand5Run = new HZH_Controls.Controls.UCConveyor();
            this.Stand6Run = new HZH_Controls.Controls.UCConveyor();
            this.tStand0 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsSystemSet = new System.Windows.Forms.ToolStripButton();
            this.tsSeeTables = new System.Windows.Forms.ToolStripButton();
            this.tsAutomaticBillet = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ts1SteelMovingMachine = new System.Windows.Forms.ToolStripButton();
            this.ts2SteelMovingMachine = new System.Windows.Forms.ToolStripButton();
            this.tStand1 = new System.Windows.Forms.Timer(this.components);
            this.tStand2 = new System.Windows.Forms.Timer(this.components);
            this.tStand3 = new System.Windows.Forms.Timer(this.components);
            this.tStand4 = new System.Windows.Forms.Timer(this.components);
            this.tStand5 = new System.Windows.Forms.Timer(this.components);
            this.tStand6 = new System.Windows.Forms.Timer(this.components);
            this.lbNowSteel = new System.Windows.Forms.Label();
            this.gcRunList = new System.Windows.Forms.DataGridView();
            this.SteelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S0 = new System.Windows.Forms.Label();
            this.S1 = new System.Windows.Forms.Label();
            this.S2 = new System.Windows.Forms.Label();
            this.S3 = new System.Windows.Forms.Label();
            this.S4 = new System.Windows.Forms.Label();
            this.S5 = new System.Windows.Forms.Label();
            this.S6 = new System.Windows.Forms.Label();
            this.ucsteelrolling = new HZH_Controls.Controls.UCConduit();
            this.uccoldbed = new HZH_Controls.Controls.UCPond();
            this.ucReturnfurnace = new HZH_Controls.Controls.UCBlower();
            this.cmschange = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.轧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.冷床ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIsSteelrolling = new System.Windows.Forms.Timer(this.components);
            this.btn0Continue = new System.Windows.Forms.Button();
            this.btn1Continue = new System.Windows.Forms.Button();
            this.btn2Continue = new System.Windows.Forms.Button();
            this.btn3Continue = new System.Windows.Forms.Button();
            this.btn4Continue = new System.Windows.Forms.Button();
            this.btn5Continue = new System.Windows.Forms.Button();
            this.btn6Continue = new System.Windows.Forms.Button();
            this.lb1Rolling = new System.Windows.Forms.Label();
            this.Stand0Run1 = new HZH_Controls.Controls.UCConveyor();
            this.Stand0Run2 = new HZH_Controls.Controls.UCConveyor();
            this.Stand0Run3 = new HZH_Controls.Controls.UCConveyor();
            this.Stand1Run1 = new HZH_Controls.Controls.UCConveyor();
            this.Stand1Run2 = new HZH_Controls.Controls.UCConveyor();
            this.Stand1Run3 = new HZH_Controls.Controls.UCConveyor();
            this.Stand2Run1 = new HZH_Controls.Controls.UCConveyor();
            this.Stand2Run2 = new HZH_Controls.Controls.UCConveyor();
            this.Stand2Run3 = new HZH_Controls.Controls.UCConveyor();
            this.Stand3Run1 = new HZH_Controls.Controls.UCConveyor();
            this.Stand3Run2 = new HZH_Controls.Controls.UCConveyor();
            this.Stand3Run3 = new HZH_Controls.Controls.UCConveyor();
            this.Stand4Run1 = new HZH_Controls.Controls.UCConveyor();
            this.Stand4Run2 = new HZH_Controls.Controls.UCConveyor();
            this.Stand4Run3 = new HZH_Controls.Controls.UCConveyor();
            this.Stand5Run1 = new HZH_Controls.Controls.UCConveyor();
            this.Stand5Run2 = new HZH_Controls.Controls.UCConveyor();
            this.Stand5Run3 = new HZH_Controls.Controls.UCConveyor();
            this.Stand6Run1 = new HZH_Controls.Controls.UCConveyor();
            this.Stand6Run2 = new HZH_Controls.Controls.UCConveyor();
            this.Stand6Run3 = new HZH_Controls.Controls.UCConveyor();
            this.pbL5 = new System.Windows.Forms.PictureBox();
            this.pbL4 = new System.Windows.Forms.PictureBox();
            this.pbL3 = new System.Windows.Forms.PictureBox();
            this.pbL2 = new System.Windows.Forms.PictureBox();
            this.pbL1 = new System.Windows.Forms.PictureBox();
            this.pbL0 = new System.Windows.Forms.PictureBox();
            this.pbL6 = new System.Windows.Forms.PictureBox();
            this.lb4Rolling = new System.Windows.Forms.Label();
            this.pbH0 = new System.Windows.Forms.PictureBox();
            this.pbH1 = new System.Windows.Forms.PictureBox();
            this.pbH2 = new System.Windows.Forms.PictureBox();
            this.pbH3 = new System.Windows.Forms.PictureBox();
            this.pbH4 = new System.Windows.Forms.PictureBox();
            this.pbH5 = new System.Windows.Forms.PictureBox();
            this.pbH6 = new System.Windows.Forms.PictureBox();
            this.lbFixed = new System.Windows.Forms.Label();
            this.btnOpt0 = new System.Windows.Forms.Button();
            this.btnOpt1 = new System.Windows.Forms.Button();
            this.btnOpt2 = new System.Windows.Forms.Button();
            this.btnOpt3 = new System.Windows.Forms.Button();
            this.btnOpt4 = new System.Windows.Forms.Button();
            this.btnOpt5 = new System.Windows.Forms.Button();
            this.btnOpt6 = new System.Windows.Forms.Button();
            this.animator = new AnimatorNS.Animator(this.components);
            this.btnOpt0Right = new System.Windows.Forms.Button();
            this.btnOpt1Right = new System.Windows.Forms.Button();
            this.btnOpt2Right = new System.Windows.Forms.Button();
            this.btnOpt3Right = new System.Windows.Forms.Button();
            this.btnOpt4Right = new System.Windows.Forms.Button();
            this.btnOpt5Right = new System.Windows.Forms.Button();
            this.btnOpt6Right = new System.Windows.Forms.Button();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.plAlarm = new System.Windows.Forms.Panel();
            this.lbAlarmStr = new System.Windows.Forms.Label();
            this.ucAlarmLamp1 = new HZH_Controls.Controls.UCAlarmLamp();
            this.btnLiftingSteel0 = new System.Windows.Forms.Button();
            this.btnLiftingSteel1 = new System.Windows.Forms.Button();
            this.btnLiftingSteel2 = new System.Windows.Forms.Button();
            this.btnLiftingSteel3 = new System.Windows.Forms.Button();
            this.btnLiftingSteel4 = new System.Windows.Forms.Button();
            this.btnLiftingSteel5 = new System.Windows.Forms.Button();
            this.btnLiftingSteel6 = new System.Windows.Forms.Button();
            this.btnFlipSteeling0 = new System.Windows.Forms.Button();
            this.btnFlipSteeling1 = new System.Windows.Forms.Button();
            this.btnFlipSteeling2 = new System.Windows.Forms.Button();
            this.btnFlipSteeling3 = new System.Windows.Forms.Button();
            this.btnFlipSteeling4 = new System.Windows.Forms.Button();
            this.btnFlipSteeling5 = new System.Windows.Forms.Button();
            this.btnFlipSteeling6 = new System.Windows.Forms.Button();
            this.txtGo4 = new System.Windows.Forms.TextBox();
            this.txtGoCold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tColor0 = new System.Windows.Forms.Timer(this.components);
            this.tColor1 = new System.Windows.Forms.Timer(this.components);
            this.tColor2 = new System.Windows.Forms.Timer(this.components);
            this.tColor3 = new System.Windows.Forms.Timer(this.components);
            this.tColor4 = new System.Windows.Forms.Timer(this.components);
            this.tColor5 = new System.Windows.Forms.Timer(this.components);
            this.tColor6 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRunList)).BeginInit();
            this.cmschange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbL5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH6)).BeginInit();
            this.plAlarm.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.animator.SetDecoration(this.statusStrip1, AnimatorNS.DecorationType.None);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsName,
            this.tsconnection,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 820);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1682, 22);
            this.statusStrip1.TabIndex = 6;
            // 
            // tsName
            // 
            this.tsName.Name = "tsName";
            this.tsName.Size = new System.Drawing.Size(0, 17);
            // 
            // tsconnection
            // 
            this.tsconnection.Name = "tsconnection";
            this.tsconnection.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // Stand0
            // 
            this.animator.SetDecoration(this.Stand0, AnimatorNS.DecorationType.None);
            this.Stand0.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.Stand0.LineColor = System.Drawing.Color.Red;
            this.Stand0.Location = new System.Drawing.Point(0, 180);
            this.Stand0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stand0.MaximumSize = new System.Drawing.Size(0, 23);
            this.Stand0.MinimumSize = new System.Drawing.Size(0, 23);
            this.Stand0.Name = "Stand0";
            this.Stand0.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stand0.Size = new System.Drawing.Size(0, 23);
            this.Stand0.TabIndex = 7;
            this.Stand0.Text = "0流";
            // 
            // Stand1
            // 
            this.animator.SetDecoration(this.Stand1, AnimatorNS.DecorationType.None);
            this.Stand1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.Stand1.LineColor = System.Drawing.Color.Red;
            this.Stand1.Location = new System.Drawing.Point(30, 331);
            this.Stand1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stand1.MaximumSize = new System.Drawing.Size(0, 23);
            this.Stand1.MinimumSize = new System.Drawing.Size(0, 23);
            this.Stand1.Name = "Stand1";
            this.Stand1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stand1.Size = new System.Drawing.Size(0, 23);
            this.Stand1.TabIndex = 7;
            this.Stand1.Text = "1流";
            // 
            // Stand2
            // 
            this.animator.SetDecoration(this.Stand2, AnimatorNS.DecorationType.None);
            this.Stand2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.Stand2.LineColor = System.Drawing.Color.Red;
            this.Stand2.Location = new System.Drawing.Point(39, 410);
            this.Stand2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stand2.MaximumSize = new System.Drawing.Size(0, 23);
            this.Stand2.MinimumSize = new System.Drawing.Size(0, 23);
            this.Stand2.Name = "Stand2";
            this.Stand2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stand2.Size = new System.Drawing.Size(0, 23);
            this.Stand2.TabIndex = 7;
            this.Stand2.Text = "2流";
            // 
            // Stand3
            // 
            this.animator.SetDecoration(this.Stand3, AnimatorNS.DecorationType.None);
            this.Stand3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.Stand3.LineColor = System.Drawing.Color.Red;
            this.Stand3.Location = new System.Drawing.Point(39, 491);
            this.Stand3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stand3.MaximumSize = new System.Drawing.Size(0, 23);
            this.Stand3.MinimumSize = new System.Drawing.Size(0, 23);
            this.Stand3.Name = "Stand3";
            this.Stand3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stand3.Size = new System.Drawing.Size(0, 23);
            this.Stand3.TabIndex = 7;
            this.Stand3.Text = "3流";
            // 
            // Stand4
            // 
            this.animator.SetDecoration(this.Stand4, AnimatorNS.DecorationType.None);
            this.Stand4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.Stand4.LineColor = System.Drawing.Color.Red;
            this.Stand4.Location = new System.Drawing.Point(39, 578);
            this.Stand4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stand4.MaximumSize = new System.Drawing.Size(0, 23);
            this.Stand4.MinimumSize = new System.Drawing.Size(0, 23);
            this.Stand4.Name = "Stand4";
            this.Stand4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stand4.Size = new System.Drawing.Size(0, 23);
            this.Stand4.TabIndex = 7;
            this.Stand4.Text = "4流";
            // 
            // Stand5
            // 
            this.animator.SetDecoration(this.Stand5, AnimatorNS.DecorationType.None);
            this.Stand5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.Stand5.LineColor = System.Drawing.Color.Red;
            this.Stand5.Location = new System.Drawing.Point(39, 667);
            this.Stand5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stand5.MaximumSize = new System.Drawing.Size(0, 23);
            this.Stand5.MinimumSize = new System.Drawing.Size(0, 23);
            this.Stand5.Name = "Stand5";
            this.Stand5.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stand5.Size = new System.Drawing.Size(0, 23);
            this.Stand5.TabIndex = 7;
            this.Stand5.Text = "5流";
            // 
            // Stand6
            // 
            this.animator.SetDecoration(this.Stand6, AnimatorNS.DecorationType.None);
            this.Stand6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.Stand6.LineColor = System.Drawing.Color.Red;
            this.Stand6.Location = new System.Drawing.Point(39, 761);
            this.Stand6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stand6.MaximumSize = new System.Drawing.Size(0, 23);
            this.Stand6.MinimumSize = new System.Drawing.Size(0, 23);
            this.Stand6.Name = "Stand6";
            this.Stand6.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stand6.Size = new System.Drawing.Size(0, 23);
            this.Stand6.TabIndex = 7;
            this.Stand6.Text = "6流";
            // 
            // lbTGJ
            // 
            this.lbTGJ.BackColor = System.Drawing.Color.Red;
            this.animator.SetDecoration(this.lbTGJ, AnimatorNS.DecorationType.None);
            this.lbTGJ.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTGJ.Location = new System.Drawing.Point(1257, 323);
            this.lbTGJ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTGJ.Name = "lbTGJ";
            this.lbTGJ.Size = new System.Drawing.Size(376, 75);
            this.lbTGJ.TabIndex = 14;
            this.lbTGJ.Text = "移钢机";
            this.lbTGJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OneRolling
            // 
            this.OneRolling.AutoSize = true;
            this.OneRolling.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.OneRolling, AnimatorNS.DecorationType.None);
            this.OneRolling.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OneRolling.ForeColor = System.Drawing.Color.Red;
            this.OneRolling.Location = new System.Drawing.Point(103, 290);
            this.OneRolling.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OneRolling.Name = "OneRolling";
            this.OneRolling.Size = new System.Drawing.Size(47, 80);
            this.OneRolling.TabIndex = 20;
            this.OneRolling.Text = "1\r\n轧";
            this.OneRolling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.animator.SetDecoration(this.label2, AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(166, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 80);
            this.label2.TabIndex = 20;
            this.label2.Text = "4\r\n轧";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.animator.SetDecoration(this.label3, AnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1234, 641);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 40);
            this.label3.TabIndex = 20;
            this.label3.Text = "冷床";
            // 
            // lbLine
            // 
            this.lbLine.BackColor = System.Drawing.Color.Black;
            this.animator.SetDecoration(this.lbLine, AnimatorNS.DecorationType.None);
            this.lbLine.Location = new System.Drawing.Point(1324, 491);
            this.lbLine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(2, 58);
            this.lbLine.TabIndex = 21;
            this.lbLine.Visible = false;
            // 
            // Rolling4Run
            // 
            this.Rolling4Run.BackColor = System.Drawing.Color.Transparent;
            this.Rolling4Run.ConveyorColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.Rolling4Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Backward;
            this.Rolling4Run.ConveyorHeight = 17;
            this.Rolling4Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Rolling4Run, AnimatorNS.DecorationType.None);
            this.Rolling4Run.Inclination = 0D;
            this.Rolling4Run.Location = new System.Drawing.Point(1468, 154);
            this.Rolling4Run.Margin = new System.Windows.Forms.Padding(2);
            this.Rolling4Run.Name = "Rolling4Run";
            this.Rolling4Run.Size = new System.Drawing.Size(944, 26);
            this.Rolling4Run.TabIndex = 27;
            // 
            // Stand0Run
            // 
            this.Stand0Run.BackColor = System.Drawing.Color.Transparent;
            this.Stand0Run.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand0Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand0Run.ConveyorHeight = 17;
            this.Stand0Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand0Run, AnimatorNS.DecorationType.None);
            this.Stand0Run.Inclination = 0D;
            this.Stand0Run.Location = new System.Drawing.Point(1429, 245);
            this.Stand0Run.Margin = new System.Windows.Forms.Padding(2);
            this.Stand0Run.Name = "Stand0Run";
            this.Stand0Run.Size = new System.Drawing.Size(64, 26);
            this.Stand0Run.TabIndex = 27;
            // 
            // Stand1Run
            // 
            this.Stand1Run.BackColor = System.Drawing.Color.Transparent;
            this.Stand1Run.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand1Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand1Run.ConveyorHeight = 17;
            this.Stand1Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand1Run, AnimatorNS.DecorationType.None);
            this.Stand1Run.Inclination = 0D;
            this.Stand1Run.Location = new System.Drawing.Point(1438, 323);
            this.Stand1Run.Margin = new System.Windows.Forms.Padding(2);
            this.Stand1Run.Name = "Stand1Run";
            this.Stand1Run.Size = new System.Drawing.Size(64, 26);
            this.Stand1Run.TabIndex = 27;
            // 
            // Stand2Run
            // 
            this.Stand2Run.BackColor = System.Drawing.Color.Transparent;
            this.Stand2Run.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand2Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand2Run.ConveyorHeight = 17;
            this.Stand2Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand2Run, AnimatorNS.DecorationType.None);
            this.Stand2Run.Inclination = 0D;
            this.Stand2Run.Location = new System.Drawing.Point(1452, 402);
            this.Stand2Run.Margin = new System.Windows.Forms.Padding(2);
            this.Stand2Run.Name = "Stand2Run";
            this.Stand2Run.Size = new System.Drawing.Size(64, 26);
            this.Stand2Run.TabIndex = 27;
            // 
            // Stand3Run
            // 
            this.Stand3Run.BackColor = System.Drawing.Color.Transparent;
            this.Stand3Run.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand3Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand3Run.ConveyorHeight = 17;
            this.Stand3Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand3Run, AnimatorNS.DecorationType.None);
            this.Stand3Run.Inclination = 0D;
            this.Stand3Run.Location = new System.Drawing.Point(1438, 481);
            this.Stand3Run.Margin = new System.Windows.Forms.Padding(2);
            this.Stand3Run.Name = "Stand3Run";
            this.Stand3Run.Size = new System.Drawing.Size(64, 26);
            this.Stand3Run.TabIndex = 27;
            // 
            // Stand4Run
            // 
            this.Stand4Run.BackColor = System.Drawing.Color.Transparent;
            this.Stand4Run.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand4Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand4Run.ConveyorHeight = 17;
            this.Stand4Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand4Run, AnimatorNS.DecorationType.None);
            this.Stand4Run.Inclination = 0D;
            this.Stand4Run.Location = new System.Drawing.Point(1438, 532);
            this.Stand4Run.Margin = new System.Windows.Forms.Padding(2);
            this.Stand4Run.Name = "Stand4Run";
            this.Stand4Run.Size = new System.Drawing.Size(64, 26);
            this.Stand4Run.TabIndex = 27;
            // 
            // Stand5Run
            // 
            this.Stand5Run.BackColor = System.Drawing.Color.Transparent;
            this.Stand5Run.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand5Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand5Run.ConveyorHeight = 17;
            this.Stand5Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand5Run, AnimatorNS.DecorationType.None);
            this.Stand5Run.Inclination = 0D;
            this.Stand5Run.Location = new System.Drawing.Point(1445, 557);
            this.Stand5Run.Margin = new System.Windows.Forms.Padding(2);
            this.Stand5Run.Name = "Stand5Run";
            this.Stand5Run.Size = new System.Drawing.Size(64, 26);
            this.Stand5Run.TabIndex = 28;
            // 
            // Stand6Run
            // 
            this.Stand6Run.BackColor = System.Drawing.Color.Transparent;
            this.Stand6Run.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand6Run.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand6Run.ConveyorHeight = 17;
            this.Stand6Run.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand6Run, AnimatorNS.DecorationType.None);
            this.Stand6Run.Inclination = 0D;
            this.Stand6Run.Location = new System.Drawing.Point(1429, 214);
            this.Stand6Run.Margin = new System.Windows.Forms.Padding(2);
            this.Stand6Run.Name = "Stand6Run";
            this.Stand6Run.Size = new System.Drawing.Size(64, 26);
            this.Stand6Run.TabIndex = 27;
            // 
            // tStand0
            // 
            this.tStand0.Interval = 1000;
            this.tStand0.Tick += new System.EventHandler(this.tStand0_Tick);
            // 
            // toolStrip1
            // 
            this.animator.SetDecoration(this.toolStrip1, AnimatorNS.DecorationType.None);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSystemSet,
            this.tsSeeTables,
            this.tsAutomaticBillet,
            this.toolStripButton1,
            this.ts1SteelMovingMachine,
            this.ts2SteelMovingMachine});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1682, 56);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsSystemSet
            // 
            this.tsSystemSet.Image = ((System.Drawing.Image)(resources.GetObject("tsSystemSet.Image")));
            this.tsSystemSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSystemSet.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.tsSystemSet.Name = "tsSystemSet";
            this.tsSystemSet.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsSystemSet.Size = new System.Drawing.Size(60, 53);
            this.tsSystemSet.Text = "系统设置";
            this.tsSystemSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsSystemSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSystemSet.ToolTipText = " ";
            this.tsSystemSet.Click += new System.EventHandler(this.tsSystemSet_Click);
            // 
            // tsSeeTables
            // 
            this.tsSeeTables.Image = ((System.Drawing.Image)(resources.GetObject("tsSeeTables.Image")));
            this.tsSeeTables.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSeeTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSeeTables.Name = "tsSeeTables";
            this.tsSeeTables.Size = new System.Drawing.Size(60, 53);
            this.tsSeeTables.Text = "查看报表";
            this.tsSeeTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSeeTables.ToolTipText = " ";
            this.tsSeeTables.Click += new System.EventHandler(this.tsSeeTables_Click);
            // 
            // tsAutomaticBillet
            // 
            this.tsAutomaticBillet.Image = ((System.Drawing.Image)(resources.GetObject("tsAutomaticBillet.Image")));
            this.tsAutomaticBillet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAutomaticBillet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAutomaticBillet.Name = "tsAutomaticBillet";
            this.tsAutomaticBillet.Size = new System.Drawing.Size(84, 53);
            this.tsAutomaticBillet.Text = "停止自动出坯";
            this.tsAutomaticBillet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAutomaticBillet.ToolTipText = " ";
            this.tsAutomaticBillet.Click += new System.EventHandler(this.tsAutomaticBillet_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButton1.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton1.Text = "生产设置";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = " ";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // ts1SteelMovingMachine
            // 
            this.ts1SteelMovingMachine.Image = ((System.Drawing.Image)(resources.GetObject("ts1SteelMovingMachine.Image")));
            this.ts1SteelMovingMachine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts1SteelMovingMachine.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.ts1SteelMovingMachine.Name = "ts1SteelMovingMachine";
            this.ts1SteelMovingMachine.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ts1SteelMovingMachine.Size = new System.Drawing.Size(115, 53);
            this.ts1SteelMovingMachine.Text = "开启1号移钢机自动";
            this.ts1SteelMovingMachine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ts1SteelMovingMachine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ts1SteelMovingMachine.ToolTipText = " ";
            this.ts1SteelMovingMachine.Click += new System.EventHandler(this.tsSteelMovingMachine_Click);
            // 
            // ts2SteelMovingMachine
            // 
            this.ts2SteelMovingMachine.Image = ((System.Drawing.Image)(resources.GetObject("ts2SteelMovingMachine.Image")));
            this.ts2SteelMovingMachine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts2SteelMovingMachine.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.ts2SteelMovingMachine.Name = "ts2SteelMovingMachine";
            this.ts2SteelMovingMachine.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ts2SteelMovingMachine.Size = new System.Drawing.Size(115, 53);
            this.ts2SteelMovingMachine.Text = "开启2号移钢机自动";
            this.ts2SteelMovingMachine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ts2SteelMovingMachine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ts2SteelMovingMachine.ToolTipText = " ";
            this.ts2SteelMovingMachine.Click += new System.EventHandler(this.ts2SteelMovingMachine_Click);
            // 
            // tStand1
            // 
            this.tStand1.Interval = 1000;
            this.tStand1.Tick += new System.EventHandler(this.tStand1_Tick);
            // 
            // tStand2
            // 
            this.tStand2.Interval = 1000;
            this.tStand2.Tick += new System.EventHandler(this.tStand2_Tick);
            // 
            // tStand3
            // 
            this.tStand3.Interval = 1000;
            this.tStand3.Tick += new System.EventHandler(this.tStand3_Tick);
            // 
            // tStand4
            // 
            this.tStand4.Interval = 1000;
            this.tStand4.Tick += new System.EventHandler(this.tStand4_Tick);
            // 
            // tStand5
            // 
            this.tStand5.Interval = 1000;
            this.tStand5.Tick += new System.EventHandler(this.tStand5_Tick);
            // 
            // tStand6
            // 
            this.tStand6.Interval = 1000;
            this.tStand6.Tick += new System.EventHandler(this.tStand6_Tick);
            // 
            // lbNowSteel
            // 
            this.lbNowSteel.AutoSize = true;
            this.lbNowSteel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.animator.SetDecoration(this.lbNowSteel, AnimatorNS.DecorationType.None);
            this.lbNowSteel.Font = new System.Drawing.Font("微软雅黑", 17.2F, System.Drawing.FontStyle.Bold);
            this.lbNowSteel.ForeColor = System.Drawing.Color.Red;
            this.lbNowSteel.Location = new System.Drawing.Point(660, 8);
            this.lbNowSteel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNowSteel.Name = "lbNowSteel";
            this.lbNowSteel.Size = new System.Drawing.Size(0, 31);
            this.lbNowSteel.TabIndex = 30;
            this.lbNowSteel.MouseEnter += new System.EventHandler(this.lbNowSteel_MouseEnter);
            // 
            // gcRunList
            // 
            this.gcRunList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gcRunList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gcRunList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gcRunList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gcRunList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gcRunList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcRunList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SteelType,
            this.thick});
            this.animator.SetDecoration(this.gcRunList, AnimatorNS.DecorationType.None);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gcRunList.DefaultCellStyle = dataGridViewCellStyle5;
            this.gcRunList.Location = new System.Drawing.Point(0, 761);
            this.gcRunList.Margin = new System.Windows.Forms.Padding(2);
            this.gcRunList.MultiSelect = false;
            this.gcRunList.Name = "gcRunList";
            this.gcRunList.ReadOnly = true;
            this.gcRunList.RowHeadersVisible = false;
            this.gcRunList.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑 Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcRunList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gcRunList.RowTemplate.Height = 27;
            this.gcRunList.Size = new System.Drawing.Size(809, 180);
            this.gcRunList.TabIndex = 31;
            // 
            // SteelType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SteelType.DefaultCellStyle = dataGridViewCellStyle3;
            this.SteelType.HeaderText = "时间";
            this.SteelType.MinimumWidth = 6;
            this.SteelType.Name = "SteelType";
            this.SteelType.ReadOnly = true;
            this.SteelType.Width = 65;
            // 
            // thick
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.thick.DefaultCellStyle = dataGridViewCellStyle4;
            this.thick.HeaderText = "事件";
            this.thick.MinimumWidth = 6;
            this.thick.Name = "thick";
            this.thick.ReadOnly = true;
            this.thick.Width = 65;
            // 
            // S0
            // 
            this.S0.AutoSize = true;
            this.animator.SetDecoration(this.S0, AnimatorNS.DecorationType.None);
            this.S0.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S0.ForeColor = System.Drawing.Color.Red;
            this.S0.Location = new System.Drawing.Point(422, 501);
            this.S0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S0.Name = "S0";
            this.S0.Size = new System.Drawing.Size(40, 19);
            this.S0.TabIndex = 32;
            this.S0.Text = "0.00";
            // 
            // S1
            // 
            this.S1.AutoSize = true;
            this.animator.SetDecoration(this.S1, AnimatorNS.DecorationType.None);
            this.S1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S1.ForeColor = System.Drawing.Color.Red;
            this.S1.Location = new System.Drawing.Point(487, 501);
            this.S1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S1.Name = "S1";
            this.S1.Size = new System.Drawing.Size(40, 19);
            this.S1.TabIndex = 32;
            this.S1.Text = "0.00";
            // 
            // S2
            // 
            this.S2.AutoSize = true;
            this.animator.SetDecoration(this.S2, AnimatorNS.DecorationType.None);
            this.S2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S2.ForeColor = System.Drawing.Color.Red;
            this.S2.Location = new System.Drawing.Point(548, 501);
            this.S2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S2.Name = "S2";
            this.S2.Size = new System.Drawing.Size(40, 19);
            this.S2.TabIndex = 32;
            this.S2.Text = "0.00";
            // 
            // S3
            // 
            this.S3.AutoSize = true;
            this.animator.SetDecoration(this.S3, AnimatorNS.DecorationType.None);
            this.S3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S3.ForeColor = System.Drawing.Color.Red;
            this.S3.Location = new System.Drawing.Point(609, 501);
            this.S3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S3.Name = "S3";
            this.S3.Size = new System.Drawing.Size(40, 19);
            this.S3.TabIndex = 32;
            this.S3.Text = "0.00";
            // 
            // S4
            // 
            this.S4.AutoSize = true;
            this.animator.SetDecoration(this.S4, AnimatorNS.DecorationType.None);
            this.S4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S4.ForeColor = System.Drawing.Color.Red;
            this.S4.Location = new System.Drawing.Point(669, 501);
            this.S4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S4.Name = "S4";
            this.S4.Size = new System.Drawing.Size(40, 19);
            this.S4.TabIndex = 32;
            this.S4.Text = "0.00";
            // 
            // S5
            // 
            this.S5.AutoSize = true;
            this.animator.SetDecoration(this.S5, AnimatorNS.DecorationType.None);
            this.S5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S5.ForeColor = System.Drawing.Color.Red;
            this.S5.Location = new System.Drawing.Point(736, 501);
            this.S5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S5.Name = "S5";
            this.S5.Size = new System.Drawing.Size(40, 19);
            this.S5.TabIndex = 32;
            this.S5.Text = "0.00";
            // 
            // S6
            // 
            this.S6.AutoSize = true;
            this.animator.SetDecoration(this.S6, AnimatorNS.DecorationType.None);
            this.S6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S6.ForeColor = System.Drawing.Color.Red;
            this.S6.Location = new System.Drawing.Point(815, 501);
            this.S6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S6.Name = "S6";
            this.S6.Size = new System.Drawing.Size(40, 19);
            this.S6.TabIndex = 32;
            this.S6.Text = "0.00";
            // 
            // ucsteelrolling
            // 
            this.ucsteelrolling.BackColor = System.Drawing.Color.Transparent;
            this.ucsteelrolling.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucsteelrolling.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_None;
            this.ucsteelrolling.ConduitWidth = 50;
            this.animator.SetDecoration(this.ucsteelrolling, AnimatorNS.DecorationType.None);
            this.ucsteelrolling.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucsteelrolling.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucsteelrolling.LiquidSpeed = 100;
            this.ucsteelrolling.Location = new System.Drawing.Point(1237, 164);
            this.ucsteelrolling.Margin = new System.Windows.Forms.Padding(2);
            this.ucsteelrolling.Name = "ucsteelrolling";
            this.ucsteelrolling.Size = new System.Drawing.Size(331, 461);
            this.ucsteelrolling.TabIndex = 34;
            // 
            // uccoldbed
            // 
            this.animator.SetDecoration(this.uccoldbed, AnimatorNS.DecorationType.None);
            this.uccoldbed.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.uccoldbed.Location = new System.Drawing.Point(1268, 770);
            this.uccoldbed.Margin = new System.Windows.Forms.Padding(2);
            this.uccoldbed.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.uccoldbed.Name = "uccoldbed";
            this.uccoldbed.Size = new System.Drawing.Size(139, 98);
            this.uccoldbed.TabIndex = 62;
            this.uccoldbed.Value = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.uccoldbed.WallColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.uccoldbed.WallWidth = 2;
            // 
            // ucReturnfurnace
            // 
            this.ucReturnfurnace.BlowerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.animator.SetDecoration(this.ucReturnfurnace, AnimatorNS.DecorationType.None);
            this.ucReturnfurnace.EntranceDirection = HZH_Controls.Controls.BlowerEntranceDirection.Right;
            this.ucReturnfurnace.ExitDirection = HZH_Controls.Controls.BlowerExitDirection.Right;
            this.ucReturnfurnace.FanColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucReturnfurnace.Location = new System.Drawing.Point(-86, 58);
            this.ucReturnfurnace.Margin = new System.Windows.Forms.Padding(2);
            this.ucReturnfurnace.Name = "ucReturnfurnace";
            this.ucReturnfurnace.Size = new System.Drawing.Size(247, 94);
            this.ucReturnfurnace.TabIndex = 63;
            this.ucReturnfurnace.TurnAround = HZH_Controls.Controls.TurnAround.Counterclockwise;
            this.ucReturnfurnace.TurnSpeed = 100;
            // 
            // cmschange
            // 
            this.animator.SetDecoration(this.cmschange, AnimatorNS.DecorationType.None);
            this.cmschange.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmschange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.轧ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.冷床ToolStripMenuItem});
            this.cmschange.Name = "cmschange";
            this.cmschange.Size = new System.Drawing.Size(144, 136);
            // 
            // 轧ToolStripMenuItem
            // 
            this.轧ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.轧ToolStripMenuItem.Name = "轧ToolStripMenuItem";
            this.轧ToolStripMenuItem.Size = new System.Drawing.Size(143, 44);
            this.轧ToolStripMenuItem.Text = "1轧";
            this.轧ToolStripMenuItem.Click += new System.EventHandler(this.轧ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 44);
            this.toolStripMenuItem2.Text = "4轧";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 冷床ToolStripMenuItem
            // 
            this.冷床ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.冷床ToolStripMenuItem.Name = "冷床ToolStripMenuItem";
            this.冷床ToolStripMenuItem.Size = new System.Drawing.Size(143, 44);
            this.冷床ToolStripMenuItem.Text = "冷床";
            this.冷床ToolStripMenuItem.Click += new System.EventHandler(this.冷床ToolStripMenuItem_Click);
            // 
            // tIsSteelrolling
            // 
            this.tIsSteelrolling.Interval = 1000;
            this.tIsSteelrolling.Tick += new System.EventHandler(this.tIsSteelrolling_Tick);
            // 
            // btn0Continue
            // 
            this.animator.SetDecoration(this.btn0Continue, AnimatorNS.DecorationType.None);
            this.btn0Continue.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn0Continue.ForeColor = System.Drawing.Color.Red;
            this.btn0Continue.Location = new System.Drawing.Point(426, 77);
            this.btn0Continue.Name = "btn0Continue";
            this.btn0Continue.Size = new System.Drawing.Size(109, 65);
            this.btn0Continue.TabIndex = 64;
            this.btn0Continue.Text = "继续";
            this.btn0Continue.UseVisualStyleBackColor = true;
            this.btn0Continue.Visible = false;
            this.btn0Continue.Click += new System.EventHandler(this.btn0Continue_Click);
            // 
            // btn1Continue
            // 
            this.animator.SetDecoration(this.btn1Continue, AnimatorNS.DecorationType.None);
            this.btn1Continue.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn1Continue.ForeColor = System.Drawing.Color.Red;
            this.btn1Continue.Location = new System.Drawing.Point(426, 147);
            this.btn1Continue.Name = "btn1Continue";
            this.btn1Continue.Size = new System.Drawing.Size(109, 65);
            this.btn1Continue.TabIndex = 64;
            this.btn1Continue.Text = "继续";
            this.btn1Continue.UseVisualStyleBackColor = true;
            this.btn1Continue.Visible = false;
            this.btn1Continue.Click += new System.EventHandler(this.btn1Continue_Click);
            // 
            // btn2Continue
            // 
            this.animator.SetDecoration(this.btn2Continue, AnimatorNS.DecorationType.None);
            this.btn2Continue.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn2Continue.ForeColor = System.Drawing.Color.Red;
            this.btn2Continue.Location = new System.Drawing.Point(426, 216);
            this.btn2Continue.Name = "btn2Continue";
            this.btn2Continue.Size = new System.Drawing.Size(109, 65);
            this.btn2Continue.TabIndex = 64;
            this.btn2Continue.Text = "继续";
            this.btn2Continue.UseVisualStyleBackColor = true;
            this.btn2Continue.Visible = false;
            this.btn2Continue.Click += new System.EventHandler(this.btn2Continue_Click);
            // 
            // btn3Continue
            // 
            this.animator.SetDecoration(this.btn3Continue, AnimatorNS.DecorationType.None);
            this.btn3Continue.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn3Continue.ForeColor = System.Drawing.Color.Red;
            this.btn3Continue.Location = new System.Drawing.Point(426, 287);
            this.btn3Continue.Name = "btn3Continue";
            this.btn3Continue.Size = new System.Drawing.Size(109, 65);
            this.btn3Continue.TabIndex = 64;
            this.btn3Continue.Text = "继续";
            this.btn3Continue.UseVisualStyleBackColor = true;
            this.btn3Continue.Visible = false;
            this.btn3Continue.Click += new System.EventHandler(this.btn3Continue_Click);
            // 
            // btn4Continue
            // 
            this.animator.SetDecoration(this.btn4Continue, AnimatorNS.DecorationType.None);
            this.btn4Continue.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn4Continue.ForeColor = System.Drawing.Color.Red;
            this.btn4Continue.Location = new System.Drawing.Point(426, 358);
            this.btn4Continue.Name = "btn4Continue";
            this.btn4Continue.Size = new System.Drawing.Size(109, 65);
            this.btn4Continue.TabIndex = 64;
            this.btn4Continue.Text = "继续";
            this.btn4Continue.UseVisualStyleBackColor = true;
            this.btn4Continue.Visible = false;
            this.btn4Continue.Click += new System.EventHandler(this.btn4Continue_Click);
            // 
            // btn5Continue
            // 
            this.animator.SetDecoration(this.btn5Continue, AnimatorNS.DecorationType.None);
            this.btn5Continue.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn5Continue.ForeColor = System.Drawing.Color.Red;
            this.btn5Continue.Location = new System.Drawing.Point(426, 433);
            this.btn5Continue.Name = "btn5Continue";
            this.btn5Continue.Size = new System.Drawing.Size(109, 65);
            this.btn5Continue.TabIndex = 64;
            this.btn5Continue.Text = "继续";
            this.btn5Continue.UseVisualStyleBackColor = true;
            this.btn5Continue.Visible = false;
            this.btn5Continue.Click += new System.EventHandler(this.btn5Continue_Click);
            // 
            // btn6Continue
            // 
            this.animator.SetDecoration(this.btn6Continue, AnimatorNS.DecorationType.None);
            this.btn6Continue.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn6Continue.ForeColor = System.Drawing.Color.Red;
            this.btn6Continue.Location = new System.Drawing.Point(426, 523);
            this.btn6Continue.Name = "btn6Continue";
            this.btn6Continue.Size = new System.Drawing.Size(109, 65);
            this.btn6Continue.TabIndex = 64;
            this.btn6Continue.Text = "继续";
            this.btn6Continue.UseVisualStyleBackColor = true;
            this.btn6Continue.Visible = false;
            this.btn6Continue.Click += new System.EventHandler(this.btn6Continue_Click);
            // 
            // lb1Rolling
            // 
            this.lb1Rolling.AutoSize = true;
            this.lb1Rolling.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.lb1Rolling, AnimatorNS.DecorationType.None);
            this.lb1Rolling.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb1Rolling.ForeColor = System.Drawing.Color.Red;
            this.lb1Rolling.Location = new System.Drawing.Point(1077, 9);
            this.lb1Rolling.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb1Rolling.Name = "lb1Rolling";
            this.lb1Rolling.Size = new System.Drawing.Size(0, 46);
            this.lb1Rolling.TabIndex = 67;
            // 
            // Stand0Run1
            // 
            this.Stand0Run1.BackColor = System.Drawing.Color.Transparent;
            this.Stand0Run1.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand0Run1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand0Run1.ConveyorHeight = 17;
            this.Stand0Run1.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand0Run1, AnimatorNS.DecorationType.None);
            this.Stand0Run1.Inclination = 0D;
            this.Stand0Run1.Location = new System.Drawing.Point(1450, 58);
            this.Stand0Run1.Margin = new System.Windows.Forms.Padding(2);
            this.Stand0Run1.Name = "Stand0Run1";
            this.Stand0Run1.Size = new System.Drawing.Size(30, 26);
            this.Stand0Run1.TabIndex = 27;
            // 
            // Stand0Run2
            // 
            this.Stand0Run2.BackColor = System.Drawing.Color.Transparent;
            this.Stand0Run2.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand0Run2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand0Run2.ConveyorHeight = 17;
            this.Stand0Run2.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand0Run2, AnimatorNS.DecorationType.None);
            this.Stand0Run2.Inclination = 0D;
            this.Stand0Run2.Location = new System.Drawing.Point(1684, 58);
            this.Stand0Run2.Margin = new System.Windows.Forms.Padding(2);
            this.Stand0Run2.Name = "Stand0Run2";
            this.Stand0Run2.Size = new System.Drawing.Size(30, 26);
            this.Stand0Run2.TabIndex = 27;
            this.Stand0Run2.MouseEnter += new System.EventHandler(this.Stand0Run2_MouseEnter);
            // 
            // Stand0Run3
            // 
            this.Stand0Run3.BackColor = System.Drawing.Color.Transparent;
            this.Stand0Run3.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand0Run3.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand0Run3.ConveyorHeight = 17;
            this.Stand0Run3.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand0Run3, AnimatorNS.DecorationType.None);
            this.Stand0Run3.Inclination = 0D;
            this.Stand0Run3.Location = new System.Drawing.Point(1934, 58);
            this.Stand0Run3.Margin = new System.Windows.Forms.Padding(2);
            this.Stand0Run3.Name = "Stand0Run3";
            this.Stand0Run3.Size = new System.Drawing.Size(30, 26);
            this.Stand0Run3.TabIndex = 27;
            // 
            // Stand1Run1
            // 
            this.Stand1Run1.BackColor = System.Drawing.Color.Transparent;
            this.Stand1Run1.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand1Run1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand1Run1.ConveyorHeight = 17;
            this.Stand1Run1.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand1Run1, AnimatorNS.DecorationType.None);
            this.Stand1Run1.Inclination = 0D;
            this.Stand1Run1.Location = new System.Drawing.Point(1450, 88);
            this.Stand1Run1.Margin = new System.Windows.Forms.Padding(2);
            this.Stand1Run1.Name = "Stand1Run1";
            this.Stand1Run1.Size = new System.Drawing.Size(30, 26);
            this.Stand1Run1.TabIndex = 27;
            // 
            // Stand1Run2
            // 
            this.Stand1Run2.BackColor = System.Drawing.Color.Transparent;
            this.Stand1Run2.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand1Run2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand1Run2.ConveyorHeight = 17;
            this.Stand1Run2.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand1Run2, AnimatorNS.DecorationType.None);
            this.Stand1Run2.Inclination = 0D;
            this.Stand1Run2.Location = new System.Drawing.Point(1684, 88);
            this.Stand1Run2.Margin = new System.Windows.Forms.Padding(2);
            this.Stand1Run2.Name = "Stand1Run2";
            this.Stand1Run2.Size = new System.Drawing.Size(30, 26);
            this.Stand1Run2.TabIndex = 27;
            this.Stand1Run2.MouseEnter += new System.EventHandler(this.Stand1Run2_MouseEnter);
            // 
            // Stand1Run3
            // 
            this.Stand1Run3.BackColor = System.Drawing.Color.Transparent;
            this.Stand1Run3.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand1Run3.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand1Run3.ConveyorHeight = 17;
            this.Stand1Run3.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand1Run3, AnimatorNS.DecorationType.None);
            this.Stand1Run3.Inclination = 0D;
            this.Stand1Run3.Location = new System.Drawing.Point(1934, 88);
            this.Stand1Run3.Margin = new System.Windows.Forms.Padding(2);
            this.Stand1Run3.Name = "Stand1Run3";
            this.Stand1Run3.Size = new System.Drawing.Size(30, 26);
            this.Stand1Run3.TabIndex = 27;
            // 
            // Stand2Run1
            // 
            this.Stand2Run1.BackColor = System.Drawing.Color.Transparent;
            this.Stand2Run1.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand2Run1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand2Run1.ConveyorHeight = 17;
            this.Stand2Run1.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand2Run1, AnimatorNS.DecorationType.None);
            this.Stand2Run1.Inclination = 0D;
            this.Stand2Run1.Location = new System.Drawing.Point(1450, 118);
            this.Stand2Run1.Margin = new System.Windows.Forms.Padding(2);
            this.Stand2Run1.Name = "Stand2Run1";
            this.Stand2Run1.Size = new System.Drawing.Size(30, 26);
            this.Stand2Run1.TabIndex = 27;
            // 
            // Stand2Run2
            // 
            this.Stand2Run2.BackColor = System.Drawing.Color.Transparent;
            this.Stand2Run2.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand2Run2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand2Run2.ConveyorHeight = 17;
            this.Stand2Run2.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand2Run2, AnimatorNS.DecorationType.None);
            this.Stand2Run2.Inclination = 0D;
            this.Stand2Run2.Location = new System.Drawing.Point(1684, 118);
            this.Stand2Run2.Margin = new System.Windows.Forms.Padding(2);
            this.Stand2Run2.Name = "Stand2Run2";
            this.Stand2Run2.Size = new System.Drawing.Size(30, 26);
            this.Stand2Run2.TabIndex = 27;
            this.Stand2Run2.MouseEnter += new System.EventHandler(this.Stand2Run2_MouseEnter);
            // 
            // Stand2Run3
            // 
            this.Stand2Run3.BackColor = System.Drawing.Color.Transparent;
            this.Stand2Run3.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand2Run3.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand2Run3.ConveyorHeight = 17;
            this.Stand2Run3.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand2Run3, AnimatorNS.DecorationType.None);
            this.Stand2Run3.Inclination = 0D;
            this.Stand2Run3.Location = new System.Drawing.Point(1934, 118);
            this.Stand2Run3.Margin = new System.Windows.Forms.Padding(2);
            this.Stand2Run3.Name = "Stand2Run3";
            this.Stand2Run3.Size = new System.Drawing.Size(30, 26);
            this.Stand2Run3.TabIndex = 27;
            // 
            // Stand3Run1
            // 
            this.Stand3Run1.BackColor = System.Drawing.Color.Transparent;
            this.Stand3Run1.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand3Run1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand3Run1.ConveyorHeight = 17;
            this.Stand3Run1.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand3Run1, AnimatorNS.DecorationType.None);
            this.Stand3Run1.Inclination = 0D;
            this.Stand3Run1.Location = new System.Drawing.Point(1438, 164);
            this.Stand3Run1.Margin = new System.Windows.Forms.Padding(2);
            this.Stand3Run1.Name = "Stand3Run1";
            this.Stand3Run1.Size = new System.Drawing.Size(40, 26);
            this.Stand3Run1.TabIndex = 27;
            // 
            // Stand3Run2
            // 
            this.Stand3Run2.BackColor = System.Drawing.Color.Transparent;
            this.Stand3Run2.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand3Run2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand3Run2.ConveyorHeight = 17;
            this.Stand3Run2.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand3Run2, AnimatorNS.DecorationType.None);
            this.Stand3Run2.Inclination = 0D;
            this.Stand3Run2.Location = new System.Drawing.Point(1672, 164);
            this.Stand3Run2.Margin = new System.Windows.Forms.Padding(2);
            this.Stand3Run2.Name = "Stand3Run2";
            this.Stand3Run2.Size = new System.Drawing.Size(40, 26);
            this.Stand3Run2.TabIndex = 27;
            this.Stand3Run2.MouseEnter += new System.EventHandler(this.Stand3Run2_MouseEnter);
            // 
            // Stand3Run3
            // 
            this.Stand3Run3.BackColor = System.Drawing.Color.Transparent;
            this.Stand3Run3.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand3Run3.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand3Run3.ConveyorHeight = 17;
            this.Stand3Run3.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand3Run3, AnimatorNS.DecorationType.None);
            this.Stand3Run3.Inclination = 0D;
            this.Stand3Run3.Location = new System.Drawing.Point(1922, 164);
            this.Stand3Run3.Margin = new System.Windows.Forms.Padding(2);
            this.Stand3Run3.Name = "Stand3Run3";
            this.Stand3Run3.Size = new System.Drawing.Size(40, 26);
            this.Stand3Run3.TabIndex = 27;
            // 
            // Stand4Run1
            // 
            this.Stand4Run1.BackColor = System.Drawing.Color.Transparent;
            this.Stand4Run1.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand4Run1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand4Run1.ConveyorHeight = 17;
            this.Stand4Run1.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand4Run1, AnimatorNS.DecorationType.None);
            this.Stand4Run1.Inclination = 0D;
            this.Stand4Run1.Location = new System.Drawing.Point(1438, 194);
            this.Stand4Run1.Margin = new System.Windows.Forms.Padding(2);
            this.Stand4Run1.Name = "Stand4Run1";
            this.Stand4Run1.Size = new System.Drawing.Size(40, 26);
            this.Stand4Run1.TabIndex = 27;
            // 
            // Stand4Run2
            // 
            this.Stand4Run2.BackColor = System.Drawing.Color.Transparent;
            this.Stand4Run2.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand4Run2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand4Run2.ConveyorHeight = 17;
            this.Stand4Run2.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand4Run2, AnimatorNS.DecorationType.None);
            this.Stand4Run2.Inclination = 0D;
            this.Stand4Run2.Location = new System.Drawing.Point(1672, 194);
            this.Stand4Run2.Margin = new System.Windows.Forms.Padding(2);
            this.Stand4Run2.Name = "Stand4Run2";
            this.Stand4Run2.Size = new System.Drawing.Size(40, 26);
            this.Stand4Run2.TabIndex = 27;
            this.Stand4Run2.MouseEnter += new System.EventHandler(this.Stand4Run2_MouseEnter);
            // 
            // Stand4Run3
            // 
            this.Stand4Run3.BackColor = System.Drawing.Color.Transparent;
            this.Stand4Run3.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand4Run3.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand4Run3.ConveyorHeight = 17;
            this.Stand4Run3.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand4Run3, AnimatorNS.DecorationType.None);
            this.Stand4Run3.Inclination = 0D;
            this.Stand4Run3.Location = new System.Drawing.Point(1922, 194);
            this.Stand4Run3.Margin = new System.Windows.Forms.Padding(2);
            this.Stand4Run3.Name = "Stand4Run3";
            this.Stand4Run3.Size = new System.Drawing.Size(40, 26);
            this.Stand4Run3.TabIndex = 27;
            // 
            // Stand5Run1
            // 
            this.Stand5Run1.BackColor = System.Drawing.Color.Transparent;
            this.Stand5Run1.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand5Run1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand5Run1.ConveyorHeight = 17;
            this.Stand5Run1.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand5Run1, AnimatorNS.DecorationType.None);
            this.Stand5Run1.Inclination = 0D;
            this.Stand5Run1.Location = new System.Drawing.Point(1438, 224);
            this.Stand5Run1.Margin = new System.Windows.Forms.Padding(2);
            this.Stand5Run1.Name = "Stand5Run1";
            this.Stand5Run1.Size = new System.Drawing.Size(40, 26);
            this.Stand5Run1.TabIndex = 27;
            // 
            // Stand5Run2
            // 
            this.Stand5Run2.BackColor = System.Drawing.Color.Transparent;
            this.Stand5Run2.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand5Run2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand5Run2.ConveyorHeight = 17;
            this.Stand5Run2.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand5Run2, AnimatorNS.DecorationType.None);
            this.Stand5Run2.Inclination = 0D;
            this.Stand5Run2.Location = new System.Drawing.Point(1672, 224);
            this.Stand5Run2.Margin = new System.Windows.Forms.Padding(2);
            this.Stand5Run2.Name = "Stand5Run2";
            this.Stand5Run2.Size = new System.Drawing.Size(40, 26);
            this.Stand5Run2.TabIndex = 27;
            this.Stand5Run2.MouseEnter += new System.EventHandler(this.Stand5Run2_MouseEnter);
            // 
            // Stand5Run3
            // 
            this.Stand5Run3.BackColor = System.Drawing.Color.Transparent;
            this.Stand5Run3.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand5Run3.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand5Run3.ConveyorHeight = 17;
            this.Stand5Run3.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand5Run3, AnimatorNS.DecorationType.None);
            this.Stand5Run3.Inclination = 0D;
            this.Stand5Run3.Location = new System.Drawing.Point(1922, 224);
            this.Stand5Run3.Margin = new System.Windows.Forms.Padding(2);
            this.Stand5Run3.Name = "Stand5Run3";
            this.Stand5Run3.Size = new System.Drawing.Size(40, 26);
            this.Stand5Run3.TabIndex = 27;
            // 
            // Stand6Run1
            // 
            this.Stand6Run1.BackColor = System.Drawing.Color.Transparent;
            this.Stand6Run1.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand6Run1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand6Run1.ConveyorHeight = 17;
            this.Stand6Run1.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand6Run1, AnimatorNS.DecorationType.None);
            this.Stand6Run1.Inclination = 0D;
            this.Stand6Run1.Location = new System.Drawing.Point(1438, 254);
            this.Stand6Run1.Margin = new System.Windows.Forms.Padding(2);
            this.Stand6Run1.Name = "Stand6Run1";
            this.Stand6Run1.Size = new System.Drawing.Size(40, 26);
            this.Stand6Run1.TabIndex = 27;
            // 
            // Stand6Run2
            // 
            this.Stand6Run2.BackColor = System.Drawing.Color.Transparent;
            this.Stand6Run2.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand6Run2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand6Run2.ConveyorHeight = 17;
            this.Stand6Run2.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand6Run2, AnimatorNS.DecorationType.None);
            this.Stand6Run2.Inclination = 0D;
            this.Stand6Run2.Location = new System.Drawing.Point(1672, 254);
            this.Stand6Run2.Margin = new System.Windows.Forms.Padding(2);
            this.Stand6Run2.Name = "Stand6Run2";
            this.Stand6Run2.Size = new System.Drawing.Size(40, 26);
            this.Stand6Run2.TabIndex = 27;
            this.Stand6Run2.MouseEnter += new System.EventHandler(this.Stand6Run2_MouseEnter);
            // 
            // Stand6Run3
            // 
            this.Stand6Run3.BackColor = System.Drawing.Color.Transparent;
            this.Stand6Run3.ConveyorColor = System.Drawing.Color.Gray;
            this.Stand6Run3.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.Stand6Run3.ConveyorHeight = 17;
            this.Stand6Run3.ConveyorSpeed = 200;
            this.animator.SetDecoration(this.Stand6Run3, AnimatorNS.DecorationType.None);
            this.Stand6Run3.Inclination = 0D;
            this.Stand6Run3.Location = new System.Drawing.Point(1922, 254);
            this.Stand6Run3.Margin = new System.Windows.Forms.Padding(2);
            this.Stand6Run3.Name = "Stand6Run3";
            this.Stand6Run3.Size = new System.Drawing.Size(40, 26);
            this.Stand6Run3.TabIndex = 27;
            // 
            // pbL5
            // 
            this.animator.SetDecoration(this.pbL5, AnimatorNS.DecorationType.None);
            this.pbL5.Image = ((System.Drawing.Image)(resources.GetObject("pbL5.Image")));
            this.pbL5.Location = new System.Drawing.Point(319, 189);
            this.pbL5.Name = "pbL5";
            this.pbL5.Size = new System.Drawing.Size(18, 50);
            this.pbL5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbL5.TabIndex = 74;
            this.pbL5.TabStop = false;
            // 
            // pbL4
            // 
            this.animator.SetDecoration(this.pbL4, AnimatorNS.DecorationType.None);
            this.pbL4.Image = ((System.Drawing.Image)(resources.GetObject("pbL4.Image")));
            this.pbL4.Location = new System.Drawing.Point(268, 189);
            this.pbL4.Name = "pbL4";
            this.pbL4.Size = new System.Drawing.Size(18, 50);
            this.pbL4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbL4.TabIndex = 73;
            this.pbL4.TabStop = false;
            // 
            // pbL3
            // 
            this.animator.SetDecoration(this.pbL3, AnimatorNS.DecorationType.None);
            this.pbL3.Image = ((System.Drawing.Image)(resources.GetObject("pbL3.Image")));
            this.pbL3.Location = new System.Drawing.Point(216, 189);
            this.pbL3.Name = "pbL3";
            this.pbL3.Size = new System.Drawing.Size(18, 50);
            this.pbL3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbL3.TabIndex = 72;
            this.pbL3.TabStop = false;
            // 
            // pbL2
            // 
            this.animator.SetDecoration(this.pbL2, AnimatorNS.DecorationType.None);
            this.pbL2.Image = ((System.Drawing.Image)(resources.GetObject("pbL2.Image")));
            this.pbL2.Location = new System.Drawing.Point(173, 190);
            this.pbL2.Name = "pbL2";
            this.pbL2.Size = new System.Drawing.Size(18, 50);
            this.pbL2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbL2.TabIndex = 71;
            this.pbL2.TabStop = false;
            // 
            // pbL1
            // 
            this.animator.SetDecoration(this.pbL1, AnimatorNS.DecorationType.None);
            this.pbL1.Image = ((System.Drawing.Image)(resources.GetObject("pbL1.Image")));
            this.pbL1.Location = new System.Drawing.Point(132, 189);
            this.pbL1.Name = "pbL1";
            this.pbL1.Size = new System.Drawing.Size(18, 50);
            this.pbL1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbL1.TabIndex = 70;
            this.pbL1.TabStop = false;
            // 
            // pbL0
            // 
            this.animator.SetDecoration(this.pbL0, AnimatorNS.DecorationType.None);
            this.pbL0.Image = ((System.Drawing.Image)(resources.GetObject("pbL0.Image")));
            this.pbL0.Location = new System.Drawing.Point(90, 189);
            this.pbL0.Name = "pbL0";
            this.pbL0.Size = new System.Drawing.Size(18, 50);
            this.pbL0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbL0.TabIndex = 69;
            this.pbL0.TabStop = false;
            // 
            // pbL6
            // 
            this.animator.SetDecoration(this.pbL6, AnimatorNS.DecorationType.None);
            this.pbL6.Image = ((System.Drawing.Image)(resources.GetObject("pbL6.Image")));
            this.pbL6.Location = new System.Drawing.Point(279, 77);
            this.pbL6.Name = "pbL6";
            this.pbL6.Size = new System.Drawing.Size(18, 50);
            this.pbL6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbL6.TabIndex = 75;
            this.pbL6.TabStop = false;
            // 
            // lb4Rolling
            // 
            this.lb4Rolling.AutoSize = true;
            this.lb4Rolling.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.lb4Rolling, AnimatorNS.DecorationType.None);
            this.lb4Rolling.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb4Rolling.ForeColor = System.Drawing.Color.Red;
            this.lb4Rolling.Location = new System.Drawing.Point(1617, 9);
            this.lb4Rolling.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb4Rolling.Name = "lb4Rolling";
            this.lb4Rolling.Size = new System.Drawing.Size(0, 46);
            this.lb4Rolling.TabIndex = 67;
            // 
            // pbH0
            // 
            this.animator.SetDecoration(this.pbH0, AnimatorNS.DecorationType.None);
            this.pbH0.Image = ((System.Drawing.Image)(resources.GetObject("pbH0.Image")));
            this.pbH0.Location = new System.Drawing.Point(173, 263);
            this.pbH0.Name = "pbH0";
            this.pbH0.Size = new System.Drawing.Size(50, 35);
            this.pbH0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbH0.TabIndex = 69;
            this.pbH0.TabStop = false;
            // 
            // pbH1
            // 
            this.animator.SetDecoration(this.pbH1, AnimatorNS.DecorationType.None);
            this.pbH1.Image = ((System.Drawing.Image)(resources.GetObject("pbH1.Image")));
            this.pbH1.Location = new System.Drawing.Point(173, 301);
            this.pbH1.Name = "pbH1";
            this.pbH1.Size = new System.Drawing.Size(50, 35);
            this.pbH1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbH1.TabIndex = 69;
            this.pbH1.TabStop = false;
            // 
            // pbH2
            // 
            this.animator.SetDecoration(this.pbH2, AnimatorNS.DecorationType.None);
            this.pbH2.Image = ((System.Drawing.Image)(resources.GetObject("pbH2.Image")));
            this.pbH2.Location = new System.Drawing.Point(173, 342);
            this.pbH2.Name = "pbH2";
            this.pbH2.Size = new System.Drawing.Size(50, 35);
            this.pbH2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbH2.TabIndex = 69;
            this.pbH2.TabStop = false;
            // 
            // pbH3
            // 
            this.animator.SetDecoration(this.pbH3, AnimatorNS.DecorationType.None);
            this.pbH3.Image = ((System.Drawing.Image)(resources.GetObject("pbH3.Image")));
            this.pbH3.Location = new System.Drawing.Point(173, 380);
            this.pbH3.Name = "pbH3";
            this.pbH3.Size = new System.Drawing.Size(50, 35);
            this.pbH3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbH3.TabIndex = 69;
            this.pbH3.TabStop = false;
            // 
            // pbH4
            // 
            this.animator.SetDecoration(this.pbH4, AnimatorNS.DecorationType.None);
            this.pbH4.Image = ((System.Drawing.Image)(resources.GetObject("pbH4.Image")));
            this.pbH4.Location = new System.Drawing.Point(173, 421);
            this.pbH4.Name = "pbH4";
            this.pbH4.Size = new System.Drawing.Size(50, 35);
            this.pbH4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbH4.TabIndex = 69;
            this.pbH4.TabStop = false;
            // 
            // pbH5
            // 
            this.animator.SetDecoration(this.pbH5, AnimatorNS.DecorationType.None);
            this.pbH5.Image = ((System.Drawing.Image)(resources.GetObject("pbH5.Image")));
            this.pbH5.Location = new System.Drawing.Point(173, 460);
            this.pbH5.Name = "pbH5";
            this.pbH5.Size = new System.Drawing.Size(50, 35);
            this.pbH5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbH5.TabIndex = 69;
            this.pbH5.TabStop = false;
            // 
            // pbH6
            // 
            this.animator.SetDecoration(this.pbH6, AnimatorNS.DecorationType.None);
            this.pbH6.Image = ((System.Drawing.Image)(resources.GetObject("pbH6.Image")));
            this.pbH6.Location = new System.Drawing.Point(173, 503);
            this.pbH6.Name = "pbH6";
            this.pbH6.Size = new System.Drawing.Size(50, 35);
            this.pbH6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbH6.TabIndex = 69;
            this.pbH6.TabStop = false;
            // 
            // lbFixed
            // 
            this.lbFixed.AutoSize = true;
            this.lbFixed.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.lbFixed, AnimatorNS.DecorationType.None);
            this.lbFixed.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFixed.ForeColor = System.Drawing.Color.Red;
            this.lbFixed.Location = new System.Drawing.Point(520, 4);
            this.lbFixed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFixed.Name = "lbFixed";
            this.lbFixed.Size = new System.Drawing.Size(0, 46);
            this.lbFixed.TabIndex = 67;
            // 
            // btnOpt0
            // 
            this.animator.SetDecoration(this.btnOpt0, AnimatorNS.DecorationType.None);
            this.btnOpt0.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt0.ForeColor = System.Drawing.Color.Red;
            this.btnOpt0.Location = new System.Drawing.Point(538, 77);
            this.btnOpt0.Name = "btnOpt0";
            this.btnOpt0.Size = new System.Drawing.Size(159, 50);
            this.btnOpt0.TabIndex = 64;
            this.btnOpt0.Text = "去[4轧]";
            this.btnOpt0.UseVisualStyleBackColor = true;
            this.btnOpt0.Visible = false;
            this.btnOpt0.Click += new System.EventHandler(this.btnOpt0_Click);
            this.btnOpt0.MouseLeave += new System.EventHandler(this.btnOpt0_MouseLeave);
            // 
            // btnOpt1
            // 
            this.animator.SetDecoration(this.btnOpt1, AnimatorNS.DecorationType.None);
            this.btnOpt1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt1.ForeColor = System.Drawing.Color.Red;
            this.btnOpt1.Location = new System.Drawing.Point(538, 130);
            this.btnOpt1.Name = "btnOpt1";
            this.btnOpt1.Size = new System.Drawing.Size(159, 50);
            this.btnOpt1.TabIndex = 64;
            this.btnOpt1.Text = "去[4轧]";
            this.btnOpt1.UseVisualStyleBackColor = true;
            this.btnOpt1.Visible = false;
            this.btnOpt1.Click += new System.EventHandler(this.btnOpt1_Click);
            this.btnOpt1.MouseLeave += new System.EventHandler(this.btnOpt1_MouseLeave);
            // 
            // btnOpt2
            // 
            this.animator.SetDecoration(this.btnOpt2, AnimatorNS.DecorationType.None);
            this.btnOpt2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt2.ForeColor = System.Drawing.Color.Red;
            this.btnOpt2.Location = new System.Drawing.Point(538, 183);
            this.btnOpt2.Name = "btnOpt2";
            this.btnOpt2.Size = new System.Drawing.Size(159, 50);
            this.btnOpt2.TabIndex = 64;
            this.btnOpt2.Text = "去[4轧]";
            this.btnOpt2.UseVisualStyleBackColor = true;
            this.btnOpt2.Visible = false;
            this.btnOpt2.Click += new System.EventHandler(this.btnOpt2_Click);
            this.btnOpt2.MouseLeave += new System.EventHandler(this.btnOpt2_MouseLeave);
            // 
            // btnOpt3
            // 
            this.animator.SetDecoration(this.btnOpt3, AnimatorNS.DecorationType.None);
            this.btnOpt3.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt3.ForeColor = System.Drawing.Color.Red;
            this.btnOpt3.Location = new System.Drawing.Point(538, 236);
            this.btnOpt3.Name = "btnOpt3";
            this.btnOpt3.Size = new System.Drawing.Size(159, 50);
            this.btnOpt3.TabIndex = 64;
            this.btnOpt3.Text = "去[4轧]";
            this.btnOpt3.UseVisualStyleBackColor = true;
            this.btnOpt3.Visible = false;
            this.btnOpt3.Click += new System.EventHandler(this.btnOpt3_Click);
            this.btnOpt3.MouseLeave += new System.EventHandler(this.btnOpt3_MouseLeave);
            // 
            // btnOpt4
            // 
            this.animator.SetDecoration(this.btnOpt4, AnimatorNS.DecorationType.None);
            this.btnOpt4.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt4.ForeColor = System.Drawing.Color.Red;
            this.btnOpt4.Location = new System.Drawing.Point(538, 292);
            this.btnOpt4.Name = "btnOpt4";
            this.btnOpt4.Size = new System.Drawing.Size(159, 50);
            this.btnOpt4.TabIndex = 64;
            this.btnOpt4.Text = "去[4轧]";
            this.btnOpt4.UseVisualStyleBackColor = true;
            this.btnOpt4.Visible = false;
            this.btnOpt4.Click += new System.EventHandler(this.btnOpt4_Click);
            this.btnOpt4.MouseLeave += new System.EventHandler(this.btnOpt4_MouseLeave);
            // 
            // btnOpt5
            // 
            this.animator.SetDecoration(this.btnOpt5, AnimatorNS.DecorationType.None);
            this.btnOpt5.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt5.ForeColor = System.Drawing.Color.Red;
            this.btnOpt5.Location = new System.Drawing.Point(538, 348);
            this.btnOpt5.Name = "btnOpt5";
            this.btnOpt5.Size = new System.Drawing.Size(159, 50);
            this.btnOpt5.TabIndex = 64;
            this.btnOpt5.Text = "去[4轧]";
            this.btnOpt5.UseVisualStyleBackColor = true;
            this.btnOpt5.Visible = false;
            this.btnOpt5.Click += new System.EventHandler(this.btnOpt5_Click);
            this.btnOpt5.MouseLeave += new System.EventHandler(this.btnOpt5_MouseLeave);
            // 
            // btnOpt6
            // 
            this.animator.SetDecoration(this.btnOpt6, AnimatorNS.DecorationType.None);
            this.btnOpt6.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt6.ForeColor = System.Drawing.Color.Red;
            this.btnOpt6.Location = new System.Drawing.Point(538, 402);
            this.btnOpt6.Name = "btnOpt6";
            this.btnOpt6.Size = new System.Drawing.Size(159, 50);
            this.btnOpt6.TabIndex = 64;
            this.btnOpt6.Text = "去[4轧]";
            this.btnOpt6.UseVisualStyleBackColor = true;
            this.btnOpt6.Visible = false;
            this.btnOpt6.Click += new System.EventHandler(this.btnOpt6_Click);
            this.btnOpt6.MouseLeave += new System.EventHandler(this.btnOpt6_MouseLeave);
            // 
            // animator
            // 
            this.animator.AnimationType = AnimatorNS.AnimationType.VertSlide;
            this.animator.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.animator.DefaultAnimation = animation1;
            // 
            // btnOpt0Right
            // 
            this.animator.SetDecoration(this.btnOpt0Right, AnimatorNS.DecorationType.None);
            this.btnOpt0Right.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt0Right.ForeColor = System.Drawing.Color.Red;
            this.btnOpt0Right.Location = new System.Drawing.Point(703, 77);
            this.btnOpt0Right.Name = "btnOpt0Right";
            this.btnOpt0Right.Size = new System.Drawing.Size(159, 50);
            this.btnOpt0Right.TabIndex = 64;
            this.btnOpt0Right.Text = "去[冷床]";
            this.btnOpt0Right.UseVisualStyleBackColor = true;
            this.btnOpt0Right.Visible = false;
            this.btnOpt0Right.Click += new System.EventHandler(this.btnOpt0Right_Click);
            this.btnOpt0Right.MouseLeave += new System.EventHandler(this.btnOpt0_MouseLeave);
            // 
            // btnOpt1Right
            // 
            this.animator.SetDecoration(this.btnOpt1Right, AnimatorNS.DecorationType.None);
            this.btnOpt1Right.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt1Right.ForeColor = System.Drawing.Color.Red;
            this.btnOpt1Right.Location = new System.Drawing.Point(703, 130);
            this.btnOpt1Right.Name = "btnOpt1Right";
            this.btnOpt1Right.Size = new System.Drawing.Size(159, 50);
            this.btnOpt1Right.TabIndex = 64;
            this.btnOpt1Right.Text = "去[冷床]";
            this.btnOpt1Right.UseVisualStyleBackColor = true;
            this.btnOpt1Right.Visible = false;
            this.btnOpt1Right.Click += new System.EventHandler(this.btnOpt1Right_Click);
            this.btnOpt1Right.MouseLeave += new System.EventHandler(this.btnOpt1_MouseLeave);
            // 
            // btnOpt2Right
            // 
            this.animator.SetDecoration(this.btnOpt2Right, AnimatorNS.DecorationType.None);
            this.btnOpt2Right.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt2Right.ForeColor = System.Drawing.Color.Red;
            this.btnOpt2Right.Location = new System.Drawing.Point(703, 183);
            this.btnOpt2Right.Name = "btnOpt2Right";
            this.btnOpt2Right.Size = new System.Drawing.Size(159, 50);
            this.btnOpt2Right.TabIndex = 64;
            this.btnOpt2Right.Text = "去[冷床]";
            this.btnOpt2Right.UseVisualStyleBackColor = true;
            this.btnOpt2Right.Visible = false;
            this.btnOpt2Right.Click += new System.EventHandler(this.btnOpt2Right_Click);
            this.btnOpt2Right.MouseLeave += new System.EventHandler(this.btnOpt2_MouseLeave);
            // 
            // btnOpt3Right
            // 
            this.animator.SetDecoration(this.btnOpt3Right, AnimatorNS.DecorationType.None);
            this.btnOpt3Right.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt3Right.ForeColor = System.Drawing.Color.Red;
            this.btnOpt3Right.Location = new System.Drawing.Point(703, 236);
            this.btnOpt3Right.Name = "btnOpt3Right";
            this.btnOpt3Right.Size = new System.Drawing.Size(159, 50);
            this.btnOpt3Right.TabIndex = 64;
            this.btnOpt3Right.Text = "去[冷床]";
            this.btnOpt3Right.UseVisualStyleBackColor = true;
            this.btnOpt3Right.Visible = false;
            this.btnOpt3Right.Click += new System.EventHandler(this.btnOpt3Right_Click);
            this.btnOpt3Right.MouseLeave += new System.EventHandler(this.btnOpt3_MouseLeave);
            // 
            // btnOpt4Right
            // 
            this.animator.SetDecoration(this.btnOpt4Right, AnimatorNS.DecorationType.None);
            this.btnOpt4Right.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt4Right.ForeColor = System.Drawing.Color.Red;
            this.btnOpt4Right.Location = new System.Drawing.Point(703, 292);
            this.btnOpt4Right.Name = "btnOpt4Right";
            this.btnOpt4Right.Size = new System.Drawing.Size(159, 50);
            this.btnOpt4Right.TabIndex = 64;
            this.btnOpt4Right.Text = "去[冷床]";
            this.btnOpt4Right.UseVisualStyleBackColor = true;
            this.btnOpt4Right.Visible = false;
            this.btnOpt4Right.Click += new System.EventHandler(this.btnOpt4Right_Click);
            this.btnOpt4Right.MouseLeave += new System.EventHandler(this.btnOpt4_MouseLeave);
            // 
            // btnOpt5Right
            // 
            this.animator.SetDecoration(this.btnOpt5Right, AnimatorNS.DecorationType.None);
            this.btnOpt5Right.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt5Right.ForeColor = System.Drawing.Color.Red;
            this.btnOpt5Right.Location = new System.Drawing.Point(703, 348);
            this.btnOpt5Right.Name = "btnOpt5Right";
            this.btnOpt5Right.Size = new System.Drawing.Size(159, 50);
            this.btnOpt5Right.TabIndex = 64;
            this.btnOpt5Right.Text = "去[冷床]";
            this.btnOpt5Right.UseVisualStyleBackColor = true;
            this.btnOpt5Right.Visible = false;
            this.btnOpt5Right.Click += new System.EventHandler(this.btnOpt5Right_Click);
            this.btnOpt5Right.MouseLeave += new System.EventHandler(this.btnOpt5_MouseLeave);
            // 
            // btnOpt6Right
            // 
            this.animator.SetDecoration(this.btnOpt6Right, AnimatorNS.DecorationType.None);
            this.btnOpt6Right.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpt6Right.ForeColor = System.Drawing.Color.Red;
            this.btnOpt6Right.Location = new System.Drawing.Point(703, 402);
            this.btnOpt6Right.Name = "btnOpt6Right";
            this.btnOpt6Right.Size = new System.Drawing.Size(159, 50);
            this.btnOpt6Right.TabIndex = 64;
            this.btnOpt6Right.Text = "去[冷床]";
            this.btnOpt6Right.UseVisualStyleBackColor = true;
            this.btnOpt6Right.Visible = false;
            this.btnOpt6Right.Click += new System.EventHandler(this.btnOpt6Right_Click);
            this.btnOpt6Right.MouseLeave += new System.EventHandler(this.btnOpt6_MouseLeave);
            // 
            // txtSpeed
            // 
            this.animator.SetDecoration(this.txtSpeed, AnimatorNS.DecorationType.None);
            this.txtSpeed.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSpeed.Location = new System.Drawing.Point(832, 9);
            this.txtSpeed.Multiline = true;
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(52, 37);
            this.txtSpeed.TabIndex = 1;
            this.txtSpeed.Visible = false;
            this.txtSpeed.TextChanged += new System.EventHandler(this.txtSpeed_TextChanged);
            this.txtSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpeed_KeyPress);
            this.txtSpeed.MouseLeave += new System.EventHandler(this.txtSpeed_MouseLeave);
            this.txtSpeed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtSpeed_MouseMove);
            // 
            // plAlarm
            // 
            this.plAlarm.Controls.Add(this.lbAlarmStr);
            this.plAlarm.Controls.Add(this.ucAlarmLamp1);
            this.animator.SetDecoration(this.plAlarm, AnimatorNS.DecorationType.None);
            this.plAlarm.Location = new System.Drawing.Point(238, 557);
            this.plAlarm.Name = "plAlarm";
            this.plAlarm.Size = new System.Drawing.Size(548, 62);
            this.plAlarm.TabIndex = 77;
            this.plAlarm.Visible = false;
            // 
            // lbAlarmStr
            // 
            this.lbAlarmStr.AutoSize = true;
            this.animator.SetDecoration(this.lbAlarmStr, AnimatorNS.DecorationType.None);
            this.lbAlarmStr.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAlarmStr.Location = new System.Drawing.Point(89, 7);
            this.lbAlarmStr.Name = "lbAlarmStr";
            this.lbAlarmStr.Size = new System.Drawing.Size(462, 46);
            this.lbAlarmStr.TabIndex = 79;
            this.lbAlarmStr.Text = "0流辊道运输超时，请检查！";
            // 
            // ucAlarmLamp1
            // 
            this.animator.SetDecoration(this.ucAlarmLamp1, AnimatorNS.DecorationType.None);
            this.ucAlarmLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))))};
            this.ucAlarmLamp1.Lampstand = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ucAlarmLamp1.Location = new System.Drawing.Point(6, 1);
            this.ucAlarmLamp1.Margin = new System.Windows.Forms.Padding(2);
            this.ucAlarmLamp1.Name = "ucAlarmLamp1";
            this.ucAlarmLamp1.Size = new System.Drawing.Size(78, 60);
            this.ucAlarmLamp1.TabIndex = 78;
            this.ucAlarmLamp1.TwinkleSpeed = 200;
            // 
            // btnLiftingSteel0
            // 
            this.animator.SetDecoration(this.btnLiftingSteel0, AnimatorNS.DecorationType.None);
            this.btnLiftingSteel0.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiftingSteel0.ForeColor = System.Drawing.Color.Red;
            this.btnLiftingSteel0.Location = new System.Drawing.Point(1055, 77);
            this.btnLiftingSteel0.Name = "btnLiftingSteel0";
            this.btnLiftingSteel0.Size = new System.Drawing.Size(159, 50);
            this.btnLiftingSteel0.TabIndex = 64;
            this.btnLiftingSteel0.Text = "提钢";
            this.btnLiftingSteel0.UseVisualStyleBackColor = true;
            this.btnLiftingSteel0.Click += new System.EventHandler(this.btnLiftingSteel0_Click);
            this.btnLiftingSteel0.MouseLeave += new System.EventHandler(this.btnFlipSteeling0_MouseLeave);
            // 
            // btnLiftingSteel1
            // 
            this.animator.SetDecoration(this.btnLiftingSteel1, AnimatorNS.DecorationType.None);
            this.btnLiftingSteel1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiftingSteel1.ForeColor = System.Drawing.Color.Red;
            this.btnLiftingSteel1.Location = new System.Drawing.Point(1055, 130);
            this.btnLiftingSteel1.Name = "btnLiftingSteel1";
            this.btnLiftingSteel1.Size = new System.Drawing.Size(159, 50);
            this.btnLiftingSteel1.TabIndex = 64;
            this.btnLiftingSteel1.Text = "提钢";
            this.btnLiftingSteel1.UseVisualStyleBackColor = true;
            this.btnLiftingSteel1.Click += new System.EventHandler(this.btnLiftingSteel1_Click);
            this.btnLiftingSteel1.MouseLeave += new System.EventHandler(this.btnFlipSteeling1_MouseLeave);
            // 
            // btnLiftingSteel2
            // 
            this.animator.SetDecoration(this.btnLiftingSteel2, AnimatorNS.DecorationType.None);
            this.btnLiftingSteel2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiftingSteel2.ForeColor = System.Drawing.Color.Red;
            this.btnLiftingSteel2.Location = new System.Drawing.Point(1055, 183);
            this.btnLiftingSteel2.Name = "btnLiftingSteel2";
            this.btnLiftingSteel2.Size = new System.Drawing.Size(159, 50);
            this.btnLiftingSteel2.TabIndex = 64;
            this.btnLiftingSteel2.Text = "提钢";
            this.btnLiftingSteel2.UseVisualStyleBackColor = true;
            this.btnLiftingSteel2.Click += new System.EventHandler(this.btnLiftingSteel2_Click);
            this.btnLiftingSteel2.MouseLeave += new System.EventHandler(this.btnFlipSteeling2_MouseLeave);
            // 
            // btnLiftingSteel3
            // 
            this.animator.SetDecoration(this.btnLiftingSteel3, AnimatorNS.DecorationType.None);
            this.btnLiftingSteel3.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiftingSteel3.ForeColor = System.Drawing.Color.Red;
            this.btnLiftingSteel3.Location = new System.Drawing.Point(1055, 236);
            this.btnLiftingSteel3.Name = "btnLiftingSteel3";
            this.btnLiftingSteel3.Size = new System.Drawing.Size(159, 50);
            this.btnLiftingSteel3.TabIndex = 64;
            this.btnLiftingSteel3.Text = "提钢";
            this.btnLiftingSteel3.UseVisualStyleBackColor = true;
            this.btnLiftingSteel3.Click += new System.EventHandler(this.btnLiftingSteel3_Click);
            this.btnLiftingSteel3.MouseLeave += new System.EventHandler(this.btnFlipSteeling3_MouseLeave);
            // 
            // btnLiftingSteel4
            // 
            this.animator.SetDecoration(this.btnLiftingSteel4, AnimatorNS.DecorationType.None);
            this.btnLiftingSteel4.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiftingSteel4.ForeColor = System.Drawing.Color.Red;
            this.btnLiftingSteel4.Location = new System.Drawing.Point(1055, 289);
            this.btnLiftingSteel4.Name = "btnLiftingSteel4";
            this.btnLiftingSteel4.Size = new System.Drawing.Size(159, 50);
            this.btnLiftingSteel4.TabIndex = 64;
            this.btnLiftingSteel4.Text = "提钢";
            this.btnLiftingSteel4.UseVisualStyleBackColor = true;
            this.btnLiftingSteel4.Click += new System.EventHandler(this.btnLiftingSteel4_Click);
            this.btnLiftingSteel4.MouseLeave += new System.EventHandler(this.btnFlipSteeling4_MouseLeave);
            // 
            // btnLiftingSteel5
            // 
            this.animator.SetDecoration(this.btnLiftingSteel5, AnimatorNS.DecorationType.None);
            this.btnLiftingSteel5.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiftingSteel5.ForeColor = System.Drawing.Color.Red;
            this.btnLiftingSteel5.Location = new System.Drawing.Point(1055, 342);
            this.btnLiftingSteel5.Name = "btnLiftingSteel5";
            this.btnLiftingSteel5.Size = new System.Drawing.Size(159, 50);
            this.btnLiftingSteel5.TabIndex = 64;
            this.btnLiftingSteel5.Text = "提钢";
            this.btnLiftingSteel5.UseVisualStyleBackColor = true;
            this.btnLiftingSteel5.Click += new System.EventHandler(this.btnLiftingSteel5_Click);
            this.btnLiftingSteel5.MouseLeave += new System.EventHandler(this.btnFlipSteeling5_MouseLeave);
            // 
            // btnLiftingSteel6
            // 
            this.animator.SetDecoration(this.btnLiftingSteel6, AnimatorNS.DecorationType.None);
            this.btnLiftingSteel6.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiftingSteel6.ForeColor = System.Drawing.Color.Red;
            this.btnLiftingSteel6.Location = new System.Drawing.Point(1055, 395);
            this.btnLiftingSteel6.Name = "btnLiftingSteel6";
            this.btnLiftingSteel6.Size = new System.Drawing.Size(159, 50);
            this.btnLiftingSteel6.TabIndex = 64;
            this.btnLiftingSteel6.Text = "提钢";
            this.btnLiftingSteel6.UseVisualStyleBackColor = true;
            this.btnLiftingSteel6.Click += new System.EventHandler(this.btnLiftingSteel6_Click);
            this.btnLiftingSteel6.MouseLeave += new System.EventHandler(this.btnFlipSteeling6_MouseLeave);
            // 
            // btnFlipSteeling0
            // 
            this.animator.SetDecoration(this.btnFlipSteeling0, AnimatorNS.DecorationType.None);
            this.btnFlipSteeling0.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlipSteeling0.ForeColor = System.Drawing.Color.Red;
            this.btnFlipSteeling0.Location = new System.Drawing.Point(890, 77);
            this.btnFlipSteeling0.Name = "btnFlipSteeling0";
            this.btnFlipSteeling0.Size = new System.Drawing.Size(159, 50);
            this.btnFlipSteeling0.TabIndex = 64;
            this.btnFlipSteeling0.Text = "翻钢";
            this.btnFlipSteeling0.UseVisualStyleBackColor = true;
            this.btnFlipSteeling0.Visible = false;
            this.btnFlipSteeling0.Click += new System.EventHandler(this.btnFlipSteeling0_Click);
            this.btnFlipSteeling0.MouseLeave += new System.EventHandler(this.btnFlipSteeling0_MouseLeave);
            // 
            // btnFlipSteeling1
            // 
            this.animator.SetDecoration(this.btnFlipSteeling1, AnimatorNS.DecorationType.None);
            this.btnFlipSteeling1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlipSteeling1.ForeColor = System.Drawing.Color.Red;
            this.btnFlipSteeling1.Location = new System.Drawing.Point(890, 130);
            this.btnFlipSteeling1.Name = "btnFlipSteeling1";
            this.btnFlipSteeling1.Size = new System.Drawing.Size(159, 50);
            this.btnFlipSteeling1.TabIndex = 64;
            this.btnFlipSteeling1.Text = "翻钢";
            this.btnFlipSteeling1.UseVisualStyleBackColor = true;
            this.btnFlipSteeling1.Visible = false;
            this.btnFlipSteeling1.Click += new System.EventHandler(this.btnFlipSteeling1_Click);
            this.btnFlipSteeling1.MouseLeave += new System.EventHandler(this.btnFlipSteeling1_MouseLeave);
            // 
            // btnFlipSteeling2
            // 
            this.animator.SetDecoration(this.btnFlipSteeling2, AnimatorNS.DecorationType.None);
            this.btnFlipSteeling2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlipSteeling2.ForeColor = System.Drawing.Color.Red;
            this.btnFlipSteeling2.Location = new System.Drawing.Point(890, 183);
            this.btnFlipSteeling2.Name = "btnFlipSteeling2";
            this.btnFlipSteeling2.Size = new System.Drawing.Size(159, 50);
            this.btnFlipSteeling2.TabIndex = 64;
            this.btnFlipSteeling2.Text = "翻钢";
            this.btnFlipSteeling2.UseVisualStyleBackColor = true;
            this.btnFlipSteeling2.Visible = false;
            this.btnFlipSteeling2.Click += new System.EventHandler(this.btnFlipSteeling2_Click);
            this.btnFlipSteeling2.MouseLeave += new System.EventHandler(this.btnFlipSteeling2_MouseLeave);
            // 
            // btnFlipSteeling3
            // 
            this.animator.SetDecoration(this.btnFlipSteeling3, AnimatorNS.DecorationType.None);
            this.btnFlipSteeling3.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlipSteeling3.ForeColor = System.Drawing.Color.Red;
            this.btnFlipSteeling3.Location = new System.Drawing.Point(890, 236);
            this.btnFlipSteeling3.Name = "btnFlipSteeling3";
            this.btnFlipSteeling3.Size = new System.Drawing.Size(159, 50);
            this.btnFlipSteeling3.TabIndex = 64;
            this.btnFlipSteeling3.Text = "翻钢";
            this.btnFlipSteeling3.UseVisualStyleBackColor = true;
            this.btnFlipSteeling3.Visible = false;
            this.btnFlipSteeling3.Click += new System.EventHandler(this.btnFlipSteeling3_Click);
            this.btnFlipSteeling3.MouseLeave += new System.EventHandler(this.btnFlipSteeling3_MouseLeave);
            // 
            // btnFlipSteeling4
            // 
            this.animator.SetDecoration(this.btnFlipSteeling4, AnimatorNS.DecorationType.None);
            this.btnFlipSteeling4.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlipSteeling4.ForeColor = System.Drawing.Color.Red;
            this.btnFlipSteeling4.Location = new System.Drawing.Point(890, 289);
            this.btnFlipSteeling4.Name = "btnFlipSteeling4";
            this.btnFlipSteeling4.Size = new System.Drawing.Size(159, 50);
            this.btnFlipSteeling4.TabIndex = 64;
            this.btnFlipSteeling4.Text = "翻钢";
            this.btnFlipSteeling4.UseVisualStyleBackColor = true;
            this.btnFlipSteeling4.Visible = false;
            this.btnFlipSteeling4.Click += new System.EventHandler(this.btnFlipSteeling4_Click);
            this.btnFlipSteeling4.MouseLeave += new System.EventHandler(this.btnFlipSteeling4_MouseLeave);
            // 
            // btnFlipSteeling5
            // 
            this.animator.SetDecoration(this.btnFlipSteeling5, AnimatorNS.DecorationType.None);
            this.btnFlipSteeling5.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlipSteeling5.ForeColor = System.Drawing.Color.Red;
            this.btnFlipSteeling5.Location = new System.Drawing.Point(890, 342);
            this.btnFlipSteeling5.Name = "btnFlipSteeling5";
            this.btnFlipSteeling5.Size = new System.Drawing.Size(159, 50);
            this.btnFlipSteeling5.TabIndex = 64;
            this.btnFlipSteeling5.Text = "翻钢";
            this.btnFlipSteeling5.UseVisualStyleBackColor = true;
            this.btnFlipSteeling5.Visible = false;
            this.btnFlipSteeling5.Click += new System.EventHandler(this.btnFlipSteeling5_Click);
            this.btnFlipSteeling5.MouseLeave += new System.EventHandler(this.btnFlipSteeling5_MouseLeave);
            // 
            // btnFlipSteeling6
            // 
            this.animator.SetDecoration(this.btnFlipSteeling6, AnimatorNS.DecorationType.None);
            this.btnFlipSteeling6.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlipSteeling6.ForeColor = System.Drawing.Color.Red;
            this.btnFlipSteeling6.Location = new System.Drawing.Point(890, 395);
            this.btnFlipSteeling6.Name = "btnFlipSteeling6";
            this.btnFlipSteeling6.Size = new System.Drawing.Size(159, 50);
            this.btnFlipSteeling6.TabIndex = 64;
            this.btnFlipSteeling6.Text = "翻钢";
            this.btnFlipSteeling6.UseVisualStyleBackColor = true;
            this.btnFlipSteeling6.Visible = false;
            this.btnFlipSteeling6.Click += new System.EventHandler(this.btnFlipSteeling6_Click);
            this.btnFlipSteeling6.MouseLeave += new System.EventHandler(this.btnFlipSteeling6_MouseLeave);
            // 
            // txtGo4
            // 
            this.animator.SetDecoration(this.txtGo4, AnimatorNS.DecorationType.None);
            this.txtGo4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGo4.Location = new System.Drawing.Point(1420, 12);
            this.txtGo4.Multiline = true;
            this.txtGo4.Name = "txtGo4";
            this.txtGo4.Size = new System.Drawing.Size(57, 30);
            this.txtGo4.TabIndex = 78;
            this.txtGo4.TextChanged += new System.EventHandler(this.txtGo4_TextChanged);
            this.txtGo4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGo4_KeyPress);
            // 
            // txtGoCold
            // 
            this.animator.SetDecoration(this.txtGoCold, AnimatorNS.DecorationType.None);
            this.txtGoCold.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGoCold.Location = new System.Drawing.Point(1531, 12);
            this.txtGoCold.Multiline = true;
            this.txtGoCold.Name = "txtGoCold";
            this.txtGoCold.Size = new System.Drawing.Size(57, 30);
            this.txtGoCold.TabIndex = 78;
            this.txtGoCold.TextChanged += new System.EventHandler(this.txtGoCold_TextChanged);
            this.txtGoCold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoCold_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.label1, AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1371, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 79;
            this.label1.Text = "去4轧";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.label4, AnimatorNS.DecorationType.None);
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(1477, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 79;
            this.label4.Text = "去冷床";
            // 
            // tColor0
            // 
            this.tColor0.Interval = 500;
            this.tColor0.Tick += new System.EventHandler(this.tColor0_Tick);
            // 
            // tColor1
            // 
            this.tColor1.Interval = 500;
            this.tColor1.Tick += new System.EventHandler(this.tColor1_Tick);
            // 
            // tColor2
            // 
            this.tColor2.Interval = 500;
            this.tColor2.Tick += new System.EventHandler(this.tColor2_Tick);
            // 
            // tColor3
            // 
            this.tColor3.Interval = 500;
            this.tColor3.Tick += new System.EventHandler(this.tColor3_Tick);
            // 
            // tColor4
            // 
            this.tColor4.Interval = 500;
            this.tColor4.Tick += new System.EventHandler(this.tColor4_Tick);
            // 
            // tColor5
            // 
            this.tColor5.Interval = 500;
            this.tColor5.Tick += new System.EventHandler(this.tColor5_Tick);
            // 
            // tColor6
            // 
            this.tColor6.Interval = 500;
            this.tColor6.Tick += new System.EventHandler(this.tColor6_Tick);
            // 
            // IntelligentBilletProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 842);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGoCold);
            this.Controls.Add(this.txtGo4);
            this.Controls.Add(this.btnFlipSteeling6);
            this.Controls.Add(this.btnFlipSteeling5);
            this.Controls.Add(this.btnFlipSteeling4);
            this.Controls.Add(this.btnFlipSteeling3);
            this.Controls.Add(this.btnFlipSteeling2);
            this.Controls.Add(this.btnFlipSteeling1);
            this.Controls.Add(this.btnFlipSteeling0);
            this.Controls.Add(this.btnLiftingSteel6);
            this.Controls.Add(this.btnLiftingSteel5);
            this.Controls.Add(this.btnLiftingSteel4);
            this.Controls.Add(this.btnLiftingSteel3);
            this.Controls.Add(this.btnLiftingSteel2);
            this.Controls.Add(this.btnLiftingSteel1);
            this.Controls.Add(this.btnLiftingSteel0);
            this.Controls.Add(this.plAlarm);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.lbTGJ);
            this.Controls.Add(this.pbL5);
            this.Controls.Add(this.pbL4);
            this.Controls.Add(this.pbL3);
            this.Controls.Add(this.pbL2);
            this.Controls.Add(this.pbL1);
            this.Controls.Add(this.pbH6);
            this.Controls.Add(this.pbH5);
            this.Controls.Add(this.pbH4);
            this.Controls.Add(this.pbH3);
            this.Controls.Add(this.pbH2);
            this.Controls.Add(this.pbH1);
            this.Controls.Add(this.pbH0);
            this.Controls.Add(this.pbL0);
            this.Controls.Add(this.lb4Rolling);
            this.Controls.Add(this.lbFixed);
            this.Controls.Add(this.lb1Rolling);
            this.Controls.Add(this.btn6Continue);
            this.Controls.Add(this.btn5Continue);
            this.Controls.Add(this.btn4Continue);
            this.Controls.Add(this.btn3Continue);
            this.Controls.Add(this.btn2Continue);
            this.Controls.Add(this.btn1Continue);
            this.Controls.Add(this.btnOpt6Right);
            this.Controls.Add(this.btnOpt6);
            this.Controls.Add(this.btnOpt5Right);
            this.Controls.Add(this.btnOpt5);
            this.Controls.Add(this.btnOpt4Right);
            this.Controls.Add(this.btnOpt4);
            this.Controls.Add(this.btnOpt3Right);
            this.Controls.Add(this.btnOpt3);
            this.Controls.Add(this.btnOpt2Right);
            this.Controls.Add(this.btnOpt2);
            this.Controls.Add(this.btnOpt1Right);
            this.Controls.Add(this.btnOpt1);
            this.Controls.Add(this.btnOpt0Right);
            this.Controls.Add(this.btnOpt0);
            this.Controls.Add(this.btn0Continue);
            this.Controls.Add(this.ucReturnfurnace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uccoldbed);
            this.Controls.Add(this.S6);
            this.Controls.Add(this.S5);
            this.Controls.Add(this.S4);
            this.Controls.Add(this.S3);
            this.Controls.Add(this.S2);
            this.Controls.Add(this.S1);
            this.Controls.Add(this.S0);
            this.Controls.Add(this.gcRunList);
            this.Controls.Add(this.lbNowSteel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Stand5Run);
            this.Controls.Add(this.Stand4Run);
            this.Controls.Add(this.Stand3Run);
            this.Controls.Add(this.Stand2Run);
            this.Controls.Add(this.Stand1Run);
            this.Controls.Add(this.Stand6Run3);
            this.Controls.Add(this.Stand6Run2);
            this.Controls.Add(this.Stand5Run3);
            this.Controls.Add(this.Stand5Run2);
            this.Controls.Add(this.Stand4Run3);
            this.Controls.Add(this.Stand4Run2);
            this.Controls.Add(this.Stand3Run3);
            this.Controls.Add(this.Stand3Run2);
            this.Controls.Add(this.Stand6Run1);
            this.Controls.Add(this.Stand2Run3);
            this.Controls.Add(this.Stand5Run1);
            this.Controls.Add(this.Stand2Run2);
            this.Controls.Add(this.Stand4Run1);
            this.Controls.Add(this.Stand1Run3);
            this.Controls.Add(this.Stand3Run1);
            this.Controls.Add(this.Stand1Run2);
            this.Controls.Add(this.Stand2Run1);
            this.Controls.Add(this.Stand0Run3);
            this.Controls.Add(this.Stand1Run1);
            this.Controls.Add(this.Stand0Run2);
            this.Controls.Add(this.Stand0Run1);
            this.Controls.Add(this.Stand0Run);
            this.Controls.Add(this.Stand6Run);
            this.Controls.Add(this.Rolling4Run);
            this.Controls.Add(this.lbLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OneRolling);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Stand6);
            this.Controls.Add(this.Stand5);
            this.Controls.Add(this.Stand4);
            this.Controls.Add(this.Stand3);
            this.Controls.Add(this.Stand2);
            this.Controls.Add(this.Stand1);
            this.Controls.Add(this.Stand0);
            this.Controls.Add(this.ucsteelrolling);
            this.Controls.Add(this.pbL6);
            this.animator.SetDecoration(this, AnimatorNS.DecorationType.None);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IntelligentBilletProduction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能出坯";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntelligentBilletProduction_FormClosing);
            this.Load += new System.EventHandler(this.IntelligentBilletProduction_Load);
            this.Shown += new System.EventHandler(this.IntelligentBilletProduction_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRunList)).EndInit();
            this.cmschange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbL5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbL6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH6)).EndInit();
            this.plAlarm.ResumeLayout(false);
            this.plAlarm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000044 RID: 68
		private global::System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsName;
        private System.Windows.Forms.ToolStripStatusLabel tsconnection;
        private HZH_Controls.Controls.UCSplitLabel Stand0;
        private HZH_Controls.Controls.UCSplitLabel Stand1;
        private HZH_Controls.Controls.UCSplitLabel Stand2;
        private HZH_Controls.Controls.UCSplitLabel Stand3;
        private HZH_Controls.Controls.UCSplitLabel Stand4;
        private HZH_Controls.Controls.UCSplitLabel Stand5;
        private HZH_Controls.Controls.UCSplitLabel Stand6;
        private System.Windows.Forms.Label lbTGJ;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label OneRolling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private HZH_Controls.Controls.UCConveyor Rolling4Run;
        private HZH_Controls.Controls.UCConveyor Stand0Run;
        private HZH_Controls.Controls.UCConveyor Stand1Run;
        private HZH_Controls.Controls.UCConveyor Stand2Run;
        private HZH_Controls.Controls.UCConveyor Stand3Run;
        private HZH_Controls.Controls.UCConveyor Stand4Run;
        private HZH_Controls.Controls.UCConveyor Stand5Run;
        private HZH_Controls.Controls.UCConveyor Stand6Run;
        private System.Windows.Forms.Timer tStand0;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsSystemSet;
        private System.Windows.Forms.ToolStripButton tsSeeTables;
        private System.Windows.Forms.ToolStripButton tsAutomaticBillet;
        private System.Windows.Forms.Timer tStand1;
        private System.Windows.Forms.Timer tStand2;
        private System.Windows.Forms.Timer tStand3;
        private System.Windows.Forms.Timer tStand4;
        private System.Windows.Forms.Timer tStand5;
        private System.Windows.Forms.Timer tStand6;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label lbNowSteel;
        private System.Windows.Forms.DataGridView gcRunList;
        private System.Windows.Forms.Label S0;
        private System.Windows.Forms.Label S1;
        private System.Windows.Forms.Label S2;
        private System.Windows.Forms.Label S3;
        private System.Windows.Forms.Label S4;
        private System.Windows.Forms.Label S5;
        private System.Windows.Forms.Label S6;
        private HZH_Controls.Controls.UCConduit ucsteelrolling;
        private HZH_Controls.Controls.UCPond uccoldbed;
        private HZH_Controls.Controls.UCBlower ucReturnfurnace;
        private System.Windows.Forms.ContextMenuStrip cmschange;
        private System.Windows.Forms.ToolStripMenuItem 轧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 冷床ToolStripMenuItem;
        private System.Windows.Forms.Timer tIsSteelrolling;
        private System.Windows.Forms.DataGridViewTextBoxColumn SteelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn thick;
        private System.Windows.Forms.Button btn0Continue;
        private System.Windows.Forms.Button btn1Continue;
        private System.Windows.Forms.Button btn2Continue;
        private System.Windows.Forms.Button btn3Continue;
        private System.Windows.Forms.Button btn4Continue;
        private System.Windows.Forms.Button btn5Continue;
        private System.Windows.Forms.Button btn6Continue;
        private System.Windows.Forms.Label lb1Rolling;
        private HZH_Controls.Controls.UCConveyor Stand0Run1;
        private HZH_Controls.Controls.UCConveyor Stand0Run2;
        private HZH_Controls.Controls.UCConveyor Stand0Run3;
        private HZH_Controls.Controls.UCConveyor Stand1Run1;
        private HZH_Controls.Controls.UCConveyor Stand1Run2;
        private HZH_Controls.Controls.UCConveyor Stand1Run3;
        private HZH_Controls.Controls.UCConveyor Stand2Run1;
        private HZH_Controls.Controls.UCConveyor Stand2Run2;
        private HZH_Controls.Controls.UCConveyor Stand2Run3;
        private HZH_Controls.Controls.UCConveyor Stand3Run1;
        private HZH_Controls.Controls.UCConveyor Stand3Run2;
        private HZH_Controls.Controls.UCConveyor Stand3Run3;
        private HZH_Controls.Controls.UCConveyor Stand4Run1;
        private HZH_Controls.Controls.UCConveyor Stand4Run2;
        private HZH_Controls.Controls.UCConveyor Stand4Run3;
        private HZH_Controls.Controls.UCConveyor Stand5Run1;
        private HZH_Controls.Controls.UCConveyor Stand5Run2;
        private HZH_Controls.Controls.UCConveyor Stand5Run3;
        private HZH_Controls.Controls.UCConveyor Stand6Run1;
        private HZH_Controls.Controls.UCConveyor Stand6Run2;
        private HZH_Controls.Controls.UCConveyor Stand6Run3;
        private System.Windows.Forms.PictureBox pbL0;
        private System.Windows.Forms.PictureBox pbL1;
        private System.Windows.Forms.PictureBox pbL2;
        private System.Windows.Forms.PictureBox pbL3;
        private System.Windows.Forms.PictureBox pbL4;
        private System.Windows.Forms.PictureBox pbL5;
        private System.Windows.Forms.PictureBox pbL6;
        private System.Windows.Forms.Label lb4Rolling;
        private System.Windows.Forms.PictureBox pbH0;
        private System.Windows.Forms.PictureBox pbH1;
        private System.Windows.Forms.PictureBox pbH2;
        private System.Windows.Forms.PictureBox pbH3;
        private System.Windows.Forms.PictureBox pbH4;
        private System.Windows.Forms.PictureBox pbH5;
        private System.Windows.Forms.PictureBox pbH6;
        private System.Windows.Forms.Label lbFixed;
        private System.Windows.Forms.Button btnOpt0;
        private System.Windows.Forms.Button btnOpt1;
        private System.Windows.Forms.Button btnOpt2;
        private System.Windows.Forms.Button btnOpt3;
        private System.Windows.Forms.Button btnOpt4;
        private System.Windows.Forms.Button btnOpt5;
        private System.Windows.Forms.Button btnOpt6;
        private AnimatorNS.Animator animator;
        private System.Windows.Forms.Timer tColor0;
        private System.Windows.Forms.Timer tColor1;
        private System.Windows.Forms.Timer tColor2;
        private System.Windows.Forms.Timer tColor3;
        private System.Windows.Forms.Timer tColor4;
        private System.Windows.Forms.Timer tColor5;
        private System.Windows.Forms.Timer tColor6;
        private System.Windows.Forms.Button btnOpt0Right;
        private System.Windows.Forms.Button btnOpt1Right;
        private System.Windows.Forms.Button btnOpt2Right;
        private System.Windows.Forms.Button btnOpt3Right;
        private System.Windows.Forms.Button btnOpt4Right;
        private System.Windows.Forms.Button btnOpt5Right;
        private System.Windows.Forms.Button btnOpt6Right;
        private System.Windows.Forms.ToolStripButton ts1SteelMovingMachine;
        private System.Windows.Forms.ToolStripButton ts2SteelMovingMachine;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Panel plAlarm;
        private HZH_Controls.Controls.UCAlarmLamp ucAlarmLamp1;
        private System.Windows.Forms.Label lbAlarmStr;
        private System.Windows.Forms.Button btnLiftingSteel0;
        private System.Windows.Forms.Button btnLiftingSteel1;
        private System.Windows.Forms.Button btnLiftingSteel2;
        private System.Windows.Forms.Button btnLiftingSteel3;
        private System.Windows.Forms.Button btnLiftingSteel4;
        private System.Windows.Forms.Button btnLiftingSteel5;
        private System.Windows.Forms.Button btnLiftingSteel6;
        private System.Windows.Forms.Button btnFlipSteeling0;
        private System.Windows.Forms.Button btnFlipSteeling1;
        private System.Windows.Forms.Button btnFlipSteeling2;
        private System.Windows.Forms.Button btnFlipSteeling3;
        private System.Windows.Forms.Button btnFlipSteeling4;
        private System.Windows.Forms.Button btnFlipSteeling5;
        private System.Windows.Forms.Button btnFlipSteeling6;
        private System.Windows.Forms.TextBox txtGo4;
        private System.Windows.Forms.TextBox txtGoCold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

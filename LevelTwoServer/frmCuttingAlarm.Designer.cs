namespace IntelligentBilletProduction
{
    partial class frmCuttingAlarm
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
            this.ucAlarmLamp1 = new HZH_Controls.Controls.UCAlarmLamp();
            this.ucbtnYes = new HZH_Controls.Controls.UCBtnExt();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucAlarmLamp1
            // 
            this.ucAlarmLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))))};
            this.ucAlarmLamp1.Lampstand = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ucAlarmLamp1.Location = new System.Drawing.Point(15, 28);
            this.ucAlarmLamp1.Margin = new System.Windows.Forms.Padding(2);
            this.ucAlarmLamp1.Name = "ucAlarmLamp1";
            this.ucAlarmLamp1.Size = new System.Drawing.Size(220, 198);
            this.ucAlarmLamp1.TabIndex = 29;
            this.ucAlarmLamp1.TwinkleSpeed = 200;
            // 
            // ucbtnYes
            // 
            this.ucbtnYes.BackColor = System.Drawing.Color.Transparent;
            this.ucbtnYes.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucbtnYes.BtnFont = new System.Drawing.Font("微软雅黑", 19F, System.Drawing.FontStyle.Bold);
            this.ucbtnYes.BtnForeColor = System.Drawing.Color.White;
            this.ucbtnYes.BtnText = "确  定";
            this.ucbtnYes.ConerRadius = 34;
            this.ucbtnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucbtnYes.EnabledMouseEffect = true;
            this.ucbtnYes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.ucbtnYes.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucbtnYes.ForeColor = System.Drawing.Color.White;
            this.ucbtnYes.IsRadius = true;
            this.ucbtnYes.IsShowRect = false;
            this.ucbtnYes.IsShowTips = false;
            this.ucbtnYes.Location = new System.Drawing.Point(580, 180);
            this.ucbtnYes.Margin = new System.Windows.Forms.Padding(0);
            this.ucbtnYes.Name = "ucbtnYes";
            this.ucbtnYes.RectColor = System.Drawing.Color.Gainsboro;
            this.ucbtnYes.RectWidth = 1;
            this.ucbtnYes.Size = new System.Drawing.Size(147, 69);
            this.ucbtnYes.TabIndex = 30;
            this.ucbtnYes.TabStop = false;
            this.ucbtnYes.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucbtnYes.TipsText = "";
            this.ucbtnYes.BtnClick += new System.EventHandler(this.ucbtnYes_BtnClick);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.Location = new System.Drawing.Point(266, 54);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(633, 64);
            this.lbMessage.TabIndex = 31;
            this.lbMessage.Text = "0流钢坯切割超时，请检查！";
            // 
            // frmCuttingAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 295);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.ucbtnYes);
            this.Controls.Add(this.ucAlarmLamp1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCuttingAlarm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "停止自动出坯";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCAlarmLamp ucAlarmLamp1;
        private HZH_Controls.Controls.UCBtnExt ucbtnYes;
        private System.Windows.Forms.Label lbMessage;
    }
}
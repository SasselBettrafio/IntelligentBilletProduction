namespace IntelligentBilletProduction
{
    partial class frmAddWorkPlan
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
            this.txtheatno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSteeltype = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtaimedlength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdestination = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtthick = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtwidth = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtheatno
            // 
            this.txtheatno.Location = new System.Drawing.Point(125, 30);
            this.txtheatno.Name = "txtheatno";
            this.txtheatno.Size = new System.Drawing.Size(169, 25);
            this.txtheatno.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 25;
            this.label3.Text = "炉次编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(323, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 25;
            this.label1.Text = "钢种：";
            // 
            // txtSteeltype
            // 
            this.txtSteeltype.Location = new System.Drawing.Point(393, 30);
            this.txtSteeltype.Name = "txtSteeltype";
            this.txtSteeltype.Size = new System.Drawing.Size(169, 25);
            this.txtSteeltype.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(591, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 25;
            this.label2.Text = "定尺长度：";
            // 
            // txtaimedlength
            // 
            this.txtaimedlength.Location = new System.Drawing.Point(701, 30);
            this.txtaimedlength.Name = "txtaimedlength";
            this.txtaimedlength.Size = new System.Drawing.Size(169, 25);
            this.txtaimedlength.TabIndex = 26;
            this.txtaimedlength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaimedlength_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(55, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 25;
            this.label4.Text = "直径：";
            // 
            // txtdestination
            // 
            this.txtdestination.Location = new System.Drawing.Point(125, 94);
            this.txtdestination.Name = "txtdestination";
            this.txtdestination.Size = new System.Drawing.Size(169, 25);
            this.txtdestination.TabIndex = 26;
            this.txtdestination.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdestination_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(323, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 27);
            this.label5.TabIndex = 25;
            this.label5.Text = "厚度：";
            // 
            // txtthick
            // 
            this.txtthick.Location = new System.Drawing.Point(393, 94);
            this.txtthick.Name = "txtthick";
            this.txtthick.Size = new System.Drawing.Size(169, 25);
            this.txtthick.TabIndex = 26;
            this.txtthick.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtthick_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(631, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 25;
            this.label6.Text = "宽度：";
            // 
            // txtwidth
            // 
            this.txtwidth.Location = new System.Drawing.Point(701, 92);
            this.txtwidth.Name = "txtwidth";
            this.txtwidth.Size = new System.Drawing.Size(169, 25);
            this.txtwidth.TabIndex = 26;
            this.txtwidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtwidth_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(499, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 43);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(302, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 43);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddWorkPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 206);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtaimedlength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtwidth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtthick);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdestination);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSteeltype);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtheatno);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddWorkPlan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加生产计划";
            this.Load += new System.EventHandler(this.frmAddWorkPlan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtheatno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSteeltype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtaimedlength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdestination;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtthick;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtwidth;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}
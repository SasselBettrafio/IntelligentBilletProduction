namespace IntelligentBilletProduction
{
    partial class frmCurrentSteelGrade
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.AddProductionPlan = new System.Windows.Forms.Button();
            this.gcOrderTable = new System.Windows.Forms.DataGridView();
            this.heatno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.steeltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aimedlength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.furnacestatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOrders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnfg0 = new System.Windows.Forms.Button();
            this.btnfg1 = new System.Windows.Forms.Button();
            this.btnfg2 = new System.Windows.Forms.Button();
            this.btnfg3 = new System.Windows.Forms.Button();
            this.btnfg4 = new System.Windows.Forms.Button();
            this.btnfg5 = new System.Windows.Forms.Button();
            this.btnfg6 = new System.Windows.Forms.Button();
            this.btntg0 = new System.Windows.Forms.Button();
            this.btntg1 = new System.Windows.Forms.Button();
            this.btntg2 = new System.Windows.Forms.Button();
            this.btntg3 = new System.Windows.Forms.Button();
            this.btntg4 = new System.Windows.Forms.Button();
            this.btntg5 = new System.Windows.Forms.Button();
            this.btntg6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrderTable)).BeginInit();
            this.cmsOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(526, 580);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddProductionPlan
            // 
            this.AddProductionPlan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddProductionPlan.Location = new System.Drawing.Point(251, 580);
            this.AddProductionPlan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddProductionPlan.Name = "AddProductionPlan";
            this.AddProductionPlan.Size = new System.Drawing.Size(119, 38);
            this.AddProductionPlan.TabIndex = 3;
            this.AddProductionPlan.Text = "添加生产计划";
            this.AddProductionPlan.UseVisualStyleBackColor = true;
            this.AddProductionPlan.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gcOrderTable
            // 
            this.gcOrderTable.AllowUserToAddRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gcOrderTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gcOrderTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gcOrderTable.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gcOrderTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gcOrderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcOrderTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.heatno,
            this.steeltype,
            this.aimedlength,
            this.destination,
            this.thick,
            this.width,
            this.furnacestatus,
            this.recordtime});
            this.gcOrderTable.ContextMenuStrip = this.cmsOrders;
            this.gcOrderTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcOrderTable.Location = new System.Drawing.Point(0, 0);
            this.gcOrderTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcOrderTable.Name = "gcOrderTable";
            this.gcOrderTable.ReadOnly = true;
            this.gcOrderTable.RowHeadersVisible = false;
            this.gcOrderTable.RowHeadersWidth = 51;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微软雅黑 Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcOrderTable.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.gcOrderTable.RowTemplate.Height = 27;
            this.gcOrderTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gcOrderTable.Size = new System.Drawing.Size(933, 286);
            this.gcOrderTable.TabIndex = 28;
            // 
            // heatno
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.heatno.DefaultCellStyle = dataGridViewCellStyle11;
            this.heatno.FillWeight = 110F;
            this.heatno.HeaderText = "炉号";
            this.heatno.MinimumWidth = 6;
            this.heatno.Name = "heatno";
            this.heatno.ReadOnly = true;
            this.heatno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // steeltype
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.steeltype.DefaultCellStyle = dataGridViewCellStyle12;
            this.steeltype.HeaderText = "钢种";
            this.steeltype.MinimumWidth = 6;
            this.steeltype.Name = "steeltype";
            this.steeltype.ReadOnly = true;
            // 
            // aimedlength
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.aimedlength.DefaultCellStyle = dataGridViewCellStyle13;
            this.aimedlength.HeaderText = "定尺长度";
            this.aimedlength.MinimumWidth = 6;
            this.aimedlength.Name = "aimedlength";
            this.aimedlength.ReadOnly = true;
            // 
            // destination
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.destination.DefaultCellStyle = dataGridViewCellStyle14;
            this.destination.FillWeight = 90F;
            this.destination.HeaderText = "直径";
            this.destination.MinimumWidth = 6;
            this.destination.Name = "destination";
            this.destination.ReadOnly = true;
            // 
            // thick
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.thick.DefaultCellStyle = dataGridViewCellStyle15;
            this.thick.FillWeight = 90F;
            this.thick.HeaderText = "厚度";
            this.thick.MinimumWidth = 6;
            this.thick.Name = "thick";
            this.thick.ReadOnly = true;
            // 
            // width
            // 
            this.width.FillWeight = 90F;
            this.width.HeaderText = "宽度";
            this.width.MinimumWidth = 6;
            this.width.Name = "width";
            this.width.ReadOnly = true;
            // 
            // furnacestatus
            // 
            this.furnacestatus.FillWeight = 90F;
            this.furnacestatus.HeaderText = "浇注状态";
            this.furnacestatus.MinimumWidth = 6;
            this.furnacestatus.Name = "furnacestatus";
            this.furnacestatus.ReadOnly = true;
            // 
            // recordtime
            // 
            this.recordtime.FillWeight = 110F;
            this.recordtime.HeaderText = "计划时间";
            this.recordtime.MinimumWidth = 6;
            this.recordtime.Name = "recordtime";
            this.recordtime.ReadOnly = true;
            // 
            // cmsOrders
            // 
            this.cmsOrders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改计划ToolStripMenuItem,
            this.删除计划ToolStripMenuItem});
            this.cmsOrders.Name = "cmsOrders";
            this.cmsOrders.Size = new System.Drawing.Size(138, 52);
            // 
            // 修改计划ToolStripMenuItem
            // 
            this.修改计划ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.修改计划ToolStripMenuItem.Name = "修改计划ToolStripMenuItem";
            this.修改计划ToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.修改计划ToolStripMenuItem.Text = "修改计划";
            this.修改计划ToolStripMenuItem.Click += new System.EventHandler(this.修改计划ToolStripMenuItem_Click);
            // 
            // 删除计划ToolStripMenuItem
            // 
            this.删除计划ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.删除计划ToolStripMenuItem.Name = "删除计划ToolStripMenuItem";
            this.删除计划ToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.删除计划ToolStripMenuItem.Text = "删除计划";
            this.删除计划ToolStripMenuItem.Click += new System.EventHandler(this.删除计划ToolStripMenuItem_Click);
            // 
            // btnfg0
            // 
            this.btnfg0.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfg0.Location = new System.Drawing.Point(31, 291);
            this.btnfg0.Name = "btnfg0";
            this.btnfg0.Size = new System.Drawing.Size(128, 32);
            this.btnfg0.TabIndex = 29;
            this.btnfg0.Text = "0流翻钢";
            this.btnfg0.UseVisualStyleBackColor = true;
            this.btnfg0.Click += new System.EventHandler(this.btnfg0_Click);
            // 
            // btnfg1
            // 
            this.btnfg1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfg1.Location = new System.Drawing.Point(31, 329);
            this.btnfg1.Name = "btnfg1";
            this.btnfg1.Size = new System.Drawing.Size(128, 32);
            this.btnfg1.TabIndex = 29;
            this.btnfg1.Text = "1流翻钢";
            this.btnfg1.UseVisualStyleBackColor = true;
            // 
            // btnfg2
            // 
            this.btnfg2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfg2.Location = new System.Drawing.Point(31, 367);
            this.btnfg2.Name = "btnfg2";
            this.btnfg2.Size = new System.Drawing.Size(128, 32);
            this.btnfg2.TabIndex = 29;
            this.btnfg2.Text = "2流翻钢";
            this.btnfg2.UseVisualStyleBackColor = true;
            // 
            // btnfg3
            // 
            this.btnfg3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfg3.Location = new System.Drawing.Point(31, 405);
            this.btnfg3.Name = "btnfg3";
            this.btnfg3.Size = new System.Drawing.Size(128, 32);
            this.btnfg3.TabIndex = 29;
            this.btnfg3.Text = "3流翻钢";
            this.btnfg3.UseVisualStyleBackColor = true;
            // 
            // btnfg4
            // 
            this.btnfg4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfg4.Location = new System.Drawing.Point(31, 443);
            this.btnfg4.Name = "btnfg4";
            this.btnfg4.Size = new System.Drawing.Size(128, 32);
            this.btnfg4.TabIndex = 29;
            this.btnfg4.Text = "4流翻钢";
            this.btnfg4.UseVisualStyleBackColor = true;
            // 
            // btnfg5
            // 
            this.btnfg5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfg5.Location = new System.Drawing.Point(31, 481);
            this.btnfg5.Name = "btnfg5";
            this.btnfg5.Size = new System.Drawing.Size(128, 32);
            this.btnfg5.TabIndex = 29;
            this.btnfg5.Text = "5流翻钢";
            this.btnfg5.UseVisualStyleBackColor = true;
            // 
            // btnfg6
            // 
            this.btnfg6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfg6.Location = new System.Drawing.Point(31, 519);
            this.btnfg6.Name = "btnfg6";
            this.btnfg6.Size = new System.Drawing.Size(128, 32);
            this.btnfg6.TabIndex = 29;
            this.btnfg6.Text = "6流翻钢";
            this.btnfg6.UseVisualStyleBackColor = true;
            // 
            // btntg0
            // 
            this.btntg0.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntg0.Location = new System.Drawing.Point(165, 291);
            this.btntg0.Name = "btntg0";
            this.btntg0.Size = new System.Drawing.Size(128, 32);
            this.btntg0.TabIndex = 29;
            this.btntg0.Text = "0流提钢";
            this.btntg0.UseVisualStyleBackColor = true;
            // 
            // btntg1
            // 
            this.btntg1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntg1.Location = new System.Drawing.Point(165, 329);
            this.btntg1.Name = "btntg1";
            this.btntg1.Size = new System.Drawing.Size(128, 32);
            this.btntg1.TabIndex = 29;
            this.btntg1.Text = "1流提钢";
            this.btntg1.UseVisualStyleBackColor = true;
            // 
            // btntg2
            // 
            this.btntg2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntg2.Location = new System.Drawing.Point(165, 367);
            this.btntg2.Name = "btntg2";
            this.btntg2.Size = new System.Drawing.Size(128, 32);
            this.btntg2.TabIndex = 29;
            this.btntg2.Text = "2流提钢";
            this.btntg2.UseVisualStyleBackColor = true;
            // 
            // btntg3
            // 
            this.btntg3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntg3.Location = new System.Drawing.Point(165, 405);
            this.btntg3.Name = "btntg3";
            this.btntg3.Size = new System.Drawing.Size(128, 32);
            this.btntg3.TabIndex = 29;
            this.btntg3.Text = "3流提钢";
            this.btntg3.UseVisualStyleBackColor = true;
            // 
            // btntg4
            // 
            this.btntg4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntg4.Location = new System.Drawing.Point(165, 443);
            this.btntg4.Name = "btntg4";
            this.btntg4.Size = new System.Drawing.Size(128, 32);
            this.btntg4.TabIndex = 29;
            this.btntg4.Text = "4流提钢";
            this.btntg4.UseVisualStyleBackColor = true;
            // 
            // btntg5
            // 
            this.btntg5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntg5.Location = new System.Drawing.Point(165, 481);
            this.btntg5.Name = "btntg5";
            this.btntg5.Size = new System.Drawing.Size(128, 32);
            this.btntg5.TabIndex = 29;
            this.btntg5.Text = "5流提钢";
            this.btntg5.UseVisualStyleBackColor = true;
            // 
            // btntg6
            // 
            this.btntg6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btntg6.Location = new System.Drawing.Point(165, 519);
            this.btntg6.Name = "btntg6";
            this.btntg6.Size = new System.Drawing.Size(128, 32);
            this.btntg6.TabIndex = 29;
            this.btntg6.Text = "6流提钢";
            this.btntg6.UseVisualStyleBackColor = true;
            // 
            // frmCurrentSteelGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 626);
            this.Controls.Add(this.btntg6);
            this.Controls.Add(this.btntg5);
            this.Controls.Add(this.btnfg6);
            this.Controls.Add(this.btntg4);
            this.Controls.Add(this.btnfg5);
            this.Controls.Add(this.btntg3);
            this.Controls.Add(this.btnfg4);
            this.Controls.Add(this.btntg2);
            this.Controls.Add(this.btnfg3);
            this.Controls.Add(this.btntg1);
            this.Controls.Add(this.btnfg2);
            this.Controls.Add(this.btntg0);
            this.Controls.Add(this.btnfg1);
            this.Controls.Add(this.btnfg0);
            this.Controls.Add(this.gcOrderTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.AddProductionPlan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCurrentSteelGrade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产计划";
            this.Load += new System.EventHandler(this.frmCurrentSteelGrade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcOrderTable)).EndInit();
            this.cmsOrders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button AddProductionPlan;
        private System.Windows.Forms.DataGridView gcOrderTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn heatno;
        private System.Windows.Forms.DataGridViewTextBoxColumn steeltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn aimedlength;
        private System.Windows.Forms.DataGridViewTextBoxColumn destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn thick;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn furnacestatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordtime;
        private System.Windows.Forms.ContextMenuStrip cmsOrders;
        private System.Windows.Forms.ToolStripMenuItem 修改计划ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除计划ToolStripMenuItem;
        private System.Windows.Forms.Button btnfg0;
        private System.Windows.Forms.Button btnfg1;
        private System.Windows.Forms.Button btnfg2;
        private System.Windows.Forms.Button btnfg3;
        private System.Windows.Forms.Button btnfg4;
        private System.Windows.Forms.Button btnfg5;
        private System.Windows.Forms.Button btnfg6;
        private System.Windows.Forms.Button btntg0;
        private System.Windows.Forms.Button btntg1;
        private System.Windows.Forms.Button btntg2;
        private System.Windows.Forms.Button btntg3;
        private System.Windows.Forms.Button btntg4;
        private System.Windows.Forms.Button btntg5;
        private System.Windows.Forms.Button btntg6;
    }
}
namespace FileMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Started = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.originPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backupPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathItemBindingSource1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(348, 391);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "开机自动运行";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "游戏存档监视器";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Started,
            this.originPathDataGridViewTextBoxColumn,
            this.backupPathDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pathItemBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(494, 385);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // Started
            // 
            this.Started.DataPropertyName = "Started";
            this.Started.FalseValue = "false";
            this.Started.FillWeight = 50F;
            this.Started.HeaderText = "已监控";
            this.Started.Name = "Started";
            this.Started.ReadOnly = true;
            this.Started.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Started.TrueValue = "true";
            this.Started.Width = 50;
            // 
            // originPathDataGridViewTextBoxColumn
            // 
            this.originPathDataGridViewTextBoxColumn.DataPropertyName = "OriginPath";
            this.originPathDataGridViewTextBoxColumn.FillWeight = 220F;
            this.originPathDataGridViewTextBoxColumn.HeaderText = "原路径";
            this.originPathDataGridViewTextBoxColumn.Name = "originPathDataGridViewTextBoxColumn";
            this.originPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.originPathDataGridViewTextBoxColumn.Width = 220;
            // 
            // backupPathDataGridViewTextBoxColumn
            // 
            this.backupPathDataGridViewTextBoxColumn.DataPropertyName = "BackupPath";
            this.backupPathDataGridViewTextBoxColumn.FillWeight = 220F;
            this.backupPathDataGridViewTextBoxColumn.HeaderText = "备份路径";
            this.backupPathDataGridViewTextBoxColumn.Name = "backupPathDataGridViewTextBoxColumn";
            this.backupPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.backupPathDataGridViewTextBoxColumn.Width = 220;
            // 
            // pathItemBindingSource1
            // 
            this.pathItemBindingSource1.DataSource = typeof(FileMonitor.PathItem);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteItem.Text = "删除该项";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(180, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 410);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "游戏存档监视器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathItemBindingSource1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteItem;
        private System.Windows.Forms.BindingSource pathItemBindingSource1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Started;
        private System.Windows.Forms.DataGridViewTextBoxColumn originPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backupPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Exit;
    }
}


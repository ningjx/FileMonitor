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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pathItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.originPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backupPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "源文件目录";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(312, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "备份文件目录";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(36, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "开机自动运行";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.originPathDataGridViewTextBoxColumn,
            this.backupPathDataGridViewTextBoxColumn,
            this.deleteDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pathItemBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(438, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // pathItemBindingSource
            // 
            this.pathItemBindingSource.DataSource = typeof(FileMonitor.PathItem);
            // 
            // originPathDataGridViewTextBoxColumn
            // 
            this.originPathDataGridViewTextBoxColumn.DataPropertyName = "OriginPath";
            this.originPathDataGridViewTextBoxColumn.FillWeight = 200F;
            this.originPathDataGridViewTextBoxColumn.HeaderText = "原路径";
            this.originPathDataGridViewTextBoxColumn.Name = "originPathDataGridViewTextBoxColumn";
            this.originPathDataGridViewTextBoxColumn.Width = 200;
            // 
            // backupPathDataGridViewTextBoxColumn
            // 
            this.backupPathDataGridViewTextBoxColumn.DataPropertyName = "BackupPath";
            this.backupPathDataGridViewTextBoxColumn.FillWeight = 200F;
            this.backupPathDataGridViewTextBoxColumn.HeaderText = "备份路径";
            this.backupPathDataGridViewTextBoxColumn.Name = "backupPathDataGridViewTextBoxColumn";
            this.backupPathDataGridViewTextBoxColumn.Width = 200;
            // 
            // deleteDataGridViewTextBoxColumn
            // 
            this.deleteDataGridViewTextBoxColumn.DataPropertyName = "Delete";
            this.deleteDataGridViewTextBoxColumn.FillWeight = 30F;
            this.deleteDataGridViewTextBoxColumn.HeaderText = "";
            this.deleteDataGridViewTextBoxColumn.Name = "deleteDataGridViewTextBoxColumn";
            this.deleteDataGridViewTextBoxColumn.Width = 30;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 410);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "游戏存档监视器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource pathItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn originPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backupPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteDataGridViewTextBoxColumn;
    }
}


﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileMonitor
{
    public partial class MainForm : Form
    {
        private readonly Regex PathRegex = new Regex(@"^[A-Z]:\\(.+?\\)*.*$");
        public MainForm()
        {
            InitializeComponent();
            Program.FormsContainer.Add(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Icon = notifyIcon1.Icon = Resource.icon;

            if (MainProcess.Config.WindowPos.ContainsKey(Name))
            {
                Top = MainProcess.Config.WindowPos[Name].Top;
                Left = MainProcess.Config.WindowPos[Name].Left;
                Height = MainProcess.Config.WindowPos[Name].Height;
                Width = MainProcess.Config.WindowPos[Name].Width;
            }

            checkBox1.Checked = MainProcess.Config.AutoRun;
            if (MainProcess.Config.AutoRun)
            {
                WindowState = FormWindowState.Minimized;
                notifyIcon1.ShowBalloonTip(5000, "存档监控", "已经在监控游戏存档了", ToolTipIcon.Info);
            }

            dataGridView1.DataSource = MainProcess.Config.FilePaths;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{
            //    string StartupPath = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartup);
            //    //获得文件的当前路径
            //    string dir = Directory.GetCurrentDirectory();
            //    //获取可执行文件的全部路径
            //    //string exeDir = dir + @"\FileMonitor.exe.lnk";
            //    string exeDir = dir + @"\FileMonitor.exe.lnk";
            //    File.Copy(exeDir, StartupPath + @"\FileMonitor.exe.lnk", true);
            //}
            //else
            //{
            //    string StartupPath = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartup);
            //    File.Delete(StartupPath + @"\FileMonitor.exe.lnk");
            //}
            MainProcess.Config.AutoRun = checkBox1.Checked;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                //notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                //notifyIcon1.Visible = false;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//显示右键菜单
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex != 0)
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "DeleteItem" && dataGridView1.SelectedRows.Count > 0)
            {
                var selectIndex = dataGridView1.SelectedRows[0].Index;
                MainProcess.Config.FilePaths.RemoveAt(selectIndex);
                RefreshGridView();
            }
        }

        private void RefreshGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MainProcess.Config.FilePaths;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var item = MainProcess.Config.FilePaths[e.RowIndex];

                if (item.Started)
                    item.Started = false;
                else
                {
                    if (PathRegex.IsMatch(item.OriginPath ?? "") && PathRegex.IsMatch(item.BackupPath ?? ""))
                        item.Started = true;
                    else
                    {
                        MessageBox.Show("请选择正确的原路径和备份路径");
                        return;
                    }
                }
                RefreshGridView();
            }

            //刷新监控
            MainProcess.InitWatchers();
        }
    }
}

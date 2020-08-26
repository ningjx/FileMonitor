using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMonitor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Icon = notifyIcon1.Icon = Resource.icon;
            try
            {
                string s = File.ReadAllText("position.ini");
                int[] position = s.Split(',').Select(x => int.Parse(x)).ToArray();
                Top = position[0];
                Left = position[1];
                Height = position[2];
                Width = position[3];
            }
            catch { }

            checkBox1.Checked = MainProcess.Config.AutoRun;
            textBox1.Text = MainProcess.Config?.FilePaths?.FirstOrDefault().Key ?? "源文件夹";
            textBox2.Text = MainProcess.Config?.FilePaths?.FirstOrDefault().Value ?? "备份文件夹";
            if (MainProcess.Config.AutoRun)
            {
                MainProcess.InitWatchers();
                WindowState = FormWindowState.Minimized;
                notifyIcon1.ShowBalloonTip(5000,"存档监控","已经在监控游戏存档了",ToolTipIcon.Info);
            }

            if (MainProcess.Run)
            {
                button1.Text = "停下";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "选择游戏存档所在的文件夹";
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            ChangePathConfig();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "选择备份到指定文件夹";
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
            ChangePathConfig();
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
            MainProcess.SaveConfig();
        }

        private void ChangePathConfig()
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                if (MainProcess.Config.FilePaths.ContainsKey(textBox1.Text))
                    MainProcess.Config.FilePaths[textBox1.Text] = textBox2.Text;
                else
                    MainProcess.Config.FilePaths.Add(textBox1.Text, textBox2.Text);
            }
            MainProcess.SaveConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainProcess.Run)
            {
                MainProcess.Stop();
                button1.Text = "走你";
            }
            else
            {
                MainProcess.InitWatchers();
                button1.Text = "停下";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string position = string.Format("{0},{1},{2},{3}", Top, Left, Height, Width);
            System.IO.File.WriteAllText("position.ini", position);
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
    }
}

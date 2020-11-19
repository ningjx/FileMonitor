using System;
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
            textBox1.Text = MainProcess.Config.FilePaths.FirstOrDefault()?.OriginPath ?? "源文件夹";
            textBox2.Text = MainProcess.Config.FilePaths.FirstOrDefault()?.BackupPath ?? "备份文件夹";
            if (MainProcess.Config.AutoRun)
            {
                MainProcess.InitWatchers();
                WindowState = FormWindowState.Minimized;
                notifyIcon1.ShowBalloonTip(5000, "存档监控", "已经在监控游戏存档了", ToolTipIcon.Info);
            }

            MainProcess.Config.FilePaths.Add(new PathItem());
            MainProcess.Config.FilePaths.Add(new PathItem());

            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.DataSource = MainProcess.Config.FilePaths;

            if (MainProcess.Run)
            {
                button1.Text = "停下";
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "选择游戏存档所在的文件夹";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            ChangePathConfig();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "选择备份到指定文件夹";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
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
        }

        private void ChangePathConfig()
        {
            if (PathRegex.IsMatch(textBox1.Text) && PathRegex.IsMatch(textBox2.Text))
            {
                if (MainProcess.Config.FilePaths.Exists(t => t.OriginPath == textBox1.Text))
                    MainProcess.Config.FilePaths.First(t => t.OriginPath == textBox1.Text).BackupPath = textBox2.Text;
                else
                    MainProcess.Config.FilePaths.Add(new PathItem { OriginPath = textBox1.Text, BackupPath = textBox2.Text });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainProcess.Run)
            {
                MainProcess.Stop();
            }
            else
            {
                MainProcess.InitWatchers();
            }
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                //dataGridView1[e.ColumnIndex, e.RowIndex].Value = folderBrowserDialog1.SelectedPath;
        }
    }
}

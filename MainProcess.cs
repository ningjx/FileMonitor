using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FileMonitor
{
    public static class MainProcess
    {
        public static Config Config = new Config();
        public static bool Run = false;

        private static List<FileSystemWatcher> Watchers = new List<FileSystemWatcher>();
        static MainProcess()
        {
            var configStr = FileHelper.Read(Config.ConfigPath);
            if (!string.IsNullOrEmpty(configStr))
                Config = JsonConvert.DeserializeObject<Config>(configStr);
        }

        public static void SaveConfig()
        {
            FileHelper.Write(Config.ConfigPath, JsonConvert.SerializeObject(Config));
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitWatchers()
        {
            Watchers.ForEach(t => t.Dispose());
            //为设置的路径初始化监视器
            if (Config?.FilePaths?.Count != 0)
            {
                foreach (var item in Config.FilePaths)
                {
                    FileSystemWatcher watcher;
                    try
                    {
                        watcher = new FileSystemWatcher(item.Key);
                        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size;
                        watcher.Filter = "*";
                        watcher.Changed += Watcher_Changed;
                        watcher.Renamed += Watcher_Changed;
                        Watchers.Add(watcher);
                        watcher.EnableRaisingEvents = true;
                    }
                    catch (Exception ex)
                    {
                        new string[] { "Log.json" }.Write_Append(JsonConvert.SerializeObject(ex));
                    }
                }
            }
            Run = true;
        }

        public static void Stop()
        {
            Watchers.ForEach(t => t.Dispose());
            Run = false;
        }

        /// <summary>
        /// 当文件夹修改时，读取所有文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                Thread.Sleep(100);
                var originDic = e.FullPath.Replace($@"\{e.Name}", "");
                string targetDicPath = Config.FilePaths[originDic];//目标备份文件夹

                DirectoryInfo originRoot = new DirectoryInfo(originDic);
                FileInfo[] originFiles = originRoot.GetFiles();

                DirectoryInfo targetRoot = new DirectoryInfo(targetDicPath);
                var targetFileNames = targetRoot.GetFiles().Select(t => t.Name);

                var needBackup = originFiles;//.Where(t => !targetFileNames.Contains(t.Name));
                foreach (var file in needBackup)
                {
                    file.CopyTo(targetDicPath + $@"\【{DateTime.Now:yyyyMMddhhmmss}】{file.Name}", true);
                }
            }
            catch (Exception ex)
            {
                new string[] { "Log.json" }.Write_Append(JsonConvert.SerializeObject(ex));
            }
        }
    }
}

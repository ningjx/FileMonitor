using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FileMonitor
{
    public static class MainProcess
    {
        public static Regex PathRegex = new Regex(@"^[A-Z]:\\(.+?\\)*.*$");

        public static Config Config = new Config();

        private static List<FileSystemWatcher> Watchers = new List<FileSystemWatcher>();

        static MainProcess()
        {
            var configStr = FileHelper.Read(Config.ConfigPath);
            try
            {
                if (!string.IsNullOrEmpty(configStr))
                    Config = JsonConvert.DeserializeObject<Config>(configStr);
            }
            catch { }
        }

        public static void SaveConfig(List<Form> forms)
        {
            foreach (var form in forms)
            {
                Config.WindowPos[form.Name] = new Pos(form.Top, form.Left, form.Height, form.Width);
            }
            FileHelper.Write(Config.ConfigPath, JsonConvert.SerializeObject(Config));
        }

        public static void InitWatchers()
        {
            Watchers.ForEach(t => t.Dispose());
            Watchers = new List<FileSystemWatcher>();
            //为设置的路径初始化监视器
            if (Config?.FilePaths?.Count != 0)
            {
                foreach (var item in Config.FilePaths)
                {
                    if (item.OriginPath == null || item.BackupPath == null)
                        continue;
                    if (item.Started && PathRegex.IsMatch(item.OriginPath) && PathRegex.IsMatch(item.BackupPath))
                    {
                        FileSystemWatcher watcher;
                        try
                        {
                            watcher = new FileSystemWatcher(item.OriginPath)
                            {
                                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size,
                                Filter = "*"
                            };
                            watcher.Created += Watcher_Changed;
                            watcher.Changed += Watcher_Changed;
                            watcher.Renamed += Watcher_Changed;

                            Watchers.Add(watcher);
                            watcher.EnableRaisingEvents = true;
                        }
                        catch (Exception ex)
                        {
                            new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileMonitor", "Log.json" }.Write_Append(JsonConvert.SerializeObject(ex));
                            item.Started = false;
                        }
                    }
                    else
                    {
                        item.Started = false;
                    }
                }
            }
        }

        public static void Dispose(int index)
        {
            Watchers.FirstOrDefault(t => t.Path == Config.FilePaths[index].OriginPath)?.Dispose();
            Watchers.RemoveAll(t => t.Path == Config.FilePaths[index].OriginPath);
            Config.FilePaths[index].Started = false;
        }

        public static void InitWatcher(int index)
        {
            var item = Config.FilePaths[index];
            if (item.OriginPath == null || item.BackupPath == null)
                return;
            if (PathRegex.IsMatch(item.OriginPath) && PathRegex.IsMatch(item.BackupPath))
            {
                FileSystemWatcher watcher;
                try
                {
                    watcher = new FileSystemWatcher(item.OriginPath)
                    {
                        NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size,
                        Filter = "*"
                    };
                    watcher.Created += Watcher_Changed;
                    watcher.Changed += Watcher_Changed;
                    watcher.Renamed += Watcher_Changed;

                    Watchers.Add(watcher);
                    watcher.EnableRaisingEvents = true;
                    item.Started = true;
                }
                catch (Exception ex)
                {
                    new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileMonitor", "Log.json" }.Write_Append(JsonConvert.SerializeObject(ex));
                    item.Started = false;
                }
            }
            else
            {
                item.Started = false;
            }
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                Thread.Sleep(0);
                var originDic = e.FullPath.Replace($@"\{e.Name}", "");
                string targetDicPath = Config.FilePaths.First(t => t.OriginPath == originDic).BackupPath;//目标备份文件夹
                #region 备份目录下全部文件
                //DirectoryInfo originRoot = new DirectoryInfo(originDic);
                //FileInfo[] originFiles = originRoot.GetFiles();

                //DirectoryInfo targetRoot = new DirectoryInfo(targetDicPath);
                //var targetFileNames = targetRoot.GetFiles().Select(t => t.Name);

                //var needBackup = originFiles;//.Where(t => !targetFileNames.Contains(t.Name));
                //foreach (var file in needBackup)
                //{
                //    var backupFilePath = targetDicPath.TrimEnd('\\') + $@"\[{DateTime.Now:yyyy年MM月dd日 hh时mm分ss秒}]{file.Name}";
                //    file.CopyTo(backupFilePath, true);
                //}
                #endregion
                var file = new FileInfo(e.FullPath);
                var backupFilePath = targetDicPath.TrimEnd('\\') + $@"\[{DateTime.Now:yyyy年MM月dd日 hh时mm分ss秒}]{file.Name}";
                file.CopyTo(backupFilePath, true);
            }
            catch (Exception ex)
            {
                new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileMonitor", "Log.json" }.Write_Append(JsonConvert.SerializeObject(ex));
            }
        }
    }
}

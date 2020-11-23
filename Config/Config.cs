using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileMonitor
{
    public class Config
    {
        /// <summary>
        /// 窗体位置
        /// </summary>
        [JsonProperty("窗体位置")]
        public WindowPosition WindowPos { get; set; } = new WindowPosition();

        /// <summary>
        /// 刷新频率（秒）
        /// </summary>
        [JsonProperty("刷新频率（秒）")]
        public int Freq = 30;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        [JsonProperty("配置文件路径（不可修改）")]
        public string[] ConfigPath = new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileMonitor", "Config.json" };

        /// <summary>
        /// 文件路径和对应的备份文件夹路径
        /// </summary>
        [JsonProperty("监视文件路径和对应的备份文件夹路径")]
        public List<PathItem> FilePaths
        {
            get
            {
                if (_Items.Count(t => t.OriginPath + t.BackupPath == string.Empty) > 1)
                    _Items.RemoveAll(t => t.OriginPath + t.BackupPath == string.Empty);

                if (!_Items.Exists(t => t.OriginPath + t.BackupPath == string.Empty))
                    _Items.Add(new PathItem());

                return _Items;
            }
            set
            {
                if (!value.Exists(t => t.OriginPath + t.BackupPath == string.Empty))
                    value.Add(new PathItem());
                _Items = value;
            }
        }

        /// <summary>
        /// 开机自动运行
        /// </summary>
        [JsonProperty("开机自动运行")]
        public bool AutoRun = false;

        [JsonIgnore]
        private List<PathItem> _Items = new List<PathItem>();
    }

    public class WindowPosition : Dictionary<string, Pos>
    {
        public new Pos this[string index]
        {
            get
            {
                TryGetValue(index, out Pos pos);
                return pos;
            }
            set
            {
                if (ContainsKey(index))
                    base[index] = value;
                else
                    Add(index, value);
            }
        }
    }

    public class Pos
    {
        public Pos(int top, int left, int height, int width)
        {
            Top = top; Left = left; Height = height; Width = width;
        }

        public int Top;
        public int Left;
        public int Height;
        public int Width;
    }

    public class PathItem
    {
        public string OriginPath { get; set; }
        public string BackupPath { get; set; }
        public bool Started { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileMonitor
{
    public class Config
    {
        /// <summary>
        /// 刷新频率（秒）
        /// </summary>
        [JsonProperty("刷新频率（秒）")]
        public int Freq = 30;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        [JsonProperty("配置文件路径（不可修改）")]
        public string[] ConfigPath = new string[] { "Config.json" };

        /// <summary>
        /// 文件路径和对应的备份文件夹路径
        /// </summary>
        [JsonProperty("监视文件路径和对应的备份文件夹路径")]
        public Dictionary<string, string> FilePaths = new Dictionary<string, string>();

        /// <summary>
        /// 开机自动运行
        /// </summary>
        [JsonProperty("开机自动运行")]
        public bool AutoRun = false;
    }
}

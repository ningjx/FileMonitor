using System.IO;
using System.Text;

namespace FileMonitor
{
    public static class FileHelper
    {
        /// <summary>
        /// 覆写
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void Write(this string[] path, string data)
        {
            string pathStr = Path.Combine(path);
            string dicPath = string.Empty;
            if (path.Length > 1)
                dicPath = Path.Combine(path.GetByCount(0, path.Length - 1));
            if (!string.IsNullOrEmpty(dicPath) && !Directory.Exists(dicPath))
                Directory.CreateDirectory(dicPath);
            using (FileStream fileStream = new FileStream(pathStr, FileMode.Create))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fileStream.Write(bytes, 0, bytes.Length);
            };
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Read(this string[] path)
        {
            string pathStr = Path.Combine(path);
            if (!File.Exists(pathStr))
                return string.Empty;
            using (FileStream fileStream = new FileStream(pathStr, FileMode.Open))
            {
                int length = (int)fileStream.Length;
                byte[] bytes = new byte[length];
                fileStream.Read(bytes, 0, bytes.Length);
                return Encoding.UTF8.GetString(bytes);
            };
        }

        public static byte[] ReadStream(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                int length = (int)fileStream.Length;
                byte[] bytes = new byte[length];
                fileStream.Read(bytes, 0, bytes.Length);
                return bytes;
            };
        }

        /// <summary>
        /// 续写
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void Write_Append(this string[] path, string data)
        {
            string pathStr = Path.Combine(path);
            string dicPath = string.Empty;
            if (path.Length > 1)
                dicPath = Path.Combine(path.GetByCount(0, path.Length - 1));
            if (!string.IsNullOrEmpty(dicPath) && !Directory.Exists(dicPath))
                Directory.CreateDirectory(dicPath);
            using (FileStream fileStream = new FileStream(pathStr, FileMode.Append))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fileStream.Write(bytes, 0, bytes.Length);
            };
        }

        /// <summary>
        /// 获取字符串数组的指定数量的子集
        /// </summary>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static string[] GetByCount(this string[] data, int offset, int count)
        {
            string[] result = new string[count - offset];
            for (int i = offset; i < count; i++)
            {
                result[i - offset] = data[i];
            }
            return result;
        }
    }
}

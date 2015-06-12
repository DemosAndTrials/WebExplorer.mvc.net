using System;
using System.IO;

namespace WebExplorer.Helpers
{
    public static class Utils
    {
        /// <summary>
        /// Get file size
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileSize(string filePath)
        {
            try
            {
                FileInfo f = new FileInfo(filePath);
                return BytesToString(f.Length);
            }
            catch (Exception)
            {
            }
            // file not found
            return "Unknown";
        }

        /// <summary>
        /// Ged readable file size from bytes
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        public static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }
    }
}
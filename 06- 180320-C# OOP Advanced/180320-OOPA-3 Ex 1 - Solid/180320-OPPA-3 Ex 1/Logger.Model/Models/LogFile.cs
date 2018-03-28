using Logger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Model.Models
{
    public class LogFile : ILogFile
    {
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public long Size { get; private set; }

        public LogFile()
        {
            this.filePath = GetFilePath();
            this.Size = 0;
            File.WriteAllText(this.filePath, "");
        }

        private string GetFilePath()
        {
            return string.Format(@"{0}/{1}_log.txt", this.filePath, DateTime.Now.Ticks);
        }

        public void Write(string text)
        {
            UpdateFileSize(text);
            File.AppendAllText(filePath, text + Environment.NewLine);
        }

        private void UpdateFileSize(string text)
        {
            List<string> results = text.Split(new[] { ' ', '\t', '\r', '\n' }).ToList();
            results.Remove(results.First(s => s.Contains('/')));
            results.Remove(results.First(s => s.Contains(':')));

            string result = string.Join("", results);

            this.Size += result.Sum(c => (int)c);
        }
    }
}

using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Domain.Exceptions
{
    public class Logger
    {
        private static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;
        public bool WriteExceptionToLog(string fileName, string ob)
        {
            try
            {
                string fullPath = new StringBuilder(Path).Append(fileName).ToString();
                string logMessage = string.Format("{0} - an exception has been threw in object with parameters: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), ob);
                WriteToLog(fullPath, logMessage);
                return true;
            }
            catch (Exception)
            {
                string fullPath = new StringBuilder(Path).Append(@"\Fatal.txt").ToString();
                string logMessage = string.Format("{0} - can't write to the log file: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), fullPath);
                WriteToLog(fullPath, logMessage);
                return false;
            }
        }

        private void WriteToLog(string path, string message)
        {
            using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
            {
                sw.WriteLine(message);
            } 
        }
    }
}

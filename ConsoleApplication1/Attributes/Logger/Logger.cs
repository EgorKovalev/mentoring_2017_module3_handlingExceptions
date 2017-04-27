using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Attributes.Logger
{
    public class Logger
    {
        private static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;
        private const string FatalFileName = @"\Fatal.txt";

        public bool WriteExceptionToLog(string fileName, string ob, string message = "")
        {
            try
            {
                string fullPath = new StringBuilder(Path).Append(fileName).ToString();
                string logMessage = string.Format("{0} - an exception has been threw in object with parameters: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), ob);

                if (!message.Equals(""))
                {
                    logMessage = message;
                }
                
                WriteToLog(fullPath, logMessage);
                return true;
            }
            catch (Exception)
            {
                string fullPath = new StringBuilder(Path).Append(FatalFileName).ToString();
                string logMessage = string.Format("{0} - can't write to the log file: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), fullPath);
                WriteToLog(fullPath, logMessage);
                return false;
            }
        }

        public bool WriteExceptionToLog(string message)
        {
            return WriteExceptionToLog(FatalFileName, null, message);
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

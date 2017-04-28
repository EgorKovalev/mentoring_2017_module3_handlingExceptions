using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Attributes.Logger
{
    public class Logger : ILogger
    {
        public void Write(string path, string message)
        {
			if(path.Equals(null))
			{
				path = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory).Append(@"\Fatal.txt").ToString();
			}
            using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
            {
                sw.WriteLine(message);
            } 
        }
    }
}

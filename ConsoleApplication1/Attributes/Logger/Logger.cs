using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Attributes.Logger
{
    public class Logger
    {
        public void Write(string path, string message)
        {
            using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
            {
                sw.WriteLine(message);
            } 
        }
    }
}

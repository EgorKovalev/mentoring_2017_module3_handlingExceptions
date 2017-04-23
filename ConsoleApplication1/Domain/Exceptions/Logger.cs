using System;
using System.Globalization;
using System.IO;

namespace Domain.Exceptions
{
    public class Logger
    {
        public bool WriteExceptionToLog(string path, string ob)
        {
            if (File.Exists(path))
            {
                string createText = string.Format("{0} - an exception has been threw in object with parameters: {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), ob);
                File.WriteAllText(path, createText);
                return true;
            }
            return false;
        }
    }
}

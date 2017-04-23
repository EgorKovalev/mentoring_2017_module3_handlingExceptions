using System;

namespace Domain.Exceptions
{
    public class UpdateDbException : Exception
    {
        private const string UpdateDbExceptionMessage = "An exception has been threw while updating database. For more details please see the log file";
        private const string Path = "E:/Test/Text.txt";

        public UpdateDbException(string order)
            : base(UpdateDbExceptionMessage)
        {
            var log = new Logger();
            log.WriteExceptionToLog(Path, order);
        }
    }
}

using System;

namespace Reports.DAL.Tools.Exceptions
{
    public class ReportsDataException : Exception
    {
        public ReportsDataException()
        {
        }

        public ReportsDataException(string message)
            : base(message)
        {
        }

        public ReportsDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
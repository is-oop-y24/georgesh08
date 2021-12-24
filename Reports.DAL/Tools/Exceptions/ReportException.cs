using System;

namespace Reports.DAL.Tools.Exceptions
{
    public class ReportException : ReportsDataException
    {
        public ReportException()
        {
        }

        public ReportException(string message)
            : base(message)
        {
        }

        public ReportException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
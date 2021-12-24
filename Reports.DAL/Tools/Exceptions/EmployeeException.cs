using System;

namespace Reports.DAL.Tools.Exceptions
{
    public class EmployeeException : ReportsDataException
    {
        public EmployeeException()
        {
        }

        public EmployeeException(string message)
            : base(message)
        {
        }

        public EmployeeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
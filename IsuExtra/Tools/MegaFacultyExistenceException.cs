using System;

namespace IsuExtra.Tools
{
    public class MegaFacultyExistenceException : IsuExtraException
    {
        public MegaFacultyExistenceException()
        {
        }

        public MegaFacultyExistenceException(string message)
            : base(message)
        {
        }

        public MegaFacultyExistenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
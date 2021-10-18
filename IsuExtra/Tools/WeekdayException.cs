using System;

namespace IsuExtra.Tools
{
    public class WeekdayException : IsuExtraException
    {
        public WeekdayException()
        {
        }

        public WeekdayException(string message)
            : base(message)
        {
        }

        public WeekdayException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
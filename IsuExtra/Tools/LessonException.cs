using System;

namespace IsuExtra.Tools
{
    public class LessonException : IsuExtraException
    {
        public LessonException()
        {
        }

        public LessonException(string message)
            : base(message)
        {
        }

        public LessonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
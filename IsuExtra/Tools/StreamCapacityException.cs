using System;

namespace IsuExtra.Tools
{
    public class StreamCapacityException : IsuExtraException
    {
        public StreamCapacityException()
        {
        }

        public StreamCapacityException(string message)
            : base(message)
        {
        }

        public StreamCapacityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
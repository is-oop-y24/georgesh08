using System;

namespace IsuExtra.Tools
{
    public class OgnpException : IsuExtraException
    {
        public OgnpException()
        {
        }

        public OgnpException(string message)
            : base(message)
        {
        }

        public OgnpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
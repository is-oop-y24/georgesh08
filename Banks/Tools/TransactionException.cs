using System;

namespace Banks.Tools
{
    public class TransactionException : BanksException
    {
        public TransactionException()
        {
        }

        public TransactionException(string message)
            : base(message)
        {
        }

        public TransactionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
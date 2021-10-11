using System;

namespace Shops.Tools
{
    public class AddressException : ShopsException
    {
        public AddressException()
        {
        }

        public AddressException(string message)
            : base(message)
        {
        }

        public AddressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
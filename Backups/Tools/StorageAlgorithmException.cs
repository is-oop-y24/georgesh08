using System;

namespace Backups.Tools
{
    public class StorageAlgorithmException : BackupsException
    {
        public StorageAlgorithmException()
        {
        }

        public StorageAlgorithmException(string message)
            : base(message)
        {
        }

        public StorageAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
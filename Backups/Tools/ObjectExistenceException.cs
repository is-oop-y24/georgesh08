using System;

namespace Backups.Tools
{
    public class ObjectExistenceException : BackupsException
    {
        public ObjectExistenceException()
        {
        }

        public ObjectExistenceException(string message)
            : base(message)
        {
        }

        public ObjectExistenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
using System;
using System.Collections.Generic;

namespace Backups.RestorePoint
{
    public class RestorePoint
    {
        private DateTime _creationTime;
        private List<string> _filesList;

        public RestorePoint(List<string> copiesList)
        {
            _creationTime = DateTime.Now;
            _filesList = copiesList;
        }

        public DateTime CreationTime()
        {
            return _creationTime;
        }

        public IReadOnlyList<string> FilesList()
        {
            return _filesList;
        }
    }
}
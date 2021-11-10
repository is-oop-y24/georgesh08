using System;
using System.Collections.Generic;

namespace Backups
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
    }
}
using System.Collections.Generic;
using Backups;
using Backups.Repository;

namespace BackupsExtra.Logging
{
    public interface ILogger
    {
        void StorageCreationNotification(Repository repo, int storagesBefore, bool timeCodePrefixNeeded = false);
        void RestorePointCreationNotification(RestorePoint point, bool timeCodePrefixNeeded = false);
        void AddingFileToBackupJobNotification(string path, string jobName, bool timeCodePrefix = false);
        void DeletingFileFromBackupJobNotification(string path, string jobName,  bool timeCodePrefix = false);
        void BackupJobCreationNotification(string name, bool timeCodePrefixNeeded = false);
    }
}
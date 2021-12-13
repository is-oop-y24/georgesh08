using System.Collections.Generic;
using Backups.RepositoryFolder;
using Backups.RestorePointFolder;

namespace Backups.BackupJobFolder
{
    public interface IBackupJob
    {
        void AddObject(string objectPath);
        IReadOnlyList<string> Objects();
        void RemoveObject(string objectPath);
        void StartJob(Repository repository);
        IReadOnlyList<RestorePoint> Points();
    }
}
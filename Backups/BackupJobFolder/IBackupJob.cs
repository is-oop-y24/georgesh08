using System.Collections.Generic;

namespace Backups.BackupJob
{
    public interface IBackupJob
    {
        void AddObject(string objectPath);
        IReadOnlyList<string> Objects();
        void RemoveObject(string objectPath);
        void StartJob(Repository.Repository repository);
        IReadOnlyList<RestorePoint.RestorePoint> Points();
    }
}
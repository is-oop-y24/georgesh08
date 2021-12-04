using Backups.BackupJobFolder;
using Backups.RestorePointFolder;

namespace BackupsExtra.PointRemover
{
    public interface IPointRemover
    {
        void Update(BackupJob job);
        void RemovePoints(BackupJob job, RestorePoint point);
    }
}
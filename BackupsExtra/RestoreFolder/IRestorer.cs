using Backups.RestorePointFolder;
using BackupsExtra.Subjects;

namespace BackupsExtra.RestoreFolder
{
    public interface IRestorer
    {
        void RestoreToOriginLocation(BackupJobSubject job, RestorePoint point);
        void RestoreToNewLocation(string path, RestorePoint point);
    }
}
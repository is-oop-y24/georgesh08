using Backups.RestorePointFolder;
using BackupsExtra.Subjects;

namespace BackupsExtra.RestoreFolder
{
    public class VirtualRestorer : IRestorer
    {
        public void RestoreToOriginLocation(BackupJobSubject job, RestorePoint point)
        {
            // do nothing
        }

        public void RestoreToNewLocation(string path, RestorePoint point)
        {
            // do nothing
        }
    }
}
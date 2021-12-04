using System.IO;
using Backups.BackupJobFolder;
using Backups.RestorePointFolder;

namespace BackupsExtra.PointRemover
{
    public class PointMerger : IPointRemover
    {
        public void Update(BackupJob job)
        {
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            throw new System.NotImplementedException();
        }

        private string GetOriginalFileName(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            int index = filename.LastIndexOf("_");
            return filename[..index];
        }
    }
}
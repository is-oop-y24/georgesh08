using System.Linq;
using Backups.BackupJobFolder;
using Backups.RestorePointFolder;

namespace BackupsExtra.PointRemover
{
    public class ByNumberPointRemover : IPointRemover
    {
        private int _limitNum;

        public ByNumberPointRemover(int num)
        {
            _limitNum = num;
        }

        public void Update(BackupJob job)
        {
            while (job.Points().Count > _limitNum)
            {
                RemovePoints(job, job.Points().First());
            }
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }
    }
}
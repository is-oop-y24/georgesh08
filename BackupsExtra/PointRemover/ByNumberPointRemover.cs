using System.Linq;
using Backups.BackupJobFolder;
using Backups.RestorePointFolder;
using BackupsExtra.Tools;

namespace BackupsExtra.PointRemover
{
    public class ByNumberPointRemover : IPointRemover
    {
        private int _limitNum;

        public ByNumberPointRemover(int num)
        {
            if (num < 0)
            {
                throw new PointRemoverException("Number of points can't be negative");
            }

            _limitNum = num;
        }

        public void Update(BackupJob job)
        {
            while (job.Points().Count > _limitNum)
            {
                if (job.Points().Count == 1)
                {
                    throw new PointRemoverException("Can't delete all points.");
                }

                RemovePoints(job, job.Points().First());
            }
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }
    }
}
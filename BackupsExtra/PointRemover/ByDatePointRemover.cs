using System;
using Backups.BackupJobFolder;
using Backups.RestorePointFolder;
using BackupsExtra.Tools;

namespace BackupsExtra.PointRemover
{
    public class ByDatePointRemover : IPointRemover
    {
        private DateTime _limitDate;

        public ByDatePointRemover(DateTime date)
        {
            _limitDate = date;
        }

        public void Update(BackupJob job)
        {
            foreach (RestorePoint point in job.Points())
            {
                if (point.CreationTime() < _limitDate)
                {
                    if (job.Points().Count == 1)
                    {
                        throw new PointRemoverException("Can't delete all points.");
                    }

                    RemovePoints(job, point);
                }
            }
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }
    }
}
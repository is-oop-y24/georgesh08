using System;
using System.Linq;
using Backups.BackupJobFolder;
using Backups.RestorePointFolder;

namespace BackupsExtra.PointRemover
{
    public class HybridRemover : IPointRemover
    {
        private int _limitNum;
        private DateTime _limitDate;

        public HybridRemover(int num = -1, DateTime date = default)
        {
            _limitNum = num;
            _limitDate = date;
        }

        public void Update(BackupJob job)
        {
            if (_limitNum == -1 && _limitDate.Equals(default))
            {
            }

            if (_limitNum == -1 && !_limitDate.Equals(default))
            {
                foreach (RestorePoint point in job.Points())
                {
                    if (point.CreationTime() < _limitDate)
                    {
                        RemovePoints(job, point);
                    }
                }
            }

            if (_limitNum != -1 && _limitDate.Equals(default))
            {
                while (job.Points().Count > _limitNum)
                {
                    RemovePoints(job, job.Points().First());
                }
            }

            if (_limitNum == -1 || _limitDate.Equals(default)) return;
            {
                while (job.Points().Count > _limitNum)
                {
                    RemovePoints(job, job.Points().First());
                }

                foreach (RestorePoint point in job.Points())
                {
                    if (point.CreationTime() < _limitDate)
                    {
                        RemovePoints(job, point);
                    }
                }
            }
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }
    }
}
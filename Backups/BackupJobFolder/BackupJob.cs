using System.Collections.Generic;
using Backups.RepositoryFolder;
using Backups.RestorePointFolder;
using Backups.StorageAlgorithm;
using Backups.Tools;

namespace Backups.BackupJobFolder
{
    public class BackupJob : IBackupJob
    {
        private IStorageAlgorithmType _algorithmType;
        private List<string> _filesToBackup;
        private int _startCounter = 0;
        private List<RestorePoint> _points = new List<RestorePoint>();

        public BackupJob(string name, IStorageAlgorithmType algorithmType, List<string> files)
        {
            Name = name;
            _algorithmType = algorithmType;
            _filesToBackup = files;
        }

        public string Name { get; }

        public void AddObject(string objectPath)
        {
            _filesToBackup.Add(objectPath);
        }

        public IReadOnlyList<string> Objects()
        {
            return _filesToBackup;
        }

        public IReadOnlyList<RestorePoint> Points()
        {
            return _points;
        }

        public void RemoveObject(string objectPath)
        {
            if (!_filesToBackup.Contains(objectPath))
            {
                throw new ObjectExistenceException("No such object in this job.");
            }

            _filesToBackup.Remove(objectPath);
        }

        public void StartJob(Repository repository)
        {
            _points.Add(_algorithmType.Backup(repository, _filesToBackup, (++_startCounter).ToString()));
        }

        public void RemovePoint(RestorePoint point)
        {
            _points.Remove(point);
        }

        private RestorePoint AddRestorePoint(List<string> files)
        {
            return new RestorePoint(files);
        }
    }
}
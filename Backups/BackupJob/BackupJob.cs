using System.Collections.Generic;
using Backups.StorageAlgorithm;
using Backups.Tools;

namespace Backups.BackupJob
{
    public class BackupJob : IBackupJob
    {
        private IStorageAlgorithmType _algorithmType;
        private List<string> _filesToBackup;
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

        public void StartJob(Repository.Repository repository)
        {
            _points.Add(_algorithmType.Backup(repository, _filesToBackup, (_points.Count + 1).ToString()));
        }

        private RestorePoint AddRestorePoint(List<string> files)
        {
            return new RestorePoint(files);
        }
    }
}
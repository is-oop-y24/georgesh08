using System;
using System.Collections.Generic;
using System.IO;
using Backups.Tools;

namespace Backups
{
    public class BackupJob : IBackupJob
    {
        private StorageAlgorithmType _algorithmType;
        private List<string> _filesToBackup;
        private List<RestorePoint> _points = new List<RestorePoint>();

        public BackupJob(string name, StorageAlgorithmType algorithmType, List<string> files)
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

        public void StartFileSystemJob(string repoPath)
        {
            var newManager = new LocalFileSystemBackupManager();
            if (!Directory.Exists(repoPath))
            {
                newManager.CreateRepository(repoPath);
            }

            List<string> filesInPoint;
            switch (_algorithmType)
            {
                case StorageAlgorithmType.Single:
                    filesInPoint = newManager.SingleStorage(
                        repoPath,
                        (_points.Count + 1).ToString(),
                        _filesToBackup,
                        _points.Count + 1);
                    break;
                case StorageAlgorithmType.Split:
                    filesInPoint = newManager.SplitStorage(repoPath, _filesToBackup, _points.Count + 1);
                    break;
                default:
                    throw new BackupsException("Unable to start backup job.");
            }

            _points.Add(AddRestorePoint(filesInPoint));
        }

        public StorageAlgorithmType AlgorithmType()
        {
            return _algorithmType;
        }

        public void StartMemoryJob(Repository repository)
        {
            var manager = new MemoryBackupManager();
            List<string> filesInPoint;
            switch (_algorithmType)
            {
                case StorageAlgorithmType.Single:
                    filesInPoint = manager.SingleStorage(
                        repository,
                        (_points.Count + 1).ToString(),
                        _filesToBackup,
                        _points.Count + 1);
                    break;
                case StorageAlgorithmType.Split:
                    filesInPoint = manager.SplitStorage(
                        repository,
                        _points.Count + 1,
                        _filesToBackup);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _points.Add(AddRestorePoint(filesInPoint));
        }

        private RestorePoint AddRestorePoint(List<string> files)
        {
            return new RestorePoint(files);
        }
    }
}
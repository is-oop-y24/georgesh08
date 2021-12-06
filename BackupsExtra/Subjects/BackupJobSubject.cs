using System.Collections.Generic;
using System.Linq;
using Backups.BackupJobFolder;
using Backups.RepositoryFolder;
using Backups.StorageAlgorithm;
using BackupsExtra.Logging;
using BackupsExtra.PointRemover;

namespace BackupsExtra.Subjects
{
    public class BackupJobSubject
    {
        private readonly bool _timeCodePrefixNeeded;
        private readonly BackupJob _job;
        private readonly Repository _repository;
        private readonly List<ILogger> _observers = new List<ILogger>();
        private IPointRemover _pointRemover;

        public BackupJobSubject(
            string name,
            Repository repo,
            IStorageAlgorithmType algorithmType,
            List<string> files,
            bool creationTimeNeeded = false)
        {
            _job = new BackupJob(name, algorithmType, files);
            _repository = repo;
            foreach (ILogger observer in _observers)
            {
                observer.BackupJobCreationNotification(name, creationTimeNeeded);
            }

            _timeCodePrefixNeeded = creationTimeNeeded;
        }

        public void StartJob()
        {
            int currentStorages = _repository.Storages().Count;
            _job.StartJob(_repository);
            NotifyRemover();
            NewStorageNotification(currentStorages);
            NewRestorePointNotification();
        }

        public void AddFile(string filePath)
        {
            _job.AddObject(filePath);
            NewFileAddedNotification();
        }

        public void RemoveFile(string filePath)
        {
            _job.RemoveObject(filePath);
            FileDeletedNotification();
        }

        public void AttachLogger(ILogger logger)
        {
            _observers.Add(logger);
        }

        public void DetachLogger(ILogger logger)
        {
            _observers.Remove(logger);
        }

        public void AttachPointRemover(IPointRemover remover)
        {
            _pointRemover = remover;
        }

        public void DetachPointRemover()
        {
            _pointRemover = null;
        }

        public BackupJob BackupJob()
        {
            return _job;
        }

        private void NewRestorePointNotification()
        {
            foreach (ILogger observer in _observers)
            {
                observer.RestorePointCreationNotification(_job.Points().Last(), _timeCodePrefixNeeded);
            }
        }

        private void NewStorageNotification(int currentStorages)
        {
            foreach (ILogger observer in _observers)
            {
                observer.StorageCreationNotification(_repository, currentStorages, _timeCodePrefixNeeded);
            }
        }

        private void NewFileAddedNotification()
        {
            foreach (ILogger observer in _observers)
            {
                observer.AddingFileToBackupJobNotification(_job.Objects().Last(), _job.Name, _timeCodePrefixNeeded);
            }
        }

        private void FileDeletedNotification()
        {
            foreach (ILogger observer in _observers)
            {
                observer.DeletingFileFromBackupJobNotification(_job.Objects().Last(), _job.Name, _timeCodePrefixNeeded);
            }
        }

        private void NotifyRemover()
        {
            _pointRemover?.Update(_job);
        }
    }
}
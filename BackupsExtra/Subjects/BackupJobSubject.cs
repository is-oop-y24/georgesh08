using System.Collections.Generic;
using System.Linq;
using Backups.BackupJob;
using Backups.Repository;
using Backups.StorageAlgorithm;
using BackupsExtra.Logging;

namespace BackupsExtra.Subjects
{
    public class BackupJobSubject : ISubject
    {
        private BackupJob _job;
        private Repository _repository;
        private List<ILogger> _observers = new List<ILogger>();

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
        }

        public void StartJob(bool timeCodePrefixNeeded = false)
        {
            int currentStorages = _repository.Storages().Count;
            _job.StartJob(_repository);
            NewStorageNotification(currentStorages, timeCodePrefixNeeded);
            NewRestorePointNotification(timeCodePrefixNeeded);
        }

        public void AddFile(string filePath, bool timeCodePrefixNeeded = false)
        {
            _job.AddObject(filePath);
            NewFileAddedNotification(timeCodePrefixNeeded);
        }

        public void RemoveFile(string filePath, bool timeCodePrefixNeeded = false)
        {
            _job.RemoveObject(filePath);
            FileDeletedNotification(timeCodePrefixNeeded);
        }

        public void Attach(ILogger logger)
        {
            _observers.Add(logger);
        }

        public void Detach(ILogger logger)
        {
            _observers.Remove(logger);
        }

        public void NewRestorePointNotification(bool timeCodePrefixNeeded = false)
        {
            foreach (ILogger observer in _observers)
            {
                observer.RestorePointCreationNotification(_job.Points().Last(), timeCodePrefixNeeded);
            }
        }

        public void NewStorageNotification(int currentStorages, bool timeCodePrefixNeeded = false)
        {
            foreach (ILogger observer in _observers)
            {
                observer.StorageCreationNotification(_repository, currentStorages, timeCodePrefixNeeded);
            }
        }

        public void NewFileAddedNotification(bool timeCodePrefixNeeded = false)
        {
            foreach (ILogger observer in _observers)
            {
                observer.AddingFileToBackupJobNotification(_job.Objects().Last(), _job.Name, timeCodePrefixNeeded);
            }
        }

        public void FileDeletedNotification(bool timeCodePrefixNeeded = false)
        {
            foreach (ILogger observer in _observers)
            {
                observer.DeletingFileFromBackupJobNotification(_job.Objects().Last(), _job.Name, timeCodePrefixNeeded);
            }
        }
    }
}
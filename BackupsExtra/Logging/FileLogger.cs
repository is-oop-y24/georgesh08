using System;
using System.IO;
using System.Linq;
using Backups.RepositoryFolder;
using Backups.RestorePointFolder;

namespace BackupsExtra.Logging
{
    public class FileLogger : ILogger
    {
        public FileLogger(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public void StorageCreationNotification(Repository repo, int storagesBefore, bool timeCodePrefixNeeded = false)
        {
            const string success = "New storages successfully added.";
            using var writer = new StreamWriter(Path, true);
            writer.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
            writer.WriteLine("Storages: ");
            for (int i = repo.Storages().Count; i > storagesBefore; --i)
            {
                writer.WriteLine(repo.Storages().ElementAt(i - 1).Key);
            }
        }

        public void RestorePointCreationNotification(RestorePoint point, bool timeCodePrefixNeeded = false)
        {
            const string success = "Restore point successfully created.";
            using var writer = new StreamWriter(Path, true);
            writer.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
            writer.WriteLine("Files: ");
            foreach (string path in point.FilesList())
            {
                writer.WriteLine(path);
            }
        }

        public void AddingFileToBackupJobNotification(string path, string jobName, bool timeCodePrefixNeeded = false)
        {
            string success = path + " added to " + jobName;
            using var writer = new StreamWriter(Path, true);
            writer.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
        }

        public void DeletingFileFromBackupJobNotification(string path, string jobName, bool timeCodePrefixNeeded = false)
        {
            string success = path + " deleted from " + jobName;
            using var writer = new StreamWriter(Path, true);
            writer.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
        }

        public void BackupJobCreationNotification(string name, bool timeCodePrefixNeeded = false)
        {
            string created = name + " successfully created.";
            using var writer = new StreamWriter(Path, true);
            writer.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + created : created);
        }
    }
}
using System;
using System.Linq;
using Backups;
using Backups.Repository;

namespace BackupsExtra.Logging
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger() { }

        public void StorageCreationNotification(Repository repo, int storagesBefore, bool timeCodePrefixNeeded = false)
        {
            const string success = "New storages successfully added.";
            Console.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
            Console.WriteLine("Storages: ");
            for (int i = repo.Storages().Count; i > storagesBefore; --i)
            {
                Console.WriteLine(repo.Storages().ElementAt(i));
            }
        }

        public void RestorePointCreationNotification(RestorePoint point, bool timeCodePrefixNeeded = false)
        {
            const string success = "Restore point successfully created.";
            Console.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
            Console.WriteLine("Files: ");
            foreach (string path in point.FilesList())
            {
                Console.WriteLine(path);
            }
        }

        public void AddingFileToBackupJobNotification(string path, string jobName, bool timeCodePrefixNeeded = false)
        {
            string success = path + " added to " + jobName;
            Console.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
        }

        public void DeletingFileFromBackupJobNotification(string path, string jobName, bool timeCodePrefixNeeded = false)
        {
            string success = path + " deleted from " + jobName;
            Console.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + success : success);
        }

        public void BackupJobCreationNotification(string name, bool timeCodePrefixNeeded = false)
        {
            string created = name + " successfully created.";
            Console.WriteLine(timeCodePrefixNeeded ? DateTime.Now + " - " + created : created);
        }
    }
}
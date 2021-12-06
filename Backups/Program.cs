using System.Collections.Generic;
using System.IO;
using Backups.BackupJobFolder;
using Backups.RepositoryFolder;
using Backups.StorageAlgorithm;
using Backups.StorageType;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            const string repositoryPath = "C:\\Users\\geo02\\Desktop\\MyRepository";
            var newRep = new Repository(repositoryPath);
            Directory.CreateDirectory(repositoryPath);
            var paths = new List<string>()
            {
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_1.txt",
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_2.txt",
            };
            IStorageAlgorithmType newAlgo = new SingleStorageAlgorithm(new FileSystemSaver());
            var newJob = new BackupJob("Job1", newAlgo, paths);
            newJob.StartJob(newRep);
        }
    }
}
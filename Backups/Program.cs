using System.Collections.Generic;
using System.IO;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var newRep = new Repository("C:\\Users\\geo02\\Desktop\\MyRepository", RepositoryType.Local);
            const string repositoryPath = "C:\\Users\\geo02\\Desktop\\MyRepository";
            Directory.CreateDirectory(repositoryPath);
            var paths = new List<string>()
            {
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_1.txt",
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_2.txt",
            };

            var newJob = new BackupJob("Job1", StorageAlgorithmType.Single, paths);
            newJob.StartJob(newRep);
        }
    }
}
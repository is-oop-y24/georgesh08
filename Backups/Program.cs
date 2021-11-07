using System;
using System.Collections.Generic;
using System.IO;
using Backups.Tools;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            // Test_2_On_Local_Machine
            const string repositoryPath = "C:\\Users\\geo02\\Desktop\\MyRepository";
            Directory.CreateDirectory(repositoryPath);
            var paths = new List<string>()
            {
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_1.txt",
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_2.txt",
            };

            var newJob = new BackupJob("Job1", StorageAlgorithmType.Split, paths);
            newJob.StartFileSystemJob(repositoryPath);
        }
    }
}
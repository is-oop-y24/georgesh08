using System;
using System.Collections.Generic;
using System.IO;
using Backups.RepositoryFolder;
using Backups.StorageAlgorithm;
using Backups.StorageType;
using BackupsExtra.Logging;
using BackupsExtra.PointRemover;
using BackupsExtra.Subjects;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {/*
            const string repositoryPath = "C:\\Users\\geo02\\Desktop\\MyRepository";
            var newRep = new Repository(repositoryPath);
            Directory.CreateDirectory(repositoryPath);
            var paths = new List<string>()
            {
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_1.txt",
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_2.txt",
            };
            IStorageAlgorithmType newAlgo = new SplitStorageAlgorithm(new FileSystemSaver());
            IPointRemover remover = new ByNumberPointRemover(2);
            var sb = new BackupJobSubject("Job1", newRep, newAlgo, paths, true);
            var logger = new FileLogger("C:\\Users\\geo02\\Desktop\\logger.txt");
            sb.AttachLogger(logger);
            sb.StartJob();
            sb.StartJob();*/
        }
    }
}

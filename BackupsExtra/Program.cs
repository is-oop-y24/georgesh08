using System.Collections.Generic;
using System.IO;
using Backups.RepositoryFolder;
using Backups.StorageAlgorithm;
using Backups.StorageType;
using BackupsExtra.ConfigManagement;
using BackupsExtra.Logging;
using BackupsExtra.PointRemover;
using BackupsExtra.Subjects;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            const string repositoryPath = "C:\\Users\\geo02\\Desktop\\MyRepository";

            const string configPath = "C:\\Users\\geo02\\Desktop\\config.txt";
            var newRep = new Repository(repositoryPath);
            Directory.CreateDirectory(repositoryPath);
            var paths = new List<string>()
            {
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_1.txt",
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_2.txt",
            };
            IStorageAlgorithmType newAlgo = new SplitStorageAlgorithm(new FileSystemSaver());
            IPointRemover remover = new ByNumberPointRemover(5);
            var bj = new BackupJobSubject("Job1", newRep, newAlgo, paths, true);
            var logger = new FileLogger("C:\\Users\\geo02\\Desktop\\logger.txt");
            bj.AttachLogger(logger);
            bj.AttachPointRemover(remover);
            bj.StartJob();
            bj.StartJob();
            var manager = new ConfigManager();
            manager.Serialize(bj, configPath);
        }
    }
}

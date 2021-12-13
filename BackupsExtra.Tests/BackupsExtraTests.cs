using System.Collections.Generic;
using Backups.BackupJobFolder;
using Backups.RepositoryFolder;
using Backups.StorageAlgorithm;
using Backups.StorageType;
using BackupsExtra.PointRemover;
using BackupsExtra.Subjects;
using BackupsExtra.Tools;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupsExtraTests
    {
        
        private Repository _newRepo;
        [SetUp]
        public void Setup()
        {
            _newRepo = new Repository("repoPath");
        }

        [Test]
        public void CreateRemoverWithNegativePointNumber_ThrowException()
        {
            Assert.Catch<BackupsExtraException>(() =>
            {
                IPointRemover remover = new ByNumberPointRemover(-1);
            });
        }
        [Test]
        public void PointsSuccessfullyDeleted()
        {
            var paths = new List<string>()
            {
                "examplePath1",
                "examplePath2",
            };
            IStorageAlgorithmType newAlgo = new SplitStorageAlgorithm(new VirtualStorageSaver());
            var bj = new BackupJobSubject("Job1", _newRepo, newAlgo, paths, true);
            bj.StartJob();
            bj.StartJob();
            IPointRemover remover = new ByNumberPointRemover(1);
            bj.AttachPointRemover(remover);
            var pointsBefore = bj.BackupJob().Points().Count;
            bj.StartJob();
            Assert.AreNotEqual(pointsBefore, bj.BackupJob().Points().Count);
        }
    }
}
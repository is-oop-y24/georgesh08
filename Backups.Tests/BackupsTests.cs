using System.Collections.Generic;
using Backups.BackupJobFolder;
using Backups.RepositoryFolder;
using Backups.StorageAlgorithm;
using Backups.StorageType;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupsTests
    {
        private Repository _newRepo;
        [SetUp]
        public void Setup()
        {
            _newRepo = new Repository("repoPath");
        }

        [Test]
        public void Test_1()
        {
            var paths = new List<string>()
            {
                "examplePath1",
                "examplePath2",
            };
            IStorageAlgorithmType newAlgo = new SplitStorageAlgorithm(new VirtualStorageSaver());
            var job = new BackupJob("job1", newAlgo, paths);
            job.StartJob(_newRepo);
            job.RemoveObject(paths[1]);
            job.StartJob(_newRepo);
            Assert.AreEqual(2, job.Points().Count);
            Assert.AreEqual(3, _newRepo.Storages().Count);
        }
    }
}
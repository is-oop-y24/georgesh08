using System.Collections.Generic;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupsTests
    {
        private Repository _newRepo;
        [SetUp]
        public void Setup()
        {
            _newRepo = new Repository("repoPath", RepositoryType.Virtual);
        }

        [Test]
        public void Test_1()
        {
            var paths = new List<string>()
            {
                "examplePath1",
                "examplePath2",
            };
            var job = new BackupJob("job2", StorageAlgorithmType.Split, paths);
            job.StartJob(_newRepo);
            job.RemoveObject(paths[1]);
            job.StartJob(_newRepo);
            Assert.AreEqual(2, job.Points().Count);
            Assert.AreEqual(3, _newRepo.Storages().Count);
        }
    }
}
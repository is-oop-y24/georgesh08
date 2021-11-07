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
            _newRepo = new Repository("C:\\Users\\geo02\\Desktop\\MyRepository");
        }

        [Test]
        public void Test_1()
        {
            var paths = new List<string>()
            {
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_1.txt",
                "C:\\Users\\geo02\\Desktop\\FilesToAdd\\File_2.txt",
            };
            var job = new BackupJob("job2", StorageAlgorithmType.Split, paths);
            job.StartMemoryJob(_newRepo);
            job.RemoveObject(paths[1]);
            job.StartMemoryJob(_newRepo);
            if (job.Points().Count != 2 || _newRepo.Storages().Count != 3)
            {
                Assert.Fail();
            }
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.RepositoryFolder;
using Backups.RestorePointFolder;
using Backups.StorageType;

namespace Backups.StorageAlgorithm
{
    public class SingleStorageAlgorithm : IStorageAlgorithmType
    {
        private IStorageType _storageType;

        public SingleStorageAlgorithm(IStorageType type)
        {
            _storageType = type;
        }

        public RestorePoint Backup(Repository repository, List<string> files, string name)
        {
            var newPaths = new List<string>();
            string storage = _storageType.InitStorage(repository.Path, name);
            foreach (string file in files)
            {
                string name1 = _storageType.AddFolderToZip(storage, file, name);
                newPaths.Add(name1);
            }

            repository.AddStorage(Path.GetFileName(storage), newPaths);
            return new RestorePoint(newPaths);
        }
    }
}
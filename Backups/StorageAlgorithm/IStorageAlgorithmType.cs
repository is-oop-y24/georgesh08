using System.Collections.Generic;
using Backups.RepositoryFolder;
using Backups.RestorePointFolder;

namespace Backups.StorageAlgorithm
{
    public interface IStorageAlgorithmType
    {
        RestorePoint Backup(Repository repository, List<string> files, string name);
    }
}
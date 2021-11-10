using System.Collections.Generic;

namespace Backups.StorageAlgorithm
{
    public interface IStorageAlgorithmType
    {
        RestorePoint Backup(Repository.Repository repository, List<string> files, string name);
    }
}
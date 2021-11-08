using System.Collections.Generic;

namespace Backups
{
    public interface IStartJob
    {
        List<string> StartJob(
            Repository repository,
            StorageAlgorithmType storageAlgorithmType,
            List<string> backupFiles,
            int restorePointsCounter);
    }
}
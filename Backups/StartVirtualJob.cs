using System.Collections.Generic;
using Backups.Tools;

namespace Backups
{
    public class StartVirtualJob : IStartJob
    {
        public List<string> StartJob(
            Repository repository,
            StorageAlgorithmType storageAlgorithmType,
            List<string> backupFiles,
            int restorePointsCounter)
        {
            var manager = new MemoryBackupManager();
            List<string> filesInPoint;
            switch (storageAlgorithmType)
            {
                case StorageAlgorithmType.Single:
                    filesInPoint = manager.SingleStorage(
                        repository,
                        backupFiles,
                        restorePointsCounter + 1);
                    break;
                case StorageAlgorithmType.Split:
                    filesInPoint = manager.SplitStorage(
                        repository,
                        backupFiles,
                        restorePointsCounter + 1);
                    break;
                default:
                    throw new BackupsException("Unable to start backup job.");
            }

            return filesInPoint;
        }
    }
}
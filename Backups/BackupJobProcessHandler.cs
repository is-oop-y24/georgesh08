using System.Collections.Generic;
using System.IO;
using Backups.Tools;

namespace Backups
{
    public class BackupJobProcessHandler : IBackupJobProcessHandler
    {
        public List<string> StartJob(Repository repository, StorageAlgorithmType storageAlgorithmType, List<string> backupFiles, int restorePointsCounter)
        {
            List<string> filesInPoint = null;
            if (repository.Type == RepositoryType.Local)
            {
                filesInPoint = new StartLocalJob().StartJob(
                    repository,
                    storageAlgorithmType,
                    backupFiles,
                    restorePointsCounter);
            }

            if (repository.Type == RepositoryType.Virtual)
            {
                filesInPoint = new StartVirtualJob().StartJob(
                    repository,
                    storageAlgorithmType,
                    backupFiles,
                    restorePointsCounter);
            }

            return filesInPoint;
        }
    }
}
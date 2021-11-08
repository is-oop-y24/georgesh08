using System.Collections.Generic;
using System.IO;
using Backups.Tools;

namespace Backups
{
    public class StartLocalJob : IStartJob
    {
        public List<string> StartJob(Repository repository, StorageAlgorithmType storageAlgorithmType, List<string> backupFiles, int restorePointsCounter)
        {
            List<string> filesInPoint = null;
            string repoPath = repository.Path;
            var newManager = new LocalFileSystemBackupManager();
            if (!Directory.Exists(repoPath))
            {
                newManager.CreateRepository(repoPath);
            }

            switch (storageAlgorithmType)
            {
                case StorageAlgorithmType.Single:
                    filesInPoint = newManager.SingleStorage(
                        repoPath,
                        backupFiles,
                        restorePointsCounter + 1);
                    break;
                case StorageAlgorithmType.Split:
                    filesInPoint = newManager.SplitStorage(
                        repoPath,
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
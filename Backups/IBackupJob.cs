using System.Collections.Generic;

namespace Backups
{
    public interface IBackupJob
    {
        void AddObject(string objectPath);
        IReadOnlyList<string> Objects();
        void RemoveObject(string objectPath);
        void StartFileSystemJob(string repoPath);
        StorageAlgorithmType AlgorithmType();
        IReadOnlyList<RestorePoint> Points();
        void StartMemoryJob(Repository repository);
    }
}
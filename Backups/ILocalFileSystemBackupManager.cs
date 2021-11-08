using System.Collections.Generic;

namespace Backups
{
    public interface ILocalFileSystemBackupManager
    {
        void CreateRepository(string path);
        List<string> SplitStorage(string repositoryPath, List<string> files, int numberOfBackUp);
        List<string> SingleStorage(string repositoryPath, List<string> files, int numberOfBackUp);
    }
}
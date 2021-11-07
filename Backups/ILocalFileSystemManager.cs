using System.Collections.Generic;

namespace Backups
{
    public interface ILocalFileSystemManager
    {
        void CreateRepository(string path);
        List<string> SplitStorage(string repositoryPath, List<string> files, int numberOfBackUp);
        List<string> SingleStorage(string repositoryPath, string storageName, List<string> files, int numberOfBackUp);
    }
}
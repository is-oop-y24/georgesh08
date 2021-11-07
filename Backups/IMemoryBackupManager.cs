using System.Collections.Generic;

namespace Backups
{
    public interface IMemoryBackupManager
    {
        List<string> SingleStorage(Repository repository, string storageName, List<string> files, int num);
        List<string> SplitStorage(Repository repository, int numberOfBackUp, List<string> files);
    }
}
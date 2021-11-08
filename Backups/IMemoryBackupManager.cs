using System.Collections.Generic;

namespace Backups
{
    public interface IMemoryBackupManager
    {
        List<string> SingleStorage(Repository repository, List<string> files, int numberOfBackUp);
        List<string> SplitStorage(Repository repository, List<string> files, int numberOfBackUp);
    }
}
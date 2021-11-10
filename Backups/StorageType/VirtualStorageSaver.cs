using System.Collections.Generic;

namespace Backups.StorageType
{
    public class VirtualStorageSaver : IStorageType
    {
        public string AddFolderToZip(string zipPath, string fileToZip, string name)
        {
            return name;
        }

        public string InitStorage(string outputPath, string name)
        {
            return name;
        }
    }
}
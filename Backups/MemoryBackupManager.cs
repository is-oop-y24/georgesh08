using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backups
{
    public class MemoryBackupManager : IMemoryBackupManager
    {
        public List<string> SingleStorage(Repository repository, List<string> files, int numberOfBackup)
        {
            string outputFile = repository.Path + "\\" + numberOfBackup + ".zip";
            var newFileNames = files.Select(file => Path.GetFileNameWithoutExtension(file) + "_" + numberOfBackup + Path.GetExtension(file)).Select(name => outputFile + "\\" + name).ToList();

            repository.AddStorage(numberOfBackup.ToString(), newFileNames);
            return newFileNames;
        }

        public List<string> SplitStorage(Repository repository, List<string> files, int numberOfBackup)
        {
            var newFileNames = new List<string>();
            foreach (string file in files)
            {
                var filesToAddInRep = new List<string>();
                string name = Path.GetFileNameWithoutExtension(file) + "_" + numberOfBackup;
                string outputFile = repository.Path + "\\" + name + ".zip";
                string newFilePath = outputFile + "\\" + name + Path.GetExtension(file);
                filesToAddInRep.Add(newFilePath);
                newFileNames.Add(newFilePath);
                repository.AddStorage(name, filesToAddInRep);
            }

            return newFileNames;
        }
    }
}
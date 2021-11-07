using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups
{
    public class LocalFileSystemBackupManager : ILocalFileSystemManager
    {
        public void CreateRepository(string path)
        {
            Directory.CreateDirectory(path);
        }

        public List<string> SplitStorage(string repositoryPath, List<string> files, int numberOfBackUp)
        {
            var points = new List<string>();
            foreach (string file in files)
            {
                string name = Path.GetFileNameWithoutExtension(file) + "_" + numberOfBackUp;
                string outputFile = repositoryPath + "\\" + name + ".zip";
                string newFilePath = outputFile + "\\" + name + Path.GetExtension(file);
                points.Add(newFilePath);
                using (ZipArchive archive = ZipFile.Open(outputFile, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(file, name + Path.GetExtension(file));
                }
            }

            return points;
        }

        public List<string> SingleStorage(string repositoryPath, string storageName, List<string> files, int numberOfBackUp)
        {
            var filesInPoint = new List<string>();
            string outputFile = repositoryPath + "\\" + storageName + ".zip";
            using ZipArchive archive = ZipFile.Open(outputFile, ZipArchiveMode.Create);
            foreach (string fileToZip in files)
            {
                string name = Path.GetFileNameWithoutExtension(fileToZip) + "_" + numberOfBackUp + Path.GetExtension(fileToZip);
                string newFilePath = outputFile + "\\" + name;
                filesInPoint.Add(newFilePath);
                archive.CreateEntryFromFile(fileToZip, name);
            }

            return filesInPoint;
        }
    }
}
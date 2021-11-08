using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups
{
    public class LocalFileSystemBackupManager : ILocalFileSystemBackupManager
    {
        public void CreateRepository(string path)
        {
            Directory.CreateDirectory(path);
        }

        public List<string> SplitStorage(string repositoryPath, List<string> files, int numberOfBackUp)
        {
            int fileCounter = 1;
            var points = new List<string>();
            foreach (string file in files)
            {
                string name = Path.GetFileNameWithoutExtension(file) + "_" + numberOfBackUp + Path.GetExtension(file);
                string outputFile = repositoryPath + "\\" + numberOfBackUp + "_" + fileCounter + ".zip";
                fileCounter++;
                string newFilePath = outputFile + "\\" + name;
                points.Add(newFilePath);
                using (ZipArchive archive = ZipFile.Open(outputFile, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(file, name);
                }
            }

            return points;
        }

        public List<string> SingleStorage(string repositoryPath, List<string> files, int numberOfBackUp)
        {
            var filesInPoint = new List<string>();
            string outputFile = repositoryPath + "\\" + numberOfBackUp + ".zip";
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
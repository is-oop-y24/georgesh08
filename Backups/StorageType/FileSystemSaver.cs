using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups.StorageType
{
    public class FileSystemSaver : IStorageType
    {
        public List<string> Save(string outputPath, List<string> files, string name)
        {
            var filesInPoint = new List<string>();
            string outputFile = outputPath + "\\" + name + ".zip";
            using ZipArchive archive = ZipFile.Open(outputFile, ZipArchiveMode.Create);
            foreach (string fileToZip in files)
            {
                string name1 = Path.GetFileNameWithoutExtension(fileToZip) + "_" + name + Path.GetExtension(fileToZip);
                string newFilePath = outputFile + "\\" + name1;
                filesInPoint.Add(newFilePath);
                archive.CreateEntryFromFile(fileToZip, name1);
            }

            return filesInPoint;
        }

        public string AddFolderToZip(string zipPath, string fileToZip, string name)
        {
            string name1 = Path.GetFileNameWithoutExtension(fileToZip) + "_" + name + Path.GetExtension(fileToZip);
            using ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update);
            archive.CreateEntryFromFile(fileToZip, name1);
            string newFilePath = zipPath + "\\" + name1;
            return newFilePath;
        }

        public string InitStorage(string repositoryPath, string name)
        {
            string outputFile = repositoryPath + "\\" + name + ".zip";
            using ZipArchive archive = ZipFile.Open(outputFile, ZipArchiveMode.Create);
            return outputFile;
        }
    }
}
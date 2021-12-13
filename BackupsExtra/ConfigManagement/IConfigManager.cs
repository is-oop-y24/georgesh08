using System.Collections.Generic;
using BackupsExtra.Subjects;

namespace BackupsExtra.ConfigManagement
{
    public interface IConfigManager
    {
        void Serialize(BackupJobSubject job, string configPath);
        List<DataTransformer> Deserialize(string config);
    }
}
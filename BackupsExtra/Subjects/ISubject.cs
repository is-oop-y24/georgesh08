using BackupsExtra.Logging;

namespace BackupsExtra.Subjects
{
    public interface ISubject
    {
        void Attach(ILogger logger);
        void Detach(ILogger logger);
        void NewRestorePointNotification(bool timeCodePrefixNeeded = false);
        void NewStorageNotification(int currentStorages, bool timeCodePrefixNeeded = false);
        void NewFileAddedNotification(bool timeCodePrefixNeeded = false);
        void FileDeletedNotification(bool timeCodePrefixNeeded = false);
    }
}
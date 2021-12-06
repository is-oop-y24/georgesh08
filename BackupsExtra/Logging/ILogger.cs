namespace BackupsExtra.Logging
{
    public interface ILogger
    {
        void Log(string message, bool timeNeeded);
    }
}
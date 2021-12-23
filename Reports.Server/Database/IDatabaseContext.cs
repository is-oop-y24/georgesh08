namespace Reports.Server.Database
{
    public interface IDatabaseContext
    {
        void ExecuteCommand(string query);
        string ExecuteReader(string query);
    }
}
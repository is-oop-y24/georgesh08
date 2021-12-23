using Microsoft.Data.Sqlite;

namespace Reports.Server.Database
{
    public class LocalDatabaseContext : IDatabaseContext
    {
        private static string _dbPath;
        private SqliteConnection _connection = new($"Data Source={_dbPath};");

        public LocalDatabaseContext(string Path)
        {
            _dbPath = Path;
        }
        
        public void ExecuteCommand(string query)
        {
            _connection.Open();
            var command = new SqliteCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public string ExecuteReader(string query)
        {
            _connection.Open();
            var command = new SqliteCommand(query, _connection);
            SqliteDataReader res = command.ExecuteReader();
            _connection.Close();
            return res.ToString();
        }
    }
}
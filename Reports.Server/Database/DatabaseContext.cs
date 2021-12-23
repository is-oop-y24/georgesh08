using Microsoft.Data.Sqlite;

namespace Reports.Server.Database
{
    public class DatabaseContext
    {
        private const string DbPath = "C:\\Users\\geo02\\Desktop\\Db\\reportsDb.db";
        private readonly SqliteConnection _connection = new($"Data Source={DbPath};");

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
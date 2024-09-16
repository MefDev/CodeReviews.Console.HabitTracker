using Microsoft.Data.Sqlite;
namespace CodingLogger.Models
{
    public class DBStorage
    {
        private readonly string _connectionString;
        public DBStorage(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            CreateTable(tableName);

        }
        protected DBStorage()
        {

        }
        private SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        private void CreateTable(string tableName)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $@"CREATE TABLE IF NOT EXISTS {tableName}(id INTEGER PRIMARY KEY, duration INTEGER, StartTime dateTime, EndTime datetime)";
                command.ExecuteNonQuery();
                CheckTableCreation(command, tableName);
            }
        }
        private static void CheckTableCreation(SqliteCommand command, string tableName)
        {
            command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName";
            command.Parameters.AddWithValue("@tableName", tableName);
            var tableExists = command.ExecuteScalar();
            if (tableExists != null)
            {
                Console.WriteLine("The table is created successfully.\n");
            }
            else
            {
                Console.WriteLine("The table is not created successfully.");
            }
        }


    }
}


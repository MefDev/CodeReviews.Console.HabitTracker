using CodingLogger.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace CodingLogger.Data
{
    public class CodingSessionRepository
    {
        private readonly string _connectionString;

        public CodingSessionRepository(string path)
        {
            _connectionString = $"Data Source={path};";
        }
        private SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public async Task Create(CodingSession obj)
        {
            var codingSession = obj;
            using (var connection = GetConnection())
            {
                var sql = "INSERT INTO codingSession (Id, Duration, Start, End) VALUES (@Id, @Duration, @Start, @End)";

                var rowsAffected = await connection.ExecuteAsync(sql, codingSession);
                // or var rowsAffected = await connection.ExecuteAsync(sql, customer).ConfigureAwait(false);
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
                var insertedSessions = connection.Query<CodingSession>("SELECT * FROM codingSession").ToList();
                foreach (var session in insertedSessions)
                {
                    Console.WriteLine(session);
                }
            }


             

        }

        //public void Delete(int key)
        //{
        //    using (var connection = GetConnection())
        //    {
        //        using (var cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = @"DELETE FROM habit WHERE id = @id";
        //            cmd.Parameters.AddWithValue("@id", key);
        //            cmd.Prepare();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }


        //}

        //public CodingSession Retrieve(int key)
        //{

        //    using (var connection = GetConnection())
        //    {
        //        using (var cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = @"SELECT id, name, quantity, date FROM habit WHERE id = @id";
        //            cmd.Parameters.AddWithValue("@id", key);
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    int id = reader.GetInt32(0);
        //                    string name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
        //                    string quantity = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
        //                    DateTime date = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);

        //                    return new CodingSession(id, name, quantity, date);
        //                }
        //                return null;

        //            }

        //        }
        //    }

        //}
        //public List<CodingSession> RetrieveAllHabits()
        //{
        //    List<CodingSession> habits = new List<CodingSession>();
        //    using (var connection = GetConnection())
        //    {
        //        using (var cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = @"SELECT id, name, quantity, date FROM habit";
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    int id = reader.GetInt32(0);
        //                    string name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
        //                    string quantity = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
        //                    DateTime date = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);

        //                    var habit = new CodingSession(id, name, quantity, date);
        //                    habits.Add(habit);
        //                }

        //            }

        //        }

        //    }
        //    return habits;
        //}

        //public void Update(CodingSession habit)
        //{
        //    using (var connection = GetConnection())
        //    {
        //        using (var cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = @"UPDATE habit SET name = @name, quantity = @quantity, date = @date WHERE id = @id";
        //            cmd.Parameters.AddWithValue("@id", habit.Id);
        //            cmd.Parameters.AddWithValue("@name", habit.Name);
        //            cmd.Parameters.AddWithValue("@quantity", habit.Quantity);
        //            cmd.Parameters.AddWithValue("@date", habit.Date);
        //            cmd.Prepare();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }


        //}

        //public CodingSession RetrieveByName(string habitName)
        //{
        //    using (var connection = GetConnection())
        //    {
        //        using (var cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = @"SELECT id, name, quantity, date FROM habit WHERE name = @name";
        //            cmd.Parameters.AddWithValue("@name", habitName);
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                int id = reader.GetInt32(0);
        //                string name = reader.GetString(1);
        //                string quantity = reader.GetString(2);
        //                DateTime date = reader.GetDateTime(3);
        //                return new CodingSession(id, name, quantity, date);
        //            }
        //        }
        //    }
        //}
    }
}

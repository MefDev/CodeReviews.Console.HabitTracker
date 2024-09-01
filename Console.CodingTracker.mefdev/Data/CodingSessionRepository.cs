using CodingLogger.Models;
using Microsoft.Data.Sqlite;
using Dapper;
namespace CodingLogger.Data
{
    public class CodingSessionRepository
    {
        public string _connectionString;

        public CodingSessionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public async Task Create(CodingSession codingSession)
        {
            using (var connection = GetConnection())
            {
                var sql = $"INSERT INTO codingSession (" +
                    $"{nameof(codingSession.Id)}, " +
                    $"{nameof(codingSession.Duration)}, " +
                    $"{nameof(codingSession.StartTime)}," +
                    $"{nameof(codingSession.EndTime)})" +
                    $"VALUES (@{nameof(codingSession.Id)}, " +
                    $"@{nameof(codingSession.Duration)}, " +
                    $"@{nameof(codingSession.StartTime)}, " +
                    $"@{nameof(codingSession.EndTime)})";
                var parm = new
                {
                    Id = codingSession.Id,
                    Duration = codingSession.Duration,
                    StartTime = codingSession.StartTime,
                    EndTime = codingSession.EndTime,
                };
                await connection.ExecuteAsync(sql, parm);
                
            }
        }

        public async Task Delete(int key)
        {
            string sql = $"DELETE FROM {nameof(CodingSession)} WHERE Id=@Id";
            using (var connection = GetConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = key });
            }
          
        }

        public async Task<CodingSession> Retrieve(int key)
        {
            using (var connection = GetConnection())
            {
                var sql = $"SELECT * FROM {nameof(CodingSession)} WHERE Id = @Id";
                var param = new
                {
                    Id=key
                };
                var codingSession = await connection.QuerySingleAsync<CodingSession>(sql,param);
                return codingSession;
            }

        }
        public async Task<List<CodingSession>> RetrieveAll()
        {
            List<CodingSession> codingSessionList = new List<CodingSession>();
            using (var connection = GetConnection())
            {
                var reader = await connection.ExecuteReaderAsync($@"SELECT * FROM {nameof(CodingSession)};");
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int duration = reader.GetInt32(1);
                    DateTime start = reader.GetDateTime(2);
                    DateTime end = reader.GetDateTime(3);
                    var codingSession = new CodingSession(id, duration, start, end);
                    codingSessionList.Add(codingSession);
                }
                foreach (var session in codingSessionList)
                {
                    Console.WriteLine($"{session.Id}{session.Duration}{session.StartTime}{session.EndTime}");
                }
            }
            return codingSessionList;
        }
        public async Task Update(CodingSession codingSession)
        {
            var sql = $"UPDATE {nameof(codingSession)} SET" +
                $"{nameof(codingSession.Id)} = {nameof(codingSession.Id)}, " +
                $"{nameof(codingSession.Duration)} = {nameof(codingSession.Duration)}, " +
                $"{nameof(codingSession.StartTime)} = {nameof(codingSession.StartTime)}, " +
                $"{nameof(codingSession.EndTime)} = {nameof(codingSession.EndTime)}" +
                $" WHERE {nameof(codingSession.Id)} = {nameof(codingSession.Id)}";
            using (var connection = GetConnection())
            {
                var affectedRows = connection.ExecuteAsync(sql, new {
                    Id=codingSession.Id,
                    Duration= codingSession.Duration,
                    StartTime=codingSession.StartTime,
                    EndTime=codingSession.EndTime,

                });
                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
        }

    }
}

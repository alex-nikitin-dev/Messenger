using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace MessengerServer.Data
{
    public sealed class Account
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IP { get; set; } = string.Empty;
    }

    public class OleDbAccountRepository
    {
        private readonly string _connectionString;

        public OleDbAccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Account?> GetByLoginAsync(string login)
        {
            const string query =
                "SELECT ID, Login, Password, FirstName, LastName, Email, Description, IP FROM Account WHERE Login = ?";
            await using var connection = new OleDbConnection(_connectionString);
            await using var command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@p1", login);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();
            if (reader != null && await reader.ReadAsync())
            {
                return new Account
                {
                    Id = reader.GetInt32(0),
                    Login = reader.GetString(1),
                    Password = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    FirstName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    LastName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                    Email = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                    Description = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                    IP = reader.IsDBNull(7) ? string.Empty : reader.GetString(7)
                };
            }
            return null;
        }

        public Account? GetByLogin(string login) => GetByLoginAsync(login).GetAwaiter().GetResult();

        public async Task UpdateIpAsync(int id, string ip)
        {
            const string query = "UPDATE Account SET IP = ? WHERE ID = ?";
            await using var connection = new OleDbConnection(_connectionString);
            await using var command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@p1", ip);
            command.Parameters.AddWithValue("@p2", id);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public void UpdateIp(int id, string ip) => UpdateIpAsync(id, ip).GetAwaiter().GetResult();

        public async Task<IList<string>> GetWhiteListAsync(int userId)
        {
            const string query =
                "SELECT A.Login FROM WhiteList W INNER JOIN Account A ON W.FriendID = A.ID WHERE W.LoginID = ?";
            await using var connection = new OleDbConnection(_connectionString);
            await using var command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@p1", userId);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();
            var list = new List<string>();
            if (reader != null)
            {
                while (await reader.ReadAsync())
                    list.Add(reader.GetString(0));
            }
            return list;
        }

        public IList<string> GetWhiteList(int userId) => GetWhiteListAsync(userId).GetAwaiter().GetResult();

        public async Task<IList<string>> GetBlackListAsync(int userId)
        {
            const string query =
                "SELECT A.Login FROM BlackList B INNER JOIN Account A ON B.EnemyID = A.ID WHERE B.LoginID = ?";
            await using var connection = new OleDbConnection(_connectionString);
            await using var command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@p1", userId);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();
            var list = new List<string>();
            if (reader != null)
            {
                while (await reader.ReadAsync())
                    list.Add(reader.GetString(0));
            }
            return list;
        }

        public IList<string> GetBlackList(int userId) => GetBlackListAsync(userId).GetAwaiter().GetResult();
    }
}

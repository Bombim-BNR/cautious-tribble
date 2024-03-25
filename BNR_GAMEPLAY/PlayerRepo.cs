using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BNR_GAMEPLAY
{
    public class PlayerRepository
    {
        private readonly string connectionString;
        private readonly SHA512 sha512;

        public PlayerRepository(string connectionString)
        {
            this.connectionString = connectionString;
            this.sha512 = SHA512.Create();
        }

        public async Task<bool> DoesUserExist(string login)
        {
            string checkQuery = "SELECT COUNT(*) FROM Players WHERE Login = @Login";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                await connection.OpenAsync();

                checkCommand.Parameters.AddWithValue("@Login", login);
                int? existingPlayersCount = (int?)await checkCommand.ExecuteScalarAsync();
                return existingPlayersCount > 0;
            }
        }

        public async Task<bool> IsPasswordCorrect(string login, string password)
        {
            string query = "SELECT Password FROM Players WHERE Login = @Login";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@Login", login);
                string? hashedPassword = (string?)await command.ExecuteScalarAsync();
                if (hashedPassword is null)
                {
                    throw new DataException("Hash is empty");
                }
                return VerifyHashedPassword(hashedPassword, password);
            }
        }

        private string HashPassword(string password)
        {
            byte[] hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] hashedBytes = Convert.FromBase64String(hashedPassword);
            byte[] inputBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hashedBytes.SequenceEqual(inputBytes);
        }

        public async Task SavePlayer(Player player, string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                if (await DoesUserExist(login))
                {
                    if (!await IsPasswordCorrect(login, password))
                    {
                        throw new InvalidOperationException("Password is incorrect");
                    }
                    string updateQuery = "UPDATE Players SET Name = @Name, Score = @Score, Exp = @Exp WHERE Login = @Login";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Login", login);
                        updateCommand.Parameters.AddWithValue("@Name", player.Name);
                        updateCommand.Parameters.AddWithValue("@Score", player.Score);
                        updateCommand.Parameters.AddWithValue("@Exp", player.CurrentLevel.Value);
                        await updateCommand.ExecuteNonQueryAsync();
                    }
                }
                else
                {
                    string insertQuery = "INSERT INTO Players (Id, Login, Password, Name, Score, Exp) VALUES (@Id, @Login, @Password, @Name, @Score, @Exp)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Id", player.Id);
                        insertCommand.Parameters.AddWithValue("@Login", login);
                        insertCommand.Parameters.AddWithValue("@Password", HashPassword(password));
                        insertCommand.Parameters.AddWithValue("@Name", player.Name);
                        insertCommand.Parameters.AddWithValue("@Score", player.Score);
                        insertCommand.Parameters.AddWithValue("@Exp", player.CurrentLevel.Value);
                        await insertCommand.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        public async Task<Player> LoadPlayer(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                if (await DoesUserExist(login))
                {
                    if (!await IsPasswordCorrect(login, password))
                    {
                        throw new InvalidOperationException("Password is incorrect");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Player does not exist.");
                }
                // Retrieve player data
                string selectQuery = "SELECT Id, Name, Score, Exp FROM Players WHERE Login = @Login";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Login", login);
                    using (SqlDataReader reader = await selectCommand.ExecuteReaderAsync())
                    {
                        await reader.ReadAsync();
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int score = reader.GetInt32(2);
                        int exp = reader.GetInt32(3);

                        Level level = new Level(exp);
                        Player player = new Player(id, name, score, level);
                        return player;


                    }
                }
            }
        }
    }
}

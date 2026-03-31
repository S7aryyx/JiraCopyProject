using JiraCopyProject.Database;
using JiraCopyProject.Logic.Models;
using Npgsql;
using System;
using System.Data;

namespace JiraCopyProject.Logic.Services
{
    public static class AccountService
    {
        public static int Register(string login, string clearPassword, string email, string fullname, string position)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(clearPassword);
            string sql = "SELECT \"RegisterAccount\"(@login, @hash, @email, @fullname, @position)";
            var parameters = new[]
            {
                new NpgsqlParameter("@login", login),
                new NpgsqlParameter("@hash", hash),
                new NpgsqlParameter("@email", email),
                new NpgsqlParameter("@fullname", fullname),
                new NpgsqlParameter("@position", string.IsNullOrEmpty(position) ? DBNull.Value : (object)position)
            };
            object result = Database.Database.ExecuteScalar(sql, parameters);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(result);
            }
        }

        public static (int Id, string Role, int Status) Authenticate(string login, string clearPassword)
        {
            string sql = "SELECT id, password_hash, role, is_active FROM \"Accounts\" WHERE login = @login";
            var param = new NpgsqlParameter("@login", login);
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0)
            {
                return (0, "", 0);
            }

            DataRow row = dt.Rows[0];
            string storedHash = row["password_hash"].ToString();
            bool isActive = Convert.ToBoolean(row["is_active"]);
            if (!isActive)
            {
                return (Convert.ToInt32(row["id"]), row["role"].ToString(), -1);
            }
            bool isValid = BCrypt.Net.BCrypt.Verify(clearPassword, storedHash);
            if (!isValid)
            {
                return (0, "", 0);
            }

            return (Convert.ToInt32(row["id"]), row["role"].ToString(), 1);
        }

        public static Account GetAccountById(int id)
        {
            string sql = "SELECT * FROM \"Accounts\" WHERE id = @id";
            var param = new NpgsqlParameter("@id", id);
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = dt.Rows[0];
            string position = row["position"] == DBNull.Value ? null : row["position"].ToString();
            object createdObj = row["created_at"];
            DateTime createdAt = createdObj is DateOnly d ? d.ToDateTime(TimeOnly.MinValue) : Convert.ToDateTime(createdObj);
            return new Account(
                Convert.ToInt32(row["id"]),
                row["login"].ToString(),
                row["password_hash"].ToString(),
                row["email"].ToString(),
                row["fullname"].ToString(),
                position,
                row["role"].ToString(),
                createdAt,
                Convert.ToBoolean(row["is_active"])
            );
        }

        public static DataTable GetAllUsers()
        {
            string sql = "SELECT id, login, fullname, role, is_active FROM \"Accounts\" ORDER BY id";
            return Database.Database.ExecuteQuery(sql);
        }
    }
}
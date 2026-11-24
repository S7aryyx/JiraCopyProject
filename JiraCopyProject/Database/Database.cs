using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace JiraCopyProject.Database
{
    /// <summary>
    /// Provides PostgreSQL access. Connection details are loaded from .NET User Secrets
    /// or environment variables and are never stored in source code.
    /// </summary>
    public static class Database
    {
        private static readonly Lazy<string> ConnectionString = new(LoadConnectionString);

        private static string LoadConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Database).Assembly, optional: true)
                .AddEnvironmentVariables()
                .Build();

            string? connectionString = configuration.GetConnectionString("JiraData");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Не найдена строка подключения к PostgreSQL. " +
                    "Настройте секрет ConnectionStrings:JiraData через dotnet user-secrets " +
                    "или переменную окружения ConnectionStrings__JiraData.");
            }

            return connectionString;
        }

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString.Value);
        }

        public static int ExecuteNonQuery(string sql, NpgsqlParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string sql, NpgsqlParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();
            return cmd.ExecuteScalar();
        }

        public static DataTable ExecuteQuery(string sql, NpgsqlParameter[]? parameters = null)
        {
            var dataTable = new DataTable();

            using var conn = GetConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            using var adapter = new NpgsqlDataAdapter(cmd);
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}

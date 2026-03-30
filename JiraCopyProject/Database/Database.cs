using Npgsql;
using System.Data;

namespace JiraCopyProject.Database
{
    public static class Database
    {
        private static string connectionString = "Host=46.191.235.28;Port=5432;Database=jiracopy;Username=postgres;Password=Asdf=1234Asdf=1234";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        // Выполнение запроса без возврата данных (INSERT, UPDATE, DELETE, CALL)
        public static int ExecuteNonQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Выполнение запроса с возвратом одного значения
        public static object ExecuteScalar(string sql, NpgsqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // Выполнение запроса с возвратом таблицы данных (SELECT)
        public static DataTable ExecuteQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}
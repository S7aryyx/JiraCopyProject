using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using Npgsql;

namespace JiraCopyProject.Database
{
    public class Database
    {
        private string connectionString = "Host=46.191.235.28;Port=5432;Database=jiracopy;Username=postgres;Password=Asdf=1234Asdf=1234";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        //Метод для работы с обычными процедурами (которые не возвращают результат)
        public int ExecuteNonQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                }
                return cmd.ExecuteNonQuery();
            }
        }
        //Метод для работы с процедурами, которые возвращают результат (ответ)

        public object ExecuteScalar(string sql, NpgsqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                }
                return cmd.ExecuteScalar(); //Обработчик (Ловец) ответов от БД (не путать с Reader)
                //Тут мы ловим именно статус выполнения запроса (и\или процедур)
            }
        }
        //Метод для работы с процедурами, которые возвращают результат в ВИДЕ ТАБЛИЦЫ)

        public DataTable ExecuteQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            var dataTable = new DataTable(); //Создал пустую ВИРТУАЛЬНУЮ таблицу (в памяти C#)
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    conn.Open();
                    cmd.Parameters.AddRange(parameters);
                    using (var adapter = new NpgsqlDataAdapter(cmd)) //Адаптер - это мост между БД и нашей виртуальной таблицей
                                                                     //(DataTable), который позволяет заполнять её данными из БД
                    {
                        adapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }
        }
        //public void SetConnectionString(string newConnectionString)
        //{
        //    connectionString = newConnectionString;
        //}
    }
}




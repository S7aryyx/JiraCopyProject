using System;
using System.Collections.Generic;
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


        //Вызов N процедуры (Заведомо без возвращаемых данных);

        //Вызов N процедуры (Заведомо с возвращаемыми данными);

        //Вызов N функции (Ответ в виде таблиц(ы) );
    }
}

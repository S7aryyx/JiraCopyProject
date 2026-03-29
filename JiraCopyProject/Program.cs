using JiraCopyProject.Database;
using JiraCopyProject.Models;
using Npgsql;
using System.Data;
using System.Runtime.InteropServices;

namespace JiraCopyProject
{
    class Program
    {
        static Account currentUser = null; //текущий аккаунт (под которым мы авторизируемся)
        static string hashPassword = null;
        static string password = null;


        static void Main()
        {
            Console.WriteLine("Программа для хэширования пароля с помощью BCrypt");
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введите пароль для хэширования:");
            hashPassword = BCrypt.Net.BCrypt.HashPassword(Console.ReadLine());
            
        }
        public int RegisterNewAccount(string login , string clear_password , string email , string fullname , string position)
        {
            string hash_pass = BCrypt.Net.BCrypt.HashPassword(clear_password); //Захэшировал пароль (не путать с SHA-256\512)

            //Произвести проверку на наличие такого логина в БД (чтобы не было дубликатов) (МИНИМУМ)

            //Произвести проверку на наличие такого логина,ХЭША,должности в БД (чтобы не было дубликатов) (ИДЕАЛ)

            string query = "SELECT \"RegisterAccount\"(@login,@hash_pass,@email,@fullname,@position)";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@login", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = login },
                new NpgsqlParameter("@hash_pass", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = hash_pass },
                new NpgsqlParameter("@email", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = email },
                new NpgsqlParameter("@fullname", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fullname },
                new NpgsqlParameter("@position", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = position }
             };
           

            return Convert.ToInt32(Database.Database.ExecuteQuery(query, parameters));
        }
        }
    }

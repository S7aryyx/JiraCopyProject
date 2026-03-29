using JiraCopyProject.Database;
using JiraCopyProject.Models;
using Npgsql;
using System.Data;

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
    }
}
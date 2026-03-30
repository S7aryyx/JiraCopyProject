using JiraCopyProject.Database;
using JiraCopyProject.Models;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;

namespace JiraCopyProject
{
    class Program
    {
        static Account currentUser = null;
        static int? currentUserTeamId = null;
        static string currentUserTeamName = null;

        static void Main(string[] args)
        {
            Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                if (currentUser == null)
                {
                    ShowMainMenu();
                    string choice = Console.ReadLine();
                    if (choice == "1") Register();
                    else if (choice == "2") Login();
                    else if (choice == "0") exit = true;
                    else Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }
                else
                {
                    ShowUserMenu();
                    string choice = Console.ReadLine();
                    if (choice == "1") CreateTask();
                    else if (choice == "2") ShowUserTasks();
                    else if (choice == "3") EditTask();
                    else if (choice == "4") Logout();
                    else if (choice == "0") exit = true;
                    else Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }

                if (!exit)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.WriteLine("До свидания!");
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        Jira Copy Project");
            Console.WriteLine("======================================");
            Console.WriteLine("  1. Регистрация");
            Console.WriteLine("  2. Вход в аккаунт");
            Console.WriteLine("  0. Выход");
            Console.WriteLine("======================================");
            Console.Write("Ваш выбор: ");
        }

        static void ShowUserMenu()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine($"  Добро пожаловать, {currentUser.GetFullname()}!");
            Console.WriteLine($"  ID: {currentUser.GetId()} | Роль: {currentUser.GetRole()}");
            string pos = currentUser.GetPosition() ?? "не указана";
            Console.WriteLine($"  Должность: {pos}");
            if (currentUserTeamId.HasValue)
                Console.WriteLine($"  Команда: {currentUserTeamName} (ID: {currentUserTeamId})");
            else
                Console.WriteLine("  Команда: не состоит");
            Console.WriteLine("============================================================");
            Console.WriteLine("  1. Создать задачу");
            Console.WriteLine("  2. Мои задачи (назначенные мне)");
            Console.WriteLine("  3. Редактировать задачу (только свои)");
            Console.WriteLine("  4. Выйти из аккаунта");
            Console.WriteLine("  0. Выход из программы");
            Console.WriteLine("============================================================");
            Console.Write("Ваш выбор: ");
        }

        static string FormatDate(object dateObj)
        {
            if (dateObj is DateOnly dateOnly) return dateOnly.ToDateTime(TimeOnly.MinValue).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(dateObj).ToString("yyyy-MM-dd");
        }

        static void Register()
        {
            Console.Clear();
            Console.WriteLine("=== Регистрация нового пользователя ===\n");

            Console.Write("Логин: ");
            string login = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("ФИО: ");
            string fullname = Console.ReadLine();
            Console.Write("Должность (необязательно): ");
            string position = Console.ReadLine();

            int result = RegisterNewAccount(login, password, email, fullname, position);
            string msg = result == 1 ? "Регистрация прошла успешно!" :
                         result == 0 ? "Ошибка: Логин уже занят." :
                         result == -1 ? "Ошибка: Email уже зарегистрирован." :
                         "Неизвестная ошибка регистрации.";
            Console.WriteLine("\n" + msg);
        }

        static int RegisterNewAccount(string login, string clearPassword, string email, string fullname, string position)
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
            return result == null ? 0 : Convert.ToInt32(result);
        }

        static void Login()
        {
            Console.Clear();
            Console.WriteLine("=== Вход в аккаунт ===\n");

            Console.Write("Логин: ");
            string login = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            var (id, role, status) = AuthenticateAccount(login, password);
            if (status == 1 && id != 0)
            {
                currentUser = GetAccountById(id);
                if (currentUser == null)
                {
                    Console.WriteLine("Ошибка загрузки данных пользователя.");
                    return;
                }
                LoadUserTeam();

                Console.WriteLine($"\nДобро пожаловать, {currentUser.GetFullname()}!");
                Console.WriteLine($"ID: {currentUser.GetId()}, Роль: {currentUser.GetRole()}");
                Console.WriteLine(currentUserTeamId.HasValue ? $"Команда: {currentUserTeamName}" : "Вы не состоите ни в одной команде.");
            }
            else
            {
                Console.WriteLine("\nНеверный логин или пароль, либо аккаунт неактивен.");
            }
        }

        static (int Id, string Role, int Status) AuthenticateAccount(string login, string plainPassword)
        {
            string sql = "SELECT id, password_hash, role, is_active FROM \"Accounts\" WHERE login = @login";
            var param = new NpgsqlParameter("@login", login);
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0) return (0, "", 0);

            DataRow row = dt.Rows[0];
            string storedHash = row["password_hash"].ToString();
            bool isActive = Convert.ToBoolean(row["is_active"]);
            if (!isActive) return (Convert.ToInt32(row["id"]), row["role"].ToString(), -1);

            bool isValid = BCrypt.Net.BCrypt.Verify(plainPassword, storedHash);
            if (!isValid) return (0, "", 0);

            return (Convert.ToInt32(row["id"]), row["role"].ToString(), 1);
        }

        static Account GetAccountById(int id)
        {
            string sql = "SELECT id, login, password_hash, email, fullname, position, role, created_at, is_active FROM \"Accounts\" WHERE id = @id";
            var param = new NpgsqlParameter("@id", id);
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0) return null;

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

        static void LoadUserTeam()
        {
            string sql = @"SELECT t.id, t.name FROM ""TeamMembers"" tm JOIN ""Teams"" t ON tm.team_id = t.id WHERE tm.account_id = @userId AND tm.is_active = true LIMIT 1";
            var param = new NpgsqlParameter("@userId", currentUser.GetId());
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count > 0)
            {
                currentUserTeamId = Convert.ToInt32(dt.Rows[0]["id"]);
                currentUserTeamName = dt.Rows[0]["name"].ToString();
            }
            else
            {
                currentUserTeamId = null;
                currentUserTeamName = null;
            }
        }

        static void CreateTask()
        {
            Console.Clear();
            Console.WriteLine("=== Создание задачи ===\n");

            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();

            Console.Write("ID исполнителя (Enter - назначить на себя): ");
            string assigneeInput = Console.ReadLine();
            int assigneeId = string.IsNullOrEmpty(assigneeInput) ? currentUser.GetId() : int.Parse(assigneeInput);

            Console.Write("Срок выполнения (ГГГГ-ММ-ДД): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            string sql = "CALL \"InsertTask\"(@title, @desc, @statusId, @assignee, @creator, @dueDate, NULL)";
            var parameters = new[]
            {
                new NpgsqlParameter("@title", title),
                new NpgsqlParameter("@desc", description),
                new NpgsqlParameter("@statusId", 1),
                new NpgsqlParameter("@assignee", assigneeId),
                new NpgsqlParameter("@creator", currentUser.GetId()),
                new NpgsqlParameter("@dueDate", NpgsqlDbType.Date) { Value = dueDate }
            };

            try
            {
                Database.Database.ExecuteNonQuery(sql, parameters);
                Console.WriteLine("\nЗадача успешно создана!");
            }
            catch (Exception ex) { Console.WriteLine("\nОшибка: " + ex.Message); }
        }

        static void ShowUserTasks()
        {
            Console.Clear();
            Console.WriteLine("=== Мои задачи ===\n");

            string sql = "SELECT * FROM \"GetUserTasks\"(@p_account_id)";
            var param = new NpgsqlParameter("@p_account_id", currentUser.GetId());
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0) { Console.WriteLine("У вас нет задач."); return; }

            Console.WriteLine("ID\tНазвание\t\tСтатус\t\tСрок\t\tТип");
            Console.WriteLine(new string('-', 75));
            foreach (DataRow row in dt.Rows)
            {
                string personal = Convert.ToBoolean(row["is_personal"]) ? "Личная" : "Командная";
                Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{row["status_name"]}\t\t{FormatDate(row["due_date"])}\t{personal}");
            }

            Console.WriteLine("\nДля просмотра деталей введите ID задачи (0 - вернуться в меню): ");
            if (int.TryParse(Console.ReadLine(), out int taskId) && taskId > 0)
                ShowTaskDetails(taskId);
        }

        static void ShowTaskDetails(int taskId)
        {
            Console.Clear();
            Console.WriteLine("=== Детали задачи ===\n");

            string detailsSql = @"
                SELECT t.id, t.title, t.description, t.due_date, 
                       s.name AS status_name,
                       a.fullname AS creator_fullname
                FROM ""Tasks"" t
                JOIN ""Statuses"" s ON t.status_id = s.id
                JOIN ""Accounts"" a ON t.creator_id = a.id
                WHERE t.id = @taskId";

            var param = new NpgsqlParameter("@taskId", taskId);
            DataTable dtDetails = Database.Database.ExecuteQuery(detailsSql, new[] { param });
            if (dtDetails.Rows.Count == 0)
            {
                Console.WriteLine($"Задача с ID {taskId} не найдена.");
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }

            DataRow row = dtDetails.Rows[0];
            Console.WriteLine($"ID:          {row["id"]}");
            Console.WriteLine($"Название:    {row["title"]}");
            Console.WriteLine($"Описание:    {row["description"]}");
            Console.WriteLine($"Срок сдачи:  {FormatDate(row["due_date"])}");
            Console.WriteLine($"Статус:      {row["status_name"]}");
            Console.WriteLine($"Кем создана: {row["creator_fullname"]}");

            string subtasksSql = @"
                SELECT t.id, t.title, s.name AS status_name, t.due_date
                FROM ""Tasks"" t
                JOIN ""Statuses"" s ON t.status_id = s.id
                WHERE t.parent_task_id = @taskId
                ORDER BY t.id";

            DataTable dtSubtasks = Database.Database.ExecuteQuery(subtasksSql, new[] { param });

            Console.WriteLine("\n--- Подзадачи ---");
            if (dtSubtasks.Rows.Count == 0) Console.WriteLine("Нет подзадач.");
            else
            {
                Console.WriteLine("ID\tНазвание\t\tСтатус\t\tСрок");
                Console.WriteLine(new string('-', 60));
                foreach (DataRow sub in dtSubtasks.Rows)
                {
                    Console.WriteLine($"{sub["id"]}\t{sub["title"]}\t\t{sub["status_name"]}\t\t{FormatDate(sub["due_date"])}");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void EditTask()
        {
            Console.Clear();
            Console.WriteLine("=== Редактирование задачи (только созданные вами) ===\n");

            string tasksSql = "SELECT id, title, description, due_date FROM \"Tasks\" WHERE creator_id = @creatorId";
            var param = new NpgsqlParameter("@creatorId", currentUser.GetId());
            DataTable tasksDt = Database.Database.ExecuteQuery(tasksSql, new[] { param });
            if (tasksDt.Rows.Count == 0) { Console.WriteLine("Вы не создали ни одной задачи."); return; }

            Console.WriteLine("Ваши задачи:");
            Console.WriteLine("ID    Название                       Срок");
            foreach (DataRow row in tasksDt.Rows)
            {
                Console.WriteLine($"{row["id"]}     {row["title"]}               {FormatDate(row["due_date"])}");
            }

            Console.Write("\nВведите ID задачи для редактирования: ");
            int taskId = int.Parse(Console.ReadLine());

            DataRow[] taskRows = tasksDt.Select($"id = {taskId}");
            if (taskRows.Length == 0)
            {
                Console.WriteLine("Задача с таким ID не найдена или вы не являетесь её создателем.");
                return;
            }

            Console.Write("Новое название (Enter - оставить без изменений): ");
            string newTitle = Console.ReadLine();
            Console.Write("Новое описание (Enter - оставить без изменений): ");
            string newDesc = Console.ReadLine();
            Console.Write("Новый срок (ГГГГ-ММ-ДД, Enter - оставить без изменений): ");
            string newDueDateStr = Console.ReadLine();

            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@p_id", taskId),
                new NpgsqlParameter("@p_title", string.IsNullOrEmpty(newTitle) ? DBNull.Value : (object)newTitle),
                new NpgsqlParameter("@p_description", string.IsNullOrEmpty(newDesc) ? DBNull.Value : (object)newDesc),
                new NpgsqlParameter("@p_status_id", DBNull.Value),
                new NpgsqlParameter("@p_create_date", DBNull.Value),
                new NpgsqlParameter("@p_team_id", DBNull.Value),
                new NpgsqlParameter("@p_assignee_id", DBNull.Value),
                new NpgsqlParameter("@p_creator_id", DBNull.Value),
                new NpgsqlParameter("@p_due_date", string.IsNullOrEmpty(newDueDateStr) ? DBNull.Value : (object)DateTime.Parse(newDueDateStr)),
                new NpgsqlParameter("@p_parent_task_id", DBNull.Value),
                new NpgsqlParameter("@p_changed_by_id", currentUser.GetId()),
                new NpgsqlParameter("@p_reason", "Редактирование через консоль")
            };
            if (!string.IsNullOrEmpty(newDueDateStr))
                parameters[8].NpgsqlDbType = NpgsqlDbType.Date;

            string updateSql = "CALL \"UpdateTask\"(@p_id, @p_title, @p_description, @p_status_id, @p_create_date, @p_team_id, @p_assignee_id, @p_creator_id, @p_due_date, @p_parent_task_id, @p_changed_by_id, @p_reason)";
            try
            {
                Database.Database.ExecuteNonQuery(updateSql, parameters.ToArray());
                Console.WriteLine("\nЗадача успешно обновлена!");
            }
            catch (Exception ex) { Console.WriteLine("\nОшибка: " + ex.Message); }
        }

        static void Logout()
        {
            currentUser = null;
            currentUserTeamId = null;
            currentUserTeamName = null;
            Console.WriteLine("\nВы вышли из аккаунта.");
        }
    }
}
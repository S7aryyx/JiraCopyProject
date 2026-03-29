using JiraConsole.Models;
using JiraCopyProject.Database;
using JiraCopyProject.Models;
using Npgsql;
using System.Data;

namespace JiraConsole
{
    class Program
    {
        static Account currentUser = null;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Авторизация
            if (!Authenticate())
            {
                Console.WriteLine("Не удалось войти в систему. Программа завершена.");
                return;
            }

            Console.Clear();
            Console.WriteLine($"Добро пожаловать, {currentUser.GetFullname()}! Ваша роль: {currentUser.GetRole()}");
            Console.WriteLine();

            bool exit = false;
            while (!exit)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllMyTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        EditTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        ChangeTaskStatus();
                        break;
                    case "6":
                        if (currentUser.GetRole() == "Admin" || currentUser.GetRole() == "TeamLead")
                            CreateTeam();
                        else
                            Console.WriteLine("Неверный выбор!");
                        break;
                    case "7":
                        if (currentUser.GetRole() == "Admin" || currentUser.GetRole() == "TeamLead")
                            AssignTeamTask();
                        else
                            Console.WriteLine("Неверный выбор!");
                        break;
                    case "8":
                        if (currentUser.GetRole() == "Admin" || currentUser.GetRole() == "TeamLead")
                            ShowAllTeamTasks();
                        else
                            Console.WriteLine("Неверный выбор!");
                        break;
                    case "9":
                        if (currentUser.GetRole() == "Admin" || currentUser.GetRole() == "TeamLead")
                            ShowLeaderPersonalTasks();
                        else
                            Console.WriteLine("Неверный выбор!");
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static bool Authenticate()
        {
            Console.Write("Логин: ");
            string login = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();
            // В реальном приложении здесь должно быть хэширование пароля, но для примера используем как есть
            string hash = password; // упрощённо, в боевом коде хэшируйте

            string sql = "SELECT * FROM \"AuthenticateAccount\"(@login, @hash)";
            var parameters = new[]
            {
                new NpgsqlParameter("login", login),
                new NpgsqlParameter("hash", hash)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count == 0 || Convert.ToInt32(dt.Rows[0]["status"]) != 1)
            {
                Console.WriteLine("Неверный логин или пароль, либо аккаунт заблокирован.");
                return false;
            }

            int id = Convert.ToInt32(dt.Rows[0]["account_id"]);
            string role = dt.Rows[0]["role"].ToString();

            // Получаем полные данные пользователя
            Account acc = GetAccountById(id);
            if (acc == null) return false;

            currentUser = acc;
            return true;
        }

        static Account GetAccountById(int id)
        {
            string sql = "SELECT id, login, password_hash, email, fullname, position, role, created_at, is_active FROM \"Accounts\" WHERE id = @id";
            var param = new NpgsqlParameter("id", id);
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new Account(
                Convert.ToInt32(row["id"]),
                row["login"].ToString(),
                row["password_hash"].ToString(),
                row["email"].ToString(),
                row["fullname"].ToString(),
                row["position"] == DBNull.Value ? null : row["position"].ToString(),
                row["role"].ToString(),
                Convert.ToDateTime(row["created_at"]),
                Convert.ToBoolean(row["is_active"])
            );
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("=== ГЛАВНОЕ МЕНЮ ===");
            Console.WriteLine("1. Вывести все мои задачи");
            Console.WriteLine("2. Добавить задачу");
            Console.WriteLine("3. Редактировать задачу");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("5. Изменить статус задачи");
            if (currentUser.GetRole() == "Admin" || currentUser.GetRole() == "TeamLead")
            {
                Console.WriteLine("--- Административные функции ---");
                Console.WriteLine("6. Создать команду");
                Console.WriteLine("7. Назначить общую командную задачу");
                Console.WriteLine("8. Посмотреть задачи всей команды");
                Console.WriteLine("9. Посмотреть личные задачи начальника");
            }
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");
        }

        static void ShowAllMyTasks()
        {
            Console.WriteLine("=== Мои задачи ===");
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM \"GetUserTasks\"(@p_account_id)",
                new[] { new NpgsqlParameter("p_account_id", currentUser.GetId()) });
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Нет задач.");
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                string personal = Convert.ToBoolean(row["is_personal"]) ? "личная" : "командная";
                Console.WriteLine($"ID: {row["id"]}, Название: {row["title"]}, Статус: {row["status_name"]}, Срок: {row["due_date"]}, Тип: {personal}");
            }
        }

        static void AddTask()
        {
            Console.Write("Название задачи: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string desc = Console.ReadLine();
            Console.Write("ID исполнителя (assignee_id): ");
            int assigneeId = int.Parse(Console.ReadLine());
            Console.Write("Срок выполнения (ГГГГ-ММ-ДД): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            string sql = "CALL \"InsertTask\"(@title, @desc, 1, @assignee, @creator, @dueDate, NULL)";
            var parameters = new[]
            {
                new NpgsqlParameter("title", title),
                new NpgsqlParameter("desc", desc),
                new NpgsqlParameter("assignee", assigneeId),
                new NpgsqlParameter("creator", currentUser.GetId()),
                new NpgsqlParameter("dueDate", dueDate)
            };
            DatabaseHelper.ExecuteNonQuery(sql, parameters);
            Console.WriteLine("Задача добавлена.");
        }

        static void EditTask()
        {
            Console.Write("ID задачи для редактирования: ");
            int taskId = int.Parse(Console.ReadLine());
            Console.Write("Новое название (оставьте пустым, если не менять): ");
            string title = Console.ReadLine();
            Console.Write("Новое описание (оставьте пустым, если не менять): ");
            string desc = Console.ReadLine();
            Console.Write("Новый срок (ГГГГ-ММ-ДД, оставьте пустым, если не менять): ");
            string dueDateStr = Console.ReadLine();
            DateTime? dueDate = string.IsNullOrEmpty(dueDateStr) ? (DateTime?)null : DateTime.Parse(dueDateStr);

            // Формируем вызов процедуры UpdateTask
            // Используем параметры по умолчанию
            string sql = "CALL \"UpdateTask\"(@p_id, @p_title, @p_desc, NULL, NULL, NULL, NULL, NULL, @p_due_date, NULL, @p_changed_by, @p_reason)";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_id", taskId),
                new NpgsqlParameter("p_title", string.IsNullOrEmpty(title) ? DBNull.Value : (object)title),
                new NpgsqlParameter("p_desc", string.IsNullOrEmpty(desc) ? DBNull.Value : (object)desc),
                new NpgsqlParameter("p_due_date", dueDate.HasValue ? (object)dueDate.Value : DBNull.Value),
                new NpgsqlParameter("p_changed_by", currentUser.GetId()),
                new NpgsqlParameter("p_reason", "Редактирование через консоль")
            };
            DatabaseHelper.ExecuteNonQuery(sql, parameters.ToArray());
            Console.WriteLine("Задача обновлена.");
        }

        static void DeleteTask()
        {
            Console.Write("ID задачи для удаления: ");
            int taskId = int.Parse(Console.ReadLine());
            string sql = "CALL \"RemoveTask\"(@p_id)";
            var param = new NpgsqlParameter("p_id", taskId);
            DatabaseHelper.ExecuteNonQuery(sql, new[] { param });
            Console.WriteLine("Задача удалена.");
        }

        static void ChangeTaskStatus()
        {
            Console.Write("ID задачи: ");
            int taskId = int.Parse(Console.ReadLine());
            Console.Write("Новый статус (ID): ");
            int newStatus = int.Parse(Console.ReadLine());
            Console.Write("Причина изменения: ");
            string reason = Console.ReadLine();

            string sql = "CALL \"UpdateTaskStatus\"(@p_task_id, @p_new_status, @p_changed_by, @p_reason)";
            var parameters = new[]
            {
                new NpgsqlParameter("p_task_id", taskId),
                new NpgsqlParameter("p_new_status", newStatus),
                new NpgsqlParameter("p_changed_by", currentUser.GetId()),
                new NpgsqlParameter("p_reason", reason)
            };
            DatabaseHelper.ExecuteNonQuery(sql, parameters);
            Console.WriteLine("Статус изменён.");
        }

        // --- Функции для админа/тимлида ---

        static void CreateTeam()
        {
            Console.Write("Название команды: ");
            string name = Console.ReadLine();
            Console.Write("Описание: ");
            string desc = Console.ReadLine();
            Console.Write("ID руководителя команды (team_lead_id): ");
            int leadId = int.Parse(Console.ReadLine());

            string sql = "INSERT INTO \"Teams\" (name, description, team_lead_id) VALUES (@name, @desc, @lead)";
            var parameters = new[]
            {
                new NpgsqlParameter("name", name),
                new NpgsqlParameter("desc", desc),
                new NpgsqlParameter("lead", leadId)
            };
            DatabaseHelper.ExecuteNonQuery(sql, parameters);
            Console.WriteLine("Команда создана.");
        }

        static void AssignTeamTask()
        {
            Console.Write("Название командной задачи: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string desc = Console.ReadLine();
            Console.Write("ID команды: ");
            int teamId = int.Parse(Console.ReadLine());
            Console.Write("Срок выполнения (ГГГГ-ММ-ДД): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            // Используем процедуру назначения задачи команде (без исполнителя)
            string sql = "CALL \"AssignTaskToTeam\"(@title, @desc, @teamId, @creator, @dueDate, 1)";
            var parameters = new[]
            {
                new NpgsqlParameter("title", title),
                new NpgsqlParameter("desc", desc),
                new NpgsqlParameter("teamId", teamId),
                new NpgsqlParameter("creator", currentUser.GetId()),
                new NpgsqlParameter("dueDate", dueDate)
            };
            DatabaseHelper.ExecuteNonQuery(sql, parameters);
            Console.WriteLine("Командная задача создана.");
        }

        static void ShowAllTeamTasks()
        {
            Console.Write("Введите ID команды: ");
            int teamId = int.Parse(Console.ReadLine());
            string sql = @"SELECT t.id, t.title, t.description, s.name as status, t.due_date, a.fullname as assignee 
                           FROM \"Tasks\" t
                           LEFT JOIN \"Statuses\" s ON t.status_id = s.id
                           LEFT JOIN \"Accounts\" a ON t.assignee_id = a.id
                           WHERE t.team_id = @teamId";
            var param = new NpgsqlParameter("teamId", teamId);
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("У команды нет задач.");
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"ID: {row["id"]}, Название: {row["title"]}, Статус: {row["status"]}, Срок: {row["due_date"]}, Исполнитель: {row["assignee"]}");
            }
        }

        static void ShowLeaderPersonalTasks()
        {
            // "Личные задачи начальника" – это задачи, где исполнитель = текущий пользователь (руководитель)
            Console.WriteLine("=== Личные задачи руководителя ===");
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM \"GetUserTasks\"(@p_account_id)",
                new[] { new NpgsqlParameter("p_account_id", currentUser.GetId()) });
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Нет личных задач.");
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToBoolean(row["is_personal"]))
                {
                    Console.WriteLine($"ID: {row["id"]}, Название: {row["title"]}, Статус: {row["status_name"]}, Срок: {row["due_date"]}");
                }
            }
        }
    }
}
using JiraCopyProject.Database;
using JiraCopyProject.Logic.Models;
using JiraCopyProject.Logic.Services;
using Npgsql;
using System;
using System.Data;

namespace JiraCopyProject
{
    class Program
    {
        static Account currentUser = null;
        static int? currentUserTeamId = null;
        static string currentUserTeamName = null;

        static string FormatDateString(object dateObj)
        {
            if (dateObj == null || dateObj == DBNull.Value) return "—";
            if (dateObj is DateOnly dateOnly)
                return dateOnly.ToString("yyyy-MM-dd");
            if (dateObj is DateTime dateTime)
                return dateTime.ToString("yyyy-MM-dd");
            return "—";
        }

        static void Main()
        {
            Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                if (currentUser == null)
                {
                    ShowMainMenu();
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1: Register(); break;
                            case 2: Login(); break;
                            case 0: exit = true; break;
                            default: Console.WriteLine("Неверный выбор. Попробуйте снова."); break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод.");
                    }
                }
                else
                {
                    ShowUserMenu();
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1: CreateTask(); break;
                            case 2: ShowUserTasks(); break;
                            case 3: EditTask(); break;
                            case 4: ChangeTaskStatus(); break;
                            case 5: Logout(); break;
                            case 0: exit = true; break;
                            case 6 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": CreateTeam(); break;
                            case 7 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ListAllUsers(); break;
                            case 8 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": AddUserToMyTeam(); break;
                            case 9 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": AssignTaskToAnotherUser(); break;
                            case 10 when currentUser.GetRole() == "Admin": TransferTeamLead(); break;
                            case 11 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": AddTeamTask(); break;
                            case 12 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ManageTeams(); break;
                            case 13 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ShowAllTeams(); break;
                            case 14 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ShowTeamMembers(); break;
                            case 15 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ShowDeletingTeam(); break;
                            case 16 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": CopyTaskUI(); break;
                            case 17 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": CreateSubtaskUI(); break;
                            case 18 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ShowSubtaskTree(); break;
                            case 19 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ManageComments(); break;
                            case 20 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": ManageTags(); break;
                            case 21 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": FiltersMenu(); break;
                            case 22 when currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin": HistoryMenu(); break;
                            case 23: ShowUserStats(); break;
                            default: Console.WriteLine("Неверный выбор. Попробуйте снова."); break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод.");
                    }
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

            string position = currentUser.GetPosition();
            Console.WriteLine(string.IsNullOrEmpty(position) ? "  Должность: не указана" : $"  Должность: {position}");

            if (currentUserTeamId.HasValue)
                Console.WriteLine($"  Команда: {currentUserTeamName} (ID: {currentUserTeamId})");
            else
                Console.WriteLine("  Команда: не состоит");

            Console.WriteLine("============================================================");
            Console.WriteLine("  1. Создать задачу");
            Console.WriteLine("  2. Мои задачи");
            Console.WriteLine("  3. Редактировать задачу");
            Console.WriteLine("  4. Изменить статус задачи");
            Console.WriteLine("  5. Выйти из аккаунта");
            Console.WriteLine("  0. Выход из программы");

            string role = currentUser.GetRole();
            if (role == "TeamLead" || role == "Admin")
            {
                Console.WriteLine("--- Командные функции ---");
                Console.WriteLine("  6. Создать команду");
                Console.WriteLine("  7. Список всех пользователей");
                Console.WriteLine("  8. Добавить пользователя в команду");
                Console.WriteLine("  9. Назначить задачу пользователю");
                Console.WriteLine("  11. Создать задачу на команду");
                Console.WriteLine("  12. Управление командами");
                Console.WriteLine("  13. Посмотреть команды");
                Console.WriteLine("  14. Участники команды");
                Console.WriteLine("  15. Удалить команду");
                Console.WriteLine("--- Расширенные функции ---");
                Console.WriteLine("  16. Копировать задачу");
                Console.WriteLine("  17. Создать подзадачу");
                Console.WriteLine("  18. Дерево подзадач");
                Console.WriteLine("  19. Комментарии");
                Console.WriteLine("  20. Теги");
                Console.WriteLine("  21. Фильтры и поиск");
                Console.WriteLine("  22. История изменений");
            }
            if (role == "Admin")
            {
                Console.WriteLine("--- Администрирование ---");
                Console.WriteLine("  10. Передать лидерство в команде");
            }
            Console.WriteLine("  23. Моя статистика");
            Console.WriteLine("============================================================");
            Console.Write("Ваш выбор: ");
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

            int result = AccountService.Register(login, password, email, fullname, position);
            string msg = result switch
            {
                1 => "Регистрация прошла успешно!",
                0 => "Ошибка: Логин уже занят.",
                -1 => "Ошибка: Email уже зарегистрирован.",
                _ => "Неизвестная ошибка регистрации."
            };
            Console.WriteLine("\n" + msg);
        }
        static void Login()
        {
            Console.Clear();
            Console.WriteLine("=== Вход в аккаунт ===\n");

            Console.Write("Логин: ");
            string login = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            try
            {
                var (id, role, status) = AccountService.Authenticate(login, password);

                if (status != 1 || id == 0)
                {
                    Console.WriteLine(status == -1 ? "\nАккаунт неактивен." : "\nНеверный логин или пароль.");
                    return;
                }

                string userSql = @"
                    SELECT id, login, password_hash, email, fullname, position, role, created_at, is_active 
                    FROM accounts.""Accounts"" 
                    WHERE id = @id";

                var userParams = new[] { new NpgsqlParameter("@id", id) };
                DataTable userDt = Database.Database.ExecuteQuery(userSql, userParams);

                if (userDt.Rows.Count == 0)
                {
                    Console.WriteLine("\nОшибка загрузки данных пользователя.");
                    return;
                }

                DataRow row = userDt.Rows[0];

                DateTime createdAt;
                object createdObj = row["created_at"];
                if (createdObj is DateOnly dateOnly)
                    createdAt = dateOnly.ToDateTime(TimeOnly.MinValue);
                else
                    createdAt = Convert.ToDateTime(createdObj);

                currentUser = new Account(
                    id: Convert.ToInt32(row["id"]),
                    login: row["login"].ToString(),
                    passwordHash: row["password_hash"].ToString(),
                    email: row["email"].ToString(),
                    fullname: row["fullname"].ToString(),
                    position: row["position"] == DBNull.Value ? null : row["position"].ToString(),
                    role: row["role"].ToString(),
                    createdAt: createdAt,
                    isActive: Convert.ToBoolean(row["is_active"])
                );

                var team = TeamService.GetUserTeam(id);
                currentUserTeamId = team.Id;
                currentUserTeamName = team.Name;

                Console.WriteLine($"\nДобро пожаловать, {currentUser.GetFullname()}!");
                Console.WriteLine($"ID: {currentUser.GetId()}, Роль: {currentUser.GetRole()}");
                Console.WriteLine(currentUserTeamId.HasValue ? $"Команда: {currentUserTeamName}" : "Вы не состоите ни в одной команде.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка при входе: {ex.Message}");
            }
        }
        static void Logout()
        {
            currentUser = null;
            currentUserTeamId = null;
            currentUserTeamName = null;
            Console.WriteLine("\nВы вышли из аккаунта.");
        }
        static void CreateTask()
        {
            Console.Clear();
            Console.WriteLine("=== Создание задачи ===\n");

            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();

            int assigneeId;
            string role = currentUser.GetRole();
            if (role == "User")
            {
                assigneeId = currentUser.GetId();
                Console.WriteLine($"Задача будет назначена на вас (ID: {assigneeId})");
            }
            else
            {
                Console.Write("ID исполнителя (Enter - назначить на себя): ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    assigneeId = currentUser.GetId();
                else if (!int.TryParse(input, out assigneeId))
                {
                    Console.WriteLine("Неверный ID. Операция отменена.");
                    return;
                }
            }

            Console.Write("Срок выполнения (ГГГГ-ММ-ДД): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
            {
                Console.WriteLine("Неверный формат даты.");
                return;
            }

            bool success = TaskService.CreateTask(title, description, assigneeId, currentUser.GetId(), dueDate);
            Console.WriteLine(success ? "\nЗадача успешно создана!" : "\nОшибка при создании задачи.");
        }
        static void ShowUserTasks()
        {
            Console.Clear();
            Console.WriteLine("=== Мои задачи ===\n");

            DataTable dt = TaskService.GetUserTasks(currentUser.GetId());
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("У вас нет задач.");
                return;
            }

            Console.WriteLine("ID\tНазвание\t\tСтатус\t\tСрок\t\tТип");
            foreach (DataRow row in dt.Rows)
            {
                string personal = Convert.ToBoolean(row["is_personal"]) ? "Личная" : "Командная";
                Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{row["status_name"]}\t\t{FormatDateString(row["due_date"])}\t{personal}");
            }

            Console.Write("\nВведите ID задачи для просмотра деталей (0 - назад): ");
            if (int.TryParse(Console.ReadLine(), out int taskId) && taskId > 0)
                ShowTaskDetails(taskId);
        }
        static void ShowTaskDetails(int taskId)
        {
            Console.Clear();
            Console.WriteLine("=== Детали задачи ===\n");

            DataTable dtDetails = TaskService.GetTaskDetails(taskId);
            if (dtDetails.Rows.Count == 0)
            {
                Console.WriteLine($"Задача с ID {taskId} не найдена.");
                return;
            }

            DataRow row = dtDetails.Rows[0];
            Console.WriteLine($"ID:          {row["id"]}");
            Console.WriteLine($"Название:    {row["title"]}");
            Console.WriteLine($"Описание:    {row["description"]}");
            Console.WriteLine($"Срок:        {FormatDateString(row["due_date"])}");
            Console.WriteLine($"Статус:      {row["status_name"]}");
            Console.WriteLine($"Создатель:   {row["creator_fullname"]}");

            DataTable dtSubtasks = TaskService.GetTaskSubtasks(taskId);
            Console.WriteLine("\n--- Подзадачи ---");
            if (dtSubtasks.Rows.Count == 0)
            {
                Console.WriteLine("Нет подзадач.");
            }
            else
            {
                foreach (DataRow sub in dtSubtasks.Rows)
                {
                    Console.WriteLine($"  └─ {sub["title"]} (ID: {sub["id"]}, статус: {sub["status_name"]}, срок: {FormatDateString(sub["due_date"])})");
                }
            }
        }
        static void EditTask()
        {
            Console.Clear();
            Console.WriteLine("=== Редактирование задачи ===\n");

            DataTable tasksDt = TaskService.GetUserCreatedTasks(currentUser.GetId());
            if (tasksDt.Rows.Count == 0)
            {
                Console.WriteLine("Вы не создали ни одной задачи.");
                return;
            }

            Console.WriteLine("Ваши задачи:");
            Console.WriteLine("ID\tНазвание\t\tСрок\t\tСтатус");
            foreach (DataRow row in tasksDt.Rows)
            {
                Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{FormatDateString(row["due_date"])}\t{row["status_name"]}");
            }

            Console.Write("\nВведите ID задачи для редактирования (0 - отмена): ");
            if (!int.TryParse(Console.ReadLine(), out int taskId) || taskId == 0)
            {
                Console.WriteLine("Редактирование отменено.");
                return;
            }

            DataRow[] taskRows = tasksDt.Select($"id = {taskId}");
            if (taskRows.Length == 0)
            {
                Console.WriteLine("Задача не найдена или вы не её создатель.");
                return;
            }

            Console.Write("Новое название (Enter - без изменений): ");
            string newTitle = Console.ReadLine();
            Console.Write("Новое описание (Enter - без изменений): ");
            string newDesc = Console.ReadLine();
            Console.Write("Новый срок (ГГГГ-ММ-ДД, Enter - без изменений): ");
            string newDueDateStr = Console.ReadLine();

            DateTime? newDueDate = null;
            if (!string.IsNullOrEmpty(newDueDateStr) && DateTime.TryParseExact(newDueDateStr, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsed))
                newDueDate = parsed;

            Console.Write("Причина изменения: ");
            string reason = Console.ReadLine();
            if (string.IsNullOrEmpty(reason)) reason = "Редактирование задачи";

            bool success = TaskService.UpdateTask(
                taskId,
                string.IsNullOrEmpty(newTitle) ? null : newTitle,
                string.IsNullOrEmpty(newDesc) ? null : newDesc,
                null, null, null,
                newDueDate,
                currentUser.GetId(),
                reason
            );

            Console.WriteLine(success ? "\nЗадача успешно обновлена!" : "\nОшибка при обновлении задачи.");
        }
        static void ChangeTaskStatus()
        {
            Console.Clear();
            Console.WriteLine("=== Изменение статуса задачи ===\n");

            DataTable dt = TaskService.GetUserTasks(currentUser.GetId());
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("У вас нет доступных задач.");
                return;
            }

            Console.WriteLine("Доступные задачи:");
            Console.WriteLine("ID\tНазвание\t\tСтатус\t\tСрок");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{row["status_name"]}\t\t{FormatDateString(row["due_date"])}");
            }

            Console.Write("\nВведите ID задачи (0 - отмена): ");
            if (!int.TryParse(Console.ReadLine(), out int taskId) || taskId == 0) return;

            var (creatorId, assigneeId) = TaskService.GetTaskOwners(taskId);
            if (creatorId == 0)
            {
                Console.WriteLine("Задача не найдена.");
                return;
            }

            string role = currentUser.GetRole();
            bool canChange = role == "Admin" ||
                             (role == "TeamLead" && creatorId == currentUser.GetId()) ||
                             (role == "User" && assigneeId == currentUser.GetId());

            if (!canChange)
            {
                Console.WriteLine("У вас нет прав на изменение статуса этой задачи.");
                return;
            }

            DataTable statuses = TaskService.GetAvailableStatuses();
            Console.WriteLine("\nДоступные статусы:");
            foreach (DataRow row in statuses.Rows)
                Console.WriteLine($"{row["id"]}. {row["name"]}");

            Console.Write("\nВыберите ID нового статуса: ");
            if (!int.TryParse(Console.ReadLine(), out int newStatusId)) return;

            Console.Write("Причина изменения: ");
            string reason = Console.ReadLine();

            bool success = TaskService.ChangeTaskStatus(taskId, newStatusId, currentUser.GetId(), reason);
            Console.WriteLine(success ? "\nСтатус успешно изменён!" : "\nОшибка при изменении статуса.");
        }
        static void AssignTaskToAnotherUser()
        {
            Console.Clear();
            Console.WriteLine("=== Назначение задачи пользователю ===\n");

            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();
            Console.Write("ID исполнителя: ");
            if (!int.TryParse(Console.ReadLine(), out int assigneeId)) return;
            Console.Write("Срок (ГГГГ-ММ-ДД): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate)) return;

            bool success = TaskService.CreateTask(title, description, assigneeId, currentUser.GetId(), dueDate);
            Console.WriteLine(success ? "\nЗадача успешно назначена!" : "\nОшибка при назначении задачи.");
        }
        static void AddTeamTask()
        {
            Console.Clear();
            Console.WriteLine("=== Создание задачи для команды ===\n");

            DataTable teams = TeamService.GetUserLeadTeams(currentUser.GetId());
            if (teams.Rows.Count == 0)
            {
                Console.WriteLine("Вы не являетесь лидером ни одной команды.");
                return;
            }

            Console.WriteLine("Ваши команды:");
            for (int i = 0; i < teams.Rows.Count; i++)
                Console.WriteLine($"{i + 1}. {teams.Rows[i]["name"]} (ID: {teams.Rows[i]["id"]})");

            Console.Write("Выберите номер: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > teams.Rows.Count) return;

            int teamId = Convert.ToInt32(teams.Rows[choice - 1]["id"]);

            Console.Write("Название задачи: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();
            Console.Write("Срок (ГГГГ-ММ-ДД): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate)) return;

            bool success = TaskService.CreateTeamTask(title, description, teamId, currentUser.GetId(), dueDate);
            Console.WriteLine(success ? "\nЗадача для команды успешно создана!" : "\nОшибка при создании задачи.");
        }
        static void CreateTeam()
        {
            Console.Clear();
            Console.WriteLine("=== Создание команды ===\n");

            Console.Write("Название: ");
            string name = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();

            int? teamId = TeamService.CreateTeam(name, description, currentUser.GetId());
            if (teamId.HasValue)
            {
                Console.WriteLine("\nКоманда успешно создана!");
                currentUserTeamId = teamId;
                currentUserTeamName = name;
            }
            else
                Console.WriteLine("\nОшибка при создании команды.");
        }
        static void ListAllUsers()
        {
            Console.Clear();
            Console.WriteLine("=== Список пользователей ===\n");

            DataTable dt = AccountService.GetAllUsers();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Пользователи не найдены.");
                return;
            }

            Console.WriteLine("ID\tЛогин\t\tEmail\t\t\tРоль\t\tАктивен");
            Console.WriteLine(new string('-', 90));
            foreach (DataRow row in dt.Rows)
            {
                string email = row["email"].ToString();
                if (email.Length > 20) email = email.Substring(0, 17) + "...";
                Console.WriteLine($"{row["id"]}\t{row["login"]}\t\t{email}\t{row["role"]}\t\t{(Convert.ToBoolean(row["is_active"]) ? "Да" : "Нет")}");
            }
        }
        static void AddUserToMyTeam()
        {
            Console.Clear();
            Console.WriteLine("=== Добавление пользователя в команду ===\n");

            string role = currentUser.GetRole();
            DataTable teams = role == "Admin" ? TeamService.GetAllTeams() : TeamService.GetUserLeadTeams(currentUser.GetId());

            if (teams.Rows.Count == 0)
            {
                Console.WriteLine("Нет доступных команд.");
                return;
            }

            Console.WriteLine("Доступные команды:");
            Console.WriteLine("ID\tНазвание\t\tОписание");
            foreach (DataRow row in teams.Rows)
            {
                string desc = row["description"] == DBNull.Value ? "" : row["description"].ToString();
                if (desc.Length > 30) desc = desc.Substring(0, 27) + "...";
                Console.WriteLine($"{row["id"]}\t{row["name"]}\t\t{desc}");
            }

            Console.Write("\nВведите ID команды (0 - отмена): ");
            if (!int.TryParse(Console.ReadLine(), out int teamId) || teamId == 0) return;

            bool hasAccess = role == "Admin";
            if (!hasAccess)
            {
                foreach (DataRow row in teams.Rows)
                    if (Convert.ToInt32(row["id"]) == teamId) { hasAccess = true; break; }
            }

            if (!hasAccess)
            {
                Console.WriteLine("У вас нет прав на добавление в эту команду.");
                return;
            }

            Console.Write("Введите email пользователя: ");
            string email = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(email)) return;

            string findUserSql = "SELECT id, login, fullname FROM accounts.\"Accounts\" WHERE email = @email AND is_active = true";
            DataTable userDt = Database.Database.ExecuteQuery(findUserSql, new[] { new NpgsqlParameter("@email", email) });

            if (userDt.Rows.Count == 0)
            {
                Console.WriteLine($"Пользователь с email '{email}' не найден.");
                return;
            }

            int userId = Convert.ToInt32(userDt.Rows[0]["id"]);
            Console.WriteLine($"\nНайден: {userDt.Rows[0]["fullname"]} ({userDt.Rows[0]["login"]})");
            Console.Write("Добавить в команду? (y/n): ");
            if (Console.ReadLine()?.Trim().ToLower() != "y") return;

            bool success = TeamService.AddUserToTeam(teamId, userId, currentUser.GetId());
            Console.WriteLine(success ? "\nПользователь добавлен!" : "\nОшибка при добавлении.");
        }
        static void TransferTeamLead()
        {
            Console.Clear();
            Console.WriteLine("=== Передача лидерства ===\n");

            DataTable teams = TeamService.GetAllTeams();
            if (teams.Rows.Count == 0)
            {
                Console.WriteLine("Нет команд.");
                return;
            }

            Console.WriteLine("Команды:");
            foreach (DataRow row in teams.Rows)
                Console.WriteLine($"ID: {row["id"]}, Название: {row["name"]}, Лидер ID: {row["team_lead_id"]}");

            Console.Write("\nID команды: ");
            if (!int.TryParse(Console.ReadLine(), out int teamId)) return;
            Console.Write("ID нового лидера (роль TeamLead): ");
            if (!int.TryParse(Console.ReadLine(), out int newLeadId)) return;

            bool success = TeamService.TransferTeamLead(teamId, newLeadId, currentUser.GetId(), currentUser.GetRole());
            Console.WriteLine(success ? "\nЛидерство передано!" : "\nОшибка при передаче.");
        }
        static void ManageTeams()
        {
            Console.Clear();
            Console.WriteLine("=== Управление командами ===\n");
            Console.WriteLine("1. Все команды");
            Console.WriteLine("2. Участники команды");
            Console.WriteLine("3. Удалить команду");
            Console.WriteLine("0. Назад");
            Console.Write("Выбор: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1: ShowAllTeams(); break;
                    case 2: ShowTeamMembers(); break;
                    case 3: ShowDeletingTeam(); break;
                }
            }
        }
        static void ShowAllTeams()
        {
            Console.Clear();
            string role = currentUser.GetRole();
            DataTable teams = role == "Admin" ? TeamService.GetAllTeams() : TeamService.GetUserLeadTeams(currentUser.GetId());

            if (teams.Rows.Count == 0)
            {
                Console.WriteLine("Нет доступных команд.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=== Список команд ===\n");
            foreach (DataRow row in teams.Rows)
                Console.WriteLine($"ID: {row["id"]}\t{row["name"]}\tЛидер ID: {row["team_lead_id"]}");
            Console.ReadKey();
        }
        static void ShowTeamMembers()
        {
            Console.Clear();
            string role = currentUser.GetRole();
            DataTable teams = role == "Admin" ? TeamService.GetAllTeams() : TeamService.GetUserLeadTeams(currentUser.GetId());

            if (teams.Rows.Count == 0)
            {
                Console.WriteLine("Нет доступных команд.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Команды:");
            foreach (DataRow row in teams.Rows)
                Console.WriteLine($"ID: {row["id"]}, Название: {row["name"]}");

            Console.Write("\nID команды: ");
            if (!int.TryParse(Console.ReadLine(), out int teamId)) return;

            DataTable members = TeamService.GetTeamMembers(teamId);
            if (members.Rows.Count == 0)
                Console.WriteLine("Нет участников.");
            else
                foreach (DataRow row in members.Rows)
                    Console.WriteLine($"{row["login"]}\t{row["fullname"]}\t{row["role"]}");
            Console.ReadKey();
        }
        static void ShowDeletingTeam()
        {
            Console.Clear();
            string role = currentUser.GetRole();
            DataTable teams = role == "Admin" ? TeamService.GetAllTeams() : TeamService.GetUserLeadTeams(currentUser.GetId());

            if (teams.Rows.Count == 0)
            {
                Console.WriteLine("Нет доступных команд.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Команды для удаления:");
            foreach (DataRow row in teams.Rows)
                Console.WriteLine($"ID: {row["id"]}, Название: {row["name"]}");

            Console.Write("\nID команды: ");
            if (!int.TryParse(Console.ReadLine(), out int teamId)) return;

            Console.Write("Уверены? (y/n): ");
            if (Console.ReadLine()?.Trim().ToLower() != "y") return;

            bool success = TeamService.DeleteTeam(teamId, currentUser.GetId(), role);
            Console.WriteLine(success ? "Команда удалена." : "Ошибка при удалении.");
            Console.ReadKey();
        }
        static void CopyTaskUI()
        {
            Console.Clear();
            Console.WriteLine("=== Копирование задачи ===\n");
            Console.Write("ID задачи: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId)) return;

            var owners = TaskService.GetTaskOwners(taskId);
            if (owners.CreatorId == 0)
            {
                Console.WriteLine("Задача не найдена.");
                return;
            }

            Console.Write("Новый исполнитель (Enter - тот же): ");
            string input = Console.ReadLine();
            int newAssigneeId = string.IsNullOrEmpty(input) ? (owners.AssigneeId ?? 0) : int.Parse(input);

            Console.Write("Копировать подзадачи? (y/n): ");
            bool copySubtasks = Console.ReadLine()?.Trim().ToLower() == "y";

            int? newId = TaskService.CopyTask(taskId, currentUser.GetId(), newAssigneeId, copySubtasks);
            Console.WriteLine(newId.HasValue ? $"Скопировано. Новый ID: {newId}" : "Ошибка копирования.");
        }
        static void CreateSubtaskUI()
        {
            Console.Clear();
            Console.WriteLine("=== Создание подзадачи ===\n");
            Console.Write("ID родительской задачи: ");
            if (!int.TryParse(Console.ReadLine(), out int parentId)) return;
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string desc = Console.ReadLine();
            Console.Write("ID исполнителя: ");
            if (!int.TryParse(Console.ReadLine(), out int assigneeId)) return;
            Console.Write("Срок (ГГГГ-ММ-ДД): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate)) return;

            bool success = TaskService.CreateSubtask(parentId, title, desc, assigneeId, currentUser.GetId(), dueDate);
            Console.WriteLine(success ? "Подзадача создана!" : "Ошибка.");
        }
        static void ShowSubtaskTree()
        {
            Console.Clear();
            Console.WriteLine("=== Дерево подзадач ===\n");
            Console.Write("ID задачи: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId)) return;
            DisplaySubtasks(taskId, 0);
            Console.ReadKey();
        }
        static void DisplaySubtasks(int taskId, int level)
        {
            DataTable dt = TaskService.GetTaskSubtasks(taskId);
            string indent = new string(' ', level * 2);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{indent}├─ {row["title"]} (ID: {row["id"]}, {row["status_name"]}, {FormatDateString(row["due_date"])})");
                DisplaySubtasks(Convert.ToInt32(row["id"]), level + 1);
            }
        }
        static void ManageComments()
        {
            Console.Clear();
            Console.WriteLine("=== Комментарии ===\n");
            Console.Write("ID задачи: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId)) return;

            Console.WriteLine("1. Добавить\n2. Просмотреть");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Комментарий: ");
                bool ok = TaskService.AddComment(taskId, currentUser.GetId(), Console.ReadLine());
                Console.WriteLine(ok ? "Добавлен." : "Ошибка.");
            }
            else
            {
                DataTable dt = TaskService.GetComments(taskId);
                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Нет комментариев.");
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["author_name"]} ({FormatDateString(row["created_at"])}): {row["comment"]}");
                    }
                }
            }
        }
        static void ManageTags()
        {
            Console.Clear();
            Console.WriteLine("=== Теги ===\n");
            Console.WriteLine("1. Создать\n2. Назначить\n3. Теги задачи\n4. Задачи по тегу");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Название: ");
                    string name = Console.ReadLine();
                    Console.Write("Цвет (#HEX): ");
                    string color = Console.ReadLine();
                    if (string.IsNullOrEmpty(color)) color = "#FFFFFF";
                    Console.WriteLine(TaskService.CreateTag(name, color) ? "Создан." : "Ошибка.");
                    break;
                case "2":
                    Console.Write("ID задачи: ");
                    if (int.TryParse(Console.ReadLine(), out int tId))
                    {
                        Console.Write("ID тега: ");
                        if (int.TryParse(Console.ReadLine(), out int tagId))
                            Console.WriteLine(TaskService.AddTagToTask(tId, tagId) ? "Назначен." : "Ошибка.");
                    }
                    break;
                case "3":
                    Console.Write("ID задачи: ");
                    if (int.TryParse(Console.ReadLine(), out int taskId))
                    {
                        DataTable tags = TaskService.GetTaskTags(taskId);
                        if (tags.Rows.Count == 0) Console.WriteLine("Нет тегов.");
                        else foreach (DataRow row in tags.Rows) Console.WriteLine($"{row["name"]} ({row["color"]})");
                    }
                    break;
                case "4":
                    Console.Write("ID тега: ");
                    if (int.TryParse(Console.ReadLine(), out int tag))
                    {
                        DataTable tasks = TaskService.GetTasksByTag(tag);
                        if (tasks.Rows.Count == 0)
                            Console.WriteLine("Нет задач.");
                        else
                            foreach (DataRow row in tasks.Rows)
                            {
                                Console.WriteLine($"{row["id"]}\t{row["title"]}\t{FormatDateString(row["due_date"])}");
                            }
                    }
                    break;
            }
        }
        static void FiltersMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Фильтры и поиск ===\n");
            Console.WriteLine("1. Поиск по тексту");
            Console.WriteLine("2. По статусу");
            Console.WriteLine("3. Просроченные");
            Console.Write("Выбор: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Поиск: ");
                string query = Console.ReadLine();
                DataTable dt = TaskService.SearchTasks(query, currentUser.GetId(), currentUser.GetRole());

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Ничего не найдено.");
                    return;
                }

                Console.WriteLine("\nID\tНазвание\t\tСтатус\t\tСрок\t\tИсполнитель\tРелевантность");
                foreach (DataRow row in dt.Rows)
                {
                    string assignee = row["assignee_name"] == DBNull.Value ? "—" : row["assignee_name"].ToString();
                    string relevance = row["relevance"] != DBNull.Value ? $"{Convert.ToDouble(row["relevance"]):F2}" : "—";
                    Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{row["status_name"]}\t\t{FormatDateString(row["due_date"])}\t{assignee}\t{relevance}");
                }
            }
            else if (choice == "2")
            {
                DataTable statuses = TaskService.GetAvailableStatuses();
                Console.WriteLine("Статусы:");
                foreach (DataRow row in statuses.Rows)
                    Console.WriteLine($"{row["id"]}. {row["name"]}");
                Console.Write("ID статуса: ");
                if (int.TryParse(Console.ReadLine(), out int statusId))
                {
                    DataTable tasks = TaskService.GetTasksByStatus(statusId);
                    if (tasks.Rows.Count == 0)
                        Console.WriteLine("Нет задач.");
                    else
                        foreach (DataRow row in tasks.Rows)
                        {
                            Console.WriteLine($"{row["id"]}\t{row["title"]}\t{row["assignee_name"]}\t{FormatDateString(row["due_date"])}");
                        }
                }
            }
            else if (choice == "3")
            {
                DataTable dt = TaskService.GetOverdueTasks(currentUser.GetId());
                if (dt.Rows.Count == 0)
                    Console.WriteLine("Нет просроченных задач.");
                else
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"]}\t{row["title"]}\t{row["assignee_name"]}\t{FormatDateString(row["due_date"])}\t+{row["overdue_days"]} дн.");
                    }
            }
        }
        static void HistoryMenu()
        {
            Console.Clear();
            Console.WriteLine("=== История изменений ===\n");
            Console.Write("ID задачи: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId)) return;

            Console.WriteLine("1. Статусы\n2. Дедлайны");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                DataTable dt = TaskService.GetTaskStatusHistory(taskId);
                if (dt.Rows.Count == 0)
                    Console.WriteLine("Нет записей.");
                else
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["old_status"]} → {row["new_status"]} ({row["changed_by"]}, {FormatDateString(row["changed_at"])}): {row["reason"]}");
                    }
            }
            else if (choice == "2")
            {
                DataTable dt = TaskService.GetTaskDeadlineHistory(taskId);
                if (dt.Rows.Count == 0)
                    Console.WriteLine("Нет записей.");
                else
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{FormatDateString(row["old_due_date"])} → {FormatDateString(row["new_due_date"])} ({row["changed_by"]}, {FormatDateString(row["changed_at"])}): {row["reason"]}");
                    }
            }
        }
        static void ShowUserStats()
        {
            var stats = AccountService.GetUserStats(currentUser.GetId());
            Console.Clear();
            Console.WriteLine("=== Моя статистика ===\n");
            Console.WriteLine($"Всего задач:      {stats.Total}");
            Console.WriteLine($"Выполнено:        {stats.Completed}");
            Console.WriteLine($"Просрочено:       {stats.Overdue}");
            Console.ReadKey();
        }
    }
}
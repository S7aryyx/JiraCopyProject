using JiraCopyProject.Logic.Services;
using JiraCopyProject.Logic.Models;
using System;
using System.Data;

namespace JiraCopyProject
{
    class Program
    {
        static Account currentUser = null;
        static int? currentUserTeamId = null;
        static string currentUserTeamName = null;

        static void Main()
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
                    else if (choice == "4") ChangeTaskStatus();
                    else if (choice == "5") Logout();
                    else if (choice == "0") exit = true;
                    else if ((currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin") && choice == "6") CreateTeam();
                    else if ((currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin") && choice == "7") ListAllUsers();
                    else if ((currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin") && choice == "8") AddUserToMyTeam();
                    else if ((currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin") && choice == "9") AssignTaskToAnotherUser();
                    else if (currentUser.GetRole() == "Admin" && choice == "10") TransferTeamLead();
                    else if ((currentUser.GetRole() == "TeamLead" || currentUser.GetRole() == "Admin") && choice == "11") AddTeamTask();
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

            // Должность
            string position = currentUser.GetPosition();
            if (position == null)
            {
                Console.WriteLine("  Должность: не указана");
            }
            else
            {
                Console.WriteLine($"  Должность: {position}");
            }

            // Команда
            if (currentUserTeamId.HasValue)
            {
                Console.WriteLine($"  Команда: {currentUserTeamName} (ID: {currentUserTeamId})");
            }
            else
            {
                Console.WriteLine("  Команда: не состоит");
            }

            // Общее меню (всегда)
            Console.WriteLine("============================================================");
            Console.WriteLine("  1. Создать задачу");
            Console.WriteLine("  2. Мои задачи (назначенные мне)");
            Console.WriteLine("  3. Редактировать задачу (только свои)");
            Console.WriteLine("  4. Изменить статус задачи");
            Console.WriteLine("  5. Выйти из аккаунта");
            Console.WriteLine("  0. Выход из программы");

            // Дополнительные функции для TeamLead/Admin
            string role = currentUser.GetRole();
            if (role == "TeamLead" || role == "Admin")
            {
                Console.WriteLine("--- Командные функции ---");
                Console.WriteLine("  6. Создать команду");
                Console.WriteLine("  7. Список всех пользователей");
                Console.WriteLine("  8. Добавить пользователя в мою команду");
                Console.WriteLine("  9. Назначить задачу другому пользователю");
                Console.WriteLine("  11. Создать задачу на всю команду");
            }
            if (role == "Admin")
            {
                Console.WriteLine("--- Администрирование ---");
                Console.WriteLine("  10. Передать управление командой другому TeamLead");
            }
            Console.WriteLine("============================================================");
            Console.Write("Ваш выбор: ");
        }

        static string FormatDate(object dateObj)
        {
            if (dateObj is DateOnly dateOnly)
            {
                return dateOnly.ToDateTime(TimeOnly.MinValue).ToString("yyyy-MM-dd");
            }
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

            int result = AccountService.Register(login, password, email, fullname, position);
            string msg;
            if (result == 1)
            {
                msg = "Регистрация прошла успешно!";
            }
            else if (result == 0)
            {
                msg = "Ошибка: Логин уже занят.";
            }
            else if (result == -1)
            {
                msg = "Ошибка: Email уже зарегистрирован.";
            }
            else
            {
                msg = "Неизвестная ошибка регистрации.";
            }
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

            var (id, role, status) = AccountService.Authenticate(login, password);
            if (status == 1 && id != 0)
            {
                currentUser = AccountService.GetAccountById(id);
                if (currentUser == null)
                {
                    Console.WriteLine("Ошибка загрузки данных пользователя.");
                    return;
                }
                var team = TeamService.GetUserTeam(id);
                currentUserTeamId = team.Id;
                currentUserTeamName = team.Name;

                Console.WriteLine($"\nДобро пожаловать, {currentUser.GetFullname()}!");
                Console.WriteLine($"ID: {currentUser.GetId()}, Роль: {currentUser.GetRole()}");
                if (currentUserTeamId.HasValue)
                {
                    Console.WriteLine($"Команда: {currentUserTeamName}");
                }
                else
                {
                    Console.WriteLine("Вы не состоите ни в одной команде.");
                }
            }
            else
            {
                Console.WriteLine("\nНеверный логин или пароль, либо аккаунт неактивен.");
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
                string assigneeInput = Console.ReadLine();
                if (string.IsNullOrEmpty(assigneeInput))
                {
                    assigneeId = currentUser.GetId();
                }
                else
                {
                    assigneeId = int.Parse(assigneeInput);
                }
            }

            Console.Write("Срок выполнения (ГГГГ-ММ-ДД): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            bool success = TaskService.CreateTask(title, description, assigneeId, currentUser.GetId(), dueDate);
            if (success)
            {
                Console.WriteLine("\nЗадача успешно создана!");
            }
            else
            {
                Console.WriteLine("\nОшибка при создании задачи.");
            }
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
                string personal;
                if (Convert.ToBoolean(row["is_personal"]))
                {
                    personal = "Личная";
                }
                else
                {
                    personal = "Командная";
                }
                Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{row["status_name"]}\t\t{FormatDate(row["due_date"])}\t{personal}");
            }

            Console.WriteLine("\nДля просмотра деталей введите ID задачи (0 - вернуться в меню): ");
            if (int.TryParse(Console.ReadLine(), out int taskId) && taskId > 0)
            {
                ShowTaskDetails(taskId);
            }
        }

        static void ShowTaskDetails(int taskId)
        {
            Console.Clear();
            Console.WriteLine("=== Детали задачи ===\n");

            DataTable dtDetails = TaskService.GetTaskDetails(taskId);
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

            DataTable dtSubtasks = TaskService.GetTaskSubtasks(taskId);
            Console.WriteLine("\n--- Подзадачи ---");
            if (dtSubtasks.Rows.Count == 0)
            {
                Console.WriteLine("Нет подзадач.");
            }
            else
            {
                Console.WriteLine("ID\tНазвание\t\tСтатус\t\tСрок");
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

            DataTable tasksDt = TaskService.GetUserCreatedTasks(currentUser.GetId());
            if (tasksDt.Rows.Count == 0)
            {
                Console.WriteLine("Вы не создали ни одной задачи.");
                return;
            }

            Console.WriteLine("Ваши задачи:");
            Console.WriteLine("ID\tНазвание\t\tСрок");
            foreach (DataRow row in tasksDt.Rows)
            {
                Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{FormatDate(row["due_date"])}");
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

            DateTime? newDueDate;
            if (string.IsNullOrEmpty(newDueDateStr))
            {
                newDueDate = null;
            }
            else
            {
                newDueDate = DateTime.Parse(newDueDateStr);
            }

            bool success = TaskService.UpdateTask(taskId, newTitle, newDesc, newDueDate, currentUser.GetId());
            if (success)
            {
                Console.WriteLine("\nЗадача успешно обновлена!");
            }
            else
            {
                Console.WriteLine("\nОшибка при обновлении задачи.");
            }
        }

        static void ChangeTaskStatus()
        {
            Console.Clear();
            Console.WriteLine("=== Изменение статуса задачи ===\n");

            DataTable dt = TaskService.GetUserTasks(currentUser.GetId());
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("У вас нет задач, для которых можно изменить статус.");
                return;
            }

            Console.WriteLine("Доступные задачи:");
            Console.WriteLine("ID\tНазвание\t\tСтатус\t\tСрок\t\tТип");
            foreach (DataRow row in dt.Rows)
            {
                string personal;
                if (Convert.ToBoolean(row["is_personal"]))
                {
                    personal = "Личная";
                }
                else
                {
                    personal = "Командная";
                }
                Console.WriteLine($"{row["id"]}\t{row["title"]}\t\t{row["status_name"]}\t\t{FormatDate(row["due_date"])}\t{personal}");
            }

            Console.Write("\nВведите ID задачи для изменения статуса (0 - отмена): ");
            if (!int.TryParse(Console.ReadLine(), out int taskId) || taskId == 0)
            {
                Console.WriteLine("Изменение статуса отменено.");
                return;
            }

            var (creatorId, assigneeId) = TaskService.GetTaskOwners(taskId);
            if (creatorId == 0)
            {
                Console.WriteLine("Задача не найдена.");
                return;
            }

            string role = currentUser.GetRole();
            bool canChange = false;
            bool isCreator = (creatorId == currentUser.GetId());
            bool isAssignee = (assigneeId.HasValue && assigneeId.Value == currentUser.GetId());

            if (role == "Admin")
            {
                canChange = true;
            }
            else if (role == "TeamLead")
            {
                canChange = isCreator;
            }
            else if (role == "User")
            {
                canChange = isAssignee;
            }

            if (!canChange)
            {
                Console.WriteLine("У вас нет прав на изменение статуса этой задачи.");
                return;
            }

            DataTable statuses = TaskService.GetAvailableStatuses();
            Console.WriteLine("\nДоступные статусы:");
            foreach (DataRow row in statuses.Rows)
            {
                int statusId = Convert.ToInt32(row["id"]);
                string statusName = row["name"].ToString();
                if (role == "User" && !isCreator && (statusId == 4 || statusId == 5))
                {
                    continue;
                }
                Console.WriteLine($"{statusId}. {statusName}");
            }

            Console.Write("\nВыберите ID нового статуса: ");
            int newStatusId = int.Parse(Console.ReadLine());

            Console.Write("Причина изменения: ");
            string reason = Console.ReadLine();

            bool success = TaskService.ChangeTaskStatus(taskId, newStatusId, currentUser.GetId(), reason);
            if (success)
            {
                Console.WriteLine("\nСтатус успешно изменён!");
            }
            else
            {
                Console.WriteLine("\nОшибка при изменении статуса.");
            }
        }

        static void CreateTeam()
        {
            Console.Clear();
            Console.WriteLine("=== Создание команды ===\n");

            Console.Write("Название команды: ");
            string name = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();

            int? teamId = TeamService.CreateTeam(name, description, currentUser.GetId());
            if (teamId.HasValue)
            {
                Console.WriteLine("\nКоманда успешно создана!");
                currentUserTeamId = teamId.Value;
                currentUserTeamName = name;
            }
            else
            {
                Console.WriteLine("\nОшибка при создании команды.");
            }
        }

        static void ListAllUsers()
        {
            Console.Clear();
            Console.WriteLine("=== Список всех пользователей ===\n");

            DataTable dt = AccountService.GetAllUsers();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Пользователи не найдены.");
                return;
            }

            Console.WriteLine("ID\tЛогин\t\tФИО\t\t\tРоль\t\tАктивен");
            Console.WriteLine(new string('-', 80));
            foreach (DataRow row in dt.Rows)
            {
                string active;
                if (Convert.ToBoolean(row["is_active"]))
                {
                    active = "Да";
                }
                else
                {
                    active = "Нет";
                }
                Console.WriteLine($"{row["id"]}\t{row["login"]}\t\t{row["fullname"]}\t\t{row["role"]}\t\t{active}");
            }
        }

        static void AddUserToMyTeam()
        {
            Console.Clear();
            Console.WriteLine("=== Добавление пользователя в мою команду ===\n");

            if (!currentUserTeamId.HasValue)
            {
                Console.WriteLine("Вы не являетесь лидером команды или не состоите в команде.");
                return;
            }

            if (!TeamService.IsUserTeamLead(currentUser.GetId(), currentUserTeamId.Value))
            {
                Console.WriteLine("Вы не являетесь лидером этой команды.");
                return;
            }

            Console.Write("Введите ID пользователя для добавления: ");
            int userId = int.Parse(Console.ReadLine());

            bool success = TeamService.AddUserToTeam(currentUserTeamId.Value, userId, currentUser.GetId());
            if (success)
            {
                Console.WriteLine("\nПользователь успешно добавлен в команду!");
            }
            else
            {
                Console.WriteLine("\nОшибка при добавлении пользователя.");
            }
        }

        static void AssignTaskToAnotherUser()
        {
            Console.Clear();
            Console.WriteLine("=== Назначение задачи другому пользователю ===\n");

            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();

            Console.Write("ID исполнителя: ");
            int assigneeId = int.Parse(Console.ReadLine());

            Console.Write("Срок выполнения (ГГГГ-ММ-ДД): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            bool success = TaskService.CreateTask(title, description, assigneeId, currentUser.GetId(), dueDate);
            if (success)
            {
                Console.WriteLine("\nЗадача успешно назначена!");
            }
            else
            {
                Console.WriteLine("\nОшибка при назначении задачи.");
            }
        }

        static void TransferTeamLead()
        {
            Console.Clear();
            Console.WriteLine("=== Передача управления командой ===\n");

            Console.Write("Введите ID команды: ");
            int teamId = int.Parse(Console.ReadLine());

            Console.Write("Введите ID нового лидера (должен иметь роль TeamLead): ");
            int newLeadId = int.Parse(Console.ReadLine());

            bool success = TeamService.TransferTeamLead(teamId, newLeadId, currentUser.GetId(), currentUser.GetRole());
            if (success)
            {
                Console.WriteLine("\nУправление командой успешно передано!");
                if (currentUserTeamId.HasValue && currentUserTeamId.Value == teamId)
                {
                    var team = TeamService.GetUserTeam(currentUser.GetId());
                    currentUserTeamId = team.Id;
                    currentUserTeamName = team.Name;
                }
            }
            else
            {
                Console.WriteLine("\nОшибка при передаче управления. Проверьте, что команда существует, а новый лидер имеет роль TeamLead.");
            }
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

            Console.WriteLine("Выберите команду:");
            for (int i = 0; i < teams.Rows.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teams.Rows[i]["name"]} (ID: {teams.Rows[i]["id"]})");
            }
            Console.Write("Введите номер: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > teams.Rows.Count)
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }
            int teamId = Convert.ToInt32(teams.Rows[choice - 1]["id"]);
            string teamName = teams.Rows[choice - 1]["name"].ToString();

            Console.Write("Название задачи: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();
            Console.Write("Срок выполнения (ГГГГ-ММ-ДД): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            bool success = TaskService.CreateTeamTask(title, description, teamId, currentUser.GetId(), dueDate);
            if (success)
            {
                Console.WriteLine($"\nЗадача для команды \"{teamName}\" успешно создана!");
            }
            else
            {
                Console.WriteLine("\nОшибка при создании задачи.");
            }
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
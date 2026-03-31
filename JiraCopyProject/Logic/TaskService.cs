using JiraCopyProject.Database;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;

namespace JiraCopyProject.Logic.Services
{
    public static class TaskService
    {
        public static bool CreateTask(string title, string description, int assigneeId, int creatorId, DateTime dueDate)
        {
            string sql = "CALL \"InsertTask\"(@title, @desc, @statusId, @assignee, @creator, NULL, @dueDate, NULL)";
            var parameters = new[]
            {
                new NpgsqlParameter("@title", title),
                new NpgsqlParameter("@desc", description),
                new NpgsqlParameter("@statusId", 1),
                new NpgsqlParameter("@assignee", assigneeId),
                new NpgsqlParameter("@creator", creatorId),
                new NpgsqlParameter("@dueDate", NpgsqlDbType.Date) { Value = dueDate }
            };
            try
            {
                Database.Database.ExecuteNonQuery(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CreateTeamTask(string title, string description, int teamId, int creatorId, DateTime dueDate)
        {
            string sql = "CALL \"InsertTask\"(@title, @desc, @statusId, NULL, @creator, @teamId, @dueDate, NULL)";
            var parameters = new[]
            {
                new NpgsqlParameter("@title", title),
                new NpgsqlParameter("@desc", description),
                new NpgsqlParameter("@statusId", 1),
                new NpgsqlParameter("@creator", creatorId),
                new NpgsqlParameter("@teamId", teamId),
                new NpgsqlParameter("@dueDate", NpgsqlDbType.Date) { Value = dueDate }
            };
            try
            {
                Database.Database.ExecuteNonQuery(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetUserTasks(int accountId)
        {
            string sql = "SELECT * FROM \"GetUserTasks\"(@p_account_id)";
            var param = new NpgsqlParameter("@p_account_id", accountId);
            return Database.Database.ExecuteQuery(sql, new[] { param });
        }

        public static DataTable GetTaskDetails(int taskId)
        {
            string sql = @"
                SELECT t.id, t.title, t.description, t.due_date, 
                       s.name AS status_name,
                       a.fullname AS creator_fullname
                FROM ""Tasks"" t
                JOIN ""Statuses"" s ON t.status_id = s.id
                JOIN ""Accounts"" a ON t.creator_id = a.id
                WHERE t.id = @taskId";
            var param = new NpgsqlParameter("@taskId", taskId);
            return Database.Database.ExecuteQuery(sql, new[] { param });
        }

        public static DataTable GetTaskSubtasks(int parentTaskId)
        {
            string sql = @"
                SELECT t.id, t.title, s.name AS status_name, t.due_date
                FROM ""Tasks"" t
                JOIN ""Statuses"" s ON t.status_id = s.id
                WHERE t.parent_task_id = @taskId
                ORDER BY t.id";
            var param = new NpgsqlParameter("@taskId", parentTaskId);
            return Database.Database.ExecuteQuery(sql, new[] { param });
        }

        public static DataTable GetUserCreatedTasks(int creatorId)
        {
            string sql = "SELECT id, title, description, due_date FROM \"Tasks\" WHERE creator_id = @creatorId";
            var param = new NpgsqlParameter("@creatorId", creatorId);
            return Database.Database.ExecuteQuery(sql, new[] { param });
        }

        public static bool UpdateTask(int taskId, string newTitle, string newDescription, DateTime? newDueDate, int changedById)
        {
            var parameters = new List<NpgsqlParameter>();

            parameters.Add(new NpgsqlParameter("@p_id", taskId));

            // @p_title
            if (string.IsNullOrEmpty(newTitle))
            {
                parameters.Add(new NpgsqlParameter("@p_title", DBNull.Value));
            }
            else
            {
                parameters.Add(new NpgsqlParameter("@p_title", newTitle));
            }

            // @p_description
            if (string.IsNullOrEmpty(newDescription))
            {
                parameters.Add(new NpgsqlParameter("@p_description", DBNull.Value));
            }
            else
            {
                parameters.Add(new NpgsqlParameter("@p_description", newDescription));
            }

            parameters.Add(new NpgsqlParameter("@p_status_id", DBNull.Value));
            parameters.Add(new NpgsqlParameter("@p_create_date", DBNull.Value));
            parameters.Add(new NpgsqlParameter("@p_team_id", DBNull.Value));
            parameters.Add(new NpgsqlParameter("@p_assignee_id", DBNull.Value));
            parameters.Add(new NpgsqlParameter("@p_creator_id", DBNull.Value));

            // @p_due_date
            if (newDueDate.HasValue)
            {
                parameters.Add(new NpgsqlParameter("@p_due_date", NpgsqlDbType.Date) { Value = newDueDate.Value });
            }
            else
            {
                parameters.Add(new NpgsqlParameter("@p_due_date", DBNull.Value));
            }

            parameters.Add(new NpgsqlParameter("@p_parent_task_id", DBNull.Value));
            parameters.Add(new NpgsqlParameter("@p_changed_by_id", changedById));
            parameters.Add(new NpgsqlParameter("@p_reason", "Редактирование через консоль"));

            string updateSql = "CALL \"UpdateTask\"(@p_id, @p_title, @p_description, @p_status_id, @p_create_date, @p_team_id, @p_assignee_id, @p_creator_id, @p_due_date, @p_parent_task_id, @p_changed_by_id, @p_reason)";
            try
            {
                Database.Database.ExecuteNonQuery(updateSql, parameters.ToArray());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangeTaskStatus(int taskId, int newStatusId, int changedById, string reason)
        {
            string sql = "CALL \"UpdateTaskStatus\"(@taskId, @newStatus, @changedBy, @reason)";
            var parameters = new[]
            {
                new NpgsqlParameter("@taskId", taskId),
                new NpgsqlParameter("@newStatus", newStatusId),
                new NpgsqlParameter("@changedBy", changedById),
                new NpgsqlParameter("@reason", reason)
            };
            try
            {
                Database.Database.ExecuteNonQuery(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetAvailableStatuses()
        {
            return Database.Database.ExecuteQuery("SELECT id, name FROM \"Statuses\" ORDER BY sort_order");
        }

        public static (int CreatorId, int? AssigneeId) GetTaskOwners(int taskId)
        {
            string sql = "SELECT creator_id, assignee_id FROM \"Tasks\" WHERE id = @taskId";
            var param = new NpgsqlParameter("@taskId", taskId);
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0)
            {
                return (0, null);
            }

            int creatorId = Convert.ToInt32(dt.Rows[0]["creator_id"]);
            int? assigneeId;
            if (dt.Rows[0]["assignee_id"] == DBNull.Value)
            {
                assigneeId = null;
            }
            else
            {
                assigneeId = Convert.ToInt32(dt.Rows[0]["assignee_id"]);
            }
            return (creatorId, assigneeId);
        }
    }
}
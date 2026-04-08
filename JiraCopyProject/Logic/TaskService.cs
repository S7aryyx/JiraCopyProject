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
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
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
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }
        public static DataTable GetUserTasks(int accountId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetUserTasks\"(@p_account_id)", new[] { new NpgsqlParameter("@p_account_id", accountId) });
        }
        public static DataTable GetTaskDetails(int taskId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTaskDetails\"(@p_task_id)", new[] { new NpgsqlParameter("@p_task_id", taskId) });
        }
        public static DataTable GetTaskSubtasks(int parentTaskId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTaskSubtasks\"(@p_parent_task_id)", new[] { new NpgsqlParameter("@p_parent_task_id", parentTaskId) });
        }
        public static DataTable GetUserCreatedTasks(int creatorId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetUserCreatedTasks\"(@p_creator_id)", new[] { new NpgsqlParameter("@p_creator_id", creatorId) });
        }
        public static bool UpdateTask(int taskId, string newTitle, string newDescription,
                                      int? newStatusId, int? newTeamId, int? newAssigneeId,
                                      DateTime? newDueDate, int changedById, string reason = "Редактирование")
        {
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@p_id", taskId),
                new NpgsqlParameter("@p_title", string.IsNullOrEmpty(newTitle) ? DBNull.Value : (object)newTitle),
                new NpgsqlParameter("@p_description", string.IsNullOrEmpty(newDescription) ? DBNull.Value : (object)newDescription),
                new NpgsqlParameter("@p_status_id", newStatusId ?? (object)DBNull.Value),
                new NpgsqlParameter("@p_create_date", DBNull.Value),
                new NpgsqlParameter("@p_team_id", newTeamId ?? (object)DBNull.Value),
                new NpgsqlParameter("@p_assignee_id", newAssigneeId ?? (object)DBNull.Value),
                new NpgsqlParameter("@p_creator_id", DBNull.Value),
                new NpgsqlParameter("@p_due_date", newDueDate ?? (object)DBNull.Value),
                new NpgsqlParameter("@p_parent_task_id", DBNull.Value),
                new NpgsqlParameter("@p_changed_by_id", changedById),
                new NpgsqlParameter("@p_reason", reason)
            };
            if (newDueDate.HasValue) parameters[8].NpgsqlDbType = NpgsqlDbType.Date;
            try
            {
                Database.Database.ExecuteNonQuery("CALL \"UpdateTask\"(@p_id, @p_title, @p_description, @p_status_id, @p_create_date, @p_team_id, @p_assignee_id, @p_creator_id, @p_due_date, @p_parent_task_id, @p_changed_by_id, @p_reason)", parameters.ToArray());
                return true;
            }
            catch { return false; }
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
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }

        public static bool ChangeTaskDeadline(int taskId, DateTime newDueDate, int changedById, string reason)
        {
            string sql = "CALL \"UpdateTaskDeadline\"(@taskId, @newDeadline, @changedBy, @reason)";
            var parameters = new[]
            {
                new NpgsqlParameter("@taskId", taskId),
                new NpgsqlParameter("@newDeadline", NpgsqlDbType.Date) { Value = newDueDate },
                new NpgsqlParameter("@changedBy", changedById),
                new NpgsqlParameter("@reason", reason)
            };
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }
        public static DataTable GetAvailableStatuses()
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetAvailableStatuses\"()");
        }
        public static (int CreatorId, int? AssigneeId) GetTaskOwners(int taskId)
        {
            DataTable dt = Database.Database.ExecuteQuery("SELECT * FROM \"GetTaskOwners\"(@p_task_id)", new[] { new NpgsqlParameter("@p_task_id", taskId) });
            if (dt.Rows.Count == 0) return (0, null);
            int creator = Convert.ToInt32(dt.Rows[0]["creator_id"]);
            int? assignee = dt.Rows[0]["assignee_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(dt.Rows[0]["assignee_id"]);
            return (creator, assignee);
        }
        public static int? CopyTask(int taskId, int newCreatorId, int newAssigneeId, bool copySubtasks)
        {
            string sql = "SELECT \"CopyTask\"(@p_task_id, @p_new_creator_id, @p_new_assignee_id, @p_copy_subtasks)";
            var parameters = new[]
            {
                new NpgsqlParameter("@p_task_id", taskId),
                new NpgsqlParameter("@p_new_creator_id", newCreatorId),
                new NpgsqlParameter("@p_new_assignee_id", newAssigneeId),
                new NpgsqlParameter("@p_copy_subtasks", copySubtasks)
            };
            object result = Database.Database.ExecuteScalar(sql, parameters);
            return result == null ? (int?)null : Convert.ToInt32(result);
        }
        public static bool CreateSubtask(int parentTaskId, string title, string description, int assigneeId, int creatorId, DateTime dueDate, int statusId = 1)
        {
            string sql = "CALL \"CreateSubtask\"(@p_parent, @p_title, @p_desc, @p_assignee, @p_creator, @p_due, @p_status)";
            var parameters = new[]
            {
                new NpgsqlParameter("@p_parent", parentTaskId),
                new NpgsqlParameter("@p_title", title),
                new NpgsqlParameter("@p_desc", description),
                new NpgsqlParameter("@p_assignee", assigneeId),
                new NpgsqlParameter("@p_creator", creatorId),
                new NpgsqlParameter("@p_due", NpgsqlDbType.Date) { Value = dueDate },
                new NpgsqlParameter("@p_status", statusId)
            };
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }
        public static bool AddComment(int taskId, int authorId, string comment)
        {
            string sql = "CALL \"AddTaskComment\"(@p_task, @p_author, @p_comment)";
            var parameters = new[]
            {
                new NpgsqlParameter("@p_task", taskId),
                new NpgsqlParameter("@p_author", authorId),
                new NpgsqlParameter("@p_comment", comment)
            };
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }
        public static DataTable GetComments(int taskId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTaskComments\"(@p_task)", new[] { new NpgsqlParameter("@p_task", taskId) });
        }
        public static bool CreateTag(string name, string color = "#FFFFFF")
        {
            string sql = "CALL \"CreateTag\"(@p_name, @p_color)";
            var parameters = new[] { new NpgsqlParameter("@p_name", name), new NpgsqlParameter("@p_color", color) };
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }
        public static bool AddTagToTask(int taskId, int tagId)
        {
            string sql = "CALL \"AddTagToTask\"(@p_task, @p_tag)";
            var parameters = new[] { new NpgsqlParameter("@p_task", taskId), new NpgsqlParameter("@p_tag", tagId) };
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }
        public static bool RemoveTagFromTask(int taskId, int tagId)
        {
            string sql = "CALL \"RemoveTagFromTask\"(@p_task, @p_tag)";
            var parameters = new[] { new NpgsqlParameter("@p_task", taskId), new NpgsqlParameter("@p_tag", tagId) };
            try { Database.Database.ExecuteNonQuery(sql, parameters); return true; }
            catch { return false; }
        }
        public static DataTable GetTaskTags(int taskId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTaskTags\"(@p_task)", new[] { new NpgsqlParameter("@p_task", taskId) });
        }
        public static DataTable GetTasksByTag(int tagId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTasksByTag\"(@p_tag)", new[] { new NpgsqlParameter("@p_tag", tagId) });
        }
        public static DataTable GetTasksByStatus(int statusId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTasksByStatus\"(@p_status)", new[] { new NpgsqlParameter("@p_status", statusId) });
        }
        public static DataTable GetOverdueTasks(int? accountId = null)
        {
            var param = new NpgsqlParameter("@p_account_id", accountId ?? (object)DBNull.Value);
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetOverdueTasks\"(@p_account_id)", new[] { param });
        }
        public static DataTable SearchTasks(string query, int userId, string role)
        {
            string sql = "SELECT * FROM \"SearchTasks\"(@p_query, @p_user_id, @p_role)";
            var parameters = new[]
            {
            new NpgsqlParameter("@p_query", query),
            new NpgsqlParameter("@p_user_id", userId),
            new NpgsqlParameter("@p_role", role)
    };
            return Database.Database.ExecuteQuery(sql, parameters);
        }
        public static DataTable GetTaskStatusHistory(int taskId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTaskStatusHistory\"(@p_task)", new[] { new NpgsqlParameter("@p_task", taskId) });
        }
        public static DataTable GetTaskDeadlineHistory(int taskId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTaskDeadlineHistory\"(@p_task)", new[] { new NpgsqlParameter("@p_task", taskId) });
        }
    }
}
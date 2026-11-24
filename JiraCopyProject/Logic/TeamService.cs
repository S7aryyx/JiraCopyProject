using JiraCopyProject.Database;
using Npgsql;
using System;
using System.Data;

namespace JiraCopyProject.Logic.Services
{
    public static class TeamService
    {
        public static int? CreateTeam(string name, string description, int teamLeadId)
        {
            string sql = "SELECT teams.\"CreateTeamWithLeader\"(@name, @desc, @leadId)";
            var parameters = new[]
            {
                new NpgsqlParameter("@name", name),
                new NpgsqlParameter("@desc", description),
                new NpgsqlParameter("@leadId", teamLeadId)
            };
            try
            {
                object result = Database.Database.ExecuteScalar(sql, parameters);
                return result == null ? null : Convert.ToInt32(result);
            }
            catch { return null; }
        }

        public static (int? Id, string Name) GetUserTeam(int accountId)
        {
            DataTable dt = Database.Database.ExecuteQuery("SELECT * FROM teams.\"GetUserTeam\"(@p_account_id)", new[] { new NpgsqlParameter("@p_account_id", accountId) });
            if (dt.Rows.Count == 0) return (null, null);
            return (Convert.ToInt32(dt.Rows[0]["id"]), dt.Rows[0]["name"].ToString());
        }

        public static bool AddUserToTeam(int teamId, int userId, int addedBy)
        {
            string sql = "CALL teams.\"AddUserToTeam\"(@teamId, @userId, @addedBy)";
            var parameters = new[]
            {
                new NpgsqlParameter("@teamId", teamId),
                new NpgsqlParameter("@userId", userId),
                new NpgsqlParameter("@addedBy", addedBy)
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

        public static bool TransferTeamLead(int teamId, int newLeadId, int currentUserId, string role)
        {
            if (role != "Admin") return false;
            DataTable dt = Database.Database.ExecuteQuery("SELECT team_lead_id FROM teams.\"Teams\" WHERE id = @teamId", new[] { new NpgsqlParameter("@teamId", teamId) });
            if (dt.Rows.Count == 0) return false;
            DataTable userDt = Database.Database.ExecuteQuery("SELECT role FROM accounts.\"Accounts\" WHERE id = @userId", new[] { new NpgsqlParameter("@userId", newLeadId) });
            if (userDt.Rows.Count == 0 || userDt.Rows[0]["role"].ToString() != "TeamLead") return false;
            try
            {
                Database.Database.ExecuteNonQuery("UPDATE teams.\"Teams\" SET team_lead_id = @newLeadId WHERE id = @teamId", new[] { new NpgsqlParameter("@newLeadId", newLeadId), new NpgsqlParameter("@teamId", teamId) });
                return true;
            }
            catch { return false; }
        }

        public static bool IsUserTeamLead(int accountId, int teamId)
        {
            object result = Database.Database.ExecuteScalar("SELECT teams.\"IsUserTeamLead\"(@p_account_id, @p_team_id)", new[] { new NpgsqlParameter("@p_account_id", accountId), new NpgsqlParameter("@p_team_id", teamId) });
            return result != null && Convert.ToBoolean(result);
        }

        public static DataTable GetUserLeadTeams(int accountId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM teams.\"GetUserLeadTeams\"(@p_account_id)", new[] { new NpgsqlParameter("@p_account_id", accountId) });
        }
        public static DataTable GetUsersForTeamLead(int leaderId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM accounts.\"GetUsersForTeamLead\"(@p_leader_id)", new[] { new NpgsqlParameter("@p_leader_id", leaderId) });
        }

        public static DataTable GetAllTeams()
        {
            return Database.Database.ExecuteQuery("SELECT * FROM teams.\"GetAllTeams\"()");
        }

        public static DataTable GetTeamMembers(int teamId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM teams.\"GetTeamMembers\"(@p_team_id)", new[] { new NpgsqlParameter("@p_team_id", teamId) });
        }

        public static bool DeleteTeam(int teamId, int currentUserId, string role)
        {
            if (role == "TeamLead" && !IsUserTeamLead(currentUserId, teamId)) return false;
            if (role != "Admin" && role != "TeamLead") return false;
            try
            {
                Database.Database.ExecuteNonQuery("CALL teams.\"DeleteTeam\"(@p_team_id)", new[] { new NpgsqlParameter("@p_team_id", teamId) });
                return true;
            }
            catch { return false; }
        }

        public static bool RemoveUserFromTeam(int teamId, int userId)
        {
            try
            {
                Database.Database.ExecuteNonQuery("CALL teams.\"RemoveUserFromTeam\"(@p_team_id, @p_user_id)", new[] { new NpgsqlParameter("@p_team_id", teamId), new NpgsqlParameter("@p_user_id", userId) });
                return true;
            }
            catch { return false; }
        }
        public static DataTable GetUserTeams(int userId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM teams.\"GetUserTeams\"(@p_user_id)", new[] { new NpgsqlParameter("@p_user_id", userId) });
        }
        public static DataTable GetTeamMembersForLeader(int leaderId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM accounts.\"GetUsersForTeamLead\"(@p_leader_id)",
                new[] { new NpgsqlParameter("@p_leader_id", leaderId) });
        }
    }
}
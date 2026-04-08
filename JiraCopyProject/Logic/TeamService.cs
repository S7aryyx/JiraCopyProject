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
            string insertTeamSql = "INSERT INTO \"Teams\" (name, description, team_lead_id) VALUES (@name, @desc, @leadId) RETURNING id";
            var teamParams = new[]
            {
                new NpgsqlParameter("@name", name),
                new NpgsqlParameter("@desc", description),
                new NpgsqlParameter("@leadId", teamLeadId)
            };
            try
            {
                object result = Database.Database.ExecuteScalar(insertTeamSql, teamParams);
                if (result == null) return null;
                int teamId = Convert.ToInt32(result);
                string insertMemberSql = "INSERT INTO \"TeamMembers\" (team_id, account_id, created_at, is_active) VALUES (@teamId, @accountId, CURRENT_DATE, true)";
                var memberParams = new[] { new NpgsqlParameter("@teamId", teamId), new NpgsqlParameter("@accountId", teamLeadId) };
                Database.Database.ExecuteNonQuery(insertMemberSql, memberParams);
                return teamId;
            }
            catch { return null; }
        }

        public static (int? Id, string Name) GetUserTeam(int accountId)
        {
            DataTable dt = Database.Database.ExecuteQuery("SELECT * FROM \"GetUserTeam\"(@p_account_id)", new[] { new NpgsqlParameter("@p_account_id", accountId) });
            if (dt.Rows.Count == 0) return (null, null);
            return (Convert.ToInt32(dt.Rows[0]["id"]), dt.Rows[0]["name"].ToString());
        }

        public static bool AddUserToTeam(int teamId, int userId, int addedBy)
        {
            string sql = "CALL \"AddUserToTeam\"(@teamId, @userId, @addedBy)";
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
            DataTable dt = Database.Database.ExecuteQuery("SELECT team_lead_id FROM \"Teams\" WHERE id = @teamId", new[] { new NpgsqlParameter("@teamId", teamId) });
            if (dt.Rows.Count == 0) return false;
            DataTable userDt = Database.Database.ExecuteQuery("SELECT role FROM \"Accounts\" WHERE id = @userId", new[] { new NpgsqlParameter("@userId", newLeadId) });
            if (userDt.Rows.Count == 0 || userDt.Rows[0]["role"].ToString() != "TeamLead") return false;
            try
            {
                Database.Database.ExecuteNonQuery("UPDATE \"Teams\" SET team_lead_id = @newLeadId WHERE id = @teamId", new[] { new NpgsqlParameter("@newLeadId", newLeadId), new NpgsqlParameter("@teamId", teamId) });
                return true;
            }
            catch { return false; }
        }

        public static bool IsUserTeamLead(int accountId, int teamId)
        {
            object result = Database.Database.ExecuteScalar("SELECT \"IsUserTeamLead\"(@p_account_id, @p_team_id)", new[] { new NpgsqlParameter("@p_account_id", accountId), new NpgsqlParameter("@p_team_id", teamId) });
            return result != null && Convert.ToBoolean(result);
        }

        public static DataTable GetUserLeadTeams(int accountId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetUserLeadTeams\"(@p_account_id)", new[] { new NpgsqlParameter("@p_account_id", accountId) });
        }

        public static DataTable GetAllTeams()
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetAllTeams\"()");
        }

        public static DataTable GetTeamMembers(int teamId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetTeamMembers\"(@p_team_id)", new[] { new NpgsqlParameter("@p_team_id", teamId) });
        }

        public static bool DeleteTeam(int teamId, int currentUserId, string role)
        {
            if (role == "TeamLead" && !IsUserTeamLead(currentUserId, teamId)) return false;
            if (role != "Admin" && role != "TeamLead") return false;
            try
            {
                Database.Database.ExecuteNonQuery("CALL \"DeleteTeam\"(@p_team_id)", new[] { new NpgsqlParameter("@p_team_id", teamId) });
                return true;
            }
            catch { return false; }
        }

        public static bool RemoveUserFromTeam(int teamId, int userId)
        {
            try
            {
                Database.Database.ExecuteNonQuery("CALL \"RemoveUserFromTeam\"(@p_team_id, @p_user_id)", new[] { new NpgsqlParameter("@p_team_id", teamId), new NpgsqlParameter("@p_user_id", userId) });
                return true;
            }
            catch { return false; }
        }

        public static DataTable GetUserTeams(int userId)
        {
            return Database.Database.ExecuteQuery("SELECT * FROM \"GetUserTeams\"(@p_user_id)", new[] { new NpgsqlParameter("@p_user_id", userId) });
        }
    }
}
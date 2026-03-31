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
                if (result == null)
                {
                    return null;
                }
                int teamId = Convert.ToInt32(result);

                // Добавляем лидера в TeamMembers
                string insertMemberSql = "INSERT INTO \"TeamMembers\" (team_id, account_id, created_at, is_active) VALUES (@teamId, @accountId, CURRENT_DATE, true)";
                var memberParams = new[]
                {
                    new NpgsqlParameter("@teamId", teamId),
                    new NpgsqlParameter("@accountId", teamLeadId)
                };
                Database.Database.ExecuteNonQuery(insertMemberSql, memberParams);
                return teamId;
            }
            catch
            {
                return null;
            }
        }

        public static (int? Id, string Name) GetUserTeam(int accountId)
        {
            string sql = @"SELECT t.id, t.name FROM ""TeamMembers"" tm 
                           JOIN ""Teams"" t ON tm.team_id = t.id 
                           WHERE tm.account_id = @userId AND tm.is_active = true 
                           LIMIT 1";
            var param = new NpgsqlParameter("@userId", accountId);
            DataTable dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0)
            {
                return (null, null);
            }
            else
            {
                int id = Convert.ToInt32(dt.Rows[0]["id"]);
                string name = dt.Rows[0]["name"].ToString();
                return (id, name);
            }
        }

        public static bool AddUserToTeam(int teamId, int userId, int addedById)
        {
            string sql = "CALL \"AddUserToTeam\"(@teamId, @userId, @addedBy)";
            var parameters = new[]
            {
                new NpgsqlParameter("@teamId", teamId),
                new NpgsqlParameter("@userId", userId),
                new NpgsqlParameter("@addedBy", addedById)
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
            if (role != "Admin")
            {
                return false;
            }

            // Проверяем существование команды
            string checkSql = "SELECT team_lead_id FROM \"Teams\" WHERE id = @teamId";
            var param = new NpgsqlParameter("@teamId", teamId);
            DataTable dt = Database.Database.ExecuteQuery(checkSql, new[] { param });
            if (dt.Rows.Count == 0)
            {
                return false;
            }

            // Проверяем, что новый лидер имеет роль TeamLead
            string userSql = "SELECT role FROM \"Accounts\" WHERE id = @userId";
            var userParam = new NpgsqlParameter("@userId", newLeadId);
            DataTable userDt = Database.Database.ExecuteQuery(userSql, new[] { userParam });
            if (userDt.Rows.Count == 0)
            {
                return false;
            }
            string newLeadRole = userDt.Rows[0]["role"].ToString();
            if (newLeadRole != "TeamLead")
            {
                return false;
            }

            // Обновляем команду
            string updateSql = "UPDATE \"Teams\" SET team_lead_id = @newLeadId WHERE id = @teamId";
            var updateParams = new[]
            {
                new NpgsqlParameter("@newLeadId", newLeadId),
                new NpgsqlParameter("@teamId", teamId)
            };
            try
            {
                Database.Database.ExecuteNonQuery(updateSql, updateParams);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsUserTeamLead(int accountId, int teamId)
        {
            string sql = "SELECT id FROM \"Teams\" WHERE id = @teamId AND team_lead_id = @leadId";
            var parameters = new[]
            {
                new NpgsqlParameter("@teamId", teamId),
                new NpgsqlParameter("@leadId", accountId)
            };
            DataTable dt = Database.Database.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable GetUserLeadTeams(int accountId)
        {
            string sql = "SELECT id, name FROM \"Teams\" WHERE team_lead_id = @leadId ORDER BY id";
            var param = new NpgsqlParameter("@leadId", accountId);
            return Database.Database.ExecuteQuery(sql, new[] { param });
        }
    }
}
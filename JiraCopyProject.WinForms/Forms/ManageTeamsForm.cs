using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class ManageTeamsForm : Form
    {
        public ManageTeamsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Load += ManageTeamsForm_Load;
        }

        private void ManageTeamsForm_Load(object sender, EventArgs e)
        {
            LoadTeams();
        }

        private void LoadTeams()
        {
            DataTable teams;
            if (Session.GetRole() == "Admin")
                teams = TeamService.GetAllTeams();
            else
                teams = TeamService.GetUserLeadTeams(Session.GetUserId());
            dgvTeams.DataSource = teams;
            if (teams.Rows.Count > 0)
                dgvTeams.AutoResizeColumns();
        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Название команды:", "Создание команды", "");
            if (string.IsNullOrEmpty(name)) return;
            string description = Microsoft.VisualBasic.Interaction.InputBox("Описание:", "Создание команды", "");
            int? teamId = TeamService.CreateTeam(name, description, Session.GetUserId());
            if (teamId.HasValue)
            {
                MessageBox.Show("Команда создана.", "Успех");
                LoadTeams();
            }
            else
                MessageBox.Show("Ошибка создания.", "Ошибка");
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null) return;
            int teamId = Convert.ToInt32(dgvTeams.CurrentRow.Cells["id"].Value);
            if (MessageBox.Show("Удалить команду?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool success = TeamService.DeleteTeam(teamId, Session.GetUserId(), Session.GetRole());
                MessageBox.Show(success ? "Команда удалена." : "Ошибка удаления.");
                if (success) LoadTeams();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null) return;
            int teamId = Convert.ToInt32(dgvTeams.CurrentRow.Cells["id"].Value);
            string login = Microsoft.VisualBasic.Interaction.InputBox("Введите логин пользователя:", "Добавление в команду", "");
            if (string.IsNullOrEmpty(login)) return;

            string sql = "SELECT * FROM accounts.\"FindUserByLogin\"(@login)";
            var param = new Npgsql.NpgsqlParameter("@login", login);
            var dt = Database.Database.ExecuteQuery(sql, new[] { param });
            if (dt.Rows.Count == 0 || !Convert.ToBoolean(dt.Rows[0]["is_active"]))
            {
                MessageBox.Show("Пользователь не найден или неактивен.");
                return;
            }
            int userId = Convert.ToInt32(dt.Rows[0]["id"]);
            bool success = TeamService.AddUserToTeam(teamId, userId, Session.GetUserId());
            MessageBox.Show(success ? "Пользователь добавлен." : "Ошибка добавления.");
        }

        private void btnShowMembers_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null) return;
            int teamId = Convert.ToInt32(dgvTeams.CurrentRow.Cells["id"].Value);
            DataTable members = TeamService.GetTeamMembers(teamId);
            string memberList = "";
            foreach (DataRow row in members.Rows)
                memberList += $"{row["fullname"]} ({row["login"]}) - {row["role"]}\n";
            MessageBox.Show(string.IsNullOrEmpty(memberList) ? "Нет участников." : memberList, "Участники команды");
        }

        private void btnTransferLead_Click(object sender, EventArgs e)
        {
            if (Session.GetRole() != "Admin")
            {
                MessageBox.Show("Только администратор может передавать лидерство.");
                return;
            }
            if (dgvTeams.CurrentRow == null) return;
            int teamId = Convert.ToInt32(dgvTeams.CurrentRow.Cells["id"].Value);
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите ID нового лидера:", "Передача лидерства", "");
            if (int.TryParse(input, out int newLeadId))
            {
                bool success = TeamService.TransferTeamLead(teamId, newLeadId, Session.GetUserId(), Session.GetRole());
                MessageBox.Show(success ? "Лидерство передано." : "Ошибка передачи.");
                if (success) LoadTeams();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTeams();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
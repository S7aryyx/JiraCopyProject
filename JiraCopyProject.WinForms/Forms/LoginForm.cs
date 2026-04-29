using JiraCopyProject.Database;
using JiraCopyProject.Logic.Models;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ShowError("Введите логин и пароль.");
                return;
            }

            try
            {
                var (id, role, status) = AccountService.Authenticate(login, password);

                if (status != 1 || id == 0)
                {
                    ShowError(status == -1 ? "Аккаунт неактивен." : "Неверный логин или пароль.");
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
                    ShowError("Ошибка загрузки данных пользователя.");
                    return;
                }

                DataRow row = userDt.Rows[0];
                DateTime createdAt;
                object createdObj = row["created_at"];
                if (createdObj is DateOnly dateOnly)
                    createdAt = dateOnly.ToDateTime(TimeOnly.MinValue);
                else
                    createdAt = Convert.ToDateTime(createdObj);

                var currentUser = new Account(
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
                int? teamId = team.Id;
                string teamName = team.Name;

                Session.Login(currentUser, teamId, teamName);

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при входе: {ex.Message}");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Hide();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
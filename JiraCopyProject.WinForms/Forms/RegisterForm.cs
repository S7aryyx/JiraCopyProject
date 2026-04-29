using System;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string email = txtEmail.Text.Trim();
            string fullname = txtFullName.Text.Trim();
            string position = txtPosition.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(fullname))
            {
                ShowResult("Заполните все обязательные поля (логин, пароль, email, ФИО).", false);
                return;
            }

            int result = AccountService.Register(login, password, email, fullname, position);
            string msg = result switch
            {
                1 => "Регистрация прошла успешно!",
                0 => "Ошибка: Логин уже занят.",
                -1 => "Ошибка: Email уже зарегистрирован.",
                _ => "Неизвестная ошибка регистрации."
            };
            bool success = (result == 1);
            ShowResult(msg, success);
            if (success)
            {
                
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 2000;
                timer.Elapsed += (s, args) => { this.Invoke((Action)(() => this.Close())); };
                timer.AutoReset = false;
                timer.Start();
            }
        }

        private void ShowResult(string message, bool isSuccess)
        {
            lblResult.Text = message;
            lblResult.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblResult.Visible = true;
        }
    }
}
using System;
using System.Windows.Forms;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var user = Session.CurrentUser;
            if (user == null)
            {
                MessageBox.Show("Сесия не найдена. Выполните вход.", "Ошибка");
                Application.Exit();
                return;
            }

            string teamInfo = Session.CurrentUserTeamId.HasValue ? $" | Команда: {Session.CurrentUserTeamName}" : "";
            lblUserInfo.Text = $"{user.GetFullname()} ({user.GetRole()}){teamInfo}";

            string role = Session.GetRole();
            bool isAdmin = role == "Admin";
            bool isTeamLead = role == "TeamLead";
            назначитьЗадачуToolStripMenuItem.Visible = isAdmin || isTeamLead;
            команднаяЗадачаToolStripMenuItem.Visible = isAdmin || isTeamLead;
            управлениеКомандамиToolStripMenuItem.Visible = isAdmin || isTeamLead;
            списокПользователейToolStripMenuItem.Visible = isAdmin || isTeamLead;
            копироватьПодзадачиToolStripMenuItem.Visible = isAdmin || isTeamLead;
            тегиToolStripMenuItem.Visible = isAdmin || isTeamLead;
            фильтрыToolStripMenuItem.Visible = isAdmin || isTeamLead;
            историяToolStripMenuItem.Visible = isAdmin || isTeamLead;
        }

        private void моиЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MyTasksForm();
            form.ShowDialog();
        }

        private void создатьЗадачуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CreateEditTaskForm(CreateEditTaskForm.Mode.Create);
            form.ShowDialog();
        }

        private void назначитьЗадачуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CreateEditTaskForm(CreateEditTaskForm.Mode.AssignToUser);
            form.ShowDialog();
        }

        private void команднаяЗадачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CreateEditTaskForm(CreateEditTaskForm.Mode.TeamTask);
            form.ShowDialog();
        }

        private void управлениеКомандамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ManageTeamsForm();
            form.ShowDialog();
        }

        private void списокПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UsersListForm();
            form.ShowDialog();
        }

        private void копироватьПодзадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CopySubtaskForm();
            form.ShowDialog();
        }

        private void тегиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TagsForm();
            form.ShowDialog();
        }

        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FiltersForm();
            form.ShowDialog();
        }

        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HistoryForm();
            form.ShowDialog();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UserStatsForm();
            form.ShowDialog();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Logout();
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
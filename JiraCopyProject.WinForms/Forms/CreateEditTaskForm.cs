using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class CreateEditTaskForm : Form
    {
        public enum Mode { Create, Edit, AssignToUser, TeamTask }

        private Mode _mode;
        private int? _taskId; 
        private DataTable _allTeams;

        public CreateEditTaskForm(Mode mode, int? taskId = null)
        {
            InitializeComponent();
            _mode = mode;
            _taskId = taskId;
            this.StartPosition = FormStartPosition.CenterParent;
            Load += CreateEditTaskForm_Load;
        }

        private void CreateEditTaskForm_Load(object sender, EventArgs e)
        {
            lblTeam.Visible = false;
            cmbTeam.Visible = false;
            txtTeamSearch.Visible = false;
            btnSearchTeam.Visible = false;

            switch (_mode)
            {
                case Mode.Create:
                    this.Text = "Создание задачи";
                    lblReason.Visible = false;
                    txtReason.Visible = false;
                    LoadAssigneesForCreate();
                    break;
                case Mode.Edit:
                    this.Text = "Редактирование задачи";
                    lblReason.Visible = true;
                    txtReason.Visible = true;
                    LoadTaskForEdit();
                    break;
                case Mode.AssignToUser:
                    this.Text = "Назначить задачу пользователю";
                    lblReason.Visible = false;
                    txtReason.Visible = false;
                    LoadAssigneesForAssign();
                    break;
                case Mode.TeamTask:
                    this.Text = "Создать задачу для команды";
                    lblReason.Visible = false;
                    txtReason.Visible = false;
                    lblAssignee.Visible = false;
                    cmbAssignee.Visible = false;
                    lblTeam.Visible = true;
                    cmbTeam.Visible = true;
                    txtTeamSearch.Visible = true;
                    btnSearchTeam.Visible = true;
                    LoadTeamsForTeamTask();
                    break;
            }
        }

        private void LoadAssigneesForCreate()
        {
            DataTable usersTable = new DataTable();
            if (Session.GetRole() == "User")
            {
                usersTable.Columns.Add("id", typeof(int));
                usersTable.Columns.Add("fullname", typeof(string));
                var row = usersTable.NewRow();
                row["id"] = Session.GetUserId();
                row["fullname"] = Session.CurrentUser.GetFullname();
                usersTable.Rows.Add(row);

                cmbAssignee.DataSource = usersTable;
                cmbAssignee.DisplayMember = "fullname";
                cmbAssignee.ValueMember = "id";
                cmbAssignee.Enabled = false;
                cmbAssignee.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (Session.GetRole() == "TeamLead")
            {
                DataTable members = TeamService.GetTeamMembersForLeader(Session.GetUserId());
                cmbAssignee.DataSource = members;
                cmbAssignee.DisplayMember = "fullname";
                cmbAssignee.ValueMember = "id";
                cmbAssignee.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                DataTable allUsers = AccountService.GetAllUsers();
                cmbAssignee.DataSource = allUsers;
                cmbAssignee.DisplayMember = "fullname";
                cmbAssignee.ValueMember = "id";
                cmbAssignee.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            if (cmbAssignee.Items.Count > 0)
                cmbAssignee.SelectedIndex = 0;
        }

        private void LoadAssigneesForAssign()
        {
            DataTable usersTable;
            if (Session.GetRole() == "TeamLead")
            {
                usersTable = TeamService.GetTeamMembersForLeader(Session.GetUserId());
            }
            else
            {
                usersTable = AccountService.GetAllUsers();
            }

            cmbAssignee.DataSource = usersTable;
            cmbAssignee.DisplayMember = "fullname";
            cmbAssignee.ValueMember = "id";
            cmbAssignee.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cmbAssignee.Items.Count > 0)
                cmbAssignee.SelectedIndex = 0;
        }

        private void LoadTeamsForTeamTask()
        {
            string role = Session.GetRole();
            if (role == "Admin")
                _allTeams = TeamService.GetAllTeams();
            else if (role == "TeamLead")
                _allTeams = TeamService.GetUserLeadTeams(Session.GetUserId());
            else
                _allTeams = null;

            if (_allTeams == null || _allTeams.Rows.Count == 0)
            {
                MessageBox.Show("Нет доступных команд для создания задачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            FillTeamsCombo(_allTeams);
        }

        private void FillTeamsCombo(DataTable teams)
        {
            cmbTeam.DataSource = null;
            cmbTeam.DataSource = teams;
            cmbTeam.DisplayMember = "name";
            cmbTeam.ValueMember = "id";
            cmbTeam.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbTeam.Items.Count > 0)
                cmbTeam.SelectedIndex = 0;
        }

        private void btnSearchTeam_Click(object sender, EventArgs e)
        {
            string filter = txtTeamSearch.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                FillTeamsCombo(_allTeams);
                return;
            }

            DataTable filtered = _allTeams.Clone();
            foreach (DataRow row in _allTeams.Rows)
            {
                string name = row["name"].ToString();
                if (name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    filtered.ImportRow(row);
            }
            FillTeamsCombo(filtered);
            if (cmbTeam.Items.Count == 0)
                MessageBox.Show("Команды не найдены.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadTaskForEdit()
        {
            if (!_taskId.HasValue) return;
            var dt = TaskService.GetTaskDetails(_taskId.Value);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Задача не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            DataRow row = dt.Rows[0];
            txtTitle.Text = row["title"].ToString();
            txtDescription.Text = row["description"].ToString();
            if (row["due_date"] != DBNull.Value && row["due_date"] is DateTime due)
                dtpDueDate.Value = due;

            var owners = TaskService.GetTaskOwners(_taskId.Value);
            if (owners.AssigneeId.HasValue)
            {
                var users = AccountService.GetAllUsers();
                cmbAssignee.DataSource = users;
                cmbAssignee.DisplayMember = "fullname";
                cmbAssignee.ValueMember = "id";
                cmbAssignee.SelectedValue = owners.AssigneeId.Value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime dueDate = dtpDueDate.Value;
            int currentUserId = Session.GetUserId();
            bool success = false;

            switch (_mode)
            {
                case Mode.Create:
                    int assigneeId = (int)cmbAssignee.SelectedValue;
                    success = TaskService.CreateTask(title, description, assigneeId, currentUserId, dueDate);
                    break;
                case Mode.Edit:
                    string reason = txtReason.Text.Trim();
                    if (string.IsNullOrEmpty(reason)) reason = "Редактирование задачи";
                    int? newAssigneeId = (int?)cmbAssignee.SelectedValue;
                    success = TaskService.UpdateTask(_taskId.Value,
                        string.IsNullOrEmpty(title) ? null : title,
                        string.IsNullOrEmpty(description) ? null : description,
                        null, null, newAssigneeId,
                        dueDate,
                        currentUserId, reason);
                    break;
                case Mode.AssignToUser:
                    int targetUserId = (int)cmbAssignee.SelectedValue;
                    success = TaskService.CreateTask(title, description, targetUserId, currentUserId, dueDate);
                    break;
                case Mode.TeamTask:
                    if (cmbTeam.SelectedValue == null)
                    {
                        MessageBox.Show("Выберите команду.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int teamId = (int)cmbTeam.SelectedValue;
                    success = TaskService.CreateTeamTask(title, description, teamId, currentUserId, dueDate);
                    break;
            }

            if (success)
            {
                MessageBox.Show("Операция выполнена успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при выполнении операции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
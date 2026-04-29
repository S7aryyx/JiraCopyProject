using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class TaskDetailsForm : Form
    {
        private int _taskId;

        public TaskDetailsForm(int taskId)
        {
            InitializeComponent();
            _taskId = taskId;
            this.StartPosition = FormStartPosition.CenterParent;
            Load += TaskDetailsForm_Load;
        }

        private void TaskDetailsForm_Load(object sender, EventArgs e)
        {
            DataTable dt = TaskService.GetTaskDetailsWithAssignee(_taskId);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Задача не найдена.");
                this.Close();
                return;
            }
            DataRow row = dt.Rows[0];
            lblIdValue.Text = row["id"].ToString();
            lblTitleValue.Text = row["title"].ToString();
            txtDescription.Text = row["description"]?.ToString() ?? "";
            lblDueDateValue.Text = UIHelpers.FormatDateString(row["due_date"]);
            lblStatusValue.Text = row["status_name"].ToString();
            lblCreatorValue.Text = row["creator_fullname"].ToString();
            lblAssigneeValue.Text = row["assignee_fullname"] == DBNull.Value ? "Не назначен" : row["assignee_fullname"].ToString();

            DataTable subtasks = TaskService.GetTaskSubtasks(_taskId);
            dgvSubtasks.DataSource = subtasks;
            if (subtasks.Rows.Count > 0)
                dgvSubtasks.AutoResizeColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
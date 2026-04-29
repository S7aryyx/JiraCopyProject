using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class MyTasksForm : Form
    {
        public MyTasksForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Load += MyTasksForm_Load;
        }

        private void MyTasksForm_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void LoadTasks()
        {
            DataTable dt = TaskService.GetUserTasks(Session.GetUserId());
            dgvTasks.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dgvTasks.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show("Выберите задачу.", "Внимание");
                return;
            }
            int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["id"].Value);
            ChangeStatusForm form = new ChangeStatusForm(taskId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["id"].Value);
            TaskDetailsForm form = new TaskDetailsForm(taskId);
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["id"].Value);
            var owners = TaskService.GetTaskOwners(taskId);
            if (owners.CreatorId != Session.GetUserId())
            {
                MessageBox.Show("Вы можете редактировать только созданные вами задачи.", "Доступ запрещён");
                return;
            }
            CreateEditTaskForm form = new CreateEditTaskForm(CreateEditTaskForm.Mode.Edit, taskId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["id"].Value);
            CommentForm form = new CommentForm(taskId);
            form.ShowDialog();
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["id"].Value);
            TagsForm form = new TagsForm(taskId);
            form.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["id"].Value);
            HistoryForm form = new HistoryForm(taskId);
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
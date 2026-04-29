using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class CopySubtaskForm : Form
    {
        public CopySubtaskForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Load += CopySubtaskForm_Load;
        }

        private void CopySubtaskForm_Load(object sender, EventArgs e)
        {
            LoadAssigneesForSubtask();
        }

        private void LoadAssigneesForSubtask()
        {
            var users = AccountService.GetAllUsers();
            cmbSubAssignee.DataSource = users;
            cmbSubAssignee.DisplayMember = "fullname";
            cmbSubAssignee.ValueMember = "id";
            cmbSubAssignee.SelectedValue = Session.GetUserId();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCopyTaskId.Text, out int taskId))
            {
                MessageBox.Show("Введите корректный ID задачи.");
                return;
            }
            var owners = TaskService.GetTaskOwners(taskId);
            if (owners.CreatorId == 0)
            {
                MessageBox.Show("Задача не найдена.");
                return;
            }

            bool copySubtasks = chkCopySubtasks.Checked;
            int? newId = TaskService.CopyTask(taskId, Session.GetUserId(), owners.AssigneeId ?? 0, copySubtasks);
            if (newId.HasValue)
                MessageBox.Show($"Задача скопирована. Новый ID: {newId}");
            else
                MessageBox.Show("Ошибка копирования.");
        }

        private void btnCreateSubtask_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtParentId.Text, out int parentId))
            {
                MessageBox.Show("Введите ID родительской задачи.");
                return;
            }
            string title = txtSubTitle.Text.Trim();
            string desc = txtSubDesc.Text.Trim();
            int assigneeId = (int)cmbSubAssignee.SelectedValue;
            DateTime dueDate = dtpSubDue.Value;

            bool success = TaskService.CreateSubtask(parentId, title, desc, assigneeId, Session.GetUserId(), dueDate);
            MessageBox.Show(success ? "Подзадача создана." : "Ошибка создания.");
            if (success)
            {
                txtParentId.Clear();
                txtSubTitle.Clear();
                txtSubDesc.Clear();
            }
        }

        private void btnShowTree_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRootTaskId.Text, out int taskId))
            {
                MessageBox.Show("Введите ID задачи.");
                return;
            }
            treeSubtasks.Nodes.Clear();
            TreeNode rootNode = new TreeNode($"Задача {taskId}");
            treeSubtasks.Nodes.Add(rootNode);
            LoadSubtasks(taskId, rootNode);
            treeSubtasks.ExpandAll();
        }

        private void LoadSubtasks(int parentId, TreeNode parentNode)
        {
            DataTable dt = TaskService.GetTaskSubtasks(parentId);
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string title = row["title"].ToString();
                string status = row["status_name"].ToString();
                string due = UIHelpers.FormatDateString(row["due_date"]);
                TreeNode node = new TreeNode($"{title} (ID:{id}, {status}, {due})");
                parentNode.Nodes.Add(node);
                LoadSubtasks(id, node);
            }
        }
    }
}
using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class TagsForm : Form
    {
        public TagsForm(int? preselectedTaskId = null)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Load += TagsForm_Load;
            if (preselectedTaskId.HasValue)
            {
                txtTaskIdView.Text = preselectedTaskId.ToString();
                tabControlTags.SelectedTab = tpTaskTags;
                btnShowTaskTags_Click(null, null);
            }
        }

        private void TagsForm_Load(object sender, EventArgs e)
        {
            LoadTagsIntoComboBoxes();
        }

        private void LoadTagsIntoComboBoxes()
        {
            DataTable tags = TaskService.GetAllTags();
            cmbTagAssign.DataSource = tags;
            cmbTagAssign.DisplayMember = "name";
            cmbTagAssign.ValueMember = "id";
            cmbTagSearch.DataSource = tags;
            cmbTagSearch.DisplayMember = "name";
            cmbTagSearch.ValueMember = "id";
        }

        private void btnCreateTag_Click(object sender, EventArgs e)
        {
            string name = txtTagName.Text.Trim();
            string color = txtTagColor.Text.Trim();
            if (string.IsNullOrEmpty(color)) color = "#FFFFFF";
            bool success = TaskService.CreateTag(name, color);
            MessageBox.Show(success ? "Тег создан." : "Ошибка создания.");
            if (success) LoadTagsIntoComboBoxes();
        }

        private void btnAssignTag_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTaskIdAssign.Text, out int taskId))
            {
                MessageBox.Show("Введите ID задачи.");
                return;
            }
            int tagId = (int)cmbTagAssign.SelectedValue;
            bool success = TaskService.AddTagToTask(taskId, tagId);
            MessageBox.Show(success ? "Тег назначен." : "Ошибка назначения.");
        }

        private void btnShowTaskTags_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTaskIdView.Text, out int taskId))
            {
                MessageBox.Show("Введите ID задачи.");
                return;
            }
            DataTable dt = TaskService.GetTaskTags(taskId);
            dgvTaskTags.DataSource = dt;
            if (dt.Rows.Count > 0)
                dgvTaskTags.AutoResizeColumns();
        }

        private void btnSearchByTag_Click(object sender, EventArgs e)
        {
            int tagId = (int)cmbTagSearch.SelectedValue;
            DataTable dt = TaskService.GetTasksByTag(tagId);
            dgvTasksByTag.DataSource = dt;
            if (dt.Rows.Count > 0)
                dgvTasksByTag.AutoResizeColumns();
        }
    }
}
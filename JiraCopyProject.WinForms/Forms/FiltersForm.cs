using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class FiltersForm : Form
    {
        public FiltersForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Load += FiltersForm_Load;
        }

        private void FiltersForm_Load(object sender, EventArgs e)
        {
            LoadStatuses();
        }

        private void LoadStatuses()
        {
            DataTable statuses = TaskService.GetAvailableStatuses();
            cmbStatus.DataSource = statuses;
            cmbStatus.DisplayMember = "name";
            cmbStatus.ValueMember = "id";
        }

        private void btnSearchText_Click(object sender, EventArgs e)
        {
            string query = txtSearchQuery.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Введите поисковый запрос.");
                return;
            }
            DataTable dt = TaskService.SearchTasks(query, Session.GetUserId(), Session.GetRole());
            dgvSearchResult.DataSource = dt;
            if (dt.Rows.Count > 0)
                dgvSearchResult.AutoResizeColumns();
        }

        private void btnFilterByStatus_Click(object sender, EventArgs e)
        {
            int statusId = (int)cmbStatus.SelectedValue;
            DataTable dt = TaskService.GetTasksByStatus(statusId);
            dgvByStatus.DataSource = dt;
            if (dt.Rows.Count > 0)
                dgvByStatus.AutoResizeColumns();
        }

        private void btnShowOverdue_Click(object sender, EventArgs e)
        {
            DataTable dt = TaskService.GetOverdueTasks(Session.GetUserId());
            dgvOverdue.DataSource = dt;
            if (dt.Rows.Count > 0)
                dgvOverdue.AutoResizeColumns();
        }
    }
}
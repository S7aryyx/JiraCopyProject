using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(int? preselectedTaskId = null)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            if (preselectedTaskId.HasValue)
            {
                txtTaskId.Text = preselectedTaskId.Value.ToString();
                btnLoad_Click(null, null);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTaskId.Text, out int taskId))
            {
                MessageBox.Show("Введите корректный ID задачи.");
                return;
            }

            DataTable statusHistory = TaskService.GetTaskStatusHistory(taskId);
            dgvStatusHistory.DataSource = statusHistory;
            if (statusHistory.Rows.Count > 0)
                dgvStatusHistory.AutoResizeColumns();

            DataTable deadlineHistory = TaskService.GetTaskDeadlineHistory(taskId);
            dgvDeadlineHistory.DataSource = deadlineHistory;
            if (deadlineHistory.Rows.Count > 0)
                dgvDeadlineHistory.AutoResizeColumns();
        }
    }
}
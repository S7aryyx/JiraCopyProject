using System;
using System.Data;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class ChangeStatusForm : Form
    {
        private int _taskId;

        public ChangeStatusForm(int taskId)
        {
            InitializeComponent();
            _taskId = taskId;
            this.StartPosition = FormStartPosition.CenterParent;
            Load += ChangeStatusForm_Load;
        }

        private void ChangeStatusForm_Load(object sender, EventArgs e)
        {
            DataTable statuses = TaskService.GetAvailableStatuses();
            cmbNewStatus.DataSource = statuses;
            cmbNewStatus.DisplayMember = "name";
            cmbNewStatus.ValueMember = "id";
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int newStatusId = (int)cmbNewStatus.SelectedValue;
            string reason = txtReason.Text.Trim();
            if (string.IsNullOrEmpty(reason))
                reason = "Изменение статуса";
            bool success = TaskService.ChangeTaskStatus(_taskId, newStatusId, Session.GetUserId(), reason);
            if (success)
            {
                MessageBox.Show("Статус изменён.", "Успех");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка изменения статуса.", "Ошибка");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
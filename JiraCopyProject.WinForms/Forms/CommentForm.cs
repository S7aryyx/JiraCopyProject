using System;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class CommentForm : Form
    {
        private int _taskId;

        public CommentForm(int taskId)
        {
            InitializeComponent();
            _taskId = taskId;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string comment = rtbComment.Text.Trim();
            if (string.IsNullOrEmpty(comment))
            {
                MessageBox.Show("Введите комментарий.");
                return;
            }
            bool success = TaskService.AddComment(_taskId, Session.GetUserId(), comment);
            if (success)
            {
                MessageBox.Show("Комментарий добавлен.", "Успех");
                rtbComment.Clear();
            }
            else
            {
                MessageBox.Show("Ошибка добавления комментария.", "Ошибка");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
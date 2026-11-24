using System;
using System.Windows.Forms;
using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class UserStatsForm : Form
    {
        public UserStatsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Load += UserStatsForm_Load;
        }

        private void UserStatsForm_Load(object sender, EventArgs e)
        {
            var stats = AccountService.GetUserStats(Session.GetUserId());
            lblTotalValue.Text = stats.Total.ToString();
            lblCompletedValue.Text = stats.Completed.ToString();
            lblOverdueValue.Text = stats.Overdue.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

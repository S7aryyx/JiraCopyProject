using JiraCopyProject.Logic.Services;
using JiraCopyProject.WinForms.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace JiraCopyProject.WinForms.Forms
{
    public partial class UsersListForm : Form
    {
        public UsersListForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Load += UsersListForm_Load;
        }

        private void UsersListForm_Load(object sender, EventArgs e)
        {
            DataTable dt;
            if (Session.GetRole() == "Admin")
                dt = AccountService.GetAllUsers();
            else if (Session.GetRole() == "TeamLead")
                dt = TeamService.GetUsersForTeamLead(Session.GetUserId());
            else
                dt = null;
            dgvUsers.DataSource = dt;
        }

        private void LoadUsers()
        {
            DataTable dt = AccountService.GetAllUsers();
            dgvUsers.DataSource = dt;
            if (dt.Rows.Count > 0)
                dgvUsers.AutoResizeColumns();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
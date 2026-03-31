namespace JiraCopyProject.Logic
{
    public static class RoleHelper
    {
        public static bool CanCreateTaskForOthers(string role)
        {
            return role == "TeamLead" || role == "Admin";
        }

        public static bool CanChangeTaskStatus(string role, bool isCreator, bool isAssignee)
        {
            if (role == "Admin") return true;
            if (role == "TeamLead") return isCreator;
            if (role == "User") return isAssignee;
            return false;
        }

        public static bool CanEditTask(string role, bool isCreator)
        {
            return isCreator || role == "Admin";
        }

        public static bool CanManageTeam(string role)
        {
            return role == "TeamLead" || role == "Admin";
        }

        public static bool CanTransferTeamLead(string role)
        {
            return role == "Admin";
        }
    }
}
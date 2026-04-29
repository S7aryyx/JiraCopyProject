using JiraCopyProject.Logic.Models;
using JiraCopyProject.Logic.Services;

namespace JiraCopyProject.WinForms.Helpers
{
    public static class Session
    {
        public static Account CurrentUser { get; private set; }
        public static int? CurrentUserTeamId { get; private set; }
        public static string CurrentUserTeamName { get; private set; }

        public static void Login(Account user, int? teamId, string teamName)
        {
            CurrentUser = user;
            CurrentUserTeamId = teamId;
            CurrentUserTeamName = teamName;
        }

        public static void Logout()
        {
            CurrentUser = null;
            CurrentUserTeamId = null;
            CurrentUserTeamName = null;
        }

        public static string GetRole() => CurrentUser?.GetRole() ?? "User";
        public static int GetUserId() => CurrentUser?.GetId() ?? 0;
        public static string GetFullName() => CurrentUser?.GetFullname() ?? "";
    }
}
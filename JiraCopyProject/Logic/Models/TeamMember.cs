namespace JiraCopyProject.Logic.Models
{
    public class TeamMember
    {
        private int teamId;
        private int accountId;
        private DateTime createdAt;
        private bool isActive;

        public TeamMember() { }

        public TeamMember(int teamId, int accountId, DateTime createdAt, bool isActive)
        {
            this.teamId = teamId;
            this.accountId = accountId;
            this.createdAt = createdAt;
            this.isActive = isActive;
        }

        public int GetTeamId()
        {
            return teamId;
        }
        public void SetTeamId(int value)
        {
            teamId = value;
        }

        public int GetAccountId()
        {
            return accountId;
        }
        public void SetAccountId(int value)
        {
            accountId = value;
        }

        public DateTime GetCreatedAt()
        {
            return createdAt;
        }
        public void SetCreatedAt(DateTime value)
        {
            createdAt = value;
        }

        public bool GetIsActive()
        {
            return isActive;
        }
        public void SetIsActive(bool value)
        {
            isActive = value;
        }
    }
}
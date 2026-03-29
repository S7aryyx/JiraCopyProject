namespace JiraConsole.Models
{
    public class Team
    {
        private int id;
        private string name;
        private string description;
        private int? teamLeadId;
        private DateTime createdAt;

        public Team() { }

        public Team(int id, string name, string description, int? teamLeadId, DateTime createdAt)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.teamLeadId = teamLeadId;
            this.createdAt = createdAt;
        }

        public int GetId() { return id; }
        public void SetId(int value) { id = value; }

        public string GetName() { return name; }
        public void SetName(string value) { name = value; }

        public string GetDescription() { return description; }
        public void SetDescription(string value) { description = value; }

        public int? GetTeamLeadId() { return teamLeadId; }
        public void SetTeamLeadId(int? value) { teamLeadId = value; }

        public DateTime GetCreatedAt() { return createdAt; }
        public void SetCreatedAt(DateTime value) { createdAt = value; }
    }
}
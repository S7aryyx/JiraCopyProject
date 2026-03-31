namespace JiraCopyProject.Logic.Models
{
    public class Task
    {
        private int id;
        private string title;
        private string description;
        private int statusId;
        private DateTime createDate;
        private DateTime dueDate;
        private int teamId;          
        private int assigneeId;      
        private int creatorId;
        private int parentTaskId;
        private DateTime createdAt;
        private DateTime updatedAt;

        public Task() { }

        public Task(int id, string title, string description, int statusId, DateTime createDate,
                    DateTime dueDate, int teamId, int assigneeId, int creatorId, int parentTaskId,
                    DateTime createdAt, DateTime updatedAt)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.statusId = statusId;
            this.createDate = createDate;
            this.dueDate = dueDate;
            this.teamId = teamId;
            this.assigneeId = assigneeId;
            this.creatorId = creatorId;
            this.parentTaskId = parentTaskId;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public int GetId() 
        {
            return id;
        }
        public void SetId(int value) 
        { 
            id = value; 
        }

        public string GetTitle() 
        { 
            return title;
        }
        public void SetTitle(string value) 
        { 
            title = value; 
        }

        public string GetDescription() 
        { 
            return description; 
        }
        public void SetDescription(string value) 
        { 
            description = value; 
        }
        public int GetStatusId() 
        { 
            return statusId; 
        }
        public void SetStatusId(int value)
        { 
            statusId = value; 
        }

        public DateTime GetCreateDate() 
        { 
            return createDate; 
        }
        public void SetCreateDate(DateTime value) 
        { 
            createDate = value; 
        }

        public DateTime GetDueDate() 
        { 
            return dueDate; 
        }
        public void SetDueDate(DateTime value) 
        { 
            dueDate = value; 
        }

        public int GetTeamId()
        { 
            return teamId; 
        }
        public void SetTeamId(int value)
        {
            if (value < 0)
            {
                teamId = 0;
            }
            else
            {
                teamId = value;
            }
        }

        public int GetAssigneeId() 
        { 
            return assigneeId; 
        }
        public void SetAssigneeId(int value)
        {
            if (value < 0)
            {
                assigneeId = 0;
            }
            else
            {
                assigneeId = value;
            }
        }

        public int GetCreatorId() 
        { 
            return creatorId; 
        }
        public void SetCreatorId(int value)
        { 
            creatorId = value; 
        }

        public int GetParentTaskId()
        { 
            return parentTaskId; 
        }
        public void SetParentTaskId(int value)
        {
            if (value < 0)
            {
                parentTaskId = 0;
            }
            else
            {
                parentTaskId = value;
            }
        }

        public DateTime GetCreatedAt() 
        { 
            return createdAt; 
        }
        public void SetCreatedAt(DateTime value) 
        {
            createdAt = value; 
        }
        public DateTime GetUpdatedAt()
        { 
            return updatedAt; 
        }
        public void SetUpdatedAt(DateTime value) 
        { 
            updatedAt = value;
        }
    }
}

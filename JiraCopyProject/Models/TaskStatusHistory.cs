namespace JiraCopyProject.Models
{
    public class TaskStatusHistory
    {
        private int id;
        private int taskId;
        private int oldStatusId;
        private int newStatusId;
        private int changedById;
        private string reason;
        private DateTime changedAt;

        public TaskStatusHistory() { }

        public TaskStatusHistory(int id, int taskId, int oldStatusId, int newStatusId,
                                 int changedById, string reason, DateTime changedAt)
        {
            this.id = id;
            this.taskId = taskId;
            this.oldStatusId = oldStatusId;
            this.newStatusId = newStatusId;
            this.changedById = changedById;
            this.reason = reason;
            this.changedAt = changedAt;
        }

        public int GetId() { return id; }
        public void SetId(int value) { id = value; }

        public int GetTaskId() { return taskId; }
        public void SetTaskId(int value) { taskId = value; }

        public int GetOldStatusId() { return oldStatusId; }
        public void SetOldStatusId(int value) { oldStatusId = value; }

        public int GetNewStatusId() { return newStatusId; }
        public void SetNewStatusId(int value) { newStatusId = value; }

        public int GetChangedById() { return changedById; }
        public void SetChangedById(int value) { changedById = value; }

        public string GetReason() { return reason; }
        public void SetReason(string value) { reason = value; }

        public DateTime GetChangedAt() { return changedAt; }
        public void SetChangedAt(DateTime value) { changedAt = value; }
    }
}
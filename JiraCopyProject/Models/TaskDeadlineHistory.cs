namespace JiraCopyProject.Models
{
    public class TaskDeadlineHistory
    {
        private int id;
        private int taskId;
        private DateTime oldDueDate;
        private DateTime newDueDate;
        private int changedById;
        private string reason;
        private DateTime changedAt;

        public TaskDeadlineHistory() { }

        public TaskDeadlineHistory(int id, int taskId, DateTime oldDueDate, DateTime newDueDate,
                                   int changedById, string reason, DateTime changedAt)
        {
            this.id = id;
            this.taskId = taskId;
            this.oldDueDate = oldDueDate;
            this.newDueDate = newDueDate;
            this.changedById = changedById;
            this.reason = reason;
            this.changedAt = changedAt;
        }

        public int GetId() { return id; }
        public void SetId(int value) { id = value; }

        public int GetTaskId() { return taskId; }
        public void SetTaskId(int value) { taskId = value; }

        public DateTime GetOldDueDate() { return oldDueDate; }
        public void SetOldDueDate(DateTime value) { oldDueDate = value; }

        public DateTime GetNewDueDate() { return newDueDate; }
        public void SetNewDueDate(DateTime value) { newDueDate = value; }

        public int GetChangedById() { return changedById; }
        public void SetChangedById(int value) { changedById = value; }

        public string GetReason() { return reason; }
        public void SetReason(string value) { reason = value; }

        public DateTime GetChangedAt() { return changedAt; }
        public void SetChangedAt(DateTime value) { changedAt = value; }
    }
}
namespace JiraCopyProject.Models
{
    public class TaskComment
    {
        private int id;
        private int taskId;
        private int authorId;
        private string comment;
        private DateTime createdAt;
        private DateTime updatedAt;

        public TaskComment() { }

        public TaskComment(int id, int taskId, int authorId, string comment,
                           DateTime createdAt, DateTime updatedAt)
        {
            this.id = id;
            this.taskId = taskId;
            this.authorId = authorId;
            this.comment = comment;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public int GetId() { return id; }
        public void SetId(int value) { id = value; }

        public int GetTaskId() { return taskId; }
        public void SetTaskId(int value) { taskId = value; }

        public int GetAuthorId() { return authorId; }
        public void SetAuthorId(int value) { authorId = value; }

        public string GetComment() { return comment; }
        public void SetComment(string value) { comment = value; }

        public DateTime GetCreatedAt() { return createdAt; }
        public void SetCreatedAt(DateTime value) { createdAt = value; }

        public DateTime GetUpdatedAt() { return updatedAt; }
        public void SetUpdatedAt(DateTime value) { updatedAt = value; }
    }
}
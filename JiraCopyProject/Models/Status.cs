namespace JiraCopyProject.Models
{
    public class Status
    {
        private int id;
        private string name;
        private string code;
        private string description;
        private int sortOrder;

        public Status() { }

        public Status(int id, string name, string code, string description, int sortOrder)
        {
            this.id = id;
            this.name = name;
            this.code = code;
            this.description = description;
            this.sortOrder = sortOrder;
        }

        public int GetId() { return id; }
        public void SetId(int value) { id = value; }

        public string GetName() { return name; }
        public void SetName(string value) { name = value; }

        public string GetCode() { return code; }
        public void SetCode(string value) { code = value; }

        public string GetDescription() { return description; }
        public void SetDescription(string value) { description = value; }

        public int GetSortOrder() { return sortOrder; }
        public void SetSortOrder(int value) { sortOrder = value; }
    }
}
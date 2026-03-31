namespace JiraCopyProject.Logic.Models
{
    public class Account
    {
        private int id;
        private string login;
        private string passwordHash;
        private string email;
        private string fullname;
        private string position;
        private string role;
        private DateTime createdAt;
        private bool isActive;
        public Account() { }
        public Account(int id, string login, string passwordHash, string email, string fullname,
                       string position, string role, DateTime createdAt, bool isActive)
        {
            this.id = id;
            this.login = login;
            this.passwordHash = passwordHash;
            this.email = email;
            this.fullname = fullname;
            this.position = position;
            this.role = role;
            this.createdAt = createdAt;
            this.isActive = isActive;
        }
        public int GetId() 
        { 
            return id;
        }
        public void SetId(int value) 
        { 
            id = value; 
        }

        public string GetLogin() 
        { 
            return login; 
        }
        public void SetLogin(string value) { 
            login = value; 
        }

        public string GetPasswordHash() { 
            return passwordHash; 
        }
        public void SetPasswordHash(string value) { 
            passwordHash = value; 
        }

        public string GetEmail() {
            return email; 
        }
        public void SetEmail(string value) 
        { 
            email = value; 
        }

        public string GetFullname() 
        { 
            return fullname; 
        }
        
        public void SetFullname(string value) 
        { 
            fullname = value; 
        }

        public string GetPosition() 
        { 
            return position; 
        }
        public void SetPosition(string value) 
        { 
            position = value; 
        }

        public string GetRole() 
        { 
            return role; 
        }
        public void SetRole(string value) 
        { 
            role = value; 
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
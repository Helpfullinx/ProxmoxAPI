using ProxmoxAPI.Access.Domain;

namespace ProxmoxAPI.Utility
{
    public class User
    {
        private string username;
        private string password;
        private readonly Realm realm;
        
        public User(string username, string password, Realm realm)
        {
            this.username = username;
            this.password = password;
            this.realm = realm;
        }

        public void EnsureUserAndPassNonNull()
        {
            if (username == null || password == null) throw new ArgumentNullException("username or password");
        }

        public string UserName { get { return (username + "@" + realm.type.ToString().ToLower()); } set { username = value; } }

        public string Password { get { return password; } set { password = value; } }
    }
}

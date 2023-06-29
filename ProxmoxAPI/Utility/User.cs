using ProxmoxAPI.Access.Domain;

namespace ProxmoxAPI.Utility
{
    public static class User
    {
        private static string? username;
        private static string? password;
        private static Realm? realm;

        public static void EnsureUserAndPassNonNull()
        {
            if (username == null || password == null) throw new ArgumentNullException("username or password");
        }

        public static string Username { get { return (username + "@" + realm.type.ToString().ToLower()); } set { username = value; } }

        public static string Password { get { return password; } set { password = value; } }

        public static Realm Realm { get { return realm; } set {  realm = value; } }
    }
}

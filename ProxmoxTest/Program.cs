using ProxmoxAPI.Access;
using ProxmoxAPI.Access.Domain;
using ProxmoxAPI.Utility;

internal class Program
{
    static async Task Main(string[] args)
    {
        string username = Environment.GetEnvironmentVariable("PVE_USERNAME", EnvironmentVariableTarget.User);
        string password = Environment.GetEnvironmentVariable("PVE_PASSWORD", EnvironmentVariableTarget.User);

        User.Username = username;
        User.Password = password;
        User.Realm = new Realm("pam", Realm.RealmType.PAM);

        Socket.IP = "100.124.115.75";
        Socket.Port = "8006";

        ProxmoxConnection pmconn = new();

        Ticket ticket = null;

        try
        {
            ticket = await pmconn.getTicket();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(ticket);
    }
}

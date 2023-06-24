using ProxmoxAPI.Access;
using ProxmoxAPI.Access.Domain;
using ProxmoxAPI.Utility;

internal class Program
{
    static async Task Main(string[] args)
    {
        string username = Environment.GetEnvironmentVariable("PVE_USERNAME", EnvironmentVariableTarget.User);
        string password = Environment.GetEnvironmentVariable("PVE_PASSWORD", EnvironmentVariableTarget.User);

        User user = new User(username, password, new Realm("pam", Realm.RealmType.PAM));
        Socket socket = new("100.124.115.75", "8006");
        Connection.socket = socket;
        Connection.user = user;

        HttpInterface.client.BaseAddress = new Uri("https://" + socket.ToString() + "/");

        Ticket ticket = new Ticket();
        Domain domain = new Domain();
        try
        {
            await ticket.POST();
            await domain.GET();
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(ticket + "\n" + domain);
    }
}

using ProxmoxAPI.Access;
using ProxmoxAPI.Utility;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        var username = Environment.GetEnvironmentVariable("PVE_USERNAME", EnvironmentVariableTarget.User);
        var password = Environment.GetEnvironmentVariable("PVE_PASSWORD", EnvironmentVariableTarget.User);
        var user = new User(username, password);

        var socket = new Socket("100.124.115.75", "8006");
        var con = new Connection(user, socket);
        var ticket = new Ticket(con);

        Console.WriteLine(ticket.getTicket);
    }
}

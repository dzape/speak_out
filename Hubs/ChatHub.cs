using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace speak_out.Hubs
{
    public class ChatHub : Hub
    {
        //var users = _context.Users.FirstOrDefault(a => a.UserName == login.UserName);

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

    public class MyHub : Hub // Send from user
    {
        public void Send(string userId, string message)
        {
            Clients.User(userId).SendAsync(message);
        }
    }
}
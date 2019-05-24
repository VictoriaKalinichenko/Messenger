using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Messenger.BusinessLogic.Hubs
{
    public class MessengerHub : Hub
    {
        public async Task SendMessage(string sender, string receiver, string message)
        {
            await Clients.User(receiver).SendAsync("ReceiveMessage", sender, message);
        }
    }
}

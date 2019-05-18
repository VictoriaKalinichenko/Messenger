using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Messenger.BusinessLogic.Hubs
{
    public class MessengerHub : Hub
    {
        public async Task SendMessage(string userId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userId, message);
        }
    }
}

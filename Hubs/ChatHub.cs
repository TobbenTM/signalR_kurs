using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using signalR.Models;

namespace signalR.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.Others.ReceiveMessage(message);
        }
    }
}

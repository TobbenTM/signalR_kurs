using System.Threading.Tasks;

namespace signalR.Models
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}

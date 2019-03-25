using Microsoft.AspNetCore.SignalR;

namespace signalR.Hubs
{
    public class PingPongHub : Hub
    {
        public string Ping()
        {
            return "Pong!";
        }
    }
}

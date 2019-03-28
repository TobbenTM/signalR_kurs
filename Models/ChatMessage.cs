using System;

namespace signalR.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public string Initiator { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

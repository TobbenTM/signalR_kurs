using System.Collections.Generic;

namespace signalR
{
    public class State
    {
        public HashSet<string> Viewers { get; } = new HashSet<string>();
    }
}

using Microsoft.AspNetCore.SignalR;

namespace signalR.Hubs
{
    public class ExceptionHub : Hub
    {
        public void Throw()
        {
            // By default, SignalR will sanitize exceptions thrown.
            // HubException is an exception (heh) to that rule, and
            // will return the exception message to the caller client
            throw new HubException("This method is not implemented!");
        }
    }
}

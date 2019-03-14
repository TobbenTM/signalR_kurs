using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace signalR.Hubs
{
    public class ViewerHub : Hub
    {
        private readonly State _state;
        private readonly ILogger _logger;

        public ViewerHub(State state, ILogger<ViewerHub> logger)
        {
            _state = state;
            _logger = logger;
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogInformation($"Viewer left! Connection id: {Context.ConnectionId}");
            if (_state.Viewers.Contains(Context.ConnectionId))
            {
                _state.Viewers.Remove(Context.ConnectionId);
            }
            await Clients.Others.SendAsync("ViewersUpdated", _state.Viewers);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task<ICollection<string>> Join()
        {
            _logger.LogInformation($"Viewer joined! Connection id: {Context.ConnectionId}");
            if (!_state.Viewers.Contains(Context.ConnectionId))
            {
                _state.Viewers.Add(Context.ConnectionId);
            }
            await Clients.Others.SendAsync("ViewersUpdated", _state.Viewers);
            return _state.Viewers;
        }
    }
}

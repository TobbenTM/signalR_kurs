public class LifecycleHub : Hub
{
    // Will contain exception if disconnected due to network failure
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Clients.Others.SendAsync("UserDisconnected", Context.User);
        await base.OnDisconnectedAsync(exception);
    }
    // This is a nice place to assign the client to groups
    public override Task OnConnectedAsync()
    {
        await Clients.Others.SendAsync("UserConnected", Context.User);
        await base.OnConnectedAsync();
    }
}
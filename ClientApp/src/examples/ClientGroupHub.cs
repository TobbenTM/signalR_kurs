public class ClientGroupHub : Hub
{
    [Authorize]
    public async Task Subscribe(string group)
    {
        // You can message any client(s)
        await Clients.Others.SendAsync("UserSubscribed", Context.User);
        await Clients.All.SendAsync("UserOnline", Context.User);

        // You can add a connection to groups:
        await Groups.AddToGroupAsync(Context.ConnectionId, group);

        // And message entire groups:
        await Clients.Group(group).SendAsync("UserJoinedGroup", Context.User);
    }
}
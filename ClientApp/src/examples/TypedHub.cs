public class TypedHub : Hub<ITypedClient>
{
    public async Task SendMessage(string message) {
        await Clients.All.ReceiveMessage(message);
    }
}
public interface ITypedClient
{
    Task ReceiveMessage(string message);
}
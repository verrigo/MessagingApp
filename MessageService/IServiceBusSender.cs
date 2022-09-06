namespace MessageService
{
    public interface IServiceBusSender
    {
        Task SendMessageAsync<T>(T message);
    }
}
namespace MessageService
{
    public interface IServiceBusSender
    {
        Task SendMessageAsync(string message);
    }
}
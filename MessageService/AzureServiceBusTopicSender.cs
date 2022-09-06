using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;

namespace MessageService
{
    public class AzureServiceBusTopicSender : IServiceBusSender
    {
        private readonly ServiceBusClient _azureServiceBusClient;
        private readonly ServiceBusSender _serviceBusTopicSender;
        private readonly ILogger<AzureServiceBusTopicSender> _logger;

        public AzureServiceBusTopicSender(IAzureClientFactory<ServiceBusClient> azureClientFactory, ILogger<AzureServiceBusTopicSender> logger)
        {
            _azureServiceBusClient = azureClientFactory.CreateClient("AzureServiceBus");
            _serviceBusTopicSender = _azureServiceBusClient.CreateSender("messages");
            _logger = logger;
        }

        public async Task SendMessageAsync(string message)
        {
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(message);
            try
            {
                await _serviceBusTopicSender.SendMessageAsync(serviceBusMessage).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IServiceBusSender _serviceBusSender;
        private ILogger<MessageController> _logger;
        private IServiceBusMessageProcessor _serviceBusMessageProcessor;
        public MessageController(IServiceBusMessageProcessor serviceBusMessageProcessor, IServiceBusSender serviceBusSender, ILogger<MessageController> logger)
        {
            _serviceBusSender = serviceBusSender;
            _logger = logger;
            _serviceBusMessageProcessor = serviceBusMessageProcessor;
        }

        [HttpPost(Name = "SendMessage")]
        public async Task Send(Message message)
        {
            await _serviceBusSender.SendMessageAsync(message).ConfigureAwait(false);
        }

        //this will not work. 
        //Need to figure out something else;
        //will move this to another micro service
        //gRPC? why not
        [HttpGet(Name = "GetMessages")]
        public async Task<Message> Get(string receiverId)
        {

        }
    }
}

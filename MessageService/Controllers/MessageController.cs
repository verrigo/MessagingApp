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
        public MessageController(IServiceBusSender serviceBusSender, ILogger<MessageController> logger)
        {
            _serviceBusSender = serviceBusSender;
            _logger = logger;
        }

        [HttpPost(Name ="SendMessage")]
        public async Task Send(Message message)
        {
            await _serviceBusSender.SendMessageAsync(message);
        }
    }
}

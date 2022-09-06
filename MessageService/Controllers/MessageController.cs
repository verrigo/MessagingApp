using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IServiceBusSender _serviceBusSender;

        public MessageController(IServiceBusSender serviceBusSender)
        {
            _serviceBusSender = serviceBusSender;
        }

        [HttpPost(Name ="SendMessage")]
        public void Send(Message message)
        {
            Console.WriteLine(message);
        }
    }
}

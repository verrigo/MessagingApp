using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IServiceBusClient _serviceBusClient;

        public MessageController(IServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }

        [HttpPost(Name ="SendMessage")]
        public void Send(Message message)
        {
            Console.WriteLine(message);
        }
    }
}

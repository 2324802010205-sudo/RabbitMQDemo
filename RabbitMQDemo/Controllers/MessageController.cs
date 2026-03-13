using Microsoft.AspNetCore.Mvc;
using Messaging.Common.Publishing;

namespace RabbitMQDemo.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : Controller
    {
        private readonly Publisher _publisher;

        public MessageController(Publisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        public IActionResult Send()
        {
            var msg = new
            {
                Name = "Hello RabbitMQ"
            };

            _publisher.Publish("demo.exchange", "demo.key", msg);

            return Ok("Message Sent");
        }
    }
}

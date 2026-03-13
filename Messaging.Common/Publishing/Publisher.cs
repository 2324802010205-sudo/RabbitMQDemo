using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Messaging.Common.Publishing
{
    public class Publisher
    {
        private readonly IModel _channel;

        public Publisher(IModel channel)
        {
            _channel = channel;
        }

        public void Publish<T>(string exchange, string routingKey, T message)
        {
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(
                exchange: "demo.exchange",
                routingKey: "demo.key",
                body: body);
        }
    }
}

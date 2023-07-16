using PhoneDictionary.RabbitMQService;
using RabbitMQ.Client;
using System.Text;

namespace PhoneDictionary.API
{
    public static class RabbitMQPublisher
    {
        public static void Publisher(string queueName, string message)
        {
            var _rabbitmqClient = new RabbitMQClient();

            using (var connection = _rabbitmqClient.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));
                }
            }
        }
    }
    
}

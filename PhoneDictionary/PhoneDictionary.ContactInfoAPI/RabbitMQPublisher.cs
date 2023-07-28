using Newtonsoft.Json;
using PhoneDictionary.Entity.Models;
using PhoneDictionary.RabbitMQService;
using RabbitMQ.Client;
using System.Text;

namespace PhoneDictionary.ContactInfoAPI
{
    public static class RabbitMQPublisher
    {
        private static readonly string rabbitMQReportQueueName = "ReportQueue";

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
        public static void Publisher(RabbitMQReportModel message)
        {
            var _rabbitmqClient = new RabbitMQClient();

            using (var connection = _rabbitmqClient.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(rabbitMQReportQueueName, false, false, false, null);

                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);
                    channel.BasicPublish("", rabbitMQReportQueueName, null, body);
                }
            }
        }
    }
}

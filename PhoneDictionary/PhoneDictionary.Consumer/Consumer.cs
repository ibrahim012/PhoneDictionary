using PhoneDictionary._Business.Services;
using PhoneDictionary.RabbitMQService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.Consumer
{
    public static class Consumer
    {
        public static void Consume()
        {
            RabbitMQClient _rabbitMQService = new RabbitMQClient();
            string filePath = @"C:\Users\ASUS\Desktop\PhoneDictionary\PhoneDictionary\PhoneDictionary.Consumer\Reports\\";
            string reportName = "GetPhoneNumberCountByLocationName";

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    // Received event'i sürekli listen modunda olacaktır.
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        var res = new PhoneDictionaryService().GetPhoneNumberCountByLocationName(message);
                        string fileName = reportName+"_"+DateTime.Now.ToString("yyyyMMddHHmm")+".txt";
                        string fullPath = filePath + fileName;

                        File.WriteAllText(fullPath, res.ToString());
                    };

                    channel.BasicConsume("GetPhoneNumberCountByLocationNameReport", false, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}

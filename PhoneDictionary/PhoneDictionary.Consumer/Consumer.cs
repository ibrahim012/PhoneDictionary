using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity.Models;
using PhoneDictionary.RabbitMQService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneDictionary.Consumer
{
    public class Consumer
    {
        private IPhoneDictionaryService _phoneDictionaryService;
        public Consumer()
        {
            _phoneDictionaryService = new PhoneDictionaryService();
        }
        private readonly string rabbitMQReportQueueName = "ReportQueue";
        public void Consume()
        { 
            var message = "";
            RabbitMQReportModel respModel = new RabbitMQReportModel();
            RabbitMQClient _rabbitMQService = new RabbitMQClient();
             
            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    // Received event'i sürekli listen modunda olacaktır.
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        message = Encoding.UTF8.GetString(body);
                        respModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RabbitMQReportModel>(message);
                        
                        //buraya queuedan okuduğu dataları alıp, yeni bir tane servis oluşturulacak
                        //oluşturulan servise queuedaki mesaj parametre olarak verilecek
                        //servis verilen parametredeki değerleri dbdeki report tabloya insert edecek.
                    };

                    channel.BasicConsume(rabbitMQReportQueueName, false, consumer);
                    Thread.Sleep(5000);
                }
                var r = _phoneDictionaryService.AddReport(respModel);
            }
            
        }
    }
}

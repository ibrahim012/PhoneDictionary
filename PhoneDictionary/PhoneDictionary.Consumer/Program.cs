using System;
using System.Text;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Consumer;
using PhoneDictionary.RabbitMQService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

class Program
{
    static void Main(string[] args)
    {
        Consumer.Consume();
    }
}
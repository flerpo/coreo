using System;
using System.Net;
using Confluent.Kafka;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Coreo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConnectToKafka();
        }

        private static void ConnectToKafka()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "my-cluster-kafka-bootstrap.kafka.svc.cluster.local:9092",
                ClientId = "moop",
            };
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            producer.Produce(
                "meep", new Message<Null, string> { Value = "hello rami" });
            Console.WriteLine("Sent message to kafka");
            producer.Flush();
        }
       
    }
}
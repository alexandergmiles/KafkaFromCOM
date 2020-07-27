using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using System.IO.Ports;

namespace KafkaStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Printing because duh
            Console.WriteLine("Hello Kafka producer! We're going to be writing to Kafka!");

            //Configuration object where 
            var kafkaConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
            
            //Create the port
            SerialPort port = new SerialPort("COM3"); 
            
            //Create the observer
            var comObserver = new COMToKafka(port);
            
            //While the port is
            do
            {
                //Get the current message
                var result = comObserver.ReadFromCOM("COM3");
                
                //Write the message
                Console.WriteLine(result);
            } while (comObserver.IsPortOpen);

            ///Print to Kafka

            //using (var p = new ProducerBuilder<Null, string>(kafkaConfig).Build())
            //{
            //    try
            //    {
            //        var dr = await p.ProduceAsync("topic-to-write-to", new Message<Null, string> { Value = "this is a test" });
            //        Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
            //    }
            //    catch
            //    {

                //    }
                //}
        }
    }
}

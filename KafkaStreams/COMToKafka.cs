using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace KafkaStreams
{
    public class COMToKafka
    {
        public SerialPort comPort { get; }
        public bool IsPortOpen => comPort.IsOpen;
        public COMToKafka(SerialPort port) => comPort = port; 

        //We need to setup a handshake here that configures messages
        //Becading is fun


        /// <summary>
        /// Reads from the COM port
        /// </summary>
        /// <returns></returns>
        public string ReadFromCOM(string port)
        {
            //We know we're reading messages of 9600 bits
            byte[] messageBuffer = new byte[9600];

            //We want this because we want to keep track of the number of messages
            double messageNumber = 0;

            if(!comPort.IsOpen)
            {
                comPort.Open();
            }

            //Is the port open?
            if (comPort.IsOpen)
            {
                //Get the  most recent message
                var result = comPort.Read(messageBuffer, 0, 9600);
                //Decode from byte array to string
                var stuffToWrite = Encoding.UTF8.GetString(messageBuffer);

                //Sleep for one second
                System.Threading.Thread.Sleep(1000);

                //Should probably setup a handshake thing

                //Return the most recent message
                return stuffToWrite;
            }

            return "";
        }


        /// <summary>
        /// Does the monitoring for LUMENs and writes that back to the kafka stream
        /// </summary>
        public void BeginMonitoring()
        {
            //Write to kafka using kSQL
        }
    }
}

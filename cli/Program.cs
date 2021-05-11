using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace cli
{
    class Program
    {
        static void Main(string[] args)
        {
            // Greeting
            Console.WriteLine("Write a message");

            // Socket Initialization
            UdpClient client = new UdpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"),8080));

            // Message
            Console.Write("> ");
            string inputs = Console.ReadLine();
            if (inputs!=null) {
                byte[] bytesent = Encoding.ASCII.GetBytes(inputs);
                client.Send(bytesent,bytesent.Length);
                Console.WriteLine("Message sended succesfully.");

                client.Close();
            }

            // Idle Mode
            Console.ReadLine();
        }
    }
}

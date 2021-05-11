using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace cli2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Variables */
            int  size;

            /* Socket creation */
            Socket skt = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            /* Defining endpoint */
            IPAddress srvAddress = IPAddress.Parse("127.0.0.1");
            Int32 prtNumber = 8080;
            IPEndPoint srvEndPoint = new IPEndPoint(srvAddress, prtNumber);

            /* Sending data */
            int choice = 0;
            while(choice!=4) {

                Console.WriteLine("Choice the type of message to send:\n    1. Text Message\n    2. Text File\n    3. Quit");
                Console.Write("> ");
                string opt = Console.ReadLine();
                byte[] optByte = Encoding.ASCII.GetBytes(opt);
                skt.SendTo(optByte,srvEndPoint);
                int.TryParse(opt, out choice);
                Console.Write("\n\n\n");

                /* Data */
                switch (choice) {

                    case 1:
                        Console.Write("Write your message:\n> ");
                        string msg = Console.ReadLine();
                        byte[] msgBytes = Encoding.ASCII.GetBytes(msg);
                        size = skt.SendTo(msgBytes,srvEndPoint);
                        Console.WriteLine("{0} byte(s) succesfully send.\n\n\n", size);
                        break;

                    case 2:
                        Console.Write("Choose file: \n> ");
                        string fileName = Console.ReadLine().Trim();
                        if (File.Exists(fileName))
                        {
                            // Sending filename.
                            byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                            size = skt.SendTo(fileNameBytes,srvEndPoint);

                            // Sending file data.
                            // Use sudo sysctl -w net.inet.udp.maxdgram=65535 to send larger datagrams on Mac OS
                            // Source: https://stackoverflow.com/questions/22819214/udp-message-too-long
                            // Original size: 9216
                            byte[] fileDataBytes = new byte[60000]; 
                            using (FileStream fs = File.OpenRead(fileName))
                                { fs.Read(fileDataBytes, 0, fileDataBytes.Length); }
                            size = skt.SendTo(fileDataBytes,srvEndPoint);
                            Console.WriteLine("File sent succesfully.\n\n\n", size);
                        } 
                        else 
                        {
                            Console.WriteLine("File not found.\n\n\n");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Quitting...\n\n\n");
                        break;

                    default:
                        Console.WriteLine("Wrong selection.\n\n\n");
                        break;
                }
            }
        }
    }
}

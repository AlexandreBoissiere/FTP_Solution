using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Total_library.Network.Com;

namespace FTP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            int initialCount = client.got.Count;
            string serverIP = null;
            Console.WriteLine("Server IP to connect : ");
            serverIP = Console.ReadLine();

            while (true)
            {
                if (client.got.Count > initialCount)
                {
                    string received = Encoding.ASCII.GetString(client.got[0].Data);
                    if (received.Contains("READCONTENT_"))
                    {
                        received = received.Remove(0, 12);
                        Console.WriteLine($"Content : {received}");
                        client.got.RemoveAt(0);
                    }
                    else
                    {
                        Console.WriteLine(received);
                        client.got.RemoveAt(0);
                    }
                }

                Console.WriteLine("mode to use (write, read, append) : ");
                string smode = Console.ReadLine();
                Console.WriteLine("File to use : ");
                string sfile = Console.ReadLine();
                
                if (smode == "read")
                {
                    string mode = "R";
                    string sent = $"{mode}{sfile}";

                    client.Send(sent, serverIP);
                }
                else if (smode == "write")
                {
                    string mode = "W";

                    Console.WriteLine("Content to write : ");
                    string content = Console.ReadLine();

                    string sent = $"{mode}{sfile}#{content}";

                    client.Send(sent, serverIP);
                }
                else if (smode == "append")
                {
                    string mode = "A";

                    Console.WriteLine("Content to append : ");
                    string content = Console.ReadLine();

                    string sent = $"{mode}{sfile}#{content}";

                    client.Send(sent, serverIP);
                }
                else
                {
                    Console.WriteLine("Unknown mode !");
                    continue;
                }

                Thread.Sleep(500);
            }
        }
    }
}

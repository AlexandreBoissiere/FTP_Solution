using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Total_library.Network;
using static Total_library.Network.Com;

namespace FTP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            int initialCount = server.got.Count;
            Console.WriteLine("LISTENING...");
            
            while (true)
            {
                if (server.got.Count > initialCount)
                {
                    try
                    {
                        ComData cd = server.got[0];
                        string input = Encoding.ASCII.GetString(cd.Data);
                        string filename = "";
                        string content = "";
                        int? mode = null;

                        if (input[0] == 'W')
                        {
                            mode = 1;
                        }
                        else if (input[0] == 'R')
                        {
                            mode = 2;
                        }
                        else if (input[0] == 'A')
                        {
                            mode = 3;
                        }
                        else
                        {
                            server.Send("Error : unknown mode !", cd.Client.Address.ToString());
                            server.got.RemoveAt(0);
                            continue;
                        }

                        input = input.Remove(0, 1);

                        if (mode != 2 && mode != null)
                        {
                            for (int i = 0; i < input.Length; i++)
                            {
                                if (input[i] == '#' && input[i - 1] != '|')
                                {
                                    content = input.Remove(0, i + 1);
                                    break;
                                }
                                else
                                {
                                    filename += input[i];
                                }
                            }
                        }
                        else
                        {
                            filename = input;
                        }

                        if (mode == 1)
                        {
                            File.WriteAllText(filename, content);
                            Console.WriteLine($"{DateTime.Now} => {cd.Client.Address.ToString()} has written in {filename} : {content}");
                        }
                        else if (mode == 2)
                        {
                            string fileContent = File.ReadAllText(filename);
                            server.Send($"READCONTENT_{fileContent}", cd.Client.Address.ToString());
                            Console.WriteLine($"{DateTime.Now} => {cd.Client.Address.ToString()} has read {filename}");
                        }
                        else if (mode == 3)
                        {
                            File.AppendAllText(filename, content);
                            Console.WriteLine($"{DateTime.Now} => {cd.Client.Address.ToString()} has appended in {filename} : {content}");
                        }

                        mode = null;
                        filename = "";
                        content = "";

                        server.got.RemoveAt(0);
                    }
                    catch
                    {
                        server.Send("Error while recepting data !", server.got[0].Client.Address.ToString());
                        server.got.RemoveAt(0);
                        continue;
                    }
                }
            }
        }
    }
}

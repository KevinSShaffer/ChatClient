using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatClient
{
    class Program
    {
        const int port = 13000;
        static readonly IPAddress server = IPAddress.Parse("127.0.0.1");

        static void Main(string[] args)
        {
            Console.WriteLine($"Connection to server: {server.ToString()}:{port}");

            var client = new TcpClient(new IPEndPoint(server, port));

            Console.WriteLine("Connected!");

            using (var stream = client.GetStream())
            {
                while (true)
                {
                    string message = Console.ReadLine();

                    stream.Write(Encoding.ASCII.GetBytes(message));

                    Console.WriteLine($"Send: {message}");
                }
            }
        }
    }
}

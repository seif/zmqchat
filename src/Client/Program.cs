using System;
using System.Text;
using ZeroMQ;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // ZMQ Context and client socket
            using (ZmqContext context = ZmqContext.Create())
            using (ZmqSocket client = context.CreateSocket(SocketType.PUB))
            {
                client.Bind("tcp://*:9000");

                while (true)
                {
                    var message = Console.ReadLine();
                    client.Send("seif: " + message, Encoding.ASCII);
                }
            }
        }
    }
}

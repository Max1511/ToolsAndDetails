using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ToolsAndDetailsServer
{
    public class Program
    {
        private const string ip = "127.0.0.1";
        private const int port = 8080;

        static void Main(string[] args)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(1);

            var storage = new Storage();
            var messageHandler = new MessageHandler();

            var listener = tcpSocket.Accept();

            Console.WriteLine("Server is ready to work");

            while (true)
            {
                try
                {
                    var message = string.Empty;
                    do
                    {
                        var buffer = new byte[512];
                        var size = listener.Receive(buffer);
                        message = Encoding.UTF8.GetString(buffer, 0, size);
                    }
                    while (listener.Available > 0);

                    Console.WriteLine(message);

                    var answer = messageHandler.Handle(ref storage, message);

                    if (answer == "exit")
                    {
                        listener.Shutdown(SocketShutdown.Both);
                        listener.Close();
                        return;
                    }

                    if (answer != null)
                        listener.Send(Encoding.UTF8.GetBytes(answer));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
        }
    }
}

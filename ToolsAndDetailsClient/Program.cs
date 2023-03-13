using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ToolsAndDetailsClient
{
    internal class Program
    {
        private const string ip = "127.0.0.1";
        private const int port = 8080;

        static void Main(string[] args)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Connect(tcpEndPoint);

            while (true)
            {
                Console.WriteLine("Write a command:");
                string command = Console.ReadLine();

                var data = Encoding.UTF8.GetBytes(command);
                tcpSocket.Send(data);

                var buffer = new byte[1024];
                var size = 0;
                var answer = String.Empty;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                if (answer == "exit")
                {
                    tcpSocket.Shutdown(SocketShutdown.Both);
                    tcpSocket.Close();
                    return;
                }

                Console.WriteLine(answer);
            }
        }
    }
}

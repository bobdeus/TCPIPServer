using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPIPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(iPAddress, 5001);
            listener.Start();
            Console.WriteLine($"Server started on: {listener.LocalEndpoint}");
            Socket socket = listener.AcceptSocket();
            Console.WriteLine($"Someone connected on: {socket.RemoteEndPoint}");

            byte[] bytes = new byte[4096];
            int remainingBytes = socket.Receive(bytes);
            for (int i = 0; i < remainingBytes; i++)
            {
                Console.Write(Convert.ToChar(bytes[i]));                
            }

            socket.Send(Encoding.ASCII.GetBytes("The server got stuff"));
            socket.Close();
            listener.Stop();
        }
    }
}

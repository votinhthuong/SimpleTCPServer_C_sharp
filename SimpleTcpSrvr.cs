using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Because I use Vietnamese in the slogan wellcome, so I have to use this Encoding UTF8
            Console.OutputEncoding = Encoding.UTF8;
            
            //I test this diagram Server-Client in my own computer so I decided to use my loopback IP in here.
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),5000);

            //Create Socket
            Socket server = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);


            //Create Binding
            server.Bind(ipep);

            //Create Listen
            server.Listen(10);

            //Encoding UTF8 set above use here
            Console.WriteLine("Đang chờ Client kết nối đến...");

            //If Client try to connect, Server will accept in this step
            Socket client = server.Accept();

            //This string "slogan" will appear in the Client side
            string welcome = "Welcome to my test server!";

            //All this thing to make Send and Receive in both side
            int recv;

            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(welcome);

            client.Send(data,data.Length,SocketFlags.None);

            //Close connection
            server.Close();

            client.Close();

            //This line just make the program pause screen, nothing more :")) hahaha
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using DAL.DB;

namespace MonsterCardTradingGame.Server {
    class MyServer {

        protected int _port;
        TcpListener _listener;
        Database _db;
        public MyServer() {


            //Console.WriteLine("A simple server running...\n");

            //TcpListener serverListener = new TcpListener(IPAddress.Loopback, 8000); //loopback -> localhost
            //serverListener.Start(5); //queue length -> 5

            //while (true) {

            //    TcpClient clientSocket = serverListener.AcceptTcpClient();
            //    new Task(() => {
            //        try {
            //            StreamWriter writer = new StreamWriter(clientSocket.GetStream());
            //            StreamReader reader = new StreamReader(clientSocket.GetStream());

            //            writer.WriteLine("Welcome to my server!");
            //            writer.WriteLine("Please enter your command...");
            //            writer.Flush();

            //            string message;
            //            do {
            //                message = reader.ReadLine(); //reads until return and returns string
            //                Console.WriteLine($"recieved: {message}");


            //            } while (message != "quit");
            //        }
            //        catch (Exception e) {
            //            Console.WriteLine($"error occured {e.Message}");
            //        }
            //    }).Start();


            //}

        }

        public void Run() {


        }

    }
}

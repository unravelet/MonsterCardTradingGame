using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MonsterCardTradingGame.Server {
    class MyServer {


        public MyServer() {
            Console.WriteLine("A simple server running...\n");

            //strg .
            TcpListener serverListener = new TcpListener(IPAddress.Loopback, 8000); //loopback -> localhost
            serverListener.Start(5); //how big is queue -> 5

            while (true) {

                TcpClient clientSocket = serverListener.AcceptTcpClient();
                new Task(() => {
                    try {
                        var writer = new StreamWriter(clientSocket.GetStream());
                        var reader = new StreamReader(clientSocket.GetStream());

                        writer.WriteLine("Welcome to my server!");
                        writer.WriteLine("Please enter your command...");
                        writer.Flush();

                        string message;
                        do {
                            message = reader.ReadLine(); //reads until return and returns string
                            Console.WriteLine($"recieved: {message}");


                        } while (message != "quit");
                    }
                    catch (Exception e) {
                        Console.WriteLine($"error occured {e.Message}");
                    }
                }).Start();
            }


        }

    }
}

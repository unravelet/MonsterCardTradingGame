using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace MonsterCardTradingGame.Server {
    class Client {

        public Client() {
            Console.WriteLine("A simple Client!");

            TcpClient clientSocket = new TcpClient("localhost", 8000);
            var writer = new StreamWriter(clientSocket.GetStream());
            var reader = new StreamReader(clientSocket.GetStream());

            Console.WriteLine($"{reader.ReadLine()}");
            Console.WriteLine($"{reader.ReadLine()}");

            string input = null;
            while ((input = Console.ReadLine()) != "quit") {

                writer.WriteLine(input);
                writer.Flush();

            }
            writer.WriteLine("quit");
        }

    }
}

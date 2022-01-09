using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonsterCardTradingGame.Controller;

namespace MonsterCardTradingGame.Server {
    public class HttpProcessor {
        private TcpClient socket;
        private HttpServer httpServer;

        public string Method { get; private set; }
        public string Path { get; private set; }
        public string Version { get; private set; }

        public Dictionary<string, string> Headers { get; }

        public HttpProcessor(TcpClient s, HttpServer httpServer) {
            this.socket = s;
            this.httpServer = httpServer;

            Method = null;
            Headers = new();
        }

        public void Process() {
            var writer = new StreamWriter(socket.GetStream()) { AutoFlush = true };
            var reader = new StreamReader(socket.GetStream());

            var HttpReader = new HttpReader();
            var request = new HttpRequest();
            Console.WriteLine("handling request..");
            request = HttpReader.ReadRequest(reader);
            

            HttpController httpController = new();
            
            if(httpServer.Controllers.TryGetValue(request.Path, out httpController) == true) {//out writes in httpController
                switch (request.Method.ToLower()) {
                    case "get":
                        HttpResponse response = httpController.Get(request);
                        Console.WriteLine(response.Status);
                        writer.WriteLine($"{response.version} {response.Status}");
                        break;
                    case "post":
                        response = httpController.Post(request);
                        Console.WriteLine(response.Status);
                        writer.WriteLine($"{response.version} {response.Status}");
                        break;
                    case"delete":
                        response = httpController.Delete(request);
                        writer.WriteLine($"{response.version} {response.Status}");
                        break;
                    default:
                        Console.WriteLine("couldnt read method");
                        break;

                }
            }

            writer.Flush();
            writer.Close();
        }

        private void WriteLine(StreamWriter writer, string s) {
            Console.WriteLine(s);
            writer.WriteLine(s);
        }
    }

}



using DAL.DB;
using MonsterCardTradingGame.Server;

namespace MonsterCardTradingGame {
    class Program {
        static void Main(string[] args) {
            Database db = new Database("Host = localhost; Username = postgres; Password = ; Database = MCTG");
            Console.WriteLine("Simple HTTP-Server!");
            Console.CancelKeyPress += (sender, e) => Environment.Exit(0);

            var server = new HttpServer(8080, db);

            server.Run();

        }

    }
}

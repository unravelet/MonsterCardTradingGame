
using MonsterCardTradingGame.Models;
using MonsterCardTradingGame.Server;
using System.Diagnostics;

namespace MonsterCardTradingGame {
    class Program {
        static void Main(string[] args) {
            //MyServer server = new MyServer();
            string name, password;

            Console.WriteLine("Creating User, please enter name and password: ");
            name = Console.ReadLine();
            password = Console.ReadLine();
            User user1 = new User(name, password);
            user1.BuyPackage();
            user1.CreateDeck();

            Console.WriteLine("Creating User, please enter name and password: ");
            name = Console.ReadLine();
            password = Console.ReadLine();
            User user2 = new User(name, password);
            user2.BuyPackage();
            user2.CreateDeck();


            Battle battle = new Battle(user1, user2);
            battle.StartBattle();

        }

    }
}

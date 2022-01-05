using DAL.DB;
using DAL.Repository;
using MonsterCardTradingGame.Models;

namespace DAL {
    class Program {
        static void Main(string[] args) {

            Database db = new Database("Host = localhost; Username = postgres; Password = KnautschgesichtmitDatenbank; Database = MCTG");

            string name, password;
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine("Creating User, please enter name and password: ");
            name = Console.ReadLine();
            password = Console.ReadLine();

            //create user
            User user1 = new User(name, password, Guid.NewGuid());

            //user buys cards
            //user1.BuyPackage(user1.Username);

            //add user to db
            UserRepository userrepo = new UserRepository(db);
            //userrepo.Create(user1);

            

            //add cards to db
            //CardRepository cardrepo = new CardRepository(db);
            //for (int i = 0; i < user1._userCards.Count; i++) {
            //    cardrepo.Create(user1._userCards[i]);
            //}
            
        }

    }
}


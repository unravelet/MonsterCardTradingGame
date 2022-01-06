using DAL.DB;
using DAL.Repository;
using MonsterCardTradingGame.Models;

namespace DAL {
    class Program {
        static void Main(string[] args) {

            Database db = new Database("Host = localhost; Username = postgres; Password = KnautschgesichtmitDatenbank; Database = MCTG");

            string name, password;
            Console.WriteLine("Creating User, please enter name and password: ");
            name = Console.ReadLine();
            password = Console.ReadLine();

            //create user
            //User user1 = new User(name, Guid.NewGuid(), password, 20 );

            //user buys cards
            //user1.BuyPackage(user1);

            //add user to db
            UserRepository userrepo = new UserRepository(db);
            //if (userrepo.UsernameExists(user1.Username)) {
            //    Console.WriteLine("Username already exists");
            //}
            //else {
            //    Console.WriteLine("created user");
            //    userrepo.Create(user1);
                
            //}

            userrepo.Delete(new Guid(userrepo.GetUid(name)));
            
            
            

            //add cards to db
            //CardRepository cardrepo = new CardRepository(db);
            //for (int i = 0; i < user1._userCards.Count; i++) {
            //    cardrepo.Create(user1._userCards[i]);
            //}

        }

        

    }
}


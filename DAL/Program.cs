using DAL.DB;
using DAL.Repository;
using MonsterCardTradingGame.Models;

namespace DAL {
    class Program {
        static void Main(string[] args) {

            Database db = new Database("Host = localhost; Username = postgres; Password = KnautschgesichtmitDatenbank; Database = MCTG");
            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();
            string name, password;
            //Console.WriteLine("Creating User, please enter name and password: ");
            //name = Console.ReadLine();
            //password = Console.ReadLine();
            UserRepository userrepo = new UserRepository(db);
            CardRepository cardrepo = new CardRepository(db);

            User bekki = userrepo.FindUser("bekki");
            User rival = userrepo.FindUser("rival");

            bekki._stack = cardrepo.GetUserStack(bekki.Username);
            rival._stack = cardrepo.GetUserStack(rival.Username);

            bekki.CreateDeck();
            rival.CreateDeck();

            Battle battle = new Battle(bekki, rival);
            battle.StartBattle();

            userrepo.Update(bekki);
            userrepo.Update(rival);

            //create user
            //User bekki = new User(name, Guid.NewGuid(), password, 20);

            //user buys cards
            //bekki.BuyPackage(bekki);

            //if (userrepo.UsernameExists(user1.Username)) {
            //    Console.WriteLine("Username already exists");
            //}
            //else {
            //    Console.WriteLine("created user");
            //    userrepo.Create(user1);

            //}

            //userrepo.Create(bekki);

            //User dummy = userrepo.FindUser("bekki");
            //dummy.Coins = 5;
            //userrepo.Update(dummy);

            //users = userrepo.ReadAll();

            //for (int i = 0; i < users.Count; i++) {
            //    Console.WriteLine(users[i].Username);
            //}

            //add cards to db
            //CardRepository cardrepo = new CardRepository(db);
            //for (int i = 0; i < bekki._userCards.Count; i++) {
            //    cardrepo.Create(bekki._userCards[i]);
            //}

            //cards = cardrepo.GetUserStack(bekki);
            //for (int i = 0; i < cards.Count; i++) { 
            //    Console.WriteLine(cards[i].ElementType + "" + cards[i].MonsterType);
            //}

            //userrepo.Delete("bekki");
           
        }

        

    }
}


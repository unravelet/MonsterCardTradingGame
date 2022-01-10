using DAL.DB;
using DAL.Repository;
using Models;

namespace DAL {
    class Program {
        static void Main(string[] args) {

            //Database db = new Database("Host = localhost; Username = postgres; Password = KnautschgesichtmitDatenbank; Database = MCTG");
            //List<User> users = new List<User>();
            //List<Card> cards = new List<Card>();
            //string name, password;
            
            //UserRepository userrepo = new UserRepository(db);
            //CardRepository cardrepo = new CardRepository(db);
            //ScoreRepository scorerepo = new ScoreRepository(db);

            //User bekki = userrepo.FindUser("bekki");
            //User rival = userrepo.FindUser("rival");

            //if (scorerepo.UsernameExists(bekki.Username)) {
            //    ScoreBoard score = scorerepo.GetScoreData(bekki.Username);
            //    bekki.SetScoreData(score.Score, score.Wins, score.Losses, score.WinLoseRatio);
            //}
            //if (scorerepo.UsernameExists(rival.Username)) {
            //    ScoreBoard score = scorerepo.GetScoreData(rival.Username);
            //    rival.SetScoreData(score.Score, score.Wins, score.Losses, score.WinLoseRatio);
            //}

            //bekki._stack = cardrepo.GetUserStack(bekki.Username);
            //rival._stack = cardrepo.GetUserStack(rival.Username);

            //bekki.CreateDeck();
            //rival.CreateDeck();

            //Battle battle = new Battle(bekki, rival);
            //battle.StartBattle();

            //userrepo.Update(bekki);
            //scorerepo.Update(bekki);
            //scorerepo.Update(rival);
            //userrepo.Update(rival);

            

        }



    }
}


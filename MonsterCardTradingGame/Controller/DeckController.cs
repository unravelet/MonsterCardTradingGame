using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;

namespace MonsterCardTradingGame.Controller {
    //CONFIGURE DECK
    public class DeckController : HttpController {

        DeckRepository _deckRepo;
        CardRepository _cardRepo;
        UserRepository _userRepo;
        List<Card> cards;
        List<Card> deck;

        public DeckController(UserRepository userRepo, CardRepository cardRepo, DeckRepository deckRepo) {
            _cardRepo = cardRepo;
            _userRepo = userRepo;
            _deckRepo = deckRepo;
        }

        public override HttpResponse Put(HttpRequest request) {
            deck = new List<Card>();
            deck = JsonConvert.DeserializeObject<List<Card>>(request.Body);
            HttpResponse response = new HttpResponse();

            for (int i = 0; i < deck.Count; i++) {
                deck[i] = _cardRepo.FindUsersCard(deck[i].Owner, deck[i].Name);
                _deckRepo.Create(deck[i]);
                Console.WriteLine(deck[i].Name);
                response.Body += deck[i].Name + "\n";
            }

            response.Status = 200;

            return response;
        }

        public override HttpResponse Get(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);
            HttpResponse response = new HttpResponse();

            if (_userRepo.UserLogin(user.Username, user.Password)) {
                user = _userRepo.FindUser(user.Username);
                if (_deckRepo.CheckFullDeck(user.Username)) {
                    user._deck = _deckRepo.GetUserDeck(user.Username);
                    Console.WriteLine(user.Username + "'s deck: ");

                    for (int i = 0; i < user._deck.Count; i++) {
                        Console.WriteLine(user._deck[i].Name);
                        response.Body += user._deck[i].Name + "\n";
                    }


                    response.Status = 200;
                    return response;
                }

            }

            return response;
        }


    }

}


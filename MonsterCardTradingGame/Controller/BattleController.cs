using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;

namespace MonsterCardTradingGame.Controller {
    //START BATTLE
    public class BattleController : HttpController {

        UserRepository _userRepo;
        CardRepository _cardRepo;
        DeckRepository _deckRepo;
        User _player1;
        User _player2;
        List<User> players;
        Battle _battle;
        public BattleController(UserRepository userRepo, CardRepository cardRepo, DeckRepository deckRepo) {
            _userRepo = userRepo;
            _cardRepo = cardRepo;
            _deckRepo = deckRepo;

        }

        public override HttpResponse Post(HttpRequest request) {
            players = new List<User>();
            players = JsonConvert.DeserializeObject<List<User>>(request.Body);

            HttpResponse response = new HttpResponse();

            if (_userRepo.UserLogin(players[0].Username, players[0].Password) && _userRepo.UserLogin(players[1].Username, players[1].Password)) {
                /*login users
                 get users from db
                get deck
                battle
                update users
                */

                for (int i = 0; i < players.Count; i++) {
                    players[i] = _userRepo.FindUser(players[i].Username);
                    players[i]._deck = _deckRepo.GetUserDeck(players[i].Username);
                }
                _player1 = players[0];
                _player2 = players[1];

                _battle = new Battle(_player1, _player2);
                _battle.StartBattle();

                response.Status = (HttpStatus)200;
                return response;
            }


            return response;
        }
    }
}

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
        ScoreRepository _scoreRepo;
        User _player1;
        User _player2;
        List<User> players;
        Battle _battle;
        public BattleController(UserRepository userRepo, CardRepository cardRepo, DeckRepository deckRepo, ScoreRepository scoreRepo) {
            _userRepo = userRepo;
            _cardRepo = cardRepo;
            _deckRepo = deckRepo;
            _scoreRepo = scoreRepo;

        }

        public override HttpResponse Post(HttpRequest request) {
            players = new List<User>();
            players = JsonConvert.DeserializeObject<List<User>>(request.Body);

            HttpResponse response = new HttpResponse();

            if (_userRepo.UserLogin(players[0].Username, players[0].Password) && _userRepo.UserLogin(players[1].Username, players[1].Password)) {

                for (int i = 0; i < players.Count; i++) {
                    players[i] = _userRepo.FindUser(players[i].Username);
                    players[i]._deck = _deckRepo.GetUserDeck(players[i].Username);
                }

                _player1 = players[0];
                _player2 = players[1];

                if (_scoreRepo.UsernameExists(_player1.Username)) {
                    ScoreBoard score = _scoreRepo.GetScoreData(_player1.Username);
                    _player1.SetScoreData(score.Score, score.Wins, score.Losses, score.WinLoseRatio);
                }
                if (_scoreRepo.UsernameExists(_player2.Username)) {
                    ScoreBoard score = _scoreRepo.GetScoreData(_player2.Username);
                    _player2.SetScoreData(score.Score, score.Wins, score.Losses, score.WinLoseRatio);
                }

                _battle = new Battle(_player1, _player2);
                response.Body = _battle.StartBattle();

                _userRepo.Update(_player1);
                _scoreRepo.Update(_player1);
                _userRepo.Update(_player2);
                _scoreRepo.Update(_player2);


                response.Status = 200;
                return response;
            }


            return response;
        }
    }
}

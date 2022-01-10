using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;

namespace MonsterCardTradingGame.Controller {
    //SHOW SCOREBOARD
    public class ScoreController : HttpController {

        UserRepository _userRepo;
        ScoreRepository _scoreRepo;

        List<ScoreBoard> _scores;

        public ScoreController(UserRepository userRepo, ScoreRepository scoreRepo) {
            _userRepo = userRepo;
            _scoreRepo = scoreRepo;
        }

        public override HttpResponse Get(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);

            HttpResponse response = new HttpResponse();
            _scores = new List<ScoreBoard>();

            if (_userRepo.UserLogin(user.Username, user.Password)) {
                _scores = _scoreRepo.GetAllScores();

                for (int i = 0; i < _scores.Count; i++) {
                    response.Body += _scores[i].PrintStats();
                }


                response.Status = 200;
                return response;
            }

            return response;
        }
    }
}

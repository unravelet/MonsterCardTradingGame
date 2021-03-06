using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;

namespace MonsterCardTradingGame.Controller {
    //SHOW SCOREBOARD
    public class StatsController : HttpController {

        UserRepository _userRepo;
        ScoreRepository _scoreRepo;

        ScoreBoard _score;

        public StatsController(UserRepository userRepo, ScoreRepository scoreRepo) {
            _userRepo = userRepo;
            _scoreRepo = scoreRepo;
        }

        public override HttpResponse Get(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);

            HttpResponse response = new HttpResponse();
            if (_userRepo.UserLogin(user.Username, user.Password)) {
                _score = _scoreRepo.GetScoreData(user.Username);


                response.Body += _score.PrintStats();
                response.Status = 200;
                return response;
            }

            return response;
        }
    }
}

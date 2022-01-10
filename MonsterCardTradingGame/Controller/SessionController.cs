using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;

namespace MonsterCardTradingGame.Controller {
    //LOGIN
    public class SessionController : HttpController {
        UserRepository _userRepo;

        public SessionController(UserRepository userRepo) {
            _userRepo = userRepo;
        }

        public override HttpResponse Post(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);

            HttpResponse response = new HttpResponse();

            if (_userRepo.UserLogin(user.Username, user.Password)) {
                response.Status = 200;
                response.Body = "User logged in";
                return response;
            }


            return response;
        }
    }
}

using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;

namespace MonsterCardTradingGame.Controller {

    //REGISTRATION
    public class UserController : HttpController {

        UserRepository _userRepo;

        public UserController(UserRepository userRepo) {
            _userRepo = userRepo;
        }



        public override HttpResponse Post(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);
            HttpResponse response = new HttpResponse();

            if (_userRepo.Create(user)) {
                response.Status = 200;
                response.Body = "User created";
                return response;
            }


            return response;
        }


    }
}

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

        public override HttpResponse Get(HttpRequest request) {
            var response = new HttpResponse();


            return response;
        }

        public override HttpResponse Post(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);
            HttpResponse response = new HttpResponse();

            if (_userRepo.Create(user)) {
                response.Status = (HttpStatus)200;
                //Console.WriteLine(response.Status);
                return response;
            }


            return response;
        }


    }
}

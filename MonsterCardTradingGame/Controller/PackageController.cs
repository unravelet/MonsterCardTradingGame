using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;

namespace MonsterCardTradingGame.Controller {
    //AQUIRE PACKAGE
    public class PackageController : HttpController {

        CardRepository _cardRepo;
        UserRepository _userRepo;

        public PackageController(UserRepository userRepo, CardRepository cardRepo) {
            _cardRepo = cardRepo;
            _userRepo = userRepo;

        }

        public override HttpResponse Post(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);
            HttpResponse response = new HttpResponse();


            if (_userRepo.UserLogin(user.Username, user.Password)) {

                user = _userRepo.FindUser(user.Username);
                user.BuyPackage(user);

                for (int i = 0; i < user._stack.Count; i++) {
                    _cardRepo.Create(user._stack[i]);
                    response.Body += user._stack[i].Name + "\n";
                }

                _userRepo.Update(user);

                response.Status = 200;
                return response;
            }

            return response;
        }

    }
}

using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Controller {
    //LOGIN
    public class SessionController : HttpController{
        UserRepository _userRepo;

        public SessionController(UserRepository userRepo) {
            _userRepo = userRepo;
        }

        public override HttpResponse Post(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);

            HttpResponse response = new HttpResponse();

            if (_userRepo.UserLogin(user.Username,user.Password)) {
                response.Status = (HttpStatus)200;
                //Console.WriteLine("user logged in");
                return response;
            }


            return response;
        }
    }
}

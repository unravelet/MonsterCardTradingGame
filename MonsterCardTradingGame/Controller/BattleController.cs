using DAL.Repository;
using MonsterCardTradingGame.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Controller {
    //START BATTLE
    public class BattleController : HttpController {

        UserRepository _userRepo;
        CardRepository _cardRepo;
        public BattleController(UserRepository userRepo, CardRepository cardRepo) {
            _userRepo = userRepo;
            _cardRepo = cardRepo;
        }

    }
}

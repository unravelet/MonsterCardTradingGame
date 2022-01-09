using DAL.Repository;
using MonsterCardTradingGame.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Controller {
    //CONFIGURE DECK
     public class DeckController : HttpController {

        CardRepository _cardRepo;
        UserRepository _userRepo;
        
        public DeckController(UserRepository userRepo, CardRepository cardRepo) {
            _cardRepo = cardRepo;
            _userRepo = userRepo;
        }



    }
}

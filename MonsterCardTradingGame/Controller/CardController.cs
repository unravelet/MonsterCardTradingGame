﻿using DAL.Repository;
using Models;
using MonsterCardTradingGame.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Controller {
    //SHOW ALL CARDS
    public class CardController : HttpController{

        CardRepository _cardRepo;
        UserRepository _userRepo;
        public CardController(UserRepository userRepo,CardRepository cardRepo) {
            _cardRepo = cardRepo;
            _userRepo = userRepo;
        }

        public override HttpResponse Get(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);
            HttpResponse response = new HttpResponse();


            if (_userRepo.UserLogin(user.Username, user.Password)) {
                user._stack = _cardRepo.GetUserStack(user.Username);

                for (int i = 0; i < user._stack.Count; i++) { 
                    Console.WriteLine(user._stack[i].Name);
                }

                response.Status = (HttpStatus)200;
                return response;
            }

            return response;
        }
    }
}

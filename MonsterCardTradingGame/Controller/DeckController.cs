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
    //CONFIGURE DECK
    public class DeckController : HttpController {

        DeckRepository _deckRepo;
        CardRepository _cardRepo;
        UserRepository _userRepo;
        List<Card> cards;
        List<Card> deck;

        public DeckController(UserRepository userRepo, CardRepository cardRepo, DeckRepository deckRepo) {
            _cardRepo = cardRepo;
            _userRepo = userRepo;
            _deckRepo = deckRepo;
        }

        public override HttpResponse Put(HttpRequest request) {
            cards = new List<Card>();
            cards = JsonConvert.DeserializeObject<List<Card>>(request.Body);
            HttpResponse response = new HttpResponse();

            
            deck = new List<Card>();
            foreach (Card card in cards) {
                deck.Add(new Card(card.Id, card.Owner, card.Name, card.Damage, card.Speed, card.ElementType, card.MonsterType, card.IsSpell, card.Description));
            }

            for (int i = 0; i < deck.Count; i++) {
                deck[i] = _cardRepo.FindUsersCard(deck[i].Owner, deck[i].Name);
                _deckRepo.Create(deck[i]);
                Console.WriteLine(deck[i].Name);
            }

            if (_deckRepo.CheckFullDeck(deck[0].Owner)) {
                response.Status = (HttpStatus)200;
                return response;
            }

            return response;
        }

        public override HttpResponse Get(HttpRequest request) {
            User user = JsonConvert.DeserializeObject<User>(request.Body);
            HttpResponse response = new HttpResponse();

            if (_userRepo.UserLogin(user.Username, user.Password)) { 
                user = _userRepo.FindUser(user.Username);
                if (_deckRepo.CheckFullDeck(user.Username)) {
                    user._deck = _deckRepo.GetUserDeck(user.Username);
                    Console.WriteLine(user.Username + "'s deck: ");

                    for(int i = 0; i < user._deck.Count; i++) {
                        Console.WriteLine(user._deck[i].Name);
                    }
                    
                    response.Status = (HttpStatus)200;
                    return response;
                }
                
            }

            return response;
        }


    }

}


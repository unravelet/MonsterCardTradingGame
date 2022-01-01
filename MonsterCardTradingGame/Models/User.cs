using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonsterCardTradingGame.Models {
    class User {
        string _username;
        string _password;
        int _coins;

        List<Card> _userCards;


        public string Username { get { return _username; }
            set { 
                //unique username
                //TODO check database for username
                _username = value; 
            } 
        }
        public string Password { get { return _password;}}
        public int Coins { get { return _coins;} //TODO setter doesnt work, keeps adding
            set {
                if (_coins - value < 0) {
                    _coins = 0;
                }
                else if (value < 0) {
                    _coins -= value;
                }
                else if (value > 0) {
                    _coins += value;
                }
            }
        }

        public User(string username, string password) {
            _username=username;
            _password=password;
            _coins = 20;
            _userCards = new List<Card>();  
        }

        public void BuyPackage() {
            Console.WriteLine("How many packages do you want to buy? (5 coins per package)");
            int packNum = Convert.ToInt32(Console.ReadLine());

            if(packNum <= _coins / 5) {
                for (int i = 0; i < packNum; i++) {

                    _coins -= 5;
                    Package package = new Package();
                    _userCards.AddRange(package._package);

                }
            }
            else {
                Console.WriteLine("You dont have enough coins for " + packNum + " Packages.");
            }

            //debugging
            Console.WriteLine("\nall of your cards: ");
            
            for (int i = 0; i < _userCards.Count; i++) { 
                Console.WriteLine(_userCards[i].Name);
            }
            Console.WriteLine("\nYou have " + _coins + " coins left.");

        }
    }

}

namespace MonsterCardTradingGame.Models {
    class User {
        string _username;
        string _password;
        int _coins;

        public List<Card> _userCards;
        public List<Card> _deck;


        public string Username {
            get { return _username; }
            set {
                //unique username
                //TODO check database for username
                _username = value;
            }
        }
        public string Password { get { return _password; } }
        public int Coins {
            get { return _coins; }
            set {
                if (value < 0) {
                    _coins -= value;
                    if (_coins < 0) {
                        _coins = 0;
                    }
                }
                else if (value > 0) {
                    _coins += value;
                }
            }
        }

        public User(string username, string password) {
            _username = username;
            _password = password;
            _coins = 20;
            _userCards = new List<Card>();
        }

        public void BuyPackage() {
            Console.WriteLine("How many packages do you want to buy? (5 coins per package)");
            int packNum = Convert.ToInt32(Console.ReadLine());

            if (packNum <= _coins / 5) {
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


        public void CreateDeck() {//TODO database 
            _deck = new List<Card>();
            int iplusone;

            Console.WriteLine("Choose 4 cards for your deck");

            for (int j = 0; j < 4; j++) {
                Console.WriteLine("\nyour cards: ");
                for (int i = 0; i < _userCards.Count; i++) {
                    iplusone = i + 1;
                    Console.WriteLine("(" + iplusone + ") " + _userCards[i].Name);
                }

                int cardNum = Convert.ToInt32(Console.ReadLine());
                _deck.Add(_userCards[cardNum - 1]);
                _userCards.RemoveAt(cardNum - 1);

                Console.WriteLine("\nyour deck: ");

                for (int i = 0; i < _deck.Count; i++) {

                    Console.WriteLine(_deck[i].Name);

                }
            }

        }

        public void AddCardToDeck(Card card) {
            _deck.Add(card);
        }


    }

}

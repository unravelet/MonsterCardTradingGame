namespace Models {
    public class User {

        string _uid;
        string _username;
        string _password;
        int _coins;
        public bool _booster;

        public List<Card> _stack;
        public List<Card> _deck;

        public string Uid { get { return _uid; } }
        public string Username { get { return _username; } }
        public string Password { get { return _password; } }
        public int Coins { get { return _coins; } }
        public List<Card> Stack { get { return _stack; } }
        public List<Card> Deck { get { return _deck; } }
        public int Score { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double WinLoseRatio { get; set; }

        public User(string username, string uid, string password, int coins) {
            _uid = uid;
            _username = username;
            _password = password;
            _coins = coins;
            _stack = new List<Card>();
            _deck = new List<Card>();
            Score = 0;
            Wins = 0;
            Losses = 0;
            WinLoseRatio = 1;
        }

        public void BuyPackage(User user) {
            //Console.WriteLine("How many packages do you want to buy? (5 coins per package)");
            //int packNum = Convert.ToInt32(Console.ReadLine());

            if (_coins >= 5) {
                AddCoins(-5);
                Package package = new Package(user);
                _stack.AddRange(package._package);
            }
            else {
                Console.WriteLine("You dont have enough coins");
            }

        }


        public void CreateDeck() {
            _deck = new List<Card>();
            int iplusone;
            int cardNum = -1;

            Console.WriteLine("Choose 4 cards for your deck");

            for (int j = 0; j < 4; j++) {
                Console.WriteLine("\nyour cards: ");
                for (int i = 0; i < _stack.Count; i++) {
                    iplusone = i + 1;
                    Console.WriteLine("(" + iplusone + ") " + _stack[i].Name);
                }

                cardNum = Convert.ToInt32(Console.ReadLine());
                _deck.Add(_stack[cardNum - 1]);
                _stack.RemoveAt(cardNum - 1);

                Console.WriteLine("\nyour deck: ");

                for (int i = 0; i < _deck.Count; i++) {

                    Console.WriteLine(_deck[i].Name);

                }
            }
        }

        public void AddCardToDeck(Card card) {
            _deck.Add(card);
        }

        public void AddCoins(int amount) {
            _coins += amount;
            if (_coins + amount < 0) {
                _coins = 0;
            }
        }

        public void SetScoreData(int score, int wins, int losses, double winloseratio) {
            Score = score;
            Wins = wins;
            Losses = losses;
            WinLoseRatio = winloseratio;
        }

        public void AddScore(int value) {
            Score += value;

            if (Score < 0) {
                Score = 0;
            }
        }

        public void AddWin(int value) {
            Wins += value;

            if (Score < 0) {
                Wins = 0;
            }
        }

        public void AddLoss(int value) {
            Losses += value;

            if (Losses < 0) {
                Losses = 0;
            }
        }

        public void CalWinLoseRatio() {
            if (Losses != 0) {
                WinLoseRatio = (double)Wins / (double)Losses;
            }
            else {
                WinLoseRatio = (double)Wins / 1;
            }

        }



    }
}


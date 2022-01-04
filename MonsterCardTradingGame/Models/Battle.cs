namespace MonsterCardTradingGame.Models {
    class Battle {
        int _round;
        int _coinThrow;
        User _player1;
        User _player2;
        Card _player1Card;
        Card _player2Card;
        BattleLog log;


        public Battle(User user1, User user2) {

            log = new BattleLog(user1.Username + " VS " + user2.Username);
            PrintAndAddLog("\n" + user1.Username + " VS " + user2.Username + "\n");
            _round = 1;

            Random random = new Random();
            _coinThrow = random.Next(0, 2);
            if (_coinThrow == 0) {
                _player1 = user1;
                _player2 = user2;
                PrintAndAddLog("Player 1: " + user1.Username + "\nPlayer 2: " + user2.Username);
            }
            else {
                _player1 = user2;
                _player2 = user1;
                PrintAndAddLog("Player 1: " + user2.Username + "\nPlayer 2: " + user1.Username);
            }

        }

        public void StartBattle() {

            while (_round <= 100 && IsNotOver()) {
                PrintAndAddLog("-------------------");
                PrintAndAddLog("Round: " + _round);
                PrintAndAddLog("-------------------");

                _player1Card = Draw(_player1, _player1._deck.Count);
                _player2Card = Draw(_player2, _player2._deck.Count);

                PrintAndAddLog(_player1.Username + "'s " + _player1Card.Name + " VS " + _player2.Username + "'s " + _player2Card.Name + "\n");
                //Console.WriteLine(_player1Card.Name + " is " + _player1Card.ElementType + _player1Card.MonsterType + _player1Card.IsSpell);
                //Console.WriteLine(_player2Card.Name + " is " + _player2Card.ElementType + _player2Card.MonsterType + _player2Card.IsSpell);

                Fight(_player1Card, _player2Card);

                _round++;
            }
        }

        public bool IsNotOver() {
            if (_player1._deck.Count == 0) {
                PlayerWon(_player2);
                return false;
            }
            else if (_player2._deck.Count == 0) {
                PlayerWon(_player1);
                return false;
            }
            else {
                return true;
            }
        }


        public void PlayerWon(User winner) {
            PrintAndAddLog("\n" + winner.Username + " won!");
            winner.Coins = 3;
        }

        public Card Draw(User player, int maxNum) {
            Random random = new Random();
            int drawNum = random.Next(0, maxNum);

            return player._deck[drawNum];
        }


        public void Fight(Card p1Card, Card p2Card) {

            if (_player1._deck != null && _player2._deck != null) {
                //player 1 attacks
                if (AttackerWins(p1Card, p2Card)) {
                    PrintAndAddLog("\n" + _player1.Username + "'s " + p1Card.Name + " wins!");
                    _player1._deck.Add(p2Card);
                    _player2._deck.Remove(p2Card);
                }//player 2 attacks
                else if (AttackerWins(p2Card, p1Card)) {
                    PrintAndAddLog("\n" + _player2.Username + "'s " + p2Card.Name + " wins!");
                    _player2._deck.Add(p1Card);
                    _player1._deck.Remove(p1Card);
                }
                else {
                    PrintAndAddLog("\ndraw");
                }
            }
        }


        public bool AttackerWins(Card attacker, Card defender) {
            int attDmg = attacker.Damage;
            int defDmg = defender.Damage;

            PrintAndAddLog(attacker.Name + " attacks " + defender.Name);

            //water drowns knight
            if (attacker.OneHitKO(attacker, defender)) {
                PrintAndAddLog("One Hit KO!");
                return true;
            }

            if (attacker.CanAttack(attacker, defender)) {
                //if its not a monster fight
                if (attacker.IsSpell || defender.IsSpell) {
                    if (attacker.IsEffective(attacker, defender)) {
                        PrintAndAddLog("It's very effective!");
                        attDmg *= 2;
                        defDmg /= 2;
                    }
                    else if (attacker.IsNotEffective(attacker, defender)) {
                        PrintAndAddLog("It's not effective!");
                        attDmg /= 2;
                        defDmg *= 2;
                    }
                }
                PrintAndAddLog(attDmg + " VS " + defDmg);
                if (attDmg > defDmg) {
                    return true;
                }
                else {
                    return false;
                }
            }//if it cant attack
            else {
                PrintAndAddLog(attacker.Name + " failed to attack " + defender.Name);
                return false;
            }
        }

        public void PrintAndAddLog(string text) {
            Console.WriteLine(text);
            log.CreateBattleLog(text);
        }




    }
}

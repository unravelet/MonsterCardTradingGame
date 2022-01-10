namespace Models {
    public class Battle {
        Random random = new Random();
        int _round;
        int _coinThrow;
        User _player1;
        User _player2;
        Card _player1Card;
        Card _player2Card;
        BattleLog log;
        string _result;



        public Battle(User user1, User user2) {

            log = new BattleLog(user1.Username + " VS " + user2.Username);
            PrintAndAddLog("\n" + user1.Username + " VS " + user2.Username + "\n");
            _round = 1;

            _player1 = user1;
            _player2 = user2;
            PrintAndAddLog("Player 1: " + user1.Username + "\nPlayer 2: " + user2.Username);

            _player1._booster = true;
            _player2._booster = true;
        }

        public string StartBattle() {

            while (_round <= 100 && IsNotOver()) {
                PrintAndAddLog("-------------------");
                PrintAndAddLog("Round: " + _round);
                PrintAndAddLog("-------------------");

                _player1Card = Draw(_player1, _player1._deck.Count);
                _player2Card = Draw(_player2, _player2._deck.Count);

                PrintAndAddLog(_player1.Username + "'s " + _player1Card.Name + " VS " + _player2.Username + "'s " + _player2Card.Name + "\n");

                if (_player1Card.Speed > _player2Card.Speed) {
                    Fight(_player1, _player1Card, _player2, _player2Card);
                }
                else if (_player2Card.Speed > _player1Card.Speed) {
                    Fight(_player2, _player2Card, _player1, _player1Card);
                }
                else {
                    _coinThrow = random.Next(0, 2);
                    if (_coinThrow == 0) {
                        Fight(_player1, _player1Card, _player2, _player2Card);
                    }
                    else {
                        Fight(_player2, _player2Card, _player1, _player1Card);
                    }
                }
                PrintAndAddLog(_player1.Username + "'s cards in deck: " + _player1._deck.Count);
                PrintAndAddLog(_player2.Username + "'s cards in deck: " + _player2._deck.Count);

                //wait for input
                //Console.ReadLine();

                _round++;
            }
            if (_round > 100) {
                PrintAndAddLog("DRAW");
                _result = "battle ended in a draw";
                return _result;
            }
            return _result;
        }

        public bool IsNotOver() {
            if (_player1._deck.Count == 0) {
                PlayerWon(_player2, _player1);
                return false;
            }
            else if (_player2._deck.Count == 0) {
                PlayerWon(_player1, _player2);
                return false;
            }
            else {
                return true;
            }
        }


        public void PlayerWon(User winner, User loser) {
            PrintAndAddLog("\n" + winner.Username + " won!");

            winner.AddCoins(3);
            winner.AddScore(5);
            winner.AddWin(1);
            loser.AddScore(-3);
            loser.AddLoss(1);
            winner.CalWinLoseRatio();
            loser.CalWinLoseRatio();
            _result = winner.Username + " won the battle!";
        }

        public Card Draw(User player, int maxNum) {
            Random random = new Random();
            int drawNum = random.Next(0, maxNum);

            return player._deck[drawNum];
        }


        public void Fight(User player1, Card p1Card, User player2, Card p2Card) {

            if (player1._deck != null && player2._deck != null) {
                //player 1 attacks
                if (AttackerWins(player1, p1Card, p2Card)) {
                    PrintAndAddLog("\n" + player1.Username + "'s " + p1Card.Name + " wins!\n");
                    player1._deck.Add(p2Card);
                    player2._deck.Remove(p2Card);
                }//player 2 attacks
                else if (AttackerWins(player2, p2Card, p1Card)) {
                    PrintAndAddLog("\n" + player2.Username + "'s " + p2Card.Name + " wins!\n");
                    player2._deck.Add(p1Card);
                    player1._deck.Remove(p1Card);
                }
                else {
                    PrintAndAddLog("\ndraw");
                }
            }
        }


        public bool AttackerWins(User player, Card attacker, Card defender) {
            double attDmg = attacker.Damage;
            double defDmg = defender.Damage;

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
                if (Booster(player, attacker)) {
                    attDmg = BoosterDmg(attDmg);
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

        public bool Booster(User player, Card playerCard) {
            if (player._booster) {
                if (player._deck.Count == 1) {
                    //PrintAndAddLog(player.Username + ", do you want to use your Card booster? (Y/N)");
                    PrintAndAddLog(player.Username + " used a booster");
                    player._booster = false;
                    return true;

                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }

        }

        public double BoosterDmg(double attDmg) {
            Random random = new Random();
            int roll = random.Next(0, 4);

            switch (roll) {
                case 0:
                    attDmg *= 1.2;
                    break;
                case 1:
                    attDmg *= 1.3;
                    break;
                case 2:
                    attDmg *= 1.4;
                    break;
                case 3:
                    attDmg *= 1.5;
                    break;

            }
            return attDmg;
        }


    }
}

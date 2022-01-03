using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonsterCardTradingGame.Models {
    class Battle {
        int _round;
        int _coinThrow;
        User _player1;
        User _player2;
        Card _player1Card;
        Card _player2Card;
        
       
        
        public Battle(User user1, User user2) {
            Console.WriteLine("\n" + user1.Username + " VS " + user2.Username + "\n");
            _round = 1;
            Random random = new Random();
            _coinThrow = random.Next(0, 2);
            if(_coinThrow == 0) {
                _player1 = user1;
                _player2 = user2;
                Console.WriteLine("Player 1: " + user1.Username + "\nPlayer 2: " + user2.Username);
            }
            else {
                _player1 = user2;
                _player2 = user1;
                Console.WriteLine("Player 1: " + user2.Username + "\nPlayer 2: " + user1.Username);
            }
        }

        public void StartBattle() {
            

            while(_round <= 100 && IsNotOver()){
                Console.WriteLine("-------------------" );
                Console.WriteLine("Round: " + _round);
                Console.WriteLine("-------------------");

                _player1Card = Draw(_player1, _player1._deck.Count);
                _player2Card = Draw(_player2, _player2._deck.Count);

                Console.WriteLine(_player1.Username + "'s " + _player1Card.Name + " VS " + _player2.Username + "'s " + _player2Card.Name + "\n");
                //Console.WriteLine(_player1Card.Name + " is " + _player1Card.ElementType + _player1Card.MonsterType);
                //Console.WriteLine(_player2Card.Name + " is " + _player2Card.ElementType + _player2Card.MonsterType);
                Fight(_player1Card, _player2Card);


                _round++;
            }//TODO winner wins 3 coins

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

        //TODO player doesnt get the coins
        public void PlayerWon(User winner) {
            Console.WriteLine("\n" + winner.Username + " won!");
            winner.Coins += 3;
            Console.WriteLine(winner.Username + " has " + winner.Coins + " coins");
        }

        public Card Draw(User player, int maxNum) {
            Random random = new Random();
            int drawNum = random.Next(0, maxNum);

            return player._deck[drawNum];
        }

        public void Fight(Card p1Card, Card p2Card) {
            //MONSTER FIGHT
            if (!p1Card.IsSpell && !p2Card.IsSpell) {
                Console.WriteLine("MONSTER FIGHT");
                MonsterFight(p1Card, p2Card);
            }//SPELL FIGHT
            else if (p1Card.IsSpell && p2Card.IsSpell) {
                Console.WriteLine("SPELL FIGHT");
                SpellFight(p1Card, p2Card);
            }//MIXED FIGHT
            else {
                Console.WriteLine("MIXED FIGHT");
                MixedFight(p1Card, p2Card);
            }

        }
        public void MonsterFight(Card p1Card, Card p2Card) {

            if (_player1._deck != null && _player2._deck != null) {
                //player 1 attacks
                if (AttackerWins(p1Card, p2Card)) {
                    Console.WriteLine(_player1.Username + "'s " + p1Card.Name + " wins!");
                    _player2._deck.Remove(p2Card);
                }//player 2 attacks
                else if (AttackerWins(p2Card, p1Card)) {
                    Console.WriteLine(_player2.Username + "'s " + p2Card.Name + " wins!");
                    _player1._deck.Remove(p1Card);
                }
                else {
                    Console.WriteLine("draw");
                }
            }
        }

        public void SpellFight(Card p1Card, Card p2Card) {

            if (_player1._deck != null && _player2._deck != null) {
                //player 1 attacks
                if (AttackerWins(p1Card, p2Card)) {
                    Console.WriteLine(_player1.Username + "'s " + p1Card.Name + " wins!");
                    _player2._deck.Remove(p2Card);
                }//player 2 attacks
                else if (AttackerWins(p2Card, p1Card)) {
                    Console.WriteLine(_player2.Username + "'s " + p2Card.Name + " wins!");
                    _player1._deck.Remove(p1Card);
                }
                else {
                    Console.WriteLine("draw");
                }
            }
        }

        public void MixedFight(Card p1Card, Card p2Card) {

            if (_player1._deck != null && _player2._deck != null) {
                //player 1 attacks
                if (AttackerWins(p1Card, p2Card)) {
                    Console.WriteLine(_player1.Username + "'s " + p1Card.Name + " wins!");
                    _player2._deck.Remove(p2Card);
                }//player 2 attacks
                else if (AttackerWins(p2Card, p1Card)) {
                    Console.WriteLine(_player2.Username + "'s " + p2Card.Name + " wins!");
                    _player1._deck.Remove(p1Card);
                }
                else {
                    Console.WriteLine("draw");
                }
            }
        }

        public bool AttackerWins(Card attacker, Card defender) {
            int attDmg = attacker.Damage;
            int defDmg = defender.Damage;

            if (attacker.OneHitKO(attacker, defender)) {
                Console.WriteLine("One Hit KO!");
                return true;
            }

            //TODO CHANGE EVERYTHING IDK (light and ice spells effective does not work

            if(attacker.CanAttack(attacker, defender)) {
                if (attacker.IsSpell || defender.IsSpell) {
                    if (attacker.IsEffective(attacker, defender)) {
                        Console.WriteLine("It's very effective!");
                        attDmg *= 2;
                        defDmg /= 2;
                        Console.WriteLine(attDmg + " VS " + defDmg);
                    }
                    else if (attacker.IsNotEffective(attacker, defender)) {
                        Console.WriteLine("It's not effective!");
                        attDmg /= 2;
                        defDmg *= 2;
                        Console.WriteLine(attDmg + " VS " + defDmg);
                    }
                }

                if (attDmg > defDmg) {
                    return true;
                }
                else {
                    return false;
                }

            }
            else {
                Console.WriteLine(attacker.Name + " can't attack " + defender.Name);
                return false;
            }

        }

        




    }
}

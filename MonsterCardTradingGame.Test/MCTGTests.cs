using NUnit.Framework;
using MonsterCardTradingGame;
using Models;
using DAL;
using System.Collections.Generic;

namespace MonsterCardTradingGame.Test {
    public class MCTGTests {
        
        [Test]
        public void IsEffectiveTest() {
            //arrange
            Card card1 = new Card("1", "owner", "FireGoblin(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Goblin, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");

            //act
            card1.IsEffective(card2, card1);

            //assert
            Assert.IsTrue(card2.IsEffective(card2, card1));

        }
        [Test]
        public void IsNotEffectiveTest() {
            //arrange
            Card card1 = new Card("1", "owner", "FireGoblin(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Goblin, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");

            //act
            card2.IsNotEffective(card2, card1);

            //assert
            Assert.IsFalse(card2.IsNotEffective(card2, card1));

        }

        [Test]
        public void CanAttackFailTest() {
            //arrange
            Card card1 = new Card("1", "owner", "FireGoblin(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Goblin, false, "");
            Card card2 = new Card("3", "owner", "WaterDragon(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Dragon, false, "");

            //act
            card1.CanAttack(card1, card2);

            //assert
            Assert.IsFalse(card1.CanAttack(card1, card2));

        }

        [Test]
        public void CanAttackTest() {
            //arrange
            Card card1 = new Card("1", "owner", "FireGoblin(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Goblin, false, "");
            Card card2 = new Card("3", "owner", "WaterDragon(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Dragon, false, "");

            //act
            card2.CanAttack(card2, card1);

            //assert
            Assert.IsTrue(card2.CanAttack(card2, card1));

        }


        [Test]
        public void OneHitKOTest() {
            //arrange
            Card card1 = new Card("1", "owner", "FireKnight(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Knight, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");

            //act
            card2.OneHitKO(card2, card1);

            //assert
            Assert.IsTrue(card2.OneHitKO(card2, card1));

        }

        [Test]
        public void OneHitKOFailTest() {
            //arrange
            Card card1 = new Card("1", "owner", "FireKnight(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Knight, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");

            //act
            card2.OneHitKO(card1, card2);

            //assert
            Assert.IsFalse(card2.OneHitKO(card1, card2));

        }

        [Test]
        public void AddNegativeCoinsTest() {
            //arrange
            User user = new User("username", "1", "password", 10);

            //act
            user.AddCoins(-20);

            //assert
            Assert.AreEqual(0, user.Coins);

        }

        [Test]
        public void AddCoinsTest() {
            //arrange
            User user = new User("username", "1", "password", 10);

            //act
            user.AddCoins(5);

            //assert
            Assert.AreEqual(15, user.Coins);

        }

        [Test]
        public void PlayerWonGetsCoinsTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);
            User user2 = new User("username", "1", "password", 15);
            Battle battle = new Battle(user1, user2);

            //act
            battle.PlayerWon(user1);

            //assert
            Assert.AreEqual(13, user1.Coins);
        }

        [Test]
        public void UserBuysPackageLoseCoinsTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);

            //act
            user1.BuyPackage(user1);

            //assert
            Assert.AreEqual(5, user1.Coins);

        }

        [Test]
        public void UserBuysPackageFailsTest() {
            //arrange
            User user1 = new User("username", "1", "password", 0);

            //act
            user1.BuyPackage(user1);

            //assert
            Assert.AreEqual(0, user1.Stack.Count);

        }

        [Test]
        public void UserBuysPackageTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);

            //act
            user1.BuyPackage(user1);

            //assert
            Assert.AreEqual(5, user1.Stack.Count);

        }

        [Test]
        public void AddCardToDeckTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);
            Card card1 = new Card("1", "owner", "FireKnight(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Knight, false, "");

            //act
            user1.AddCardToDeck(card1);
            
            //assert
            Assert.AreSame(card1, user1.Deck[0]);
        }

        [Test]
        public void UserBuysMorePackageTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);

            //act
            user1.BuyPackage(user1);
            user1.BuyPackage(user1);

            //assert
            Assert.AreEqual(10, user1.Stack.Count);

        }

        [Test]
        public void UserBuysMorePackageFailTest() {
            //arrange
            User user1 = new User("username", "1", "password", 5);

            //act
            user1.BuyPackage(user1);
            user1.BuyPackage(user1);

            //assert
            Assert.AreEqual(5, user1.Stack.Count);

        }

        [Test]
        public void BoosterTest() {
            //arrange
            User user1 = new User("username", "1", "password", 5);
            User user2 = new User("username", "1", "password", 15);
            
            //act
            Battle battle = new Battle(user1, user2);
            

            //assert
            Assert.Greater(battle.BoosterDmg(20), 20);

        }

        [Test]
        public void UserDrawsCardTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);
            User user2 = new User("username", "1", "password", 15);
            Card card1 = new Card("1", "owner", "FireKnight(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Knight, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");
            

            //act
            user1.AddCardToDeck(card1);
            user2.AddCardToDeck(card2);
            Battle battle = new Battle(user1, user2);


            //assert
            Assert.AreSame(card1, battle.Draw(user1, user1.Deck.Count));
        }

        [Test]
        public void IsNotOverTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);
            User user2 = new User("username", "1", "password", 15);
            Card card1 = new Card("1", "owner", "FireKnight(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Knight, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");


            //act
            user1.AddCardToDeck(card1);
            user2.AddCardToDeck(card2);
            Battle battle = new Battle(user1, user2);


            //assert
            Assert.IsTrue(battle.IsNotOver());
        }

        [Test]
        public void IsOverTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);
            User user2 = new User("username", "1", "password", 15);
            Card card1 = new Card("1", "owner", "FireKnight(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Knight, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");


            //act
            user1.AddCardToDeck(card1);
            user2.AddCardToDeck(card2);
            Battle battle = new Battle(user1, user2);
            user1.Deck.Remove(card1);

            //assert
            Assert.IsFalse(battle.IsNotOver());
        }

        [Test]
        public void AttackerWinsTest() {
            //arrange
            User user1 = new User("username", "1", "password", 10);
            User user2 = new User("username", "1", "password", 15);
            Card card1 = new Card("1", "owner", "FireKnight(80|10)", 80, 10, Card.ElementalType.Fire, Card.Monster.Knight, false, "");
            Card card2 = new Card("3", "owner", "WaterSpell(50|20)", 50, 20, Card.ElementalType.Water, Card.Monster.Spell, true, "");


            //act
            user1.AddCardToDeck(card1);
            user2.AddCardToDeck(card2);
            Battle battle = new Battle(user1, user2);

            //assert
            Assert.IsTrue(battle.AttackerWins(user2, card2, card1));
        }

        


    }
}
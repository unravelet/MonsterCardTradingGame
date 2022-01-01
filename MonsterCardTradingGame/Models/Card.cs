using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class Card {
        int _roll;
        protected string _name;
        protected int _damage;
        protected string _description;
        protected enum ElementalType { 
            Fire, 
            Water, 
            Normal,
            Ground,
            Ice,
            Light,
            Dark
        };
        //Water -> Fire, Ground
        //Fire -> Normal, Ice
        //Normal-> Water, Light
        //Ground -> Fire, Light
        //Ice -> Water, Ground
        //Light -> Dark, Ice
        //Dark -> Normal, Dark

        protected enum Monster { 
            Goblin, 
            Dragon,
            Wizard,
            Ork,
            Knight,
            Kraken,
            Elf
        };

        public string Name { get { return _name; } }
        public int Damage { get { return _damage;}  }


        public Card() {
            

        }

        public Card GetCard() {
            Random random = new Random();
            _roll = random.Next(0, 2);

            if (_roll == 0) {
                SpellCard spell = new SpellCard();
                //Console.WriteLine("This would be a spellcard");
                return spell; 
            }
            else if (_roll == 1) {
                MonsterCard monster = new MonsterCard();
                //Console.WriteLine("This would be a monstercard");
                return monster;
            }
            else {
                Console.WriteLine("Something went wrong");
                return null;
            }

        }

        public int AddRandomDamage() {
            Random random = new Random();

            return random.Next(1, 10)*10;

        }

    }
}

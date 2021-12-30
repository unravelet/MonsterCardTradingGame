using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class Card {
       
        protected string _name;
        protected int _damage;
        protected string _description;
        protected enum ElementalType { Fire, Water, Normal };
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

    }
}

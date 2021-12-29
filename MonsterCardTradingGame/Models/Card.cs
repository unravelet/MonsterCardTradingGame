﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class Card {
        string _name;
        int _damage;
        enum ElementalType { fire, water, normal };
        enum Monster { 
            Goblin, 
            Dragon,
            Wizard,
            Ork,
            Knight,
            Kraken,
            Elf
        }
        enum Spell { fire, water, normal };

        public string Name { get { return _name; } }
        public int Damage { get { return _damage;}  }

    }
}

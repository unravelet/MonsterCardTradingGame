using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class MonsterCard : Card {

        Random random = new Random();
        int _monsterRoll;
        int _elementalRoll;

        Monster _monster;
        ElementalType _elemental;

        public MonsterCard() {
            _monsterRoll = random.Next(0, 7);
            _elementalRoll = random.Next(0, 3);

            _monster = (Monster)_monsterRoll;
            _elemental = (ElementalType)_elementalRoll;

            Console.WriteLine("Card is " + _elemental + _monster );
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class SpellCard : Card {

        Random random = new Random();
        int _elementalRoll;
        ElementalType _elemental;

        public SpellCard() {
            _elementalRoll = random.Next(0, 3);
            _elemental = (ElementalType)_elementalRoll;

            Console.WriteLine("Spellcard is " + _elemental);

        }
    }
}

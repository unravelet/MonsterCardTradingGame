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
        
        

        public MonsterCard() {
            _monsterRoll = random.Next(0, 7);
            _elementalRoll = random.Next(0, 7);

            _monster = (Monster)_monsterRoll;
            _elemental = (ElementalType)_elementalRoll;
            _isSpell = false;
            _damage = AddRandomDamage();
            _name = _elemental + "" + _monster + " (" + _damage + " damage)";

            AddDescription(_monsterRoll);

            Console.WriteLine(_name );
        }

        
        public void AddDescription(int roll) {

            switch (roll) {
                case 0:
                    GoblinDescription();
                    break;
                case 1:
                    DragonDescription();
                    break;
                case 2:
                    WizardDescription();
                    break;
                case 3:
                    OrkDescription();
                    break;
                case 4:
                    KnightDescription();
                    break;
                case 5:
                    KrakenDescription();
                    break;
                case 6:
                    ElfDescription();
                    break;
            }
        }

        public void GoblinDescription() {
            _description = "";
        }
        public void DragonDescription() {
            _description = "";
        }
        public void WizardDescription() {
            _description = "";
        }
        public void OrkDescription() {
            _description = "";
        }
        public void KnightDescription() {
            _description = "";
        }
        public void KrakenDescription() {
            _description = "";
        }
        public void ElfDescription() {
            _description = "";
        }


    }
}

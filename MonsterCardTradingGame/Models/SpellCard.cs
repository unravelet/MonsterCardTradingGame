using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    class SpellCard : Card {

        Random random = new Random();
        int _elementalRoll;
        
        public SpellCard() {
            _elementalRoll = random.Next(0, 7);
            _elemental = (ElementalType)_elementalRoll;
            _isSpell = true;
            _damage = AddRandomDamage();
            _name = _elemental + "Spell" + " (" + _damage + " damage)";
           
            AddDescription(_elementalRoll);
            
            Console.WriteLine(_name);
             
        }

        public void AddDescription(int roll) {

            switch (roll) {
                case 0:
                    FireDescription();
                    break;
                case 1:
                    WaterDescription();
                    break;
                case 2: 
                    NormalDescription();
                    break;
                case 3:
                    GroundDescription();
                    break;
                case 4:
                    IceDescription();
                    break;
                case 5:
                    LightDescription();
                    break;
                case 6:
                    DarkDescription();
                    break;
            }
        }

        public void FireDescription() {
            _description = "";
        }
        public void WaterDescription() {
            _description = "";
        }
        public void NormalDescription() {
            _description = "";
        }
        public void GroundDescription() {
            _description = "";
        }
        public void IceDescription() {
            _description = "";
        }
        public void LightDescription() {
            _description = "";
        }
        public void DarkDescription() {
            _description = "";
        }


    }
}

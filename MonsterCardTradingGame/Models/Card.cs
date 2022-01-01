using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardTradingGame.Models {
    public class Card {
        int _roll;
        protected string _name;
        protected int _damage;
        protected string _description;
        protected bool _isSpell;
        public enum ElementalType { 
            Fire, 
            Water, 
            Normal,
            Ground,
            Ice,
            Light,
            Dark
        };
        protected ElementalType _elemental;
        //Water -> Fire, Ground
        //Fire -> Normal, Ice
        //Normal-> Water, Light
        //Ground -> Fire, Light
        //Ice -> Water, Ground
        //Light -> Dark, Ice
        //Dark -> Normal, Dark

        public enum Monster { 
            Goblin, 
            Dragon,
            Wizard,
            Ork,
            Knight,
            Kraken,
            Elf
        };
        protected Monster _monster;

        public string Name { get { return _name; } }
        public int Damage { get { return _damage;} }
        public string Description { get { return _description; } }
        public bool IsSpell { get { return _isSpell;} }
        public  ElementalType ElementType { get { return _elemental; } }
        public Monster MonsterType { get { return _monster; } }


        public Card() {
            

        }

        public Card GetCard() {
            Random random = new Random();
            _roll = random.Next(0, 2);

            if (_roll == 0) {
                SpellCard spell = new SpellCard();
                return spell; 
            }
            else /*if (_roll == 1)*/ {
                MonsterCard monster = new MonsterCard();
                return monster;
            }

        }

        public int AddRandomDamage() {
            Random random = new Random();

            return random.Next(1, 10)*10;

        }

        
        public bool IsEffective(ElementalType attacker, ElementalType defender) {//damage doubled

            if(attacker == ElementalType.Fire && (defender == ElementalType.Normal || defender == ElementalType.Ice) ) {
                return true;
            }
            else if (attacker == ElementalType.Water && (defender == ElementalType.Fire || defender == ElementalType.Ground)) {
                return true;
            }
            else if (attacker == ElementalType.Normal && (defender == ElementalType.Water || defender == ElementalType.Light)) {
                return true;
            }
            else if (attacker == ElementalType.Ground && (defender == ElementalType.Fire || defender == ElementalType.Light)) {
                return true;
            }
            else if (attacker == ElementalType.Ice && (defender == ElementalType.Water || defender == ElementalType.Ground)) {
                return true;
            }
            else if (attacker == ElementalType.Light && (defender == ElementalType.Dark || defender == ElementalType.Ice)) {
                return true;
            }
            else if (attacker == ElementalType.Dark && (defender == ElementalType.Normal || defender == ElementalType.Dark)) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsNotEffective(ElementalType defender, ElementalType attacker) { //damage halved
            if (defender == ElementalType.Fire && (attacker == ElementalType.Normal || attacker == ElementalType.Ice)) {
                return true;
            }
            else if (defender == ElementalType.Water && (attacker == ElementalType.Fire || attacker == ElementalType.Ground)) {
                return true;
            }
            else if (defender == ElementalType.Normal && (attacker == ElementalType.Water || attacker == ElementalType.Light)) {
                return true;
            }
            else if (defender == ElementalType.Ground && (attacker == ElementalType.Fire || attacker == ElementalType.Light)) {
                return true;
            }
            else if (defender == ElementalType.Ice && (attacker == ElementalType.Water || attacker == ElementalType.Ground)) {
                return true;
            }
            else if (defender == ElementalType.Light && (attacker == ElementalType.Dark || attacker == ElementalType.Ice)) {
                return true;
            }
            else if (defender == ElementalType.Dark && (attacker == ElementalType.Normal || attacker == ElementalType.Dark)) {
                return true;
            }
            else {
                return false;
            }
        }


        public bool CanAttack(Monster attacker, ElementalType attackerElement, Monster defender) {//TODO kraken and spells

            if (attacker == Monster.Goblin && defender == Monster.Dragon) {
                return false;
            }
            else if (attacker == Monster.Ork && defender == Monster.Wizard) {
                return false;
            }
            else if (attacker == Monster.Elf && attackerElement == ElementalType.Fire && defender == Monster.Dragon) {
                return false;
            }
            else {
                return true;
            }
        }

    }
}

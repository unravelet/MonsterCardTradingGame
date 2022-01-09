using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {
    public class Card {

        Random random = new Random();
        int _roll;

        protected string _id;
        protected string _owner;
        protected string _name;
        protected int _damage;
        protected int _speed;
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
            Spell,
            Goblin,
            Dragon,
            Wizard,
            Ork,
            Knight,
            Kraken,
            Elf
        };
        protected Monster _monster;

        public string Id { get { return _id; } }
        public string Owner { get { return _owner; } }
        public string Name { get { return _name; } }
        public int Damage { get { return _damage; } }
        public int Speed { get { return _speed; } }
        public string Description { get { return _description; } }
        public bool IsSpell { get { return _isSpell; } }
        public ElementalType ElementType { get { return _elemental; } }
        public Monster MonsterType { get { return _monster; } }


        public Card(string id, string owner, string name, int damage, int speed, ElementalType element, Monster monsterType, bool isSpell, string description) {
            _id = id;
            _owner = owner;
            _name = name;
            _damage = damage;
            _speed = speed;
            _elemental = element;
            _monster = monsterType;
            _isSpell = isSpell;
            _description = description;

        }


        //public Card GetCard(string owner) {

        //    _roll = random.Next(0, 2);

        //    if (_roll == 0) {
        //        SpellCard spell = new SpellCard(Guid.NewGuid(), owner);
        //        return spell;
        //    }
        //    else /*if (_roll == 1)*/ {
        //        MonsterCard monster = new MonsterCard(Guid.NewGuid(), owner);
        //        return monster;
        //    }

        //}



        public bool IsEffective(Card attacker, Card defender) {//damage doubled

            if (attacker.ElementType == ElementalType.Fire && (defender.ElementType == ElementalType.Normal || defender.ElementType == ElementalType.Ice)) {
                return true;
            }
            else if (attacker.ElementType == ElementalType.Water && (defender.ElementType == ElementalType.Fire || defender.ElementType == ElementalType.Ground)) {
                return true;
            }
            else if (attacker.ElementType == ElementalType.Normal && (defender.ElementType == ElementalType.Water || defender.ElementType == ElementalType.Light)) {
                return true;
            }
            else if (attacker.ElementType == ElementalType.Ground && (defender.ElementType == ElementalType.Fire || defender.ElementType == ElementalType.Light)) {
                return true;
            }
            else if (attacker.ElementType == ElementalType.Ice && (defender.ElementType == ElementalType.Water || defender.ElementType == ElementalType.Ground)) {
                return true;
            }
            else if (attacker.ElementType == ElementalType.Light && (defender.ElementType == ElementalType.Dark || defender.ElementType == ElementalType.Ice)) {
                return true;
            }
            else if (attacker.ElementType == ElementalType.Dark && (defender.ElementType == ElementalType.Normal || defender.ElementType == ElementalType.Dark)) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsNotEffective(Card attacker, Card defender) { //damage halved
            if (defender.ElementType == ElementalType.Fire && (attacker.ElementType == ElementalType.Normal || attacker.ElementType == ElementalType.Ice)) {
                return true;
            }
            else if (defender.ElementType == ElementalType.Water && (attacker.ElementType == ElementalType.Fire || attacker.ElementType == ElementalType.Ground)) {
                return true;
            }
            else if (defender.ElementType == ElementalType.Normal && (attacker.ElementType == ElementalType.Water || attacker.ElementType == ElementalType.Light)) {
                return true;
            }
            else if (defender.ElementType == ElementalType.Ground && (attacker.ElementType == ElementalType.Fire || attacker.ElementType == ElementalType.Light)) {
                return true;
            }
            else if (defender.ElementType == ElementalType.Ice && (attacker.ElementType == ElementalType.Water || attacker.ElementType == ElementalType.Ground)) {
                return true;
            }
            else if (defender.ElementType == ElementalType.Light && (attacker.ElementType == ElementalType.Dark || attacker.ElementType == ElementalType.Ice)) {
                return true;
            }
            else if (defender.ElementType == ElementalType.Dark && (attacker.ElementType == ElementalType.Normal || attacker.ElementType == ElementalType.Dark)) {
                return true;
            }
            else {
                return false;
            }
        }


        public bool CanAttack(Card attacker, Card defender) {
            if (!attacker.IsSpell) {
                if (attacker.MonsterType == Monster.Goblin && defender.MonsterType == Monster.Dragon) {
                    return false;
                }
                else if (attacker.MonsterType == Monster.Ork && defender.MonsterType == Monster.Wizard) {
                    return false;
                }
                else if (defender.MonsterType == Monster.Elf && defender.ElementType == ElementalType.Fire && attacker.MonsterType == Monster.Dragon) {
                    return false;
                }
                else {
                    return true;
                }
            }
            else if (attacker.IsSpell && defender.MonsterType == Monster.Kraken) {
                return false;
            }
            else {
                return true;
            }
        }

        public bool OneHitKO(Card attacker, Card defender) {
            if (attacker.IsSpell && attacker.ElementType == ElementalType.Water && defender.MonsterType == Monster.Knight) {
                return true;
            }
            else {
                return false;
            }
        }


    }
}


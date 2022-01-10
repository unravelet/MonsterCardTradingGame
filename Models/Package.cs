using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {
    public class Package {

        Random random = new Random();
        int _monsterRoll;
        int _elementalRoll;
        Card.ElementalType _elemental;
        Card.Monster _monsterType;
        bool _isSpell;
        int _damage;
        int _speed;
        string _name;
        string _description;

        public List<Card> _package;

        public Package(User user) {
            _package = new List<Card>();

            Console.WriteLine("\nCards in package: ");
            for (int j = 0; j < 5; j++) {
                GenerateCard();
                Card card = new Card(Guid.NewGuid().ToString(), user.Username, _name, _damage, _speed, _elemental, _monsterType, _isSpell, _description);
                _package.Add(card);
                Console.WriteLine(card.Name);
            }

        }

        public void GenerateCard() {
            int roll = random.Next(0, 2);

            //spellcard
            if (roll == 0) {
                _isSpell = true;
                _elementalRoll = random.Next(0, 7);
                _monsterType = Card.Monster.Spell;
                _elemental = (Card.ElementalType)_elementalRoll;
                _damage = AddRandomDamage();
                _speed = AddSpeed(_damage);
                _name = _elemental + "" + _monsterType + "(" + _damage + "|" + _speed + ")";
                AddSpellDescription(_elementalRoll);

            }//monstercard
            else {
                _isSpell = false;
                _monsterRoll = random.Next(1, 8);
                _elementalRoll = random.Next(0, 7);
                _monsterType = (Card.Monster)_monsterRoll;
                _elemental = (Card.ElementalType)_elementalRoll;
                _damage = AddRandomDamage();
                _speed = AddSpeed(_damage);
                _name = _elemental + "" + _monsterType + "(" + _damage + "|" + _speed + ")";
                AddMonsterDescription(_monsterRoll);
            }
        }


        public int AddRandomDamage() {
            Random random = new Random();
            int roll = random.Next(1, 101);
            int randomDmg;
            //20%
            if (roll <= 20) {
                randomDmg = 10;
            }//18%
            else if (roll <= 38) {
                randomDmg = 20;
            }//16%
            else if (roll <= 54) {
                randomDmg = 30;
            }//14%
            else if (roll <= 68) {
                randomDmg = 40;
            }//12%
            else if (roll <= 80) {
                randomDmg = 50;
            }//10%
            else if (roll <= 90) {
                randomDmg = 60;
            }//6%
            else if (roll <= 96) {
                randomDmg = 70;
            }//3%
            else if (roll <= 99) {
                randomDmg = 80;
            }//1%
            else {
                randomDmg = 90;
            }
            return randomDmg;
        }

        public int AddSpeed(int dmg) {

            int roll = random.Next(1, 101);

            switch (dmg) {
                case 10: {
                        if (roll <= 80) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 20: {
                        if (roll <= 70) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 30: {
                        if (roll <= 60) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 40: {
                        if (roll <= 50) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 50: {
                        if (roll <= 30) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 60: {
                        if (roll <= 20) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 70: {
                        if (roll <= 10) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 80: {
                        if (roll <= 5) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
                case 90: {
                        if (roll <= 2) {
                            _speed = random.Next(5, 11);
                        }
                        else {
                            _speed = random.Next(1, 5);
                        }
                        break;
                    }
            }
            return _speed;
        }


        public void AddMonsterDescription(int roll) {

            switch (roll) {
                case 1:
                    GoblinDescription();
                    break;
                case 2:
                    DragonDescription();
                    break;
                case 3:
                    WizardDescription();
                    break;
                case 4:
                    OrkDescription();
                    break;
                case 5:
                    KnightDescription();
                    break;
                case 6:
                    KrakenDescription();
                    break;
                case 7:
                    ElfDescription();
                    break;
            }
        }

        public void GoblinDescription() {
            _description = "These small but dangerous creatures live in big groups in forests or mountains. " +
                "Even though they look primitive, Goblins are actually very social creatures. They care for " +
                "another and would do anything to protect their family. However, they fear dragons more than " +
                "anything and will run away instead of fight them";
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
            _description = "Legends say kraken were created by power hungry wizards who experimented with creation magic." +
                "Kraken were created in captive until they became too powerful and escaped the wizards." +
                "To this day no one really knows why kraken are such powerful creatures, but this may explain " +
                "why they are immune to all magic spells.";
        }
        public void ElfDescription() {
            _description = "";
        }

        public void AddSpellDescription(int roll) {

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
            _description = "Fire was created by the Sun god who wanted to become the most powerful being." +
                "The Sun god hated humans and their love for the Water god, so they created Fire to defeat the Normal creatures." +
                "Because Fire is so hot, Ice melts immediatly. Therefore, the Ice god asked the Water god and the Ground god for help," +
                "so that Water and Ground would extinguish Fire";
        }
        public void WaterDescription() {
            _description = "";
        }
        public void NormalDescription() {
            _description = "Normal Magic was created by Humans in order to defend themselves against the gods. Humans learned to use " +
                "Water and Light for their advantage and cannot live without them. Humans fear the Sun god and the god of Darkness and cannot " +
                "survive their power.";
        }
        public void GroundDescription() {
            _description = "";
        }
        public void IceDescription() {
            _description = "The Ice god loved only the most beautiful things and began to freeze Water and Ground so they could create " +
                "sculptures out of frozen Water. Because of this, the Water god and the Ground god feared the Ice god and made a deal with " +
                "them, to defeat Fire so that the Ice god won't freeze their element anymore. But once a year the Ice god still creates their most beautiful " +
                "creation, Snow.";
        }
        public void LightDescription() {
            _description = "The god of Light is a very peaceful god, who wanted nothing but peace for everything and everyone." +
                "Until one day, when Darkness the world almost devoured, the god of Light had to use their power to defend the world from it." +
                "Since than, the god of Light fights against the Darkness to bring back peace.";
        }
        public void DarkDescription() {
            _description = "Darkness was the most powerful element, not even the god of Darkness themselves can fully control it. It consumes everything " +
                "it touches and only Light can stop it. Without the god of Light, Darkness would destroy all that ever existed.";
        }


    }
}


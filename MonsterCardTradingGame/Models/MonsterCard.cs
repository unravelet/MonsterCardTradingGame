namespace MonsterCardTradingGame.Models {
    class MonsterCard : Card {

        Random random = new Random();
        int _monsterRoll;
        int _elementalRoll;


        public MonsterCard() {
            _monsterRoll = random.Next(1, 8);
            _elementalRoll = random.Next(0, 7);

            _monster = (Monster)_monsterRoll;
            _elemental = (ElementalType)_elementalRoll;
            _isSpell = false;
            _damage = AddRandomDamage();
            _name = _elemental + "" + _monster + "(" + _damage + ")";

            AddDescription(_monsterRoll);

            Console.WriteLine(_name);
        }

        public void AddDescription(int roll) {

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


    }
}

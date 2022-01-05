namespace MonsterCardTradingGame.Models {
    class SpellCard : Card {

        Random random = new Random();
        int _elementalRoll;

        public SpellCard(Guid id, string owner) {
            _id = id;
            _owner = owner;
            _elementalRoll = random.Next(0, 7);
            _elemental = (ElementalType)_elementalRoll;
            _isSpell = true;
            _damage = AddRandomDamage();
            _speed = AddSpeed(_damage);
            _name = _elemental + "Spell" + "(" + _damage + "|" + _speed + ")";

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
            _description = " ";
        }
        public void DarkDescription() {
            _description = "Darkness was the most powerful element, not even the god of Darkness themselves can fully control it. It consumes everything " +
                "it touches and only Light can stop it. Without the god of Light, Darkness would destroy all that ever existed.";
        }


    }
}

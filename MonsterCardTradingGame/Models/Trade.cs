namespace MonsterCardTradingGame.Models {
    class Trade {

        User _trader1;
        User _trader2;

        public Trade(User user1, User user2) {
            _trader1 = user1;
            _trader2 = user2;

        }

        //TODO
        public Card StartTrade(Card user1Card, Card user2Card) {

            return user1Card;

        }

    }
}

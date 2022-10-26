namespace Blackjack {
    internal class Card {
        // constructor
        public Card(Values value, Suits suits) {
            _value = value;
            _suits = suits;
        }

        // fields
        private Suits _suits;
        private Values _value;

        // operations
        public Suits GetSuit() { return _suits; }
        public Values GetValue() { return _value; }
    }
}
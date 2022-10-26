using System.Collections.Generic;

namespace Blackjack {
    internal class Deck {
        // field
        internal List<Card> _deck = new();
        // operation
        // make card objects, and call int to value, to translate int to values
        public void MakeDeck(int v, Suits suit) {
            // using int to value
            IntToValue value = new(v);
            // hand values to card object
            Card _card = new(value.GetValues(), suit);
            // add card object to _deck list
            _deck.Add(_card);
        }
    }
}
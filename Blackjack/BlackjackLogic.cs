using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    internal static class BlackjackLogic {
        // FIELDS:
        // deck instance
        private static Deck _gameDeck = new();
        // score is only used for transition steps
        private static int _score;
        // list instances containing "drawn" cards from gamedeck deck instance
        internal static List<Card> _playerCards = new ();
        internal static List<Card> _dealerCards = new();
        // loop value for ui
        internal static int _loopAdder;
        // int variables, containing game scores
        internal static int _playerScore;
        internal static int _dealerScore;

        // OPERATIONS:
        // SETUP
        internal static void GameStart() {
            // loop adder 1 for running loop
            _loopAdder = 1;
            // preapare _gamedeck
            GenerateDeck();
            Shuffle();
            Shuffle();
            Shuffle();
            // draw player then dealers first two cards
            PlayerDrawCard();
            PlayerDrawCard();
            DealerDrawCard();
            DealerDrawCard();
            // add values to _playerscore and _dealerscore
            PlayerCardsValueToInt();
            DealerCardsValueToInt();
        }

        // operation for generating card class instances into gamedeck deck instance
        private static void GenerateDeck() {
            // generate cards in gamedeck instance of deck class
            for (int i = 0; i < 13; i++) {
                _gameDeck.MakeDeck(i, Suits.Hearts);
                _gameDeck.MakeDeck(i,Suits.Spades);
                _gameDeck.MakeDeck(i, Suits.Diamonds);
                _gameDeck.MakeDeck(i, Suits.Clubs);
            }
        }
        // operations for shuffling card instances in deck gamedeck deck instance
        private static void Shuffle() {
            // shuffling card objects one by one
            for (int i = 0; i < 52; i++) {
                ShuffleCards(_gameDeck._deck[i]);
            }
         }
        private static void ShuffleCards(Card shuffleCard) {
            // random instance
            Random r = new Random();
            // int between 0 and 51
            int randomNumber = r.Next(52);
            _gameDeck._deck.Remove(shuffleCard);
            _gameDeck._deck.Insert(randomNumber, shuffleCard);
        }

        // WHEN RUNNING GAME
        internal static void PlayerDraws(string? hs) {
            if (hs == "h") {
                PlayerDrawCard();
                PlayerCardsValueToInt();
            } else if (hs == "s") {
                _loopAdder = 0;
            }
        }
        internal static void DealerDraws() {
            DealerDrawCard();
            DealerCardsValueToInt();
        }
        // operations for adding cards to _playercard and _dealercard list 
        private static void PlayerDrawCard() {
            _playerCards.Add(_gameDeck._deck[0]);
            RemoveDrawnCard();
        }
        private static void DealerDrawCard() {
            _dealerCards.Add(_gameDeck._deck[0]);
            RemoveDrawnCard();
        }
        private static void RemoveDrawnCard() {
            Card toBeRemoved = _gameDeck._deck[0];
            _gameDeck._deck.Remove(toBeRemoved);
        }
        // operations for adding value to _dealerscore and _playerscore int
        private static void PlayerCardsValueToInt() {
            // get the value of the hand (ace is 11), and put it in _score
            for (int i = 0; i < _playerCards.Count; i++) {
                Values toInt = _playerCards[i].GetValue();
                ValueToIntConverter(toInt);
            }
            // ace value in _playerscore checked (checks if ace should be one), excess value removed
            for (int i = 0; i < _playerCards.Count; i++) {
                if (_score > 21) {
                    Values aceCheck = _playerCards[i].GetValue();
                    AceCheck(aceCheck);
                }
            }
            // hand _playerscore the score and reset _score
            _playerScore = _score;
            _score = 0;
        }
        private static void DealerCardsValueToInt() {
            // get the value of the hand (ace is 11), and put it in _score
            for (int i = 0; i < _dealerCards.Count; i++) {
                Values toInt = _dealerCards[i].GetValue();
                ValueToIntConverter(toInt);
            }
            // ace value in _dealerscore checked (checks if ace should be one), excess value removed
            for (int i = 0; i < _dealerCards.Count; i++) {
                if (_score > 21) {
                    Values aceCheck = _dealerCards[i].GetValue();
                    AceCheck(aceCheck);
                }
            }
            // hand _dealerscore the score and reset _score
            _dealerScore = _score;
            _score = 0;
        }
        private static void AceCheck(Values aceCheck) {
            if (aceCheck == Values.Ace) {
                _score -= 10;
            }
        }
        private static void ValueToIntConverter(Values check) {
            switch (check) {
                case Values.Ace:
                    _score += 11;
                    break;
                case Values.Two:
                    _score += 2;
                    break;
                case Values.Three:
                    _score += 3;
                    break;
                case Values.Four:
                    _score += 4;
                    break;
                case Values.Five:
                    _score += 5;
                    break;
                case Values.Six:
                    _score += 6;
                    break;
                case Values.Seven:
                    _score += 7;
                    break;
                case Values.Eight:
                    _score += 8;
                    break;
                case Values.Nine:
                    _score += 9;
                    break;
                case Values.Ten:
                    _score += 10;
                    break;
                case Values.Jack:
                    _score += 10;
                    break;
                case Values.Queen:
                    _score += 10;
                    break;
                case Values.King:
                    _score += 10;
                    break;
            }
        }
        internal static void GameReset() {
            // emptying card containers
            _gameDeck._deck.Clear();
            _dealerCards.Clear();
            _playerCards.Clear();
            // emptying score containers
            _score = 0;
            _dealerScore = 0;
            _playerScore = 0;
            // loop adder stop for loop
            _loopAdder = 0;
        }
    }
}
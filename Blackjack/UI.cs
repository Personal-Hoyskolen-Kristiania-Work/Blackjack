namespace Blackjack {
    internal class UI {
        // INTERNAL CLASS INSTANCE
        private static UITools _uiTools = new();

        // MAIN CLASS
        internal static void Main(string[] args) {
            StartBlackjack();
        }
        // CLASS FOR RUNNING GAME
        private static void StartBlackjack() {
            // GAME START
            BlackjackLogic.GameStart();
            InitialMessage();
            InitialDrawDealer();
            InitialDrawPlayer();

            // GAME RUN
            InitialScorecheck();
            PlayerCardDraw();
            DealerCardDraw();
        }

        // UI OPERATIONS
        // game run
        private static void PlayerCardDraw() {
            for (int i = 0; i < BlackjackLogic._loopAdder;) {
                _uiTools.CRLF();
                _uiTools.TextYellow();
                Console.Write("Would you like to hit or stay (h/s)? ");
                string? _hs = Console.ReadLine();
                _uiTools.TextWhite();
                if (_hs == "h" || _hs == "s") {
                    BlackjackLogic.PlayerDraws(_hs);
                    Scorecheck();
                } else {
                    Console.WriteLine("Tip, type \"h\" hit or \"s\" for stand.");
                }
            }
        }
        private static void DealerCardDraw() {
                BlackjackLogic.DealerDraws();
                Scorecheck();
        }
        private static void InitialScorecheck() {
            if(BlackjackLogic._playerScore == 21) {
                _uiTools.CRLF();
                _uiTools.TextYellow();
                Console.Write("Player got the score");
                _uiTools.TextBlue();
                Console.Write(" {0}", BlackjackLogic._playerScore);
                _uiTools.TextYellow();
                Console.Write(", from first two cards");
                _uiTools.TextWhite();
                ShowPlayerCards();
                _uiTools.CRLF();
                if (BlackjackLogic._dealerScore == BlackjackLogic._playerScore) {
                    Console.Write("Dealer got ");
                    _uiTools.TextRed();
                    Console.Write("{0}", BlackjackLogic._dealerScore);
                    _uiTools.TextWhite();
                    Console.Write(", it's the same score, player lose. Dealer cards were:");
                    ShowDealerCards();
                    End();
                } else if (BlackjackLogic._dealerScore <= BlackjackLogic._playerScore) {
                    BlackjackLogic._loopAdder = 0;
                }
            }
        }
        private static void Scorecheck() {
            if (BlackjackLogic._playerScore > 21) {
                _uiTools.CRLF();
                _uiTools.TextYellow();
                Console.Write("Player lose, players score were ");
                _uiTools.TextBlue();
                Console.Write("{0}", BlackjackLogic._playerScore);
                _uiTools.TextYellow();
                Console.Write(", it's more than 21. ");
                _uiTools.CRLF();
                Console.Write("Players cards were:");
                ShowPlayerCards();
                _uiTools.CRLF();
                Console.Write("Dealer cards were:");
                ShowDealerCards();
                End();
            } 
            else if (BlackjackLogic._playerScore == 21) {
                _uiTools.CRLF();
                _uiTools.TextYellow();
                Console.Write("Player got ");
                _uiTools.TextBlue();
                Console.Write("{0} ", BlackjackLogic._playerScore);
                _uiTools.TextYellow();
                Console.Write("from cards:");
                ShowPlayerCards();
                _uiTools.CRLF();
                if (BlackjackLogic._dealerScore == BlackjackLogic._playerScore) {
                    Console.Write("Dealer got ");
                    _uiTools.TextRed();
                    Console.Write("{0}", BlackjackLogic._dealerScore);
                    _uiTools.TextWhite();
                    Console.Write(", it's the same score, player lose. Dealer cards were:");
                    ShowDealerCards();
                    End();
                } 
                else if (BlackjackLogic._dealerScore > BlackjackLogic._playerScore) {
                    Console.Write("Dealer got ");
                    _uiTools.TextRed();
                    Console.Write("{0}", BlackjackLogic._dealerScore);
                    _uiTools.TextWhite();
                    Console.Write(", it's more than players score, which is the the score limit. Player win, and dealer cards were:");
                    ShowDealerCards();
                    End();
                } 
                else if (BlackjackLogic._dealerScore < BlackjackLogic._playerScore) {
                    BlackjackLogic._loopAdder = 0;
                    Console.Write("Dealer draw a card.");
                }
            } 
            else if (BlackjackLogic._playerScore < 21 && BlackjackLogic._loopAdder == 1) {
                _uiTools.CRLF();
                _uiTools.TextYellow();
                Console.Write("Player draw card: ");
                _uiTools.TextBlue();
                Console.Write("{0} {1}", 
                    BlackjackLogic._playerCards[BlackjackLogic._playerCards.Count - 1].GetSuit(), 
                    BlackjackLogic._playerCards[BlackjackLogic._playerCards.Count - 1].GetValue());
                _uiTools.CRLF();
                _uiTools.TextYellow();
                Console.Write("and your score is: ");
                _uiTools.TextBlue();
                Console.Write("{0}", BlackjackLogic._playerScore);
                _uiTools.TextWhite();
            } 
            else if(BlackjackLogic._playerScore < 21 && BlackjackLogic._loopAdder == 0) {
                _uiTools.CRLF();
                _uiTools.TextWhite();
                Console.Write("Dealer draws card");
                if (BlackjackLogic._dealerScore > 21) {
                    _uiTools.CRLF();
                    Console.Write("Dealer got ");
                    _uiTools.TextRed();
                    Console.Write("{0}", BlackjackLogic._dealerScore);
                    _uiTools.TextWhite();
                    Console.Write(", it's more than 21, which is the limit. Player win, and dealer cards were:");
                    ShowDealerCards();
                    _uiTools.CRLF();
                    _uiTools.TextYellow();
                    Console.Write("Player got ");
                    _uiTools.TextBlue();
                    Console.Write("{0} ", BlackjackLogic._playerScore);
                    _uiTools.TextYellow();
                    Console.Write("from cards:");
                    ShowPlayerCards();
                    End();
                }
                else if (BlackjackLogic._dealerScore >= BlackjackLogic._playerScore) {
                    _uiTools.CRLF();
                    Console.Write("Dealer got ");
                    _uiTools.TextRed();
                    Console.Write("{0}", BlackjackLogic._dealerScore);
                    _uiTools.TextWhite();
                    Console.Write(", Dealer win, and dealer cards were:");
                    ShowDealerCards();
                    _uiTools.CRLF();
                    _uiTools.TextYellow();
                    Console.Write("Player got ");
                    _uiTools.TextBlue();
                    Console.Write("{0} ", BlackjackLogic._playerScore);
                    _uiTools.TextYellow();
                    Console.Write("from cards:");
                    ShowPlayerCards();
                    End();
                }
                else {
                    DealerCardDraw();
                }
            }
        }
        private static void ShowDealerCards() {
            for (int i = 0; i < BlackjackLogic._dealerCards.Count; i++) {
                _uiTools.CRLF();
                _uiTools.TextRed();
                Console.Write("{0} {1}", BlackjackLogic._dealerCards[i].GetSuit(), BlackjackLogic._dealerCards[i].GetValue());
                _uiTools.TextWhite();
            }
        }
        private static void ShowPlayerCards() {
            for (int i = 0; i < BlackjackLogic._playerCards.Count; i++) {
                _uiTools.CRLF();
                _uiTools.TextBlue();
                Console.Write("{0} {1}", BlackjackLogic._playerCards[i].GetSuit(), BlackjackLogic._playerCards[i].GetValue());
                _uiTools.TextWhite();
            }
        }
        private static void End() {
            _uiTools.CRLF();
            Console.Write("Would you like to play again? (y/n)");
            string? yn = Console.ReadLine();
            if (yn == "y") {
                _uiTools.ConsoleClear();
                BlackjackLogic.GameReset();
                StartBlackjack();
            } 
            else if (yn == "n") {
                _uiTools.CRLF();
                _uiTools.TextYellow();
                Console.Write("Hit enter to exit");
                _uiTools.TextWhite();
                Environment.Exit(0);
            } 
            else {
                _uiTools.ConsoleClear();
                Console.Write("Tip: press \"y\" for yes or \"n\" for no.");
                End();
            }
        }

        //game start
        private static void InitialMessage() {
            Console.Write("Blackjack");
            _uiTools.CRLF();
            _uiTools.TextSplitter();
        }
        private static void InitialDrawDealer() {
            Console.Write("Dealers initial draw is the ");
            _uiTools.TextRed();
            Console.Write("\"hidden hole card\" ");
            _uiTools.TextWhite();
            Console.Write("and the card ");
            _uiTools.TextRed();
            Console.Write("{0} {1}", BlackjackLogic._dealerCards[0].GetSuit(), BlackjackLogic._dealerCards[0].GetValue());
            _uiTools.CRLF();
            _uiTools.CRLF();
            _uiTools.CRLF();
            _uiTools.TextWhite();
        }
        private static void InitialDrawPlayer() {
            _uiTools.TextYellow();
            Console.Write("Your initial draw is ");
            _uiTools.TextBlue();
            Console.Write("{0} {1} ", BlackjackLogic._playerCards[0].GetSuit(), BlackjackLogic._playerCards[0].GetValue());
            _uiTools.TextYellow();
            Console.Write("and ");
            _uiTools.TextBlue();
            Console.Write("{0} {1}", BlackjackLogic._playerCards[1].GetSuit(), BlackjackLogic._playerCards[1].GetValue());
            _uiTools.CRLF();
            _uiTools.TextYellow();
            Console.Write("and your score is: ");
            _uiTools.TextBlue();
            Console.Write("{0}",BlackjackLogic._playerScore);
            _uiTools.TextWhite();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    internal class UITools {
        // ADD STRING VALUES
        // split text by adding a horisontal line
        // (made out of lines) with a smaller vertical line at the end
        public void TextSplitter() {
            Console.WriteLine("------------------------------|\r\n");
        }
        // carriage return + line feed
        public void CRLF() {
            Console.Write("\r\n");
        }

        // TEXT COLORS
        // turn console text white
        public void TextWhite() {
            Console.ForegroundColor = ConsoleColor.White;
        }
        // turn console text red
        public void TextRed() {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        // turn console text yellow
        public void TextYellow() {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        // turn console text blue
        public void TextBlue() {
            Console.ForegroundColor = ConsoleColor.Blue;
        }


        // CLEAR CONSOLE
        public void ConsoleClear() {
            Console.Clear();
        }
    }
}

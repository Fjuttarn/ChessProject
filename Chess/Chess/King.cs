using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : ChessPiece
    {
        public King(Player p, int posX, int posY) : base(p, posX, posY) { }

        public override Boolean isValidMove(Move move)
        {
            if (move.gettoY() - move.getfromY() == 1 && (move.gettoX() - move.getfromX() == 1 ||
                  move.gettoX() - move.getfromX() == -1 || move.gettoX() == move.getfromX()))
            {
                System.Console.WriteLine("1Draget är tillåtet!");
                return true;
            }
            else if (move.gettoY() - move.getfromY() == -1 && (move.gettoX() - move.getfromX() == 1 ||
                 move.gettoX() - move.getfromX() == -1 || move.gettoX() == move.getfromX()))
            {
                System.Console.WriteLine("2Draget är tillåtet!");
                return true;
            }
            else if (move.gettoX() - move.getfromX() == 1 || move.gettoX() - move.getfromX() == -1)
            {
                System.Console.WriteLine("3Draget är tillåtet!");
                return true;
            }
            else
            {
                System.Console.WriteLine("4Draget är inte tillåtet!");
                return false;
            }
        }
    }
}

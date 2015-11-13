using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : ChessPiece
    {
        public Queen(Player p, int posX, int posY) : base(p, posX, posY) {}

        public override Boolean isValidMove(Move move)
        {
            if (move.gettoX() - move.getfromX() == move.gettoY() - move.getfromY())
            {
                return true;
            }
            else if (move.gettoX() + move.getfromX() == move.gettoY() + move.getfromY())
            {
                return true;
            }
            else if (move.gettoY() == move.getfromY() || move.gettoX() == move.getfromX())
            {
                System.Console.WriteLine("draget är tillåtet");
                return true;
            }

            return false;
        }
    }
}

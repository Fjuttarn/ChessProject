using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Horse : ChessPiece
    {
        public Horse(Player p, int posX, int posY) : base(p, posX, posY) {}

        public override Boolean isValidMove(Move move)
        {
            if(move.getfromY() - move.gettoY() == 2 || move.getfromY() - move.gettoY() == -2)
            {
                if(move.getfromX() - move.gettoX() == 1 || move.getfromX() - move.gettoX() == -1)
                {
                    System.Console.WriteLine("1Draget är tillåtet!");
                    return true;
                }
            }
            if (move.getfromX() - move.gettoX() == 2 || move.getfromX() - move.gettoX() == -2)
            {
                if (move.getfromY() - move.gettoY() == 1 || move.getfromY() - move.gettoY() == -1)
                {
                    System.Console.WriteLine("2Draget är tillåtet!");
                    return true;
                }
            }
            System.Console.WriteLine("Draget är inte tillåtet!");
            return false;
        }
    }
}

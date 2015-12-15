using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
   public class Horse : ChessPiece
    {
        public Horse(string color, int posX, int posY) : base(color, posX, posY) {}

        public override Boolean isValidMove(Move move)
        {
            if(move.getfromY() - move.gettoY() == 2 || move.getfromY() - move.gettoY() == -2)
            {
                if(move.getfromX() - move.gettoX() == 1 || move.getfromX() - move.gettoX() == -1)
                {
                    return true;
                }
            }
            if (move.getfromX() - move.gettoX() == 2 || move.getfromX() - move.gettoX() == -2)
            {
                if (move.getfromY() - move.gettoY() == 1 || move.getfromY() - move.gettoY() == -1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

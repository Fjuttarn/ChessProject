using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
   public class King : ChessPiece
    {
        public King(string color, int posX, int posY) : base(color, posX, posY) { }

        //Kollar om ett drag är godkänt för en kung
        public override Boolean isValidMove(Move move)
        {
            if (move.gettoY() - move.getfromY() == 1 && (move.gettoX() - move.getfromX() == 1 ||
                  move.gettoX() - move.getfromX() == -1 || move.gettoX() == move.getfromX()))
            {
                return true;
            }
            else if (move.gettoY() - move.getfromY() == -1 && (move.gettoX() - move.getfromX() == 1 ||
                 move.gettoX() - move.getfromX() == -1 || move.gettoX() == move.getfromX()))
            {
                return true;
            }
            else if ((move.gettoX() - move.getfromX() == 1 || move.gettoX() - move.getfromX() == -1) &&
                (move.gettoY() - move.getfromY() == 0 ))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

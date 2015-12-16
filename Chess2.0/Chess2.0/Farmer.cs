using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
   public class Farmer : ChessPiece
    {
        public Farmer(string color, int posX, int posY) : base(color, posX, posY) { }

        public override Boolean isValidMove(Move move)
        {
            //Kollar om draget är godkänt för en vit bonde
            if (color == "white")
            {
                if (move.gettoY() - move.getfromY() == 2 && move.gettoX() == move.getfromX() 
                    && move.getfromY() == 1)//Ok att gå två steg fram från startposition
                {
                    return true;
                }

                if (move.gettoY() - move.getfromY() == 1 && (move.gettoX() - move.getfromX() == -1 ||
                    (move.gettoX() - move.getfromX() == 1 && move.gettoY() - move.getfromY() == 1) ||
                    (move.gettoX() == move.getfromX() && move.gettoY() - move.getfromY() == 1)))
                {
                    return true;
                }
            }

            //Kollar om draget är godkänt för en svart bonde
            if (color == "black")
            {
                if (move.gettoY() - move.getfromY() == -2 && move.gettoX() == move.getfromX() 
                    && move.getfromY() == 6)//Ok att gå två steg fram från startposition
                {
                    return true;
                }

                if ((move.gettoY() - move.getfromY() == -1 && move.gettoX() - move.getfromX() == 1) ||
                    (move.gettoX() - move.getfromX() == -1 && (move.gettoY() - move.getfromY() == -1) ||
                    (move.gettoX() == move.getfromX() && move.gettoY() - move.getfromY() == -1)))
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}

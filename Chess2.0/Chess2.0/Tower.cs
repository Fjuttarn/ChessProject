using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
   public  class Tower : ChessPiece
    {
        public Tower(Player p, int posX, int posY) : base(p, posX, posY) {}
   
        public override Boolean isValidMove(Move move)
        {
            if(move.gettoY() == move.getfromY() || move.gettoX() == move.getfromX())
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

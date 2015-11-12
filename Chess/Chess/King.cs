using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : ChessPiece
    {
        public King(Player p, int posX, int posY) : base(p, posX, posY)
        {
        }

     

        public override Boolean isValidMove(Move move)
        {
            return true;
        }
    }
}

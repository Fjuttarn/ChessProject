using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessPiece
    {
        int positionX;
        int positionY;
        Player player;
        public ChessPiece(Player p, int posX, int posY)
        {
            player = p;
            positionX = posX;
            positionY = posY;
        }

        public int posX
        {
            get
            {
                return positionX;
            }
            set
            {
                positionX = value;
            }
        }

        public int posY
        {
            get
            {
                return positionY;
            }
            set
            {
                positionY = value;
            }
        }

        public virtual Boolean isValidMove(Move move)
        {
            return true;
        }
    }
}

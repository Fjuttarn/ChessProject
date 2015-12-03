using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class ChessPiece
    {
        protected int positionX;
        protected int positionY;
        protected Player player;

        protected ChessPiece(Player p, int posX, int posY)
        {
            positionX = posX;
            positionY = posY;
            player = p;
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

        public Player getPlayer
        {
            get
            {
                return player;
            }
        }

        public abstract Boolean isValidMove(Move move);
    }
}

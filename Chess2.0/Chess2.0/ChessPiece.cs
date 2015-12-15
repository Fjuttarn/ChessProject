using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    public abstract class ChessPiece
    {
        protected int positionX;
        protected int positionY;
        protected string color;

        protected ChessPiece(string color, int posX, int posY)
        {
            positionX = posX;
            positionY = posY;
            this.color = color;
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

        public string Color
        {
            get
            {
                return color;
            }
        }

        public abstract Boolean isValidMove(Move move);
    }
}

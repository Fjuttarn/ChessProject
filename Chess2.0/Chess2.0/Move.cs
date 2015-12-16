using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
   public class Move
    {
       private int fromX;
       private int fromY;
       private int toX;
       private int toY;

        public Move (int fromX, int fromY, int toX, int toY)
        {
            this.fromX = fromX;
            this.fromY = fromY;
            this.toX = toX;
            this.toY = toY;
        }

        public int getfromX()
        {
            return fromX;
        }

        public int getfromY()
        {
            return fromY;
        }

        public int gettoX()
        {
            return toX;
        }

        public int gettoY()
        {
            return toY;
        }

        //Kollar om ett drag är horisontellt
        public bool isHorizontal()
        {
            if(fromY == toY)
            {
                return true;
            }

            return false;
        }

        //Kollar om ett drag är vertikalt
        public bool isVertical()
        {
            if(fromX == toX)
            {
                return true;
            }

            return false;
        }

        //Kollar om ett drag är diagonalt
        public bool isDiagonal()
        {
            if(fromX != toX && fromY != toY)
            {
                return true;
            }

            return false;
        }
    }
}

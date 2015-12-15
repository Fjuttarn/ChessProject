using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    public partial class Player
    {
        private string color;

        public Player(String color)
        {
            this.color = color;
        }

        public String Color
        {
            get
            {
                return color;
            }
        }
        public virtual void setupAI(ChessBoard chessboard, GameView gw) { }

        public virtual void AImove() { }
    }
}

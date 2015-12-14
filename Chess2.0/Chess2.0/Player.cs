using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    public partial class Player
    {
        private string colour;

        public Player(String colour)
        {
            this.colour = colour;
        }

        public String getColour
        {
            get
            {
                return colour;
            }
        }
        public virtual void setupAI(ChessBoard chessboard, GameView gw) { }

        public virtual void AImove() { }
    }
}

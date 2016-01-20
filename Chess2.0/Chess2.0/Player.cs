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

        private bool playersTurn;

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

        public bool isPlayersTurn
        {
            get
            {
                return playersTurn;
            }
            set
            {
                playersTurn = value;
            }
        }

        public virtual void setupAI(ChessBoard chessboard, GameView gw) { }

        public virtual void movePiece() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class GameView
    {
        public GameView()
        {

            Player playerblack = new CPUPlayer();
            Player playerwhite = new HumanPlayer();
            ChessBoard board = new ChessBoard(playerwhite, playerblack);
            board.makeMove(1, 1, 4, 4);
        }
    }
}

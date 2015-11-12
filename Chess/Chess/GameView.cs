using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class GameView
    {
        Player playerblack = new CPUPlayer();
        Player playerwhite = new HumanPlayer();
        ChessBoard board;
        public GameView()
        {
            board = new ChessBoard(playerwhite, playerblack);
        }

        //Kallas på efter att en player försöker göra ett drag för att se till att det är giltigt
        public void makeMove(int fromX, int fromY, int toX, int toY)
        {
            Move move = new Move(fromX, fromY, toX, toY);
            if (board.isValid(move) == true)
            {
                //gui.updateBoard();
                board.updateTable(move);
            }
        }
    }
}

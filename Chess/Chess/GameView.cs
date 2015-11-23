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
        RulesEngine rules;
        bool p1turn = true;
        public GameView()
        {
            board = new ChessBoard(playerwhite, playerblack);
            rules = new RulesEngine(board);
        }

        //Kallas på efter att en player försöker göra ett drag för att se till att det är giltigt
        public void makeMove(int fromX, int fromY, int toX, int toY)
        {
            
            Move move = new Move(fromX, fromY, toX, toY);
            if (rules.isValid(move))
            {
                //gui.updateBoard();
                board.updateTable(move);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    class GameView
    {
        MainWindow window;
        Player playerblack = new CPUPlayer("black");
        Player playerwhite = new HumanPlayer("white");
        ChessBoard board;
        RulesEngine rules;
        String gamestatus = "white";


        public GameView(MainWindow window)
        {
            this.window = window;
            board = new ChessBoard(playerwhite, playerblack);
            rules = new RulesEngine(board);
        }
        public void onMoveCompleted (int[] newMove)
        {
            makeMove(newMove[0], newMove[1], newMove[2], newMove[3]);
        }

        public void run()
        {
            System.Console.WriteLine(gamestatus + " turn.");
            System.Console.WriteLine("Game ended. " + gamestatus);
        }

        //Kallas på efter att en player försöker göra ett drag för att se till att det är giltigt
        public void makeMove(int fromX, int fromY, int toX, int toY)
        {
            
            Move move = new Move(fromX, fromY, toX, toY);
            
            if (rules.isValid(move, gamestatus))
            {
                window.updateBoard();
                board.updateTable(move);
                switchTurn();
             
               
                System.Console.WriteLine(gamestatus + " turn");
            }
            if (board.isKingDead(gamestatus))
            {
                gamestatus = "The " + gamestatus + " king is dead, Game Over!";
                window.gameOver(gamestatus);
            }
            /*
            if (rules.isCheck(board.getWhiteKing()))
            {
                if (rules.isCheckMate(board.getWhiteKing()))
                {
                    gamestatus = "Black wins!";
                }

            }
            else if (rules.isCheck(board.getBlackKing()))
            {
                if (rules.isCheckMate(board.getBlackKing()))
                {
                    gamestatus = "White wins!";
                }
            }
            */
        }

        public void switchTurn()
        {
            if(gamestatus.Equals("white"))
            {
                gamestatus = "black";
            }
            else if(gamestatus.Equals("black"))
            {
                gamestatus = "white";
            }
        }
    }
}

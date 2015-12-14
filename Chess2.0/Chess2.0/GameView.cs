using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
  public class GameView
    {
        MainWindow window;
        ChessBoard board;
        Player playerblack;
        Player playerwhite = new HumanPlayer("white");
        RulesEngine rules;
        String _gamestatus = "white";
        public String gamestatus
        {
            get { return _gamestatus; }
            set
            {
                _gamestatus = value;
                if(_gamestatus == "black")
                {
                    playerblack.AImove();
                }
            }
        }



        public GameView(MainWindow window)
        {
            this.window = window;

            playerblack = new CPUPlayer("black");
            board = new ChessBoard(playerwhite, playerblack);
            rules = new RulesEngine(board);
            playerblack.setupAI(board, this);
            window.setBoard(board.get());
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
               // window.updateBoard(move);
                board.updateTable(move);
                window.updateTable();
                switchTurn();


                System.Console.WriteLine(gamestatus + " turn");

                if (board.isKingDead(gamestatus))
                {
                    gamestatus = "The " + gamestatus + " king is dead, Game Over!";
                    window.gameOver(gamestatus);
                }
          
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

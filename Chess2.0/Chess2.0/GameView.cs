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
            /*while (!gamestatus.Equals("White wins!") || !gamestatus.Equals("Black wins!"))
            {
                System.Console.WriteLine("HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEJJJJJJ!!!!!ONE");
                int fromX = new int();
                int fromY = new int();
                int toX = new int();
                int toY = new int();

                if (gamestatus.Equals("white"))
                {
                    //Hantera input
                    System.Console.WriteLine("Skriv vilket x du vill gå från.");
                    fromX = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Skriv vilket y du vill gå från.");
                    fromY = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Vilket x vill du gå till?.");
                    toX = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Vilket y vill du gå till?.");
                    toY = int.Parse(Console.ReadLine());
                    
                }
                else if(gamestatus.Equals("black"))
                {
                    //Hantera input
                    System.Console.WriteLine("Skriv vilket x du vill gå från.");
                    fromX = int.Parse(Console.ReadLine());
                    System.Console.WriteLine(fromX);
                    System.Console.WriteLine("Skriv vilket y du vill gå från.");
                    fromY = int.Parse(Console.ReadLine());
                    System.Console.WriteLine(fromY);
                    System.Console.WriteLine("Vilket x vill du gå till?.");
                    toX = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Vilket y vill du gå till?.");
                    toY = int.Parse(Console.ReadLine());
                    System.Console.Read();
                    
                }
                makeMove(fromX, fromY, toX, toY);
            }*/

            System.Console.WriteLine("Game ended. " + gamestatus);
        }

        //Kallas på efter att en player försöker göra ett drag för att se till att det är giltigt
        public void makeMove(int fromX, int fromY, int toX, int toY)
        {
            
            Move move = new Move(fromX, fromY, toX, toY);
            
            if (rules.isValid(move, gamestatus))
            {
                //gui.updateBoard();
                board.updateTable(move);
                switchTurn();
                System.Console.WriteLine(gamestatus + " turn!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!.");
            }

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

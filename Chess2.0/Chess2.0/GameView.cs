using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chess2._0
{
  public class GameView
    {
        MainWindow window;
        ChessBoard board;
        Player playerwhite;
        Player playerblack;
        RulesEngine rules;
        string _gamestatus;
        DataStorage ds = new DataStorage();

        public String gamestatus
        {
            get { return _gamestatus; }
            set
            {
                _gamestatus = value;
                if(_gamestatus == "black")
                {
                    playerblack.movePiece();
                }
                if(_gamestatus == "white")
                {
                    playerwhite.movePiece();
                }
            }
        }

        public GameView(MainWindow window)
        {
            this.window = window;
        }

        //Initierar spelare utifrån vad som har valts i menyerna
        public void GameSetup(string gamemode, bool isNewGame, string color)
        {
            if (isNewGame)
            {
                ds.removeFile();
            }

            board = new ChessBoard();

            if (gamemode == "singleplayer")
            {
                switch (color)
                {
                    case "white":
                        playerwhite = new HumanPlayer("white");
                        playerblack = new CPUPlayer("black");
                        playerblack.setupAI(board, this);
                        break;

                    case "black":
                        playerwhite = new CPUPlayer("white");
                        playerblack = new HumanPlayer("black");
                        playerwhite.setupAI(board, this);
                        break;
                }             
            }
            else if(gamemode == "multiplayer")
            {
                playerwhite = new HumanPlayer("white");
                playerblack = new HumanPlayer("black");
            }
 
            rules = new RulesEngine(board);
            window.setBoard(board.get());
            window.updateTable();
            gamestatus = "white";
        }

        //Lyssnar efter gjorda drag i ui
        public void onMoveCompleted (int[] newMove)
        {
            if (playerwhite is HumanPlayer && gamestatus == "white" ||
                playerblack is HumanPlayer && gamestatus == "black")
            {
                makeMove(newMove[0], newMove[1], newMove[2], newMove[3]);
            }
        }

        //Ändrar gamestatus till gameover, och tar bort lagringsfilen
        public void gameOver()
        {
            gamestatus = gamestatus + " player lost. GAME OVER!";
            ds.removeFile();
            window.gameOver(gamestatus);
        }

        //Kallas på efter att en player försöker göra ett drag för att se till att det är giltigt
        public void makeMove(int fromX, int fromY, int toX, int toY)
        {         
            Move move = new Move(fromX, fromY, toX, toY);

            if (rules.isValid(move, gamestatus, board.get()))
            {
                board.updateTable(move);
                window.updateTable();
                ds.SaveData(board.get());

                //Kollar om kungen blev utslagen
                switchTurn();

                if (rules.isCheckMate(gamestatus))
                {
                    gameOver();
                }
                
            }
        }

        //Byter gamestatus beroende på vems tur det är
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

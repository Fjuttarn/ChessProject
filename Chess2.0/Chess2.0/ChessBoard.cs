using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chess2._0
{
   public class ChessBoard
    {
        private ChessPiece[,] board = new ChessPiece[8, 8];
        DataStorage ds = new DataStorage();
        ChessPiece blackKing;
        ChessPiece whiteKing;

        public ChessBoard()
        {
         
            //Om det finns ett sparat spel, läs in det
            if (File.Exists(@".\chessdata\chessdata.xml"))
            {
                this.board = ds.LoadData();
                ds.SaveData(board);
            }
            else
            {
                //Skapar vita pjäser
                whiteKing = new King("white", 3, 0);
                ChessPiece whiteQueen = new Queen("white", 4, 0);
                ChessPiece whiteRunner1 = new Runner("white", 2, 0);
                ChessPiece whiteRunner2 = new Runner("white", 5, 0);
                ChessPiece whiteHorse1 = new Horse("white", 1, 0);
                ChessPiece whiteHorse2 = new Horse("white", 6, 0);
                ChessPiece whiteTower1 = new Tower("white", 0, 0);
                ChessPiece whiteTower2 = new Tower("white", 7, 0);
                ChessPiece whiteFarmer1 = new Farmer("white", 0, 1);
                ChessPiece whiteFarmer2 = new Farmer("white", 1, 1);
                ChessPiece whiteFarmer3 = new Farmer("white", 2, 1);
                ChessPiece whiteFarmer4 = new Farmer("white", 3, 1);
                ChessPiece whiteFarmer5 = new Farmer("white", 4, 1);
                ChessPiece whiteFarmer6 = new Farmer("white", 5, 1);
                ChessPiece whiteFarmer7 = new Farmer("white", 6, 1);
                ChessPiece whiteFarmer8 = new Farmer("white", 7, 1);

                //Skapar svarta pjäser
                blackKing = new King("black", 4, 7);
                ChessPiece blackQueen = new Queen("black", 3, 7);
                ChessPiece blackRunner1 = new Runner("black", 2, 7);
                ChessPiece blackRunner2 = new Runner("black", 5, 7);
                ChessPiece blackHorse1 = new Horse("black", 1, 7);
                ChessPiece blackHorse2 = new Horse("black", 6, 7);
                ChessPiece blackTower1 = new Tower("black", 0, 7);
                ChessPiece blackTower2 = new Tower("black", 7, 7);
                ChessPiece blackFarmer1 = new Farmer("black", 0, 6);
                ChessPiece blackFarmer2 = new Farmer("black", 1, 6);
                ChessPiece blackFarmer3 = new Farmer("black", 2, 6);
                ChessPiece blackFarmer4 = new Farmer("black", 3, 6);
                ChessPiece blackFarmer5 = new Farmer("black", 4, 6);
                ChessPiece blackFarmer6 = new Farmer("black", 5, 6);
                ChessPiece blackFarmer7 = new Farmer("black", 6, 6);
                ChessPiece blackFarmer8 = new Farmer("black", 7, 6);

                //Lägg till pjäser i tvådimensionell array som representerar schackbrädet
                board[3, 0] = whiteKing;
                board[4, 0] = whiteQueen;
                board[2, 0] = whiteRunner1;
                board[5, 0] = whiteRunner2;
                board[1, 0] = whiteHorse1;
                board[6, 0] = whiteHorse2;
                board[0, 0] = whiteTower1;
                board[7, 0] = whiteTower2;
                board[0, 1] = whiteFarmer1;
                board[1, 1] = whiteFarmer2;
                board[2, 1] = whiteFarmer3;
                board[3, 1] = whiteFarmer4;
                board[4, 1] = whiteFarmer5;
                board[5, 1] = whiteFarmer6;
                board[6, 1] = whiteFarmer7;
                board[7, 1] = whiteFarmer8;

                board[4, 7] = blackKing;
                board[3, 7] = blackQueen;
                board[2, 7] = blackRunner1;
                board[5, 7] = blackRunner2;
                board[1, 7] = blackHorse1;
                board[6, 7] = blackHorse2;
                board[0, 7] = blackTower1;
                board[7, 7] = blackTower2;
                board[0, 6] = blackFarmer1;
                board[1, 6] = blackFarmer2;
                board[2, 6] = blackFarmer3;
                board[3, 6] = blackFarmer4;
                board[4, 6] = blackFarmer5;
                board[5, 6] = blackFarmer6;
                board[6, 6] = blackFarmer7;
                board[7, 6] = blackFarmer8;

                ds.SaveData(board);
            }
        }

        public ChessPiece[,] get()
        {
            return board;
        }

        public ChessPiece[,] getCopy()
        {
            ChessPiece[,] boardToReturn = new ChessPiece[8,8];
            for(int x = 0; x <= 7; x++)
            {
                for(int y = 0; y <= 7; y++)
                {
                    if (board[x, y] != null)
                    boardToReturn[x, y] = board[x,y];
                } 
            }
            return boardToReturn;
        }

        public ChessPiece getblackKing()
        {
            return blackKing;
        }

        public ChessPiece getwhiteKing()
        {
            return whiteKing;
        }

        //Updaterar brädet (arrayen) efter att ett drag genomförts
        public void updateTable(Move move)
        {
            Console.WriteLine("Spelarens gamla pos: " + board[move.getfromX(), move.getfromY()]);
            Console.WriteLine("X: " + move.getfromX() + "  Y: " + move.getfromY());
            board[move.gettoX(), move.gettoY()] = board[move.getfromX(), move.getfromY()];
            board[move.getfromX(), move.getfromY()] = null;
            Console.WriteLine("X: " + move.gettoX() + "  Y: " + move.gettoY());
            Console.WriteLine("Random spelare: " + board[0, 0]);
            Console.WriteLine("Random spelare: " + board[1, 1]);
            Console.WriteLine("Spelarens gamla pos: " + board[move.getfromX(), move.getfromY()]);
            Console.WriteLine("Spelarens nya pos: " + board[move.gettoX(), move.gettoY()]);
            board[move.gettoX(), move.gettoY()].posX = move.gettoX();
            board[move.gettoX(), move.gettoY()].posY = move.gettoY();
        }

        //Kollar om någon av kungarna har blivit utslagen
        public bool isKingDead(String gameStatus)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] != null)
                    {
                        ChessPiece temp = board[x, y];

                        if (gameStatus.Equals("white"))
                        {
                            if (temp is King && temp.Color == "black")
                            {
                                return false;
                            }
                        }
                        else if (gameStatus.Equals("black"))
                        {
                            if (temp is King && temp.Color == "white")
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        //1. Egen pjäs
        //2. Motståndares pjäs
        //3. Tom ruta
        public int squareStatus(Move move)
        {
            if (board[move.gettoX(), move.gettoY()] != null)
            {
                ChessPiece p1 = board[move.getfromX(), move.getfromY()];
                ChessPiece p2 = board[move.gettoX(), move.gettoY()];

                if (p1.Color == p2.Color)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            return 3;
        }

        //Returnerar färgen på pjäsen som flyttas
        public string colourOfPiece(Move move)
        {
            if (board[move.getfromX(), move.getfromY()] != null)
            {
                return board[move.getfromX(), move.getfromY()].Color;
            }
            else return "";

        }

    }
}
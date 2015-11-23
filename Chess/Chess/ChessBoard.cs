using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessBoard
    {
        ChessPiece[,] board = new ChessPiece[8, 8];
        public ChessBoard(Player p1, Player p2)
        {
            //all white pieces
            ChessPiece whiteKing = new King(p1, 3, 0);
            ChessPiece whiteQueen = new Queen(p1, 4, 0);
            ChessPiece whiteRunner1 = new Runner(p1, 2, 0);
            ChessPiece whiteRunner2 = new Runner(p1, 5, 0);
            ChessPiece whiteHorse1 = new Horse(p1, 1, 0);
            ChessPiece whiteHorse2 = new Horse(p1, 6, 0);
            ChessPiece whiteTower1 = new Tower(p1, 0, 0);
            ChessPiece whiteTower2 = new Tower(p1, 7, 0);
            ChessPiece whiteFarmer1 = new Farmer(p1, 0, 1);
            ChessPiece whiteFarmer2 = new Farmer(p1, 1, 1);
            ChessPiece whiteFarmer3 = new Farmer(p1, 2, 1);
            ChessPiece whiteFarmer4 = new Farmer(p1, 3, 1);
            ChessPiece whiteFarmer5 = new Farmer(p1, 4, 1);
            ChessPiece whiteFarmer6 = new Farmer(p1, 5, 1);
            ChessPiece whiteFarmer7 = new Farmer(p1, 6, 1);
            ChessPiece whiteFarmer8 = new Farmer(p1, 7, 1);

            //all black pieces
            ChessPiece blackKing = new King(p2, 4, 7);
            ChessPiece blackQueen = new Queen(p2, 3, 7);
            ChessPiece blackRunner1 = new Runner(p2, 2, 7);
            ChessPiece blackRunner2 = new Runner(p2, 5, 7);
            ChessPiece blackHorse1 = new Horse(p2, 1, 7);
            ChessPiece blackHorse2 = new Horse(p2, 6, 7);
            ChessPiece blackTower1 = new Tower(p2, 0, 7);
            ChessPiece blackTower2 = new Tower(p2, 7, 7);
            ChessPiece blackFarmer1 = new Farmer(p2, 0, 6);
            ChessPiece blackFarmer2 = new Farmer(p2, 1, 6);
            ChessPiece blackFarmer3 = new Farmer(p2, 2, 6);
            ChessPiece blackFarmer4 = new Farmer(p2, 3, 6);
            ChessPiece blackFarmer5 = new Farmer(p2, 4, 6);
            ChessPiece blackFarmer6 = new Farmer(p2, 5, 6);
            ChessPiece blackFarmer7 = new Farmer(p2, 6, 6);
            ChessPiece blackFarmer8 = new Farmer(p2, 7, 6);

            //add all chesspieces to twodimensional array
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

        }
        public ChessPiece[,] get()
        {
            return board;
        }
        //Updaterar den brädet (arrayen) efter att ett drag genomförts
        public void updateTable(Move move)
        {
            board[move.gettoX(), move.gettoY()] = board[move.getfromX(), move.getfromY()];
            board[move.getfromX(), move.getfromY()] = null;
            board[move.gettoX(), move.gettoY()].posX = move.gettoX();
            board[move.gettoX(), move.gettoY()].posY = move.gettoY();

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

                if (p1.getPlayer == p2.getPlayer)
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

    }
}
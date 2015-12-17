using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
   public class RulesEngine
    {
        private ChessBoard board;
        ChessPiece[,] chessboard;

        public RulesEngine(ChessBoard board)
        {
            this.board = board;
        }

        //Kollar om det är ett tillåtet drag
        public bool isValid(Move move, String gameStatus)
        {
            chessboard = board.get();
            if (board.colourOfPiece(move) == gameStatus)
            {
                if (chessboard[move.getfromX(), move.getfromY()].isValidMove(move) && isLeagalMove(move))
                {
                    /*
                    if (isCheck(move, gameStatus))
                    {
                        return false;
                    }
                    */
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Kollar om draget är tillåtet enligt reglerna
        public bool isLeagalMove(Move move)
        {          
            ChessPiece current = chessboard[move.getfromX(), move.getfromY()];
            
            if (current is Horse)
            {
                if (board.squareStatus(move) == 1)//En av spelarens egna pjäser står i vägen
                {
                    return false;
                }
                return true;
            }
            if (current is Farmer)
            {
                if ((move.getfromX() != move.gettoX() && board.squareStatus(move) == 2) || (move.gettoX() == move.getfromX() && board.squareStatus(move) == 3))
                //bonden har tagit en enemy på sidan eller gått rak fram och inte träffat på ngn pjäs
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (move.isHorizontal() == true)
                {
                    return checkHorizontal(move);
                }
                if (move.isVertical() == true)
                {
                    return checkVertical(move);
                }
                if (move.isDiagonal() == true)
                {
                    return checkDiagonal(move);
                }
                return false;
            }
        }

        //Kollar om ett diagonalt drag är godkänt
        public bool checkDiagonal(Move move)
        {
            int y = move.getfromY();
            if (move.getfromX() < move.gettoX() && move.getfromY() < move.gettoY()) //x och y ökar
            {
                for (int x = move.getfromX() + 1; x <= move.gettoX(); x++)
                {
                    y++;
                    if (chessboard[x, y] != null) //om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move) == 2)//Pjäsen har eliminerat en motståndare
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
                return true;
            }

            if (move.getfromX() > move.gettoX() && move.getfromY() > move.gettoY()) //x och y minskar
            {
                for (int x = move.getfromX() - 1; x >= move.gettoX(); x--)
                {
                    y--;
                    if (chessboard[x, y] != null)//om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move) == 2)//Pjäsen har eliminerat en motståndare
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
                return true;
            }

            if (move.getfromX() < move.gettoX() && move.getfromY() > move.gettoY()) //x ökar, y minskar
            {
                for (int x = move.getfromX() + 1; x <= move.gettoX(); x++)
                {
                    y--;
                    if (chessboard[x, y] != null)//om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move) == 2)//Pjäsen har eliminerat en motståndare
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
                return true;
            }

            if (move.getfromX() > move.gettoX() && move.getfromY() < move.gettoY()) //x minskar, y ökar
            {
                
                for (int x = move.getfromX() - 1; x >= move.gettoX(); x--)
                {
                    y++;
                    if (chessboard[x, y] != null)//om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move) == 2)//Pjäsen har eliminerat en motståndare
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //Kollar om ett vertikalt drag är tillåtet
        public bool checkVertical(Move move)
        {//kolla om det går att hoppa över skaer
            if (move.getfromY() < move.gettoY())
            {
                for (int y = move.getfromY() + 1; y <= move.gettoY(); y++)
                {
                    if (chessboard[move.getfromX(), y] != null)
                    {
                        if (y == move.gettoY() && board.squareStatus(move) != 1)
                        {
                            return true;
                        }
                        return false;
                    }

                }
                return true;
            }

            else if (move.getfromY() > move.gettoY())
            {
                for (int y = move.getfromY() - 1; y >= move.gettoY(); y--)
                {
                    if (chessboard[move.getfromX(), y] != null)
                    {
                        if (y == move.gettoY() && (board.squareStatus(move) != 1))
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //Kollar om ett horisontellt drag är tillåtet
        public bool checkHorizontal(Move move)
        {
            if (move.getfromX() < move.gettoX())
            {
                for (int x = move.getfromX() + 1; x <= move.gettoX(); x++)
                {
                    if (chessboard[x, move.getfromY()] != null)
                    {
                        if (x == move.gettoX() && board.squareStatus(move) != 1)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return true;
            }

            if (move.getfromX() > move.gettoX())
            {
                for (int x = move.getfromX() - 1; x >= move.gettoX(); x--)
                {
                    if (chessboard[x, move.getfromY()] != null)
                    {
                        if (x == move.gettoX() && board.squareStatus(move) != 1)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //kollar om kungen står i check
        public bool isCheck(Move move, String gamestatus)
        { 
            //sätt kungen till den nuvarande spelares kung:
            ChessPiece king;
            if(gamestatus == "black")
            {
                king = board.getblackKing();
            }
            else
            {
                king = board.getwhiteKing();
            }

            //Uppdatera temporärt bord, som det kommer se ut om movet skulle gå igenom:
            chessboard[move.gettoX(), move.gettoY()] = chessboard[move.getfromX(), move.getfromY()];
            chessboard[move.getfromX(), move.getfromY()] = null;

            //loopa över nya brädet:
            for (int x = 0; x < chessboard.GetLength(0); x++)
            {
                for (int y = 0; y < chessboard.GetLength(1); y++)
                {
                    //om vi hittar en pjäs:
                    if (chessboard[x, y] != null)
                    {
                        ChessPiece temp = chessboard[x, y];
                        //Om det är motståndarens pjäs
                        if (temp.Color != gamestatus)
                        {
                            Move checkMove = new Move(x, y, king.posX, king.posY);//move tar motståndarens position mot spelarens egen kung
                            if (temp.isValidMove(checkMove) && isLeagalMove(checkMove))//om det går igenom har man satt sin egen kung i shack
                            {
                                return true;
                            }

                        }

                    }
                }

            }
            return false;
        }
        /*
        public bool isCheckMate(King king)
        {

            int posX = king.posX;
            int posY = king.posY;
            for (int x = 0; x < board.get().GetLength(0); x++)
            {
                for (int y = 0; y < board.get().GetLength(1); y++)
                {
                    Move move = new Move(posX, posY, x, y);
                    if (isValid(move, board.colourOfPiece(move)) && !isCheck(king))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        */
    }
}


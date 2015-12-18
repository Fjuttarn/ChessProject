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

        public RulesEngine(ChessBoard board)
        {
            this.board = board;
        }

        //Kollar om det är ett tillåtet drag
        public bool isValid(Move move, String gameStatus, ChessPiece[,] currentBoard)
        {
            if (board.colourOfPiece(move, currentBoard) == gameStatus)
            {
                if (currentBoard[move.getfromX(), move.getfromY()].isValidMove(move) && isLeagalMove(move, currentBoard))
                {
                    if (isCheck(move, gameStatus))
                    {
                        return false;
                    }
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
        public bool isLeagalMove(Move move, ChessPiece[,] currentBoard)
        {          
            ChessPiece current = currentBoard[move.getfromX(), move.getfromY()];
            
            if (current is Horse)
            {
                if (board.squareStatus(move, currentBoard) == 1)//En av spelarens egna pjäser står i vägen
                {
                    return false;
                }
                return true;
            }
            if (current is Farmer)
            {
                if ((move.getfromX() != move.gettoX() && board.squareStatus(move, currentBoard) == 2) ||
                    (move.gettoX() == move.getfromX() && board.squareStatus(move, currentBoard) == 3))
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
                    return checkHorizontal(move, currentBoard);
                }
                if (move.isVertical() == true)
                {
                    return checkVertical(move, currentBoard);
                }
                if (move.isDiagonal() == true)
                {
                    return checkDiagonal(move, currentBoard);
                }
                return false;
            }
        }

        //Kollar om ett diagonalt drag är godkänt
        public bool checkDiagonal(Move move, ChessPiece[,] currentBoard)
        {
            int y = move.getfromY();
            if (move.getfromX() < move.gettoX() && move.getfromY() < move.gettoY()) //x och y ökar
            {
                for (int x = move.getfromX() + 1; x <= move.gettoX(); x++)
                {
                    y++;
                    if (currentBoard[x, y] != null) //om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move, currentBoard) == 2)//Pjäsen har eliminerat en motståndare
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
                    if (currentBoard[x, y] != null)//om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move, currentBoard) == 2)//Pjäsen har eliminerat en motståndare
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
                    if (currentBoard[x, y] != null)//om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move, currentBoard) == 2)//Pjäsen har eliminerat en motståndare
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
                    if (currentBoard[x, y] != null)//om någon pjäs står i vägen
                    {
                        if (x == move.gettoX() && y == move.gettoY()) //pjäsen har nått sitt mål
                        {
                            if (board.squareStatus(move, currentBoard) == 2)//Pjäsen har eliminerat en motståndare
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
        public bool checkVertical(Move move, ChessPiece[,] currentBoard)
        {//kolla om det går att hoppa över skaer
            if (move.getfromY() < move.gettoY())
            {
                for (int y = move.getfromY() + 1; y <= move.gettoY(); y++)
                {
                    if (currentBoard[move.getfromX(), y] != null)
                    {
                        if (y == move.gettoY() && board.squareStatus(move, currentBoard) != 1)
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
                    if (currentBoard[move.getfromX(), y] != null)
                    {
                        if (y == move.gettoY() && (board.squareStatus(move, currentBoard) != 1))
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
        public bool checkHorizontal(Move move, ChessPiece[,] currentBoard)
        {
            if (move.getfromX() < move.gettoX())
            {
                for (int x = move.getfromX() + 1; x <= move.gettoX(); x++)
                {
                    if (currentBoard[x, move.getfromY()] != null)
                    {
                        if (x == move.gettoX() && board.squareStatus(move, currentBoard) != 1)
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
                    if (currentBoard[x, move.getfromY()] != null)
                    {
                        if (x == move.gettoX() && board.squareStatus(move, currentBoard) != 1)
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
        public ChessPiece getKingInCopiedBoard(ChessPiece[,] temp, String gamestatus)
        {
            for (int x = 0; x <= 7; x++)
            {
                for (int y = 0; y <= 7; y++)
                {
                    if (temp[x, y] != null)
                    {
                        ChessPiece piece = temp[x, y];
                        if (piece.Color == gamestatus && piece is King)
                        {
                            piece.posX = x;
                            piece.posY = y;
                            return piece;
                        }
                    }
                }
            }
            return null;
        }
      

        //kollar om kungen står i check
        public bool isCheck(Move move, String gamestatus)
        {
            ChessPiece[,] temp = board.getCopy();//kopierar bordet

            //Uppdatera temporärt bord, som det kommer se ut om movet skulle gå igenom:
            temp[move.gettoX(), move.gettoY()] = temp[move.getfromX(), move.getfromY()];
            temp[move.getfromX(), move.getfromY()] = null;

            //Hämta kungens position
            ChessPiece king = getKingInCopiedBoard(temp, gamestatus);
            
            //loopa över nya brädet:
            for (int x = 0; x <= 7; x++)
            {
                for (int y = 0; y <= 7; y++)
                {
                    //om vi hittar en pjäs:
                    if (temp[x, y] != null)
                    {
                        ChessPiece temp2 = temp[x, y];
                        //Om det är motståndarens pjäs
                        if (temp2.Color != gamestatus)
                        {
                            Move checkMove = new Move(x, y, king.posX, king.posY);//move tar motståndarens position mot spelarens egen kung
                            if (temp2.isValidMove(checkMove) && isLeagalMove(checkMove, temp))//om det går igenom har man satt sin egen kung i shack
                            {
                                return true;
                            }

                        }

                    }
                }

            }
            return false;
        }
        
        public bool isCheckMate(string gamestatus)
        {

           for (int fromx = 0; fromx <= 7; fromx++)
            {
                for (int fromy = 0; fromy <= 7; fromy++)
                {
                    if(board.get()[fromx, fromy] != null)
                    {
                        ChessPiece temp = board.get()[fromx, fromy];
                        if (temp.Color == gamestatus) 
                        {
                            for (int tox = 0; tox <= 7; tox++)
                            {
                                for(int toy = 0; toy <= 7; toy++)
                                {
                                    Move tempmove = new Move(fromx, fromy, tox, toy);
                                    if (isLeagalMove(tempmove, board.get()) && !isCheck(tempmove, gamestatus) && temp.isValidMove(tempmove))
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        
    }
}


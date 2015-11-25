using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class RulesEngine
    {
        private ChessBoard board;

        public RulesEngine(ChessBoard board)
        {
            this.board = board;
        }

        //Kollar om det är ett tillåtet drag
        public bool isValid(Move move, String gameStatus)
        {
            if (board.colourOfPiece(move) == gameStatus)
            {
                if (board.get()[move.getfromX(), move.getfromY()].isValidMove(move) && isLeagalMove(move))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool isLeagalMove(Move move)
        {//1 egen pjäs, 2 enemy pjäs, 3 tom ruta
            ChessPiece current = board.get()[move.getfromX(), move.getfromY()];
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

        public bool checkDiagonal(Move move)
        {
            int y = move.getfromY();
            if (move.getfromX() < move.gettoX() && move.getfromY() < move.gettoY()) //x och y ökar
            {

                for (int x = move.getfromX() + 1; x <= move.gettoX(); x++)
                {
                    y++;
                    if (board.get()[x, y] != null) //om någon pjäs står i vägen
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
                for (int x = move.getfromX() - 1; x <= move.gettoX(); x--)
                {
                    y--;
                    if (board.get()[x, y] != null)//om någon pjäs står i vägen
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
                    if (board.get()[x, y] != null)//om någon pjäs står i vägen
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
                for (int x = move.getfromX() - 1; x <= move.gettoX(); x--)
                {
                    y++;
                    if (board.get()[x, y] != null)//om någon pjäs står i vägen
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

        public bool checkVertical(Move move)
        {
            if (move.getfromY() < move.gettoY())
            {
                for (int y = move.getfromY() + 1; y <= move.gettoY(); y++)
                {
                    if (board.get()[move.getfromX(), y] != null)
                    {
                        if (y == move.gettoY() && board.squareStatus(move) == 1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            else if (move.getfromY() > move.gettoY())
            {
                for (int y = move.getfromY() - 1; y <= move.gettoY(); y--)
                {
                    if (board.get()[move.getfromX(), y] != null)
                    {
                        if (y == move.gettoY() && board.squareStatus(move) == 2)
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

        public bool checkHorizontal(Move move)
        {
            if (move.getfromX() < move.gettoX())
            {
                for (int x = move.getfromX() + 1; x <= move.gettoX(); x++)
                {
                    if (board.get()[x, move.getfromX()] != null)
                    {
                        if (x == move.gettoX() && board.squareStatus(move) == 2)
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
                for (int x = move.getfromX() - 1; x <= move.gettoX(); x--)
                {
                    if (board.get()[x, move.getfromY()] != null)
                    {
                        if (x == move.gettoX() && board.squareStatus(move) == 1)
                        {
                            return false;
                        }
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //kollar om kungen står i check
        public bool isCheck(int kingX, int kingY, Player p)
        {
            for (int x = 0; x < board.get().GetLength(0); x++)
            {
                for (int y = 0; y < board.get().GetLength(1); y++)
                {
                    if (board.get()[x, y] != null)
                    {
                        ChessPiece temp = board.get()[x, y];
                        if (temp.getPlayer != p)
                        {
                            Move move = new Move(x, y, kingX, kingY);//move som går till motståndarens kung position
                            if (isValid(move, board.colourOfPiece(move)))
                            {
                                return true;
                            }

                        }

                    }
                }

            }
            return false;
        }

        public bool isCheckMate(King king)
        {
            int posX = king.posX;
            int posY = king.posY;
            for (int x = 0; x < board.get().GetLength(0); x++)
            {
                for (int y = 0; y < board.get().GetLength(1); y++)
                {
                    Move move = new Move(posX, posY, x, y);
                    if (isValid(move, board.colourOfPiece(move)) && !isCheck(x, y, king.getPlayer))
                    {
                        return false;
                    }
                }
            }
            System.Console.WriteLine("DET BLEV SCHACK MATT!!");
            return true;
        }
    }
}


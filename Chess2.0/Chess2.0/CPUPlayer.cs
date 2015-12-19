using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    public class CPUPlayer : Player
    {
        GameView gw;
        RulesEngine rules;
        ChessBoard chessboard;
        private ChessPiece[,] board;
        ArrayList myPieces = new ArrayList();
        ArrayList enemyPieces = new ArrayList();

        public CPUPlayer(String color) : base(color) { }

        //Instantierar objekt som AI-spelaren behöver för att fungera
        public override void setupAI(ChessBoard chessboard, GameView gw)
        {
            this.chessboard = chessboard;
            this.rules = new RulesEngine(chessboard);
            this.board = chessboard.get();
            this.gw = gw;

        }

        //Uppdaterar AI-spelarens listor över pjäser
        public void updateLists()
        {
            myPieces.Clear();
            enemyPieces.Clear();
            for (int fromx = 0; fromx < board.GetLength(0); fromx++)
            {
                for (int fromy = 0; fromy < board.GetLength(1); fromy++)
                {
                    if (board[fromx, fromy] != null)
                    {
                        ChessPiece current = board[fromx, fromy];
                        if (board[fromx, fromy].Color != this.Color)//det är vår spelare
                        {

                            enemyPieces.Add(current);
                        }
                        else
                        {
                            myPieces.Add(current);
                        }
                    }
                }
            }
        }

        //AI-spelaren gör ett drag
        public async override void AImove()
        {
            await Task.Delay(500);

            this.board = chessboard.get();
            updateLists();
            Move bestMove = findBestMove();
            if (bestMove != null)
            {
                gw.makeMove(bestMove.getfromX(), bestMove.getfromY(), bestMove.gettoX(), bestMove.gettoY());
            }
         
        }

        //Hittar ett bra move
        public Move findBestMove()
        {
            bool king = false;
            bool queen = false;
            bool horseRunnerTower = false;
            bool farmer = false;
            Move kingmove = null;
            Move queenmove = null;
            Move horseRunnerTowermove = null;
            Move farmermove = null;

            //hämtar våra from kordinater
            foreach (ChessPiece myPiece in myPieces)
            {
                //Hämtar to kordinater
                foreach (ChessPiece enemyPiece in enemyPieces)
                {
                    if (canTakeKing(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        king = true;//det går att ta kungen!
                        kingmove = new Move(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                    }
                    else if (canTakeQueen(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        queen = true;//det går att ta queen!
                        queenmove = new Move(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                    }
                    else if (canTakeHorseRunnerTower(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        horseRunnerTower = true;//det går att ta horse, runner eller tower
                        horseRunnerTowermove = new Move(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                    }
                    else if (canTakeFarmer(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        farmer = true;//det går att ta en farmer
                        farmermove = new Move(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                    }
                }
            }
            if (king) return kingmove;
            else if (queen) return queenmove;
            else if (horseRunnerTower) return horseRunnerTowermove;
            else if (farmer) return farmermove;
            else return randomizeMove();

        }

        //kollar om det går att ta kungen
        public bool canTakeKing(int fromX, int fromY, int toX, int toY)
        {
            if (board[toX, toY] is King)//det är en kung
            {
                Move move = new Move(fromX, fromY, toX, toY);
                if (rules.isValid(move, this.Color, board))
                {
                    return true;
                }
            }
            return false;
        }

        //kollar om det går att ta queen
        public bool canTakeQueen(int fromX, int fromY, int toX, int toY)
        {
            if (board[toX, toY] is Queen)//det är en queen
            {
                Move move = new Move(fromX, fromY, toX, toY);
                if (rules.isValid(move, this.Color, board))
                {
                    return true;
                }
            }
            return false;
        }

        //kollar om det går att ta horse, runner eller tower
        public bool canTakeHorseRunnerTower(int fromX, int fromY, int toX, int toY)
        {
            if (board[toX, toY] is Tower || board[toX, toY] is Runner || board[toX, toY] is Horse)//det är en horse, runner eller tower
            {
                Move move = new Move(fromX, fromY, toX, toY);
                if (rules.isValid(move, this.Color, board))
                {
                    return true;
                }
            }

            return false;
        }

        //Kollar om det går att ta en farmer
        public bool canTakeFarmer(int fromX, int fromY, int toX, int toY)
        {
            if (board[toX, toY] is Farmer)
            {
                Move move = new Move(fromX, fromY, toX, toY);
                if (rules.isValid(move, this.Color, board))
                {
                    return true;
                }
            }
            return false;
        }

        //Slumpar bland alla möjliga moves
        public Move randomizeMove()
        {
            ArrayList validMoves = new ArrayList();
            for (int fromx = 0; fromx < board.GetLength(0); fromx++)
            {
                for (int fromy = 0; fromy < board.GetLength(1); fromy++)
                {
                    if (board[fromx, fromy] != null)
                    {
                        ChessPiece myPiece = board[fromx, fromy];
                        if (board[fromx, fromy].Color == this.Color)//det är vår spelare
                        {
                            //hämtar våra to kordinater
                            for (int tox = 0; tox < board.GetLength(0); tox++)
                            {
                                for (int toy = 0; toy < board.GetLength(1); toy++)
                                {
                                    Move move = new Move(fromx, fromy, tox, toy);
                                    if(rules.isValid(move, myPiece.Color, board))
                                    {
                                        validMoves.Add(move);//Lägg till i listan över alla moves
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Random rnd = new Random();
            if (validMoves.Count > 0)
            {
                int rng = rnd.Next(0, validMoves.Count - 1);
                return validMoves[rng] as Move; //return ett slumpat move
            }
            else
            {
                return null;
            }
        }

    }
}

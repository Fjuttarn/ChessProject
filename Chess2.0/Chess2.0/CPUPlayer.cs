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
        public override void AImove()
        {
            this.board = chessboard.get();
            updateLists();
            int index = findBestMove();

            if (index == 5)
            {
                randomizeMove();
            }
            else
            {
                foreach (ChessPiece myPiece in myPieces)
                {
                    foreach (ChessPiece enemyPiece in enemyPieces)
                    {
                        switch (index)
                        {
                            case 1:
                                if (canTakeKing(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                                {
                                    gw.makeMove(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                                }
                                break;

                            case 2:
                                if (canTakeQueen(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                                {
                                    gw.makeMove(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                                }
                                break;

                            case 3:
                                if (canTakeHorseRunnerTower(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                                {
                                    gw.makeMove(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                                }
                                break;

                            case 4:
                                if (canTakeFarmer(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                                {
                                    gw.makeMove(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY);
                                }
                                break;
                        }
                    }
                }
            }
        }

        //hittar det bästa movet
        //1 om den kan ta kung
        //2 om det kan ta queen
        //3 om det kan ta runner, tower eller hórse
        //4 om den kan ta en bonde
        //5 om den inte kan ta ngt
        public int findBestMove()
        {
            bool king = false;
            bool queen = false;
            bool horseRunnerTower = false;
            bool farmer = false;

            //hämtar våra from kordinater
            foreach (ChessPiece myPiece in myPieces)
            {
                foreach (ChessPiece enemyPiece in enemyPieces)
                {
                    if (canTakeKing(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        king = true;//det går att ta kungen!
                    }
                    else if (canTakeQueen(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        queen = true;//det går att ta queen!
                    }
                    else if (canTakeHorseRunnerTower(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        horseRunnerTower = true;//det går att ta horse, runner eller tower
                    }
                    else if (canTakeFarmer(myPiece.posX, myPiece.posY, enemyPiece.posX, enemyPiece.posY))
                    {
                        farmer = true;//det går att ta en farmer
                    }
                }
            }
            if (king) return 1;
            else if (queen) return 2;
            else if (horseRunnerTower) return 3;
            else if (farmer) return 4;
            else return 5;

        }

        //kollar om det går att ta kungen
        public bool canTakeKing(int fromX, int fromY, int toX, int toY)
        {
            if (board[toX, toY] is King)//det är en kung
            {
                Move move = new Move(fromX, fromY, toX, toY);
                if (rules.isValid(move, this.Color))
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
                if (rules.isValid(move, this.Color))
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
                if (rules.isValid(move, this.Color))
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
                if (rules.isValid(move, this.Color))
                {
                    return true;
                }
            }
            return false;
        }

        public void randomizeMove()
        {
            ArrayList validMoves = new ArrayList();

            foreach (ChessPiece myPiece in myPieces)
            {
                //hämtar våra to kordinater
                for (int tox = 0; tox < board.GetLength(0); tox++)
                {
                    for (int toy = 0; toy < board.GetLength(1); toy++)
                    {
                        Move move = new Move(myPiece.posX, myPiece.posY, tox, toy);
                        if (rules.isValid(move, this.Color))
                        {
                            validMoves.Add(move);
                        }
                    }
                }
            }

            Random rnd = new Random();
            int rng = rnd.Next(0, validMoves.Count); //slumpar fram ett move
            Move rngMove = validMoves[rng] as Move;
            gw.makeMove(rngMove.getfromX(), rngMove.getfromY(), rngMove.gettoX(), rngMove.gettoY());

        }


    }
}
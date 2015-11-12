using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Farmer : ChessPiece
    {
        public Farmer(Player p, int posX, int posY) : base(p, posX, posY)
        {
        }

  

        public override Boolean isValidMove(Move move)
        {
            //Check if the move is valid for white pieces
            if (player is HumanPlayer)
            {
                System.Console.WriteLine("position x:" + positionX);
                System.Console.WriteLine("position y: " + positionY);
                if (move.gettoY() - move.getfromY() == 2 && move.gettoX() == move.getfromX() 
                    && move.getfromY() == 1)
                {
                    System.Console.WriteLine("1Draget är tillåtet!");
                    return true;
                }

                if (move.gettoY() - move.getfromY() == 1 && (move.gettoX() - move.getfromX() == 1 ||
                    move.gettoX() - move.getfromX() == -1 || move.gettoX() == move.getfromX()))
                {
                    System.Console.WriteLine("2Draget är tillåtet!");
                    return true;
                }
            }

            //Check if the move is valid for black pieces
            if (player is CPUPlayer)
            {
                if (move.gettoY() - move.getfromY() == -2 && move.gettoX() == move.getfromX() 
                    && move.getfromY() == 6)
                {
                    System.Console.WriteLine("Draget är tillåtet!");
                    return true;
                }

                if (move.gettoY() - move.getfromY() == -1 && move.gettoX() - move.getfromX() == 1 ||
                    move.gettoX() - move.getfromX() == -1 || move.gettoX() == move.getfromX())
                {
                    System.Console.WriteLine("Draget är tillåtet!");
                    return true;
                }
            }

            System.Console.WriteLine("Draget är inte tillåtet!");
            return false;
        }
    }
}

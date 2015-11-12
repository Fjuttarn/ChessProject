using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Farmer : ChessPiece
    {
        int positionX;
        int positionY;
        Player player;

        public Farmer(Player p, int posX, int posY) : base(p, posX, posY)
        {
            player = p;
            positionX = posX;
            positionY = posY;
        }

        public override Boolean isValidMove(Move move)
        {
            //Check if the move is valid for white pieces
            if (player is HumanPlayer)
            {
                if (move.gettoY() - positionY == 2 && move.gettoX() == positionX && positionY == 1)
                {
                    System.Console.WriteLine("Draget är tillåtet!");
                    return true;
                }

                if (move.gettoY() - positionY == 1 && move.gettoX() - positionX == 1 ||
                    move.gettoX() - positionX == -1 || move.gettoX() == positionX)
                {
                    System.Console.WriteLine("Draget är tillåtet!");
                    return true;
                }
            }

            //Check if the move is valid for black pieces
            if (player is CPUPlayer)
            {
                if (move.gettoY() - positionY == -2 && move.gettoX() == positionX && positionY == 6)
                {
                    System.Console.WriteLine("Draget är tillåtet!");
                    return true;
                }

                if (move.gettoY() - positionY == -1 && move.gettoX() - positionX == 1 ||
                    move.gettoX() - positionX == -1 || move.gettoX() == positionX)
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

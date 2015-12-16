using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Farmer : ChessPiece
    {
        public Farmer(Player p, int posX, int posY) : base(p, posX, posY) { }

        public override Boolean isValidMove(Move move)
        {
            //Check if the move is valid for white pieces
            if (player is HumanPlayer)
            {
                if (move.gettoY() - move.getfromY() == 2 && move.gettoX() == move.getfromX() && move.getfromY() == 1)
                    
                if (move.gettoY() - move.getfromY() == 2 && move.gettoX() == move.getfromX() 
                    && move.getfromY() == 1)
                {
                    System.Console.WriteLine(" bondeHUMAN Draget är tillåtet!");
                    return true;
                }

                if (move.gettoY() - move.getfromY() == 1 && (move.gettoX() - move.getfromX() == 1 ||
                    (move.gettoX() - move.getfromX() == 1 && move.gettoY() - move.getfromY() == 1) ||
                    (move.gettoX() == move.getfromX() && move.gettoY() - move.getfromY() == 1)))
                {
                    System.Console.WriteLine(" bondeHUMAN Draget är tillåtet!");
                    return true;
                }
            }

            //Check if the move is valid for black pieces
            if (player is CPUPlayer)
            {
                if (move.gettoY() - move.getfromY() == -2 && move.gettoX() == move.getfromX() 
                    && move.getfromY() == 6)
                {
                    System.Console.WriteLine("1bondeCPU Draget är tillåtet!");
                    return true;
                }

                if ((move.gettoY() - move.getfromY() == -1 && move.gettoX() - move.getfromX() == 1) ||
                    (move.gettoX() - move.getfromX() == -1 && (move.gettoY() - move.getfromY() == -1) ||
                    (move.gettoX() == move.getfromX() && move.gettoY() - move.getfromY() == -1)))
                {
                    System.Console.WriteLine("2bondeCPU Draget är tillåtet!");
                    return true;
                }
            }

            System.Console.WriteLine("3bondeCPU Draget är inte tillåtet!");
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    class Runner : ChessPiece
    {
        public Runner(Player p, int posX, int posY) : base(p, posX, posY) {}
        
        public override Boolean isValidMove(Move move)
        {
            if(move.gettoX() - move.getfromX() == move.gettoY() - move.getfromY())
            {

                System.Console.WriteLine("Springare draget är tillåtet");
                return true;
            }
            else if(move.gettoX() + move.getfromX() == move.gettoY() + move.getfromY())
            {

                System.Console.WriteLine("Springare draget är tillåtet");
                return true;
            }

            System.Console.WriteLine("springare draget är inte tillåtet");
            return false;
        }
    }
}

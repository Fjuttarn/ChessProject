﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    public class Queen : ChessPiece
    {
        public Queen(Player p, int posX, int posY) : base(p, posX, posY) {}

        public override Boolean isValidMove(Move move)
        {
            if (Math.Abs(move.gettoX() - move.getfromX()) == Math.Abs(move.gettoY() - move.getfromY()))
            {
                
                return true;
            }
            else if (move.gettoX() - move.getfromX() == move.getfromY() - move.gettoY())
            {
                return true;
            }
            else if (move.gettoY() == move.getfromY() || move.gettoX() == move.getfromX())
            {
                return true;
            }

            return false;
        }
    }
}

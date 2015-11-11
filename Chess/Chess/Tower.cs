﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Tower : ChessPiece
    {
        int positionX;
        int positionY;
        Player player;

        public Tower(Player p, int posX, int posY) : base(p, posX, posY)
        {
            player = p;
            positionX = posX;
            positionY = posY;
        }
        public override Boolean isValidMove(Move move)
        {
            return true;
        }
    }
}

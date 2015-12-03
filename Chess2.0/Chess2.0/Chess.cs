using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    class Chess
    {
        GameView gw;
        public Chess (MainWindow mw)
        {
            this.gw = new GameView(mw);
            mw.onMoveCompleted += gw.onMoveCompleted;
        }
        
    }
}

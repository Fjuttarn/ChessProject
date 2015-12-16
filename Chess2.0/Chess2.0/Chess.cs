using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
   public class Chess
    {
        GameView gw;
        public Chess (MainWindow mw)
        {
            //Öppnar startmenyn
            StartMenu start = new StartMenu();
            start.ShowDialog();
            bool isNewGame = start.isNewGame;

            //Öppnar gamemode-menyn
            GameModeChooser gmc = new GameModeChooser();
            gmc.ShowDialog();
            string gamemode = gmc.GameMode;

            this.gw = new GameView(mw);
            gw.GameSetup(gamemode, isNewGame);
            //Sätter GameView till subscriber av knapptryck i ui
            mw.onMoveCompleted += gw.onMoveCompleted;
        }
        
    }
}

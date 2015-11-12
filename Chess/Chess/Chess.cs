using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Chess
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("hej marcus, välkommen till chess!");
            System.Console.WriteLine("tack nils, kul att vara här!");
            System.Console.WriteLine("Allid kul att ha dig här Marcus!");
            System.Console.WriteLine("Testar igen!");
            
            GameView gw = new GameView();
            gw.makeMove(1, 1, 1, 3); //får hända
            gw.makeMove(1, 3, 1, 5); //får inte hända
            gw.makeMove(1, 3, 1, 4); //får hända
            gw.makeMove(0, 0, 3, 1); //får inte hända



            Console.ReadKey();
        }
    }
}

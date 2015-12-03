using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int fromx;
        int fromy;
        int tox;
        int toy;
        bool firstClick = true;
        GameView gw = new GameView();

        public MainWindow()
        {
            Chess.Chess chess = new Chess.Chess(this);
            InitializeComponent();
          
        }





        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border c = (Border)sender;
            int row = Grid.GetRow(c);
            int col = Grid.GetColumn(c);
            if (firstClick)
            {
                fromx = row;
                fromy = col;
                firstClick = false;
            }
            else if (!firstClick)
            {
                tox = row;
                toy = col;
                gw.makeMove(fromx, fromy, tox, toy);
                firstClick = true;
            }
        }
    }
}

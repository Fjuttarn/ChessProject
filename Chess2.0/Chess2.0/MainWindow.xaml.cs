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

namespace Chess2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] move = new int[4];
        bool firstClick = true;
        

        public MainWindow()
        {
            Chess chess = new Chess(this);
            InitializeComponent();

        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border c = (Border)sender;
            int row = Grid.GetRow(c);
            int col = Grid.GetColumn(c);
            if (firstClick)
            {
                move[0] = row;
                move[1] = col;
                firstClick = false;
            }
            else if (!firstClick)
            {
                move[2] = row;
                move[3] = col;
                firstClick = true;

                //notify subscribers
                Action<int[]> change = onMoveCompleted;
                if(change != null)
                {
                    change(move);
                }
                
            }
        }

        public Action<int[]> onMoveCompleted { get; set; }

    }
}


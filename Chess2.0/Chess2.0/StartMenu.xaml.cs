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
using System.Windows.Shapes;

namespace Chess2._0
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Window
    {
        bool newgame;

        public bool isNewGame {
            get
            {
                return newgame;
            }
            set
            {
                newgame = value;
            }
        }

        public StartMenu()
        {
            InitializeComponent();
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            isNewGame = true;
            Close();
        }

        private void continueGame_Click(object sender, RoutedEventArgs e)
        {
            isNewGame = false;
            Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}

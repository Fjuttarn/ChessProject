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
    /// Interaction logic for GameModeChooser.xaml
    /// </summary>
    public partial class GameModeChooser : Window
    {
        string gamemode;

        public string GameMode
        {
            get
            {
                return gamemode;
            }
            set
            {
                gamemode = value;
            }
        }

        public GameModeChooser()
        {
            InitializeComponent();
        }

        private void singleplayer_Click(object sender, RoutedEventArgs e)
        {
            GameMode = "singleplayer";
            Close();
        }

        private void multiplayer_Click(object sender, RoutedEventArgs e)
        {
            GameMode = "multiplayer";
            Close();
        }
    }
}

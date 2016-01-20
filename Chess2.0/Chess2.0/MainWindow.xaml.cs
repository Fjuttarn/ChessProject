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
        ChessPiece[,] board;
        int[] move = new int[4];
        bool firstClick = true;
        Image[] piecesToUpdate = new Image[2];
        List<Player> humanPlayers = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
            Chess chess = new Chess(this);
        }

        public void setPlayers(List<Player> players)
        {
            humanPlayers = players;
        }
           

        public void setBoard(ChessPiece[,] board)
        {
            this.board = board;
        }

        public Action<int[], Player> onMoveCompleted { get; set; }

        //Kallas på om en kung är utslagen
        public void gameOver(string gamestatus)
        {
            MessageBox.Show(gamestatus);
            Chess chess = new Chess(this);
            updateTable();
        }

        //Kallas på när en spelare klickar på en ruta i schackbrädet
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border clickedSquare;
            Image c = e.Source as Image;
            try
            {
                int row = Grid.GetRow(c);
                int col = Grid.GetColumn(c);
            
            if (firstClick)
            {
                piecesToUpdate[0] = c;
                move[1] = row;
                move[0] = col;
                clickedSquare = getBorder(move[0], move[1]);
                firstClick = false;
                clickedSquare.BorderThickness = new Thickness(5);
                clickedSquare.BorderBrush = new SolidColorBrush(Colors.Yellow);
            }
            else if (!firstClick)
            {
                piecesToUpdate[1] = c;
                move[3] = row;
                move[2] = col;
                firstClick = true;
                clickedSquare = getBorder(move[0], move[1]);
                clickedSquare.ClearValue(Border.BorderThicknessProperty);
                clickedSquare.ClearValue(Border.BorderBrushProperty);
                
                //Meddelar subscribers om att ett drag har gjorts
                Action<int[], Player> change = onMoveCompleted;
                if (change != null)
                {
                        foreach (Player p in humanPlayers)
                        {
                            if (p.isPlayersTurn)
                            {
                                change(move, p);
                            }
                        }
               
                }
             }

            }

            catch (ArgumentNullException){}
        }

        //Returnerar ramen för rutan på den specificerade positionen
        public Border getBorder(int x, int y)
        {
            Border border = (Border)TheGrid.Children.Cast<UIElement>().
            FirstOrDefault(e => Grid.GetColumn(e) == x && Grid.GetRow(e) == y);
            return border;
        }

        //Uppdaterar pjäsernas positioner
        public void updateTable()
        {
            try
            {
                TheGrid.Children.Clear();
            }
            catch (Exception e) { }
            
            paintTable();
            for (int x = 0; x < this.board.GetLength(0); x++)
            {
                for (int y = 0; y < this.board.GetLength(1); y++)
                {
                    Image img = new Image();
                    Uri uri = new Uri(@".\images\Empty.png", UriKind.Relative);

                    if (board[x, y] != null)
                    {
                        ChessPiece current = board[x, y];
                        string color = current.Color;

                        if (current is Farmer)
                        {
                            uri = new Uri(@".\images\" + color + "_farmer.png", UriKind.Relative);
                        }
                        if (current is Horse)
                        {
                            uri = new Uri(@".\images\" + color + "_horse.png", UriKind.Relative);
                        }
                        if (current is Runner)
                        {
                            uri = new Uri(@".\images\" + color + "_runner.png", UriKind.Relative);
                        }
                        if (current is Tower)
                        {
                            uri = new Uri(@".\images\" + color + "_tower.png", UriKind.Relative);
                        }
                        if (current is King)
                        {
                            uri = new Uri(@".\images\" + color + "_king.png", UriKind.Relative);
                        }
                        if (current is Queen)
                        {
                            uri = new Uri(@".\images\" + color + "_queen.png", UriKind.Relative);
                        }

                    }

                    img.Source = new BitmapImage(uri);
                    Grid.SetColumn(img, x);
                    Grid.SetRow(img, y);
                    TheGrid.Children.Add(img);
                }
            }

            Image img2 = new Image();
            Uri uri2 = new Uri(@".\images\Empty.png", UriKind.Relative);
            img2.Source = new BitmapImage(uri2);
            Grid.SetColumn(img2, 0);
            Grid.SetRow(img2, 0);
            TheGrid.Children.Add(img2);
        }

        //Målar schackbrädet (rutorna)
        public void paintTable()
        {
            SolidColorBrush defaultBrush = new SolidColorBrush(Colors.Brown);
            SolidColorBrush alternateBrush = new SolidColorBrush(Colors.Beige);
    
            for (int x = 0; x < this.board.GetLength(0); x++)
            {       
                for (int y = 0; y < this.board.GetLength(1); y++)
                {
                    Border cell = new Border();
                    cell.Background = alternateBrush;

                    if(y % 2 == x % 2)
                    {
                        cell.Background = defaultBrush;
                    }
                    Grid.SetColumn(cell, x);
                    Grid.SetRow(cell, y);
                    TheGrid.Children.Add(cell);
                }
            }
        }
    }
}
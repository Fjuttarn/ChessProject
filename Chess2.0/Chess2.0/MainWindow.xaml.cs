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

        private ChessPiece[,] board;
        int[] move = new int[4];
        bool firstClick = true;
        Image[] piecesToUpdate = new Image[2];

        public MainWindow()
        {
            Chess chess = new Chess(this);
            InitializeComponent();
            updateTable();
        }
        public void setBoard(ChessPiece[,] board)
        {
            this.board = board;
        }

        public Action<int[]> onMoveCompleted { get; set; }

        public void gameOver(string gamestatus)
        {
            MessageBox.Show(gamestatus);
            System.Environment.Exit(1);
        }

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
                // MessageBox.Show("X: " + move[0] + "Y: " + move[1]);
            }
            else if (!firstClick)
            {
                piecesToUpdate[1] = c;
                move[3] = row;
                move[2] = col;
                //MessageBox.Show("X: " + move[2] + "Y: " + move[3]);
                firstClick = true;
                clickedSquare = getBorder(move[0], move[1]);
                clickedSquare.ClearValue(Border.BorderThicknessProperty);
                clickedSquare.ClearValue(Border.BorderBrushProperty);
                //notify subscribers
                Action<int[]> change = onMoveCompleted;
                if (change != null)
                {
                    change(move);
                }
            }

            }
            catch (ArgumentNullException)
            {

            }
        }

        public Border getBorder(int x, int y)
        {
            Border border = (Border)TheGrid.Children.Cast<UIElement>().
            FirstOrDefault(e => Grid.GetColumn(e) == x && Grid.GetRow(e) == y);
            return border;
        }

        public void updateBoard(Move move)
        {
            /*Image someImage = piecesToUpdate[0];
            someImage.SetValue(Grid.ColumnProperty, move[3]);
            someImage.SetValue(Grid.RowProperty, move[2]);
            TheGrid.Children.Add(someImage);*/

            piecesToUpdate[1].Source = piecesToUpdate[0].Source;
            piecesToUpdate[0].Source = (ImageSource)FindResource("Empty");
            //piecesToUpdate[0].

        }
        public void updateTable()
        {
            TheGrid.Children.Clear();
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
        public void paintTable()
        {
            SolidColorBrush defaultBrush = new SolidColorBrush(Colors.Brown);
            SolidColorBrush alternateBrush = new SolidColorBrush(Colors.Beige);
            
            for (int x = 0; x < this.board.GetLength(0); x++)
            {
         
                for (int y = 0; y < this.board.GetLength(1); y++)
                {
                    Border cell = new Border();
                    cell.Background = defaultBrush;

                    if(y % 2 == x % 2)
                    {
                        cell.Background = alternateBrush;
                    }
                    Grid.SetColumn(cell, x);
                    Grid.SetRow(cell, y);
                    TheGrid.Children.Add(cell);
                }
            }
           

        }

    }
}
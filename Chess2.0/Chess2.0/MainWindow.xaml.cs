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
        Image[] piecesToUpdate = new Image[2];

        //private TranslateTransform transform = new TranslateTransform();
        //Point anchorPoint;
        //Point currentPoint;
        //bool isInDrag = false;

        private Point startDragPoint;
        Image dragImage;
        


        public MainWindow()
        {
            Chess chess = new Chess(this);
            InitializeComponent();
            
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Border dragBorder =
            dragImage = e.Source as Image;
            startDragPoint = e.GetPosition(null);
        }

        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point position = e.GetPosition(null);

                if (Math.Abs(position.X - startDragPoint.X) >
                       SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(position.Y - startDragPoint.Y) >
                       SystemParameters.MinimumVerticalDragDistance)

                {
                    DataObject data = new DataObject(typeof(ImageSource), dragImage.Source);
                    DragDrop.DoDragDrop(dragImage, data, DragDropEffects.Move);
                }
            }
        }

        private void Grid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataObject)))
            {
                e.Effects = DragDropEffects.Move;
                Border c = (Border)sender;
                //Använd c för att ändra färg på border
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            //Border dropBorder = (Border)sender;
            Image dropImage = e.Source as Image;
            var element = (UIElement)e.Source;
            int toX = Grid.GetColumn(element);
            int toY = Grid.GetRow(element);
            
            dropImage.Source = dragImage.Source;
            dragImage.Source = (ImageSource)FindResource("Empty");

            MessageBox.Show("X: " + toX + "Y: " + toY);

            // dropImage.Source = e.Data.GetData(typeof(ImageSource)) as ImageSource;

        }

        public Action<int[]> onMoveCompleted { get; set; }

        public void gameOver(string gamestatus)
        {
            MessageBox.Show(gamestatus);
            System.Environment.Exit(1);
        }



















        /*  private void root_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
          {
              if (isInDrag)
              {
                  var element = sender as FrameworkElement;
                  element.ReleaseMouseCapture();
                  isInDrag = false;
                  e.Handled = true;
              }
          }

          private void root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
          {
              var element = sender as FrameworkElement;
              anchorPoint = e.GetPosition(null);
              element.CaptureMouse();
              isInDrag = true;
              e.Handled = true;
          }
          private void root_MouseMove(object sender, MouseEventArgs e)
          {
              if (isInDrag)
              {
                  var element = sender as FrameworkElement;
                  currentPoint = e.GetPosition(null);

                  transform.X += currentPoint.X - anchorPoint.X;
                  transform.Y += (currentPoint.Y - anchorPoint.Y);
                  this.RenderTransform = transform;
                  anchorPoint = currentPoint;
              }
          }*/

                private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
                {
                Border clickedSquare;
                Image c = e.Source as Image;
        
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

        public Border getBorder(int x, int y)
        {
            Border border = (Border)TheGrid.Children.Cast<UIElement>().
            FirstOrDefault(e => Grid.GetColumn(e) == x && Grid.GetRow(e) == y);
            return border;
        }

        public void updateBoard()
        {
            /*Image someImage = piecesToUpdate[0];
            someImage.SetValue(Grid.ColumnProperty, move[3]);
            someImage.SetValue(Grid.RowProperty, move[2]);
            TheGrid.Children.Add(someImage);*/
            piecesToUpdate[1].Source = piecesToUpdate[0].Source;
            piecesToUpdate[0].Source = (ImageSource)FindResource("Empty");
            //piecesToUpdate[0].
            
        }


        /*
        public void onPieceDrop(object sender, DragEventHandler e)
        {

        }*/
    }

}


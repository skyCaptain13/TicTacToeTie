using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        // Grid size
        int GRID_SIZE = 10;
        // Collection that will contain the players occupied cells
        List<string> playCells = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            // Call frmConnect
            frmConnect fConnect = new frmConnect();
            fConnect.ShowDialog();
            // call method to draw the grid
            drawBoard();
            // The player should connect to the server at this step.
            // The server will assign a colour/ shape
        }     
        public void drawBoard()
        {
            Brush brs;
            for (int i = 1; i < GRID_SIZE; i++)
            {
                for (int j = 1; j < GRID_SIZE; j++)
                {
                    // create the rectangle
                    Rectangle cell = new Rectangle();
                    // set the colours ! just like in a chessboard
                    if ((i + j) % 2 == 0)
                        brs = Brushes.LightGray;
                    else
                        brs = Brushes.LightSeaGreen;
                    cell.Fill = brs;
                    Grid.SetRow(cell, i);
                    Grid.SetColumn(cell, j);
                    // Click event
                    cell.Name = "c" + i + j;
                    cell.MouseDown += new MouseButtonEventHandler(cell_MouseDown);
                    gameGrid.Children.Add(cell);
                }
            }
        }
        public void showCellOccupied(Rectangle rct)
        {
            rct.Fill = Player.PlayerColour;
        }
        public void releaseCell(Rectangle rct)
        {
            int i = Grid.GetRow(rct);
            int j = Grid.GetColumn(rct);

            if ((i + j) % 2 == 0)
                rct.Fill = Brushes.LightGray;
            else
                rct.Fill = Brushes.LightSeaGreen;
        }
        void cell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle tmpCell = new Rectangle();
            tmpCell = (Rectangle)sender;
            if (playCells.Contains(tmpCell.Name))
            {
                playCells.Remove(tmpCell.Name);
                releaseCell(tmpCell);
            }
            else
            {
                playCells.Add(tmpCell.Name);
                showCellOccupied(tmpCell);
            }
        }
    }
}

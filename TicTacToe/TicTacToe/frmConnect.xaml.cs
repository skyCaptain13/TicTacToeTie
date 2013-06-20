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
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for frmConnect.xaml
    /// </summary>
    public partial class frmConnect : Window
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Player.PlayerColour = Brushes.IndianRed;
                Player.PlayerName = "Mehdi";
                

                ServiceReference.GamePlayClient gp = new ServiceReference.GamePlayClient();
                ServiceReference.Player p = new ServiceReference.Player();

                p.Name = Player.PlayerName;
                //p.Colour = ;
                gp.addPlayer(p);


                this.Close();
            }
        }
    }
}

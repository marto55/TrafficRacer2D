using CarRacingWPFApp.Models;
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

namespace CarRacingWPFApp
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        TestGameClass game;
        public GameWindow()
        {
            InitializeComponent();
            game = new TestGameClass(this);
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            game.OnKeyDown(sender, e);
        }
        private void OnKeyUP(object sender, KeyEventArgs e)
        {
            game.OnKeyUP(sender, e);
        }
    }
}

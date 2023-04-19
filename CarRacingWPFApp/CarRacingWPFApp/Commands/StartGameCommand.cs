using CarRacingWPFApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingWPFApp.Commands
{
    class StartGameCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }
    }
}

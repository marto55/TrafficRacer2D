using CarRacingWPFApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingWPFApp.Commands
{
    class ConfirmCarCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            CarColorForm carColorForm = new CarColorForm();
            carColorForm.ShowDialog();
        }
    }
}

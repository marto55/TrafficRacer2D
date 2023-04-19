using CarRacingWPFApp.Forms;
using CarRacingWPFApp.Stores;
using CarRacingWPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingWPFApp.Commands
{
    internal class LogInCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            LogInForm logInForm = new LogInForm();
            logInForm.Show();
        }
    }
}

using CarRacingWPFApp.Commands;
using CarRacingWPFApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarRacingWPFApp.ViewModels
{
    internal class AccountViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand LogInCommand { get; }

        public AccountViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
            LogInCommand = new LogInCommand();
        }
    }
}

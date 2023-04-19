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
    class GarageViewModel : ViewModelBase
    {
        public ICommand? NavigateAccountCommand { get; }
        public ICommand? NavigateHomeCommand { get; }
        public ICommand? NavigateSettingsCommand { get; }
        public ICommand? ConfirmCarCommand { get; }

        public GarageViewModel(NavigationStore navigationStore)
        {
            NavigateAccountCommand = new NavigateAccountCommand(navigationStore);
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
            NavigateSettingsCommand = new NavigateSettingsCommand(navigationStore);
            ConfirmCarCommand = new ConfirmCarCommand();
        }
    }
}

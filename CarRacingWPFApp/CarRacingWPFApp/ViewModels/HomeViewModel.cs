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
    class HomeViewModel : ViewModelBase
    {
        public ICommand? NavigateAccountCommand { get; }
        public ICommand? NavigateGarageCommand { get; }
        public ICommand? NavigateSettingsCommand { get; }
        public ICommand? StartGameCommand { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateAccountCommand = new NavigateAccountCommand(navigationStore);
            NavigateGarageCommand = new NavigateGarageCommand(navigationStore);
            NavigateSettingsCommand = new NavigateSettingsCommand(navigationStore);
            StartGameCommand = new StartGameCommand();
        }

    }
}

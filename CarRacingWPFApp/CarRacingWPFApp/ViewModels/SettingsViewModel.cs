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
    class SettingsViewModel : ViewModelBase
    {
        public ICommand? NavigateHomeCommand { get; }

        public SettingsViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }
    }
}

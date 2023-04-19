using CarRacingWPFApp.Stores;
using CarRacingWPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingWPFApp.Commands
{
    internal class NavigateAccountCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateAccountCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new AccountViewModel(_navigationStore);
        }
    }
}

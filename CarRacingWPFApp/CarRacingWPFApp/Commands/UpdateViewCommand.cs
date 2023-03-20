﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CarRacingWPFApp.ViewModels;

namespace CarRacingWPFApp.Commands
{
    class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (parameter.ToString() == "Garage")
            {
                viewModel.SelectedViewModel = new GarageViewModel();
            }
            else if (parameter.ToString() == "Start Game")
            {
                GameWindow gameWindow = new GameWindow();
                gameWindow.Show();
            }
        }
    }
}

using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.MVVM.ViewModel;

namespace UI.Commands
{
    class StartQuizCommand : CommandBase
    {
        private readonly QuizViewModel _vm;

        public StartQuizCommand(QuizViewModel vm)
        {
            _vm = vm;
        }

        //public override bool CanExecute(object parameter)
        //{
        //    if (_vm.NewPlayerName == null) return true;
        //    bool isAvailable = _playerService.IsPlayerNameAvailable(_vm.NewPlayerName);
        //    if (!isAvailable) _vm.AddPlayerError = "This username is already used. please use another name";
        //    return isAvailable;
        //}

        public override void Execute(object parameter)
        {
            if (_vm.Player == null) return;
            _vm.ChoosePlayerVisible = Visibility.Collapsed;
            _vm.ShowQuiz = Visibility.Visible;
        }
    }
}

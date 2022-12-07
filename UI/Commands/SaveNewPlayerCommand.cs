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
    class SaveNewPlayerCommand : CommandBase
    {
        private PlayerService _playerService;
        private readonly PlayersViewModel _vm;

        public SaveNewPlayerCommand(PlayerService playerService, PlayersViewModel vm)
        {
            _playerService = playerService;
            _vm = vm;
        }

        public override bool CanExecute(object parameter)
        {
            if (_vm.NewPlayerName == null) return true;
            bool isAvailable = _playerService.IsPlayerNameAvailable(_vm.NewPlayerName);
            if (!isAvailable) _vm.AddPlayerError = "This username is already used. please use another name";
            return isAvailable;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _playerService.Add(_vm.NewPlayerName);
                _vm.NewPlayerName = "";
                _vm.AddPlayerError = "";
                _vm.CloseAddModal();
                _vm.RefreshPlayers();
            }
            catch (Exception ex )
            {

                MessageBox.Show("Error while adding player" + ex.InnerException);
            }
        }
    }
}

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
    class DeletePlayerCommand : CommandBase
    {
        private PlayerService _playerService;
        private readonly PlayersViewModel _vm;

        public DeletePlayerCommand(PlayerService playerService, PlayersViewModel vm)
        {
            _playerService = playerService;
            _vm = vm;
        }


        public override void Execute(object parameter)
        {
            try
            {
                _playerService.Delete((string)parameter);
                _vm.RefreshPlayers();
            }
            catch (Exception ex )
            {

                MessageBox.Show("Error while deleting player" + ex.InnerException);
            }   
        }
    }
}

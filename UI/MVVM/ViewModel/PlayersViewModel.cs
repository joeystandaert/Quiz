using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UI.Commands;
using UI.Core;

namespace UI.MVVM.ViewModel

{ 
    class PlayersViewModel: ObservableObject
    {
        private PlayerService _playerService;
        private List<Player> _players;

        public List<Player> Players {
        get {
            return _players;
        }

        set {
            _players = value;
            OnPropertyChanged();
        } }

        public PlayersViewModel(PlayerService playerService)
        {
            _playerService = playerService;
            RefreshPlayers();
        }

        public void RefreshPlayers()
        {
            Players = _playerService.GetAll();

        }

        private ICommand _deletePlayerCommand;

        public ICommand DeletePlayerCommand
        {
            get {
                if (_deletePlayerCommand == null) _deletePlayerCommand = new DeletePlayerCommand(_playerService, this);
                return _deletePlayerCommand;
            }
        }

        private ICommand _saveNewPlayerCommand;

        public ICommand SaveNewPlayerCommand
        {
            get
            {
                if (_saveNewPlayerCommand == null) _saveNewPlayerCommand = new SaveNewPlayerCommand(_playerService, this);
                return _saveNewPlayerCommand;
            }
        }

        private string _newPlayerName;

        public string NewPlayerName
        {
            get { return _newPlayerName; }
            set { 
                _newPlayerName = value;
                OnPropertyChanged(nameof(NewPlayerName));
            }
        }

        private string _addPlayerError;

        public string AddPlayerError
        {
            get { return _addPlayerError; }
            set {
                _addPlayerError = value;
                    OnPropertyChanged(nameof(AddPlayerError));
            }
        }

        public void CloseAddModal()
        {
            Application.Current.MainWindow.OwnedWindows[0].Close();
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand QuizViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand PlayersViewCommand { get; set; }
        public RelayCommand LeaderboardViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public QuizViewModel QuizVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public PlayersViewModel PlayersVM { get; set; }
        public LeaderboardViewModel LeaderboardVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            QuizVM = new QuizViewModel();
            SettingsVM = new SettingsViewModel();
            PlayersVM = new PlayersViewModel();
            LeaderboardVM = new LeaderboardViewModel();




            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            QuizViewCommand = new RelayCommand(o =>
            {
                CurrentView = QuizVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

            PlayersViewCommand = new RelayCommand(o =>
            {
                CurrentView = PlayersVM;
            });

            LeaderboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = LeaderboardVM;
            });


        }
    }
}

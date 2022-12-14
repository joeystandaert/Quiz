using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;
using UI.MVVM.ViewModel;

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

        public MainViewModel(IServiceProvider services)
        {
            HomeVM = new HomeViewModel();




            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            QuizViewCommand = new RelayCommand(o =>
            {
                QuizVM = services.GetRequiredService<QuizViewModel>();
                CurrentView = QuizVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                SettingsVM = services.GetRequiredService<SettingsViewModel>();
                CurrentView = SettingsVM;
            });

            PlayersViewCommand = new RelayCommand(o =>
            {
                PlayersVM = services.GetRequiredService<PlayersViewModel>();
                CurrentView = PlayersVM;
            });

            LeaderboardViewCommand = new RelayCommand(o =>
            {
                LeaderboardVM = services.GetRequiredService<LeaderboardViewModel>();
                CurrentView = LeaderboardVM;
            });


        }
    }
}

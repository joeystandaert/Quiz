using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class LeaderboardViewModel : ObservableObject
    {
        private List<LeaderbordStat> _leaderbordStats;
        private GameService _gameService;
        public LeaderboardViewModel(GameService gameService)
        {
            _gameService = gameService;
            LeaderbordStats = _gameService.GetLeaderbordStats();
        }

        public List<LeaderbordStat> LeaderbordStats {
            get
            {
                return _leaderbordStats;
            }
            set
            {
                _leaderbordStats = value;
                OnPropertyChanged(nameof(LeaderbordStats));
            }
        }
    }
}

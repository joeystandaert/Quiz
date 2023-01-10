using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.Commands;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class QuizViewModel: ObservableObject
    {
		private QuestionService _questionService;
		private PlayerService _playerService;
		private GameService _gameService;
		public QuizViewModel(QuestionService questionService, PlayerService playerService, GameService gameService)
		{
			_questionService= questionService;
			_playerService = playerService;
			_gameService= gameService;
			Questions = _questionService.GetQuizQuestions();
			Players = _playerService.GetAll();
			
		}

		private List<Player> _players;

		public List<Player> Players
		{
			get { return _players; }
			set { 
				_players = value;
				OnPropertyChanged(nameof(Players));
			}
		}



		private Player _player;

		public Player Player
		{
			get { return _player; }
			set { _player = value;
				OnPropertyChanged(nameof(Player));
			}
		}


		private List<Question> _questions;

		public List<Question> Questions
		{
			get { return _questions; }
			set { _questions = value;
				OnPropertyChanged(nameof(Questions));
			}
		}

		private int _currentStep = 0;

		public int CurrentStep
		{
			get { return _currentStep; }
			set { _currentStep = value;
                OnPropertyChanged(nameof(CurrentStep));
                OnPropertyChanged(nameof(CurrentQuestion));
				OnPropertyChanged(nameof(CurrentQuestionLabel));
            }
		}

		
		public Question CurrentQuestion { get { return Questions.ElementAt(CurrentStep); } }



        private ICommand _nextQuestionCommand;

        public ICommand NextQuestionCommand
		{
			get
			{
                if (_nextQuestionCommand == null) _nextQuestionCommand = new NextQuestionCommand( this);
                return _nextQuestionCommand;
            }
        }

        public string CurrentQuestionLabel { 
			
			get {
				int current = CurrentStep + 1;
				return $"Question: {current}/10";
			} 
		}
		private ICommand _startQuizCommand;

        public ICommand StartQuizCommand
		{
			get
			{
				if (_startQuizCommand == null) _startQuizCommand = new StartQuizCommand(this);
				return _startQuizCommand;
			}
		}



        public Answer AnswerOne { get { return this.CurrentQuestion.Anwsers.ElementAt(0); } } 
		public Answer AnswerTwo { get { return this.CurrentQuestion.Anwsers.ElementAt(1); } } 
		public Answer AnswerThree { get { return this.CurrentQuestion.Anwsers.ElementAt(2); } } 
		public Answer AnswerFour { get { return this.CurrentQuestion.Anwsers.ElementAt(3); } }


		private int _score = 0;

		public int Score
		{
			get { return _score; }
			set {
				_score = value; 
				OnPropertyChanged(nameof(Score));
				OnPropertyChanged(nameof(FinalScore));

            }
		}



		private Visibility _showQuiz = Visibility.Hidden;

		public Visibility ShowQuiz
		{
			get { return _showQuiz; }
			set { 
				_showQuiz = value;
                OnPropertyChanged(nameof(ShowQuiz));
                OnPropertyChanged(nameof(ShowScore));


            }
        }


		public Visibility ShowScore { get 
			{ 
				if( this.ShowQuiz == Visibility.Visible || this.ChoosePlayerVisible == Visibility.Visible) 
				{
					return Visibility.Hidden; 
				} else
				{
					return Visibility.Visible;
				} 
			}
		}

		private Visibility _choosePlayerVisible = Visibility.Visible;

		public Visibility ChoosePlayerVisible
		{
			get { return _choosePlayerVisible; }
			set { 
				_choosePlayerVisible = value;
				OnPropertyChanged(nameof(ChoosePlayerVisible));
			}
		}


		public string FinalScore { get { return $"Your score was {Score}/10"; } }

		public void SaveGame()
		{
			Game game = new Game()
			{
                Player = this.Player,
                Score = this.Score,
                Date = DateTime.Now
            };
			_gameService.AddGame(game);
		}



    }
}

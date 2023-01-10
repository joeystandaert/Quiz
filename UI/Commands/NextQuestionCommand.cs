using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.MVVM.ViewModel;

namespace UI.Commands
{

     class NextQuestionCommand : CommandBase
    {
        private readonly QuizViewModel _vm;
        public NextQuestionCommand(QuizViewModel vm)
        {
            _vm = vm;

        }
        public override void Execute(object parameter)
        {
            bool correct = (bool)parameter;
            if (correct)
            {
                _vm.Score++;
            }

            if(_vm.CurrentStep < 9  )
            {
                _vm.CurrentStep++;
                return;
            }
            //Quiz complete
            _vm.ShowQuiz = Visibility.Collapsed;
            _vm.SaveGame();
            
        }
    }
}

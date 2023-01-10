using Domain.Models;
using Domain.Services;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Core;

namespace UI.MVVM.ViewModel
{
    class SettingsViewModel : ObservableObject
    {
        private QuestionService _questionService;
        public SettingsViewModel(QuestionService questionService)
        {
            _questionService= questionService;
        }
        public void ImportQuestions(string test){
            using(TextFieldParser parser = new TextFieldParser(test))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                List<Question> list = new List<Question>();
                Question tempQuestion = new Question();
                while(!parser.EndOfData)
                {
                    //process
                    string[] fields = parser.ReadFields();
                    foreach(string field in fields)
                    {
                        if (field.Contains("?"))
                        {
                            tempQuestion.Sentence = field;
                            tempQuestion.Anwsers = new List<Answer>();
                        }
                        else if (field.Contains(":"))
                        {
                            string[] splitted = field.Split(":");
                            for (int i = 0; i < splitted.Length; i++)
                            {
                                tempQuestion.Anwsers.Add(new Answer
                                {
                                    Sentence = splitted[i],
                                    IsCorrect = i == 0
                                });
                            }
                            list.Add(new Question
                            {
                                Sentence = tempQuestion.Sentence,
                                Anwsers = tempQuestion.Anwsers
                            });
                            tempQuestion = new Question();
                        }
                    }
                }
                _questionService.DeleteAllQuestions();
                _questionService.AddBulk(list);
                //
                ImportSuccess = Visibility.Visible;

            }
        }
        private Visibility _importSuccess = Visibility.Collapsed;

        public Visibility ImportSuccess
        {
            get { return _importSuccess; }
            set { 
                _importSuccess = value;
                OnPropertyChanged(nameof(ImportSuccess));
            }
        }

    }
}

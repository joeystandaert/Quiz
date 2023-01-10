using Domain.Interfaces;
using Domain.Services;
using EFDataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using System.Windows;
using UI.MVVM.ViewModel;
using UI.HostBuilders;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IAnswerRepository, AnswerRepository>();
                    services.AddSingleton<IGameRepository, GameRepository>();
                    services.AddSingleton<IPlayerRepository, PlayerRepository>();
                    services.AddSingleton<IQuestionRepository, QuestionRepository>();

                    //services.AddSingleton<StudentViewModel>();
                    services.AddSingleton<PlayerService, PlayerService>();
                    services.AddSingleton<QuestionService, QuestionService>();
                    services.AddSingleton<PlayerService, PlayerService>();
                    services.AddSingleton<GameService, GameService>();
                    services.AddSingleton<PlayersViewModel>();
                    services.AddTransient<QuizViewModel>();
                    services.AddTransient<LeaderboardViewModel>();
                    services.AddTransient<SettingsViewModel>();
                    services.AddSingleton<MainViewModel>(sp => new MainViewModel(sp));
                    

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow()
            {
                DataContext = _host.Services.GetRequiredService<MainViewModel>()
            };
            this.MainWindow = window;
            window.Show();
        }
    }
}

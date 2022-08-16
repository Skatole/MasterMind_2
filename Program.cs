

using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MasterMind_Project_2.Binders;
using MasterMind_Project_2.console_display_classes;
using MasterMind_Project_2.GameBoard;
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Menu;
using MasterMind_Project_2.Interfaces.Roles;
using MasterMind_Project_2.Configuration;
using MasterMind_Project_2.Configuration.ConsoleSettings;
using MasterMind_Project_2.Users;

namespace MasterMind_Project_2
{
    class Program
    {

        private static void Main(String[] args)
        {
            IServiceProvider serviceProvider = BuildServiceProvider();
            Processor processor = serviceProvider.GetService<Processor>()!;
            processor.InicialiseProcess();
        }

        static IServiceProvider BuildServiceProvider()
        {
            IServiceCollection collection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appSettings.json", optional: false)
              .Build();

            IConfig config = configuration.Get<Config>();
            IUser user = configuration.Get<User>();
            Guess guess = configuration.Get<Guess>();
            Hint hint = configuration.Get<Hint>();
            Solution solution = configuration.Get<Solution>();
            Permutations permutations = configuration.Get<Permutations>();


            collection.AddSingleton<Processor>();
            collection.AddSingleton<INavigator>(new Navigator());

            collection.AddSingleton<IUser>(new User(config));

            collection.AddSingleton<Board>(new Board(config, guess, hint, solution, permutations));
            collection.AddSingleton<Guess>();
            collection.AddSingleton<Hint>();
            collection.AddSingleton<Solution>();
            collection.AddSingleton<Permutations>();
            collection.AddSingleton<ISettings>(new Settings(user));

            return collection.BuildServiceProvider();
        }
    }

}

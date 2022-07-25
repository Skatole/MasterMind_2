

using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Settings;
using MasterMind_Project_2.Binders;
using MasterMind_Project_2.Players;
using MasterMind_Project_2.Players.Roles;
using MasterMind_Project_2.Pins;
using MasterMind_Project_2.console_display_classes;

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


            collection.AddSingleton<Processor>();
            collection.AddSingleton<INavigator>(new Navigator());

            collection.AddSingleton<IPlayer>(new Player(config));
            collection.AddSingleton<IMaster>(new Master(config));
            collection.AddSingleton<IUser>(new User(config));

            collection.AddSingleton<Board>(new Board(config));
            collection.AddSingleton<Guess>();
            collection.AddSingleton<Hint>();
            collection.AddSingleton<Solution>();
            collection.AddSingleton<Permutations>();

            collection.AddSingleton<IMenu>(new Menu());
            collection.AddSingleton<ISettings>(new Settings.Settings(config));

            return collection.BuildServiceProvider();
        }
    }

}

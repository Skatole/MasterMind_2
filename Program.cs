

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Settings;
using MasterMind_Project_2.Binders;

namespace MasterMind_Project_2
{
    class Program
    {

        private static void Main ( String [ ] args )
        {

          // DisplayOnConsole.Welcome();
          // ConsoleMenu.DisplayMenu();

          IServiceProvider serviceProvider = BuildServiceProvider();
          Processor processor = serviceProvider.GetService<Processor>()!;
          processor.InicialiseProcess();




        }
          static IServiceProvider BuildServiceProvider()
          {
            IServiceCollection collection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appSettings.json", optional : false)
              .Build();

            IConfig config = configuration.Get<Config>();

            collection.AddSingleton<Processor>();
            collection.AddSingleton<INavigator>( new Navigator());
            collection.AddSingleton<IPlayer>(new Players.Player());
            collection.AddSingleton<IMaster>(new Players.Master());
            collection.AddSingleton<Board>(new Board(config));
            collection.AddSingleton<Guess>();
            collection.AddSingleton<Hint>();
            collection.AddSingleton<Solution>();
            collection.AddSingleton<IMenu>( new MasterMind_Project_2.console_display_classes.Menu() );
            collection.AddSingleton<Permutations>();

            return collection.BuildServiceProvider();
          }
    }

}

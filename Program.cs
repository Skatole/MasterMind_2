
using MasterMind_Project_2.Binders;
using MasterMind_Project_2.Configuration;
using MasterMind_Project_2.Configuration.ConsoleSettings;
using MasterMind_Project_2.GameBoard;
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.GameBoard.InputValidators;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Menu;
using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.Users;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasterMind_Project_2
{
    class Program
    {

        private static void Main(String[] args)
        {
            IServiceProvider serviceProvider = BuildServiceProvider();
            ConsoleProcessor processor = serviceProvider.GetService<ConsoleProcessor>()!;
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
            IGuess guess = configuration.Get<Guess>();
            IHint hint = configuration.Get<Hint>();
            IMappable solution = configuration.Get<Solution>();
            IPermutable permutations = configuration.Get<Permutations>();
            INavigator navigator = configuration.Get<Navigator>();
            IBoard board = configuration.Get<Board>();
            ISettings settings = configuration.Get<Settings>();
            IValidatable validatable = configuration.Get<InputValidator>();
            IConvertable convertable = configuration.Get<InputToPinConverter>();



            collection.AddSingleton<IProcessor>(
                new ConsoleProcessor(
                    user,
                    navigator,
                    board,
                    config,
                    settings
                    )
                );

            collection.AddSingleton<IBoard>(
                new Board(
                    config,
                    guess,
                    hint,
                    solution,
                    permutations,
                    validatable,
                    convertable
                    ));

            collection.AddSingleton<IUser>(new User(config));
            collection.AddSingleton<INavigator>(new Navigator());
            collection.AddSingleton<IGuess>(new Guess(config));
            collection.AddSingleton<IHint>(new Hint(config));
            collection.AddSingleton<IMappable>(new Solution(config));
            collection.AddSingleton<ISettings>(new Settings(user));
            collection.AddSingleton<IPermutable>();

            collection.AddTransient<IValidatable>();
            collection.AddTransient<IConvertable>();

            return collection.BuildServiceProvider();
        }
    }

}

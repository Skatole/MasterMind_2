using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2.Players.Roles
{
    public class Player : User, IPlayer
    {

        private int i { get; } = 0;
        private string TestString { get; set; } = " TEST ";

        public Player(IConfig config) : base(config)
        {
            Points = 0;
            i++;
            Console.WriteLine("HI THERe " + i);
        }

        public void StartGame()
        {
            try
            {
                Console.WriteLine(" START GAME: ");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e + " THIS IS NOT INSTATIATED ");
            }
        }
        public string MakeMove()
        {
            return TestString;
        }

        public void TakeHint()
        {
            Console.WriteLine("TAkE a HINT: ");
        }
        //      public void StartGame()
        // 	{
        // 		while(!GameOver())
        // 		{
        // 			List<(GuessPin Pin, bool Valid)> convGuess = Guess.PinConverter( 
        // 				Guess.CleanAndValidate(
        // 					DisplayOnConsole.MakeAGuess(),
        // 					Columns,
        // 					Row,
        // 					out _isGuessValid),
        // 				ref _isGuessValid);

        // 			if ( IsGuessValid )
        // 			{
        // 				Guess.mapper(convGuess, Guess.GuessBoard, ref _guessCounter, ref _isGuessValid);
        // 				Hint.GenerateHint(Guess, Solution, ref _guessCounter);
        // 				DisplayOnConsole.DisplayBoard(Guess, Hint);
        // 				Win();
        // 				GuessCounter++;
        // 			}

        // 		}
        // 	}

        //     public string MakeMove()
        //     {
        //         return DisplayOnConsole.AskForGuess();
        //     }

        //     public void TakeHint()
        //     {

        //     }
    }
}
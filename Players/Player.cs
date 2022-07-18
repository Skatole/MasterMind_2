using MasterMind_Project_2;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2.Players
{
    public class Player
    {

        public int Points { get; set; }
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
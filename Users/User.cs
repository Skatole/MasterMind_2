using MasterMind_Project_2.Configuration;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Roles;

namespace MasterMind_Project_2.Users
{
    public class User : IUser, IPlayer, IMaster
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public IInput Input { get; set; }
        public IConfig UserCustomConfig { get; set; }

        public User(IConfig config)
        {
            Points = 0;
            Name = Login();
            UserCustomConfig = config;
        }
        public IInput GiveInput()
        {
            Input.ConsoleInput = Console.ReadLine();
            return Input;
        }

        public string Login()
        {
            System.Console.WriteLine("ENTER YOUR NAME: \n");
            string input = Console.ReadLine();
            return input;
            // Its gona be empty for now ==> When DB or mock DB is set then implement.
        }

        public void Register()
        {
            /* THis will be empty for now ==>
             * This app will have a Login Interface and Class that checks if a user exists or not.
             * If not then it will register it else it will log the user in based on the parameters.
             */
        }

        //public void StartGame()
        //{
        //    try
        //    {
        //        Console.WriteLine(" START GAME: ");
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        Console.WriteLine(e + " THIS IS NOT INSTATIATED ");
        //    }
        //}

        /* ------------------ PLAYER ------------------*/

        public string MakeMove()
        {
            string MakeMoveTest = " I Made a move. ";
            Console.WriteLine(MakeMoveTest);
            return MakeMoveTest;
        }

        /* ------------------ Master ------------------*/
        public IInput MakeHint()
        {
            GiveInput();
            Input.
        }

    }
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
// 				Guess.mapper(convGuess, Guess.Board, ref _guessCounter, ref _isGuessValid);
// 				Hint.GenerateHint(Guess, Solution, ref _guessCounter);
// 				DisplayOnConsole.DisplayBoard(Guess, Hint);
// 				Win();
// 				GuessCounter++;
// 			}

// 		}
// 	}
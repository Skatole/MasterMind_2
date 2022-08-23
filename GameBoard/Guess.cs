using System.Text.RegularExpressions;
using Pastel;

using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Roles;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Board.Pins;


namespace MasterMind_Project_2.GameBoard
{
    public class Guess : PinMapper, IGuess
    {
        public IPin[] GuessPins { get; set; }
        public override Dictionary<int, IPin[]> Board { get; set; }

        public Guess(IConfig config) : base(config)
        {
            Board = new Dictionary<int, IPin[]>();
            GuessPins = new GuessPin[config.Columns];
            AddToBoard();
        }

        /*
         * Fill Board with empty pins:
         */

        public override Dictionary<int, IPin[]> AddToBoard()
        {
            for (int i = 0; i < Config.Rows; i++)
            {
                Board[i] = GuessPins;
            }
            return Board;
        }

        /*
         * Add guess to Board:
         */

        public override Dictionary<int, IPin[]> AddToBoard(IConvertable convertedInput)
        {

            for (int j = 0; j < convertedInput.convertedPins.Length; j++)
            {
                GuessPins[j] = (GuessPin)convertedInput.convertedPins[j];
            }

            Board[GuessCounter] = GuessPins;

            return Board;

        }



        //internal string[] CleanAndValidate(string? guess, int columns, out bool isGuessValid)
        //{
        //    isGuessValid = false;
        //    string[] guessArr = new string[columns];
        //    Array pinArray = Enum.GetValues(typeof(PinColor));

        //    if (guess.Length == 0)
        //    {
        //        Console.WriteLine(" \n	No guess Input! \n 	Please choose from the given color input options. \n"
        //        .Pastel(System.Drawing.Color.DarkRed));
        //        isGuessValid = false;

        //    }
        //    else if (guess.Length > columns)
        //    {
        //        Console.WriteLine($"\n Please Only Enter {columns} characters! \n".Pastel(System.Drawing.Color.DarkRed));
        //        isGuessValid = false;
        //    }
        //    else if (guess.Length < columns)
        //    {
        //        Console.WriteLine($"\n This is less than {columns} characters".Pastel(System.Drawing.Color.DarkRed));
        //        isGuessValid = false;
        //    }
        //    else if (guess.Length == columns)
        //    {
        //        string replacedGuess = Regex.Replace(guess, @"[^0-9a-zA-Z]+", "").ToUpper();
        //        isGuessValid = true;
        //        for (var i = 0; i < replacedGuess.Length; i++)
        //        {
        //            guessArr[i] = replacedGuess[i].ToString();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(System.Drawing.Color.DarkRed));
        //        isGuessValid = false;
        //    }

        //    return guessArr;
        //}


    }
}
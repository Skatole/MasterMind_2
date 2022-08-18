using System.Text.RegularExpressions;

using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces;

using Pastel;

namespace MasterMind_Project_2.GameBoard
{
    public class Guess : PinMapper
    {

        private Pin _pin;
        private Dictionary<int, Pin[]> _guessBoard;
        internal Dictionary<int, Pin[]> GuessBoard { get => _guessBoard; set => _guessBoard = value; }
        private IConfig _config;


        public Guess(IConfig config) : base(config)
        {
            _config = config;
            _pin = new GuessPin();
            _guessBoard = new Dictionary<int, Pin[]>();
            _guessBoard = Mapper(_pin, _guessBoard);
        }

        internal string[] CleanAndValidate(string? guess, int columns, out bool isGuessValid)
        {
            isGuessValid = false;
            string[] guessArr = new string[columns];
            Array pinArray = Enum.GetValues(typeof(PinColor));

            if (guess.Length == 0)
            {
                Console.WriteLine(" \n	No guess Input! \n 	Please choose from the given color input options. \n"
                .Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;

            }
            else if (guess.Length > columns)
            {
                Console.WriteLine($"\n Please Only Enter {columns} characters! \n".Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;
            }
            else if (guess.Length < columns)
            {
                Console.WriteLine($"\n This is less than {columns} characters".Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;
            }
            else if (guess.Length == columns)
            {
                string replacedGuess = Regex.Replace(guess, @"[^0-9a-zA-Z]+", "").ToUpper();
                isGuessValid = true;
                for (var i = 0; i < replacedGuess.Length; i++)
                {
                    guessArr[i] = replacedGuess[i].ToString();
                }
            }
            else
            {
                Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;
            }

            return guessArr;
        }

      
    }
}
using System.Collections.Generic;
using Pastel;
using System.Text.RegularExpressions;
using MasterMind_Project_2.Interfaces;

namespace MasterMind_Project_2
{
    public class Guess : PinMapper
    {

        private Pin _guessPin;
        private Dictionary<int, GuessPin[]> _guessBoard;
        internal Dictionary<int, GuessPin[]> GuessBoard { get => _guessBoard; set => _guessBoard = value; }
        private IConfig _config;


        public Guess(IConfig config) : base(config)
        {
            _guessBoard = new Dictionary<int, GuessPin[]>();
            _guessPin = new GuessPin(config);
            _guessBoard = mapper((GuessPin)_guessPin, _guessBoard);
            _config = config;
        }

        internal string[] CleanAndValidate ( string? guess, int columns, out bool isGuessValid )
        {
            isGuessValid = false;
            string[] guessArr = new string[columns];
            Array pinArray = Enum.GetValues(typeof(PinColor));

            if ( guess.Length == 0 )
            {
                Console.WriteLine(" \n	No guess Input! \n 	Please choose from the given color input options. \n"
                .Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;

            }
            else if ( guess.Length > columns )
            {
                Console.WriteLine($"\n Please Only Enter {columns} characters! \n".Pastel(System.Drawing.Color.DarkRed) );
                isGuessValid = false;
            }
            else if ( guess.Length < columns )
            {
                System.Console.WriteLine( $"\n This is less than {columns} characters".Pastel(System.Drawing.Color.DarkRed) );
                isGuessValid = false;
            }
            else if ( guess.Length == columns )
            {
                string replacedGuess = Regex.Replace(guess, @"[^0-9a-zA-Z]+", "").ToUpper();
                isGuessValid = true;
                for ( var i = 0; i < replacedGuess.Length; i++ )
                {
                    guessArr[i] = replacedGuess [ i ].ToString();
                }
            }
            else
            {
                Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;
            }

            return guessArr;
        }

         internal List<GuessPin> NoneNotAllowedConverter ( string[] validatedInput, ref bool isGuessValid )
        {
            List<GuessPin> convertedPins = new List<GuessPin>();
            List<bool> validatorList = new List<bool>();
            GuessColor[] Pins = (GuessColor[]) Enum.GetValues(typeof(GuessColor));

            for (int i = 0; i < validatedInput.Length; i++)
            {
                for (int j = 0; j < Pins.Length; j++)
                {
                    if (validatedInput[i] == ((char) ((int) Pins[j])).ToString()
                        && validatedInput[i] != ( (char) GuessColor.None ).ToString())
                    {
                        convertedPins.Add( new GuessPin( _config, Pins[j] ) );
                    }
                }
            }

            if ( convertedPins.Count == Columns )
            { 
                isGuessValid = true;
            }
            else
            {
                isGuessValid = false;
                System.Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed)); 
            }

            return convertedPins;

        }

        internal List<GuessPin> NoneAllowedConverter ( string[] validatedInput, ref bool isGuessValid )
        {
            List<GuessPin> convertedPins = new List<GuessPin>();
            List<bool> validatorList = new List<bool>();
            GuessColor[] Pins = (GuessColor[]) Enum.GetValues(typeof(GuessColor));

              for (int i = 0; i < validatedInput.Length; i++)
            {
                for (int j = 0; j < Pins.Length; j++)
                {
                    if (validatedInput[i] == ((char) ((int) Pins[j])).ToString())
                    {
                        convertedPins.Add( new GuessPin( _config, Pins[j] ) );
                    }
                }
            }

            if ( convertedPins.Count == Columns )
            { 
                isGuessValid = true;
            }
            else
            {
                isGuessValid = false;
                System.Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed)); 
            }

            return convertedPins;

        }
    }
}
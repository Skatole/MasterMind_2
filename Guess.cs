using System.Collections.Generic;
using Pastel;
using System.Text.RegularExpressions;

namespace MasterMind_Project_2
{
    class Guess : PinMapper
    {

        private Pin _guessPin;
        private Dictionary<int, GuessPin[]> _guessBoard;
        internal Dictionary<int, GuessPin[]> GuessBoard { get => _guessBoard; set => _guessBoard = value; }


        internal Guess()
        {
            _guessBoard = new Dictionary<int, GuessPin[]>();
            _guessPin = new GuessPin();
            _guessBoard = mapper((GuessPin)_guessPin, _guessBoard);
        }

        internal string[] CleanAndValidate ( string? guess, int? columns, int? row, out bool isGuessValid )
        {
            isGuessValid = false;
            string[] guessArr = new string[ (int) columns];
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
                    // if (replacedGuess.Contains("?"))
                    // {
                        // isGuessValid = true;
                        // CALL AUTOSOLVER
                    // }
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

         internal List<(GuessPin Pin, bool Valid)> PinConverter ( string[] validatedInput, ref bool isGuessValid )
        {
            List<(GuessPin Pin, bool Valid)> convertedPins = new List<(GuessPin Pin, bool Valid)>();
            Array Pins = Enum.GetValues(typeof(GuessColor));
            Dictionary<int, (string guess, bool valid )> shortTermLocalMemory = new Dictionary<int, (string guess, bool valid)>();

            // Seed memory:
            for ( int i = 0; i < validatedInput.Length; i++ )
            {
                shortTermLocalMemory.Add(i, (validatedInput [ i ], false));
            }

            // IF NONE IS ALLOWED YOU SHOULD IMPLEMENT IT HERE!!!

            foreach ( var guess in validatedInput.Select(( value, i ) => new { value, i }) )
            {
                foreach ( var pin in Pins )
                {
                    if ( guess.value == (( char ) (( int ) pin)).ToString() )
                    {
                        isGuessValid = true;
                        shortTermLocalMemory [ guess.i ] = (guess.value, true);
                        convertedPins.Add((new GuessPin(( GuessColor ) pin), isGuessValid));
                    }
                }
                if ( shortTermLocalMemory.ContainsValue((guess.value, false)) )
                {
                    isGuessValid = false;
                }
            }

            if ( !isGuessValid )
            { System.Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed)); }

            return convertedPins;
        }
    }
}
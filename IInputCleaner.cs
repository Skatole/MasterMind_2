using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

using Pastel;

namespace MasterMind_Project_2
{
    interface IInputCleaner
    {



        internal List<string> CleanAndValidate(string guess, int columns, int row, ref bool isGuessValid)
        {
            List<string> guestList = new List<string> { };
            Array pinArray = Enum.GetValues(typeof(PinColor));

            if (guess.Length == 0)
            {
                Console.WriteLine(" \n	No guess Input! \n 	Please choose from the given color input options. \n"
                .Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;

            }
            else if (guess.Length > columns)
            {
                Console.WriteLine("\n" + ("Please Only Enter " + columns + "characters!").Pastel(System.Drawing.Color.DarkRed) + "\n");
                isGuessValid = false;
            }
            else if (guess.Length < columns)
            {
                System.Console.WriteLine("\n" + ("This is less than " + columns + " characters").Pastel(System.Drawing.Color.DarkRed) + "\n");
                isGuessValid = false;
            }
            else if (guess.Length == columns)
            {
                string replacedGuess = Regex.Replace(guess, @"[^0-9a-zA-Z]+", "").ToUpper();
                isGuessValid = true;
                for (var i = 0; i < replacedGuess.Length; i++)
                {
                    guestList.Add(replacedGuess[i].ToString());
                    if (replacedGuess.Contains("?"))
                    {
                        isGuessValid = true;
                        //CALL AUTOSOLVER HERE !!!!!
                    }
                }

            }
            else
            {
                Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(Color.DarkRed));
                isGuessValid = false;
            }


            return guestList;
        }
    }
}

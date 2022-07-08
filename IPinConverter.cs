using System;
using System.Collections.Generic;

using Pastel;

namespace MasterMind_Project_2
{
    interface IPinConverter
    {


        internal List<(GuessPin Pin, bool Valid)> PinConverter ( string [ ] validatedInput, ref bool isGuessValid )
        {

            List<(GuessPin Pin, bool Valid)> convertedPins = new List<(GuessPin Pin, bool Valid)>();
            Array Pins = Enum.GetValues(typeof(GuessColor));
            Dictionary<int, (string guess, bool valid )> shortTermLocalMemory = new ();

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
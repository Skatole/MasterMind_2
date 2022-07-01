using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    interface IPinConverter
    {


        internal List<GuessPin> PinConverter(List<string> validatedInput)
        {

            List<GuessPin> convertedPins = new List<GuessPin>();
            GuessPin guessPin;
            Array Pins = Enum.GetValues(typeof(GuessColor));

// IF NONE IS ALLOWED YOU SHOULD IMPLEMENT IT HERE!!!

            foreach (var guess in validatedInput)
            {

                foreach (var pin in Pins)
                {
                    if (guess == ((char)((int)pin)).ToString())
                    {
                        guessPin = new GuessPin((PinColor) pin);
                        convertedPins.Add(guessPin);
                    } 
                }

            }

            return convertedPins;
        } 
            

    }
}
using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    interface IPinConverter
    {


        internal List<(PinColor Name, char Vlaue)> PinConverter((List<string> Guesses, bool Valid) validatedInput)
        {

            List<(PinColor Name, char Value)> convertedPins = new List<(PinColor Name, char Value)>();
            Array Pins = Enum.GetValues(typeof(PinColor));

            if (validatedInput.Valid)
            {

                foreach (var guess in validatedInput.Guesses)
                {
                    foreach (var pin in Pins)
                    {
                    	if (validatedInput.Valid && guess == pin) 
                    	{
                    	    convertedPins.Add(((PinColor) pin, (char) ((int) pin)));
                    	}
    
                        }
                }
            } else
            {
                global::System.Console.WriteLine("Invalid Guess while converting.");
            }


			
            
            return convertedPins;
        }

    }
}
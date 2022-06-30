using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    interface IPinConverter
    {


        internal List<(PinColor Name, bool Valid)> PinConverter((List<string> Guesses, bool Valid) validatedInput)
        {

            List<(PinColor Name, bool Valid)> convertedPins = new List<(PinColor Name, bool Valid)>();
            Array Pins = Enum.GetValues(typeof(PinColor));
            bool isValidPin = validatedInput.Valid;


            if (validatedInput.Valid)
            {

                foreach (var guess in validatedInput.Guesses)
                {

                    foreach (var pin in Pins)
                    {
                    	if (guess == ((char) ((int) pin)).ToString()) 
                    	{
                    	    convertedPins.Add(((PinColor) pin, isValidPin));
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
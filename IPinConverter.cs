using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    interface IPinConverter
    {


        internal List<PinColor> PinConverter(List<string> validatedInput)
        {

            List<PinColor> convertedPins = new List<PinColor>();
            Array Pins = Enum.GetValues(typeof(PinColor));


            foreach (var guess in validatedInput)
            {

                foreach (var pin in Pins)
                {
                    if (guess == ((char)((int)pin)).ToString())
                    {
                        convertedPins.Add(((PinColor)pin));
                    } 
                    else
                    {
                        convertedPins.Add(PinColor.None);
                    }
                }
            }

            foreach ( var item in convertedPins )
            {
            }
            return convertedPins;
        } 
            

    }
}
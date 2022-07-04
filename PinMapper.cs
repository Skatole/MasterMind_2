using System;
using System.Collections.Generic;
using System.Linq;

using Pastel;

namespace MasterMind_Project_2
{
    abstract class PinMapper : Pin
    {
        // Guess Pin from constructor
        internal Dictionary<int, GuessPin [ ]> mapper ( GuessPin pin, Dictionary<int, GuessPin [ ]> Board )
        {
            GuessPin[] pinArr = new GuessPin[Columns];

            for ( int i = 0; i < Row; i++ )
            {
                for ( int j = 0; j < Columns; j++ )
                {

                    pin = new GuessPin();
                    pinArr [ j ] = pin;
                }

                Board.Add(i, pinArr);

            }
            return Board;
        }

        // HintPin from constructor

        internal Dictionary<int, HintPin [ ]> mapper ( HintPin pin, Dictionary<int, HintPin [ ]> Board )
        {
            HintPin[] pinArr = new HintPin[Columns];

            for ( int i = 0; i < Row; i++ )
            {
                for ( int j = 0; j < Columns; j++ )
                {

                    pin = new HintPin();
                    pinArr [ j ] = pin;
                }

                Board.Add(i, pinArr);

            }
            return Board;
        }

        // Guess Pin from List
        internal Dictionary<int, GuessPin [ ]> mapper ( List<GuessPin> convertedPinList, Dictionary<int, GuessPin [ ]> guessBoard, out int counter, ref bool isGuessValid )
        {
            counter = GuessCounter;
            GuessPin[] pinArr = new GuessPin[Columns];

            // If NONE is allowed then take out the convertedPinList[i] != PinColor.None statement!


            if ( convertedPinList.Count == Columns && isGuessValid )
            {
                for ( int i = 0; i < convertedPinList.Count; i++ )
                {
                    // (GuessColor) this was a cast taken out for testing
                    if ( convertedPinList [ i ].Color != GuessColor.None )
                    {
                        pinArr [ i ] = convertedPinList [ i ];
                        isGuessValid = true;
                    }
                }

                guessBoard [ Row - counter ] = isGuessValid ? pinArr : guessBoard [ Row - counter ];
            }
            else
            {
                Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(System.Drawing.Color.DarkRed));
                isGuessValid = false;
            }


            return guessBoard;
        }

        // Hint Pin from Guess Board

        // internal Dictionary<int, HintPin [ ]> mapper ( HintPin[] rowOfHintPins,  Dictionary<int, HintPin [ ]> hintBoard)
        // {


           

        //     return hintBoard;                                                                                            
        // }
    }
}
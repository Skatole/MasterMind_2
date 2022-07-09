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
        internal Dictionary<int, GuessPin [ ]> mapper ( List<(GuessPin pin, bool valid)> convertedPinList, Dictionary<int, GuessPin [ ]> guessBoard, ref int counter, ref bool isGuessValid )
        {
            GuessPin[] pinArr = new GuessPin[Columns];

            // If NONE is allowed then take out the convertedPinList[i] != PinColor.None statement!

            if ( isGuessValid )
            {
                for ( int i = 0; i < convertedPinList.Count; i++ )
                {
                    if ( convertedPinList [ i ].pin.Color != GuessColor.None && convertedPinList[i].valid )
                    {
                        pinArr [ i ] = convertedPinList [ i ].pin;
                    }
                }
                guessBoard [ Row - counter ] = isGuessValid ? pinArr : guessBoard [ Row - counter ];
            }
            return guessBoard;
        }

        // HintPin to Hint Dictionary Mapping
        internal HintPin[] mapper( int InPlace, int In, HintPin[] BoardRow )
        {
            System.Console.WriteLine("HintBoardMapper: ");
            if (InPlace > 0)
            {
                for (int i = 0; i < InPlace; i++)
                {
                    
                    BoardRow[i] = new HintPin( HintColor.InPlace); 
                }
            }
            foreach (var item in BoardRow.Select( (value, i ) => new { value, i }))
            {
                if ( item.value.Color == HintColor.None && In > 0 )    
                { 
                    for (int j = 0; j < In; j++)
                    {
                        BoardRow[item.i] = new HintPin( HintColor.In );
                    }
                }

                System.Console.WriteLine(item.value);
            }


            return BoardRow;
        }



        internal List<GuessPin> CreateShortTermMemory ( GuessPin[ ] Pins )
        {
            List<GuessPin> sMemory = new List<GuessPin>();
            for ( int i = 0; i < Pins.Length; i++ )
            {
                sMemory[i] = (Pins [ i ]);
            }

            return sMemory;
        }
    
        internal HintPin[] Scramble (HintPin[] oneRow)
        {
            List<int> indexMemory = new List<int>();
            Random random = new Random((int) DateTime.Now.Ticks);
            


            while(indexMemory.Count < oneRow.Length)
            {
                int randIndex = random.Next(oneRow.Length);
                HintPin temp = new HintPin();
                for (int i = 0; i < oneRow.Length; i++)
                {
                    if (!indexMemory.Contains(randIndex) && i != randIndex)
                    {
                        indexMemory.Add(randIndex);
                        temp = oneRow[i];
                        oneRow[i] = oneRow[randIndex];
                        oneRow[randIndex] = temp;

                    }
                }
            }

            return oneRow;
        }
    }
}
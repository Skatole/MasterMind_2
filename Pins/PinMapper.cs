using System;
using System.Collections.Generic;
using System.Linq;

using Pastel;

namespace MasterMind_Project_2
{
    abstract class PinMapper : Pin
    {

        private int _rows;
        private int _columns;

        internal PinMapper() : base()
        {
            _rows = base.Row;
            _columns = base.Columns;
        }

        internal PinMapper( int Rows, int Columns, bool isNoneAllowed) : base( Rows, Columns, isNoneAllowed)
        {
            _rows = Rows;
            _columns = Columns;
        }
        // Guess Pin from constructor
        internal Dictionary<int, GuessPin [ ]> mapper ( GuessPin pin, Dictionary<int, GuessPin [ ]> Board )
        {

            GuessPin[] pinArr = new GuessPin[_columns];

            for ( int i = 0; i < _rows; i++ )
            {
                for ( int j = 0; j < _columns; j++ )
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
            HintPin[] pinArr = new HintPin[_columns];

            for ( int i = 0; i < _rows; i++ )
            {
                for ( int j = 0; j < _columns; j++ )
                {

                    pin = new HintPin();
                    pinArr [ j ] = pin;
                }

                Board.Add(i, pinArr);

            }
            return Board;
        }

        // Guess Pin from List
        internal Dictionary<int, GuessPin [ ]> mapper ( List<(GuessPin pin, bool valid)> convertedPinList, Dictionary<int, GuessPin [ ]> guessBoard, ref int guessCounter, ref bool isGuessValid )
        {
            GuessPin[] pinArr = new GuessPin[_columns];

            // If NONE is allowed then take out the convertedPinList[i] != PinColor.None statement!

            if (IsNoneAllowed)
            {
                Console.WriteLine("\n" + IsNoneAllowed + " IsNONE IN FIRST. \n");
                for ( int i = 0; i < convertedPinList.Count; i++ )
                {
                    if ( convertedPinList[i].valid )
                    {
                        pinArr [ i ] = convertedPinList [ i ].pin;
                    }
                }                
            }
            else
            {
                Console.WriteLine("\n" + IsNoneAllowed + " IsNONE IN SECOND. \n");

                for ( int i = 0; i < convertedPinList.Count; i++ )
                {
                    if ( convertedPinList [ i ].pin.Color != GuessColor.None && convertedPinList[i].valid )
                    {
                        pinArr [ i ] = convertedPinList [ i ].pin;
                    }
                    else
                    {
                        pinArr [ i ] = null;
                    }
                }
            }
            Console.WriteLine(pinArr.Length + " pinARR");

            foreach ( var item in pinArr )
            {
                Console.WriteLine(item + " , ");
            }
            if (pinArr.Length == Columns || isGuessValid)
            {  
                guessBoard [ guessCounter ] = pinArr;
            }
            else
            {
                isGuessValid = false;
                System.Console.WriteLine("\n Invalid Input. Please choose from the given color input options. \n ".Pastel(System.Drawing.Color.DarkRed));
            }

            return guessBoard;
        }

        // HintPin to Hint Dictionary Mapping
        internal HintPin[] mapper( int InPlace, int In, HintPin[] hintBoardRow )
        {

            for (int i = 0; i < InPlace; i++)
            {
                hintBoardRow[i] = new HintPin( HintColor.InPlace );
            }

            for (int j = InPlace; j < In + InPlace; j++)
            {
                hintBoardRow[j] = new HintPin( HintColor.In );
            }
            
            return hintBoardRow;
        }

        internal List<GuessColor> CreateCopy ( GuessColor[] colorArray)
        {
            List<GuessColor> colorList = new List<GuessColor>();
            for (int i = 0; i < colorArray.Length; i++)
            {
                colorList.Add(colorArray[i]);
            }
            return colorList;
        }

        internal List<GuessPin> CreateCopy ( GuessPin[] pinArray)
        {
            List<GuessPin> pinList = new List<GuessPin>();
            for (int i = 0; i < pinArray.Length; i++)
            {
                pinList.Add(pinArray[i]);
            }
            return pinList;
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
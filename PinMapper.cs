using System;
using System.Collections.Generic;

using Pastel;

namespace MasterMind_Project_2
{
    abstract class PinMapper : Pin
    {
        // Guess Pin from constructor
        internal Dictionary<int, GuessPin[]> mapper( GuessPin pin, Dictionary<int, GuessPin[]> Board ) 
        {
            Board = new Dictionary<int, GuessPin[]>();

             GuessPin[] pinArr = new GuessPin[Columns];

            for ( int i = 0; i < Row; i++)
            {
                for ( int j = 0; j < Columns; j++)
                {

                    pin = new GuessPin();
                    pinArr[j] = (GuessPin) pin;
                }

                Board.Add(i, pinArr );

            }
            return Board;
        }

        // HintPin from constructor

        internal Dictionary<int, HintPin[]> mapper( HintPin pin, Dictionary<int, HintPin[]> Board ) 
        {
            Board = new Dictionary<int, HintPin[]>();

             HintPin[] pinArr = new HintPin[Columns];

            for ( int i = 0; i < Row; i++)
            {
                for ( int j = 0; j < Columns; j++)
                {

                    pin = new HintPin();
                    pinArr[j] = (HintPin) pin;
                }

                Board.Add(i, pinArr );

            }
            return Board;
        }

        // Guess Pin from List
        internal Dictionary<int, GuessPin[]> mapper ( List<PinColor> convertedPinList, Dictionary<int, GuessPin[]> guessBoard, out int counter, out bool isGuessValid) 
        {
            Pin pin;
            counter = GuessCounter;
            isGuessValid = IsGuessValid;
            GuessPin[] pinArr = new GuessPin[convertedPinList.Count];

            for (int i = 0; i < convertedPinList.Count; i++)
            {
                if ((convertedPinList[i] != PinColor.Red && convertedPinList[i] != PinColor.White) && convertedPinList.Count == Columns)
                {
                    Console.WriteLine("IN here");
                    pin = new GuessPin();
                    pin.Color = convertedPinList[i];
                    pinArr[i] = (GuessPin) pin;
                    isGuessValid = true;
                }
                else
                {
                    Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(System.Drawing.Color.DarkRed));
                    isGuessValid = false;
                }
            }

            if(isGuessValid)
            {
                guessBoard[Row - counter] =  pinArr;
                counter--;
            }

            return guessBoard;
        }

        // Hint Pin from List

        internal Dictionary<int, HintPin[]> mapper ( List<PinColor> convertedPinList, Dictionary<int, HintPin[]> hintBoard,int counter) 
        {
           Pin pin;

            HintPin[] pinArr = new HintPin[convertedPinList.Count];

            for (int i = 0; i < convertedPinList.Count; i++)
            {
                pin = new HintPin();
                pin.Color = convertedPinList[i];
                pinArr[i] = (HintPin) pin;
            }
                hintBoard.Add(Row - counter, pinArr);
            
            return hintBoard;
        
        }


        
    }
}
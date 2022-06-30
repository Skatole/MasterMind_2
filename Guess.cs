using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    class Guess : PinMapper, IInputValidator, IPinConverter
    {

        private Pin _guessPin;
        private Dictionary<int, GuessPin[]> _guessBoard;
        internal Dictionary<int, GuessPin[]> GuessBoard { get => _guessBoard; set => _guessBoard = value; }
        private Array allPin = Enum.GetValues(typeof(PinColor));
        private List<(PinColor Name, char Value)> convertedGuessPins;
        private bool isGuessValid;
    

        internal Guess()
        {
            _guessBoard = new Dictionary<int, GuessPin[]>();
            _guessPin = new GuessPin();
            _guessBoard = mapper((GuessPin)_guessPin, _guessBoard);
            convertedGuessPins = new List<(PinColor Name, char Value)>();
            isGuessValid = false;

        }

        


        // private Dictionary<int, GuessPin[]> initialiseNoneGuessBoard()
        // {
        //     GuessPin[] guessNone = new GuessPin[Columns];

        //     for ( int i = 0; i < Row; i++)
        //     {
        //         for ( int j = 0; j < Columns; j++)
        //         {

        //             guessPin = new GuessPin();
        //             guessNone[j] = (GuessPin) guessPin;
        //         }

        //         _guessBoard.Add(i, guessNone );

        //     }
        //     return GuessBoard;
        // }
    }
}
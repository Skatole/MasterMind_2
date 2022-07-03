using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    class Hint : PinMapper
    {
        Pin hintPin;
        internal Dictionary<int, HintPin[]>? _hintBoard;
        private Array allPin = Enum.GetValues(typeof(PinColor));
        internal Dictionary<int, HintPin [ ]>? HintBoard { get => _hintBoard; set => _hintBoard = value; }


        public Hint ( )
        {
            _hintBoard = new Dictionary<int, HintPin [ ]>();
            hintPin = new HintPin();
            _hintBoard = mapper(( HintPin ) hintPin, HintBoard);
           
        }




        internal Dictionary<int, HintPin [ ]> GenerateHint ( Guess guess, Solution solution, bool isGuessValid )
        {
            if (isGuessValid)
            {
                for ( int i = 0; i < guess.GuessBoard [ Row - GuessCounter ].Length; i++ )
                {
                    foreach ( var sol in solution.Sol )
                    {
                       if ( guess.GuessBoard [ Row - GuessCounter ] [ i ].Color == sol)
                        {
                            hintPin.Color = (PinColor) HintColor.In;
                            _hintBoard = mapper((HintPin) hintPin, _hintBoard, isGuessValid);
                        }
                       else
                        {
                            hintPin.Color = (PinColor) HintColor.None;
                        }
                    }


                    hintPin.Color =  guess.GuessBoard [ Row - GuessCounter ] [ i ].Color == solution.Sol [ i ] ? hintPin.Color = (PinColor) HintColor.InPlace : hintPin.Color;


                    _hintBoard = mapper((HintPin) hintPin, _hintBoard, isGuessValid);
                }

                Console.WriteLine(" \n HintBoard");
                foreach ( var item in _hintBoard )
                {
                    Console.WriteLine(item.Key + " : ");

                    foreach ( var val in item.Value )
                    {
                        Console.Write(val.Color + " , ");
                    }
                }
            }

            return _hintBoard;
        }
    }
}
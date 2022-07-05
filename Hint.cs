using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind_Project_2
{
    class Hint : PinMapper
    {
        private HintPin hintPin;
        private Dictionary<int, GuessColor> memory = new Dictionary<int, GuessColor>();
        internal Dictionary<int, HintPin[]>? _hintBoard;
        private Array allPin = Enum.GetValues(typeof(PinColor));
        internal Dictionary<int, HintPin [ ]>? HintBoard { get => _hintBoard; set => _hintBoard = value; }


        public Hint ( )
        {
            _hintBoard = new Dictionary<int, HintPin [ ]>();
            hintPin = new HintPin();
            _hintBoard = mapper(( HintPin ) hintPin, HintBoard);

        }




        internal Dictionary<int, HintPin [ ]> GenerateHint ( Guess guess, Solution solution )
        {
                HintPin[] rowOfHintPins = new HintPin[guess.GuessBoard [ Row - GuessCounter ].Length];
                // Seed one row of hints with empty pins 
                for ( int i = 0; i < guess.GuessBoard [ Row - GuessCounter ].Length; i++ )
                {
                    rowOfHintPins [ i ] = new HintPin(HintColor.None);
                }
                //Seed memory

                memory = CreateShortTermMemory(solution.Sol);

                foreach ( var item in guess.GuessBoard [ Row - GuessCounter ].Select(( value, i ) => new { value, i }) )
                {
                    if ( guess.GuessBoard [ Row - GuessCounter ] [ item.i ].Color == memory [ item.i ] )
                    {
                        rowOfHintPins [ item.i ] = new HintPin(HintColor.InPlace);
                        memory [ item.i ] = GuessColor.None;
                    }
                }
                foreach ( var item in guess.GuessBoard [ Row - GuessCounter ].Select(( value, i ) => new { value, i }) )
                {
                    foreach ( var sol in solution.Sol.Select(( value, i ) => new { value, i }) )
                    {
                        if ( guess.GuessBoard [ Row - GuessCounter ] [ item.i ].Color == memory [ sol.i ] )
                        {
                            rowOfHintPins [ item.i ] = new HintPin(HintColor.In);
                            memory [ sol.i ] = GuessColor.None;
                        }
                    }
                }

                _hintBoard [ Row - GuessCounter ] = rowOfHintPins;
                memory.Clear();

            return _hintBoard;
        }
    }
}
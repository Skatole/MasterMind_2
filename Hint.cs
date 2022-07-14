using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind_Project_2
{
    class Hint : PinMapper
    {
        private HintPin hintPin;
        private List<GuessColor> memory = new List<GuessColor>();
        internal Dictionary<int, HintPin[]>? _hintBoard;
        private Array allPin = Enum.GetValues(typeof(PinColor));
        internal Dictionary<int, HintPin [ ]>? HintBoard { get => _hintBoard; set => _hintBoard = value; }
        private int _in;
        private int _inPlace;
        internal int In { get => _in; set => _in = value; }
        internal int InPlace { get => _inPlace; set => _inPlace = value; }

        public Hint ()
        {
            _hintBoard = new Dictionary<int, HintPin [ ]>();
            hintPin = new HintPin();
            _hintBoard = mapper(( HintPin ) hintPin, HintBoard);
        }

        public Hint( int Row, int Columns) : base(Row, Columns)
        {
            _hintBoard = new Dictionary<int, HintPin [ ]>();
            hintPin = new HintPin();
            _hintBoard = mapper(( HintPin ) hintPin, HintBoard);
        }

        internal Dictionary<int, HintPin [ ]> GenerateHint ( Guess guess, Solution solution, ref int guessCounter )
        {
            // Local hint Copy:
            HintPin[] hintPinArray = new HintPin[ guess.GuessBoard[ guessCounter ].Length ];
            Array.Copy(_hintBoard[ guessCounter ], hintPinArray, _hintBoard[ guessCounter ].Length );

            In = 0;
            InPlace = 0;

            // LOCAL MEMORY CREATION FOR DELETEING THE CHECKED PINS.
            GuessColor[] sMemory = new GuessColor[ solution.Sol.Length ];
            GuessColor[] gMemory = new GuessColor[ guess.GuessBoard[ guessCounter ].Length ];

            // Solution + Guess memory seed:
            Array.Copy( solution.Sol, sMemory, solution.Sol.Length );

            for (int i = 0; i < guess.GuessBoard[ guessCounter ].Length; i++)
            {
                gMemory[i] = guess.GuessBoard[ guessCounter ][i].Color;
            }
            
            // Red + WHite Dot determination:
            for (int i = 0; i < solution.Sol.Length; i++)
            {
               if (gMemory[i] == sMemory[i])
               {
                   InPlace++;
                   gMemory[i] = GuessColor.None;
                   sMemory[i] = GuessColor.None;
               }
            }

            for (int j = 0; j < solution.Sol.Length; j++)
            {
                if (sMemory[j] != GuessColor.None )
                {
                    int position = Array.IndexOf(gMemory, sMemory[j]);
                    if ( position >= 0 )
                    {
                        In++;
                        gMemory[position] = GuessColor.None;
                    }
                }
            }

            _hintBoard[ guessCounter ] = Scramble(mapper(InPlace, In, hintPinArray));

            return _hintBoard;
        }
    }
}
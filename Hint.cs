using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind_Project_2
{
    class Hint : PinMapper
    {
        private HintPin hintPin;
        private GuessColor[] memory = new GuessColor[Columns];
        internal Dictionary<int, HintPin[]>? _hintBoard;
        private Array allPin = Enum.GetValues(typeof(PinColor));
        internal Dictionary<int, HintPin [ ]>? HintBoard { get => _hintBoard; set => _hintBoard = value; }
        private int _in;
        private int _inPlace;
        internal int In {get => _in; set => _in = value; }
        internal int InPlace { get => _inPlace; set => _inPlace = value; }


        public Hint ( )
        {
            _hintBoard = new Dictionary<int, HintPin [ ]>();
            hintPin = new HintPin();
            _hintBoard = mapper(( HintPin ) hintPin, HintBoard);
        }




        // internal Dictionary<int, HintPin [ ]> GenerateHint ( Guess guess, Solution solution )
        // {
        //         HintPin[] rowOfHintPins = new HintPin[guess.GuessBoard [ Row - GuessCounter ].Length];
        //         // Seed one row of hints with empty pins 
        //         for ( int i = 0; i < guess.GuessBoard [ Row - GuessCounter ].Length; i++ )
        //         {
        //             rowOfHintPins [ i ] = new HintPin(HintColor.None);
        //         }
        //         //Seed memory

        //         memory = CreateShortTermMemory(solution.Sol);

        //         foreach ( var item in guess.GuessBoard [ Row - GuessCounter ].Select(( value, i ) => new { value, i }) )
        //         {
        //             if ( guess.GuessBoard [ Row - GuessCounter ] [ item.i ].Color == memory [ item.i ] )
        //             {
        //                 rowOfHintPins [ item.i ] = new HintPin(HintColor.InPlace);
        //                 memory [ item.i ] = GuessColor.None;
        //             }
        //         }
        //         foreach ( var item in guess.GuessBoard [ Row - GuessCounter ].Select(( value, i ) => new { value, i }) )
        //         {
        //             foreach ( var sol in solution.Sol.Select(( value, i ) => new { value, i }) )
        //             {
        //                 if ( guess.GuessBoard [ Row - GuessCounter ] [ item.i ].Color == memory [ sol.i ] )
        //                 {
        //                     rowOfHintPins [ item.i ] = new HintPin(HintColor.In);
        //                     memory [ sol.i ] = GuessColor.None;
        //                 }
        //             }
        //         }
                

        //         rowOfHintPins = Scramble(rowOfHintPins);

        //         _hintBoard [ Row - GuessCounter ] = rowOfHintPins;

        //     return _hintBoard;
        // }

        internal Dictionary<int, HintPin[]> GenerateHint2 (Guess guess, Solution solution)
        {

            In = 0;
            InPlace = 0;

            GuessColor[] sMemory = new GuessColor[solution.Sol.Length];
            List<GuessPin> gMemory = CreateShortTermMemory(guess.GuessBoard[ Row - GuessCounter ]);

            Console.WriteLine("Solution: ");
            for ( int i = 0; i < solution.Sol.Length; i++ )
            {
                sMemory [ i ] = solution.Sol [ i ];
                Console.WriteLine(solution.Sol [i]);
            }

            // Red 
            foreach (var item in gMemory.Select( (value, i ) => new { value, i}))
            {   
                int position = Array.IndexOf(sMemory, item.value.Color);
                System.Console.WriteLine("INDEX:  " + item.i + " POSITION IN BLACK: " + position);
                if (item.i == position && position >= 0)    
                {
                    System.Console.WriteLine(   "In RED" );
                    InPlace++;
                    sMemory[ item.i ] = GuessColor.None;
                    gMemory [ item.i ] = new GuessPin(GuessColor.None);

                }
            }

            // White
            foreach (var item in gMemory.Select( (value, i ) => new { value, i}))
            {
                int position = Array.IndexOf(sMemory, item.value.Color);
                System.Console.WriteLine("INDEX:  " + item.i  + " POSITION IN WHITE: " + position );

                if (position >= 0)    
                {
                    System.Console.WriteLine(   "In White" );
                    In++;
                    sMemory[ item.i ] = GuessColor.None;
                }
            }

            System.Console.WriteLine(" ALL IN ALL: " + " WHITE: " + In + " RED: " + InPlace);

            _hintBoard[ Row - GuessCounter ] = Scramble(mapper(InPlace, In, _hintBoard[ Row - GuessCounter ]));

            return _hintBoard;
        }

        // internal Dictionary<int, HintPin[]> GiveHint( Guess guess, Solution solution)
        // {
        //     _inPlace = 0;
        //     _in = 0;
        //     memory = CreateShortTermMemory(solution.Sol);

        //     foreach (var item in guess.GuessBoard[ Row - GuessCounter].Select( (value, i ) => new { value, i }))
        //     {
        //         int position = Array.IndexOf(memory, item.value.Color);
        //         System.Console.WriteLine(" Position: " + position + " item.i: " + item.i);

        //         if(position >= 0)
        //         {
        //             if(item.i == position) 
        //             {
        //                 InPlace++;
        //                 // _hintBoard[ Row - GuessCounter ][item.i] = new HintPin( HintColor.InPlace );
        //                 memory[item.i] = GuessColor.None;
        //                 System.Console.WriteLine("INRED " + " MEMORY: " + memory[item.i]);
        //             }
        //             else 
        //             { 
        //                 In++;
        //                 // _hintBoard[ Row - GuessCounter ][item.i] = new HintPin( HintColor.In );
        //                 memory[position] = GuessColor.None;
        //                 System.Console.WriteLine("INWHITE" + " MEMORY: " + memory[item.i]);
        //             }

        //         }
        //     }
            
            
        //     _hintBoard[ Row - GuessCounter ] = Scramble(mapper(InPlace, In, HintBoard[ Row - GuessCounter ]));
        //     return _hintBoard;
        // }
    }
}
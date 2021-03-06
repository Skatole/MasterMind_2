using MasterMind_Project_2.Interfaces;

namespace MasterMind_Project_2
{
    public abstract class PinMapper : Pin
    {

        private int _rows;
        private int _columns;
        private IConfig _config;

        internal PinMapper(IConfig config) : base(config)
        {
            _config = config;
            _rows = config.Rows;
            _columns = config.Columns;

        }

        // Guess Pin from constructor
        internal Dictionary<int, GuessPin [ ]> mapper ( GuessPin pin, Dictionary<int, GuessPin [ ]> Board )
        {

            GuessPin[] pinArr = new GuessPin[_columns];

            for ( int i = 0; i < _rows; i++ )
            {
                for ( int j = 0; j < _columns; j++ )
                {
                    pin = new GuessPin(_config);
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

                    pin = new HintPin(_config);
                    pinArr [ j ] = pin;
                }

                Board.Add(i, pinArr);

            }
            return Board;
        }

        // Guess Pin from List
        internal Dictionary<int, GuessPin [ ]> mapper ( List<GuessPin> convertedPinList, Dictionary<int, GuessPin [ ]> guessBoard, ref int guessCounter, ref bool isGuessValid )
        {
            GuessPin[] pinArr = new GuessPin[_columns];

            for ( int i = 0; i < Columns; i++ )
            {
                if ( isGuessValid && convertedPinList.Count == Columns )
                {
                    pinArr [ i ] = convertedPinList [ i ];
                }
                else
                {
                    isGuessValid = false;
                    pinArr[ i ] = new GuessPin(_config);
                }
            }                

            guessBoard [ guessCounter ] = pinArr;

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
                HintPin temp = new HintPin(_config);
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
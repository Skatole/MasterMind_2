using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Enums;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.Interfaces.Board;

namespace MasterMind_Project_2.GameBoard
{
    public class Hint : PinMapper, IHint
    {
        public IPin[] HintPins { get; set; }
        public override Dictionary<int, IPin[]> Board { get; set; }
        public int In { get; set; }
        public int InPlace { get; set; }

        public Hint(IConfig config) : base(config)
        {
            HintPins = new HintPin[Config.Columns];
            Board = new Dictionary<int, IPin[]>();
            AddToBoard();
        }

        public Dictionary<int, IPin[]> GenerateHint(IGuess guess, ISolution solution)
        {
            // Local hint Copy:
            Array.Copy(Board[GuessCounter], HintPins, Board[GuessCounter].Length);

            In = 0;
            InPlace = 0;

            // LOCAL MEMORY CREATION FOR DELETEING THE CHECKED PINS.
            GuessColor[] sMemory = new GuessColor[solution.Board[Config.Rounds].Length];
            GuessColor[] gMemory = new GuessColor[guess.Board[GuessCounter].Length];

            // Solution + Guess memory seed:

            for (int j = 0; j < solution.Board[Config.Rounds].Length; j++)
            {
                sMemory[j] = (GuessColor) solution.Board[Config.Rounds][j].Color;
            }

            for (int i = 0; i < guess.Board[GuessCounter].Length; i++)
            {
                gMemory[i] = (GuessColor)guess.Board[GuessCounter][i].Color;
            }

            // Red + WHite Dot determination:
            for (int i = 0; i < solution.Board[Config.Rounds].Length; i++)
            {
                if (gMemory[i] == sMemory[i])
                {
                    InPlace++;
                    gMemory[i] = GuessColor.None;
                    sMemory[i] = GuessColor.None;
                }
            }

            for (int j = 0; j < solution.Board[Config.Rounds].Length; j++)
            {
                if (sMemory[j] != GuessColor.None)
                {
                    int position = Array.IndexOf(gMemory, sMemory[j]);
                    if (position >= 0)
                    {
                        In++;
                        gMemory[position] = GuessColor.None;
                    }
                }
            }
            Board[GuessCounter] = solution.Board[Config.Rounds].Length > 1 ? Scramble(AddToBoard(InPlace, In, HintPins)) : AddToBoard(InPlace, In, HintPins);
            return Board;
        }

        /* 
         * Fill Board with empty pins:
         */

        public override Dictionary<int, IPin[]> AddToBoard()
        {
            for (int i = 0; i < Config.Rows; i++)
            {
                Board[i] = HintPins;
            }
            return Board;
        }

        /*
         * Add to the Board from player imput:
         */

        public override Dictionary<int, IPin[]> AddToBoard(IConvertable convertedInput)
        {

            for (int j = 0; j < convertedInput.convertedPins.Length; j++)
            {
                HintPins[j] = (HintPin)convertedInput.convertedPins[j];
            }

            Board[GuessCounter] = HintPins;

            return Board;

        }

        /* 
         * Map the Generated input into the Board:
         */

        public IPin[] AddToBoard(int InPlace, int In, IPin[] BoardRow)
        {

            for (int i = 0; i < InPlace; i++)
            {
                BoardRow[i] = new HintPin(HintColor.InPlace);
            }

            for (int j = InPlace; j < In + InPlace; j++)
            {
                BoardRow[j] = new HintPin(HintColor.In);
            }

            return BoardRow;
        }

        /* 
         * Scrable the generated imput
         */

        public IPin[] Scramble(IPin[] oneRow)
        {
            List<int> indexMemory = new List<int>();
            Random random = new Random((int)DateTime.Now.Ticks);

            while (indexMemory.Count < oneRow.Length)
            {
                int randIndex = random.Next(oneRow.Length);
                HintPin temp = new HintPin();
                for (int i = 0; i < oneRow.Length; i++)
                {
                    if (!indexMemory.Contains(randIndex) && i != randIndex)
                    {
                        indexMemory.Add(randIndex);
                        temp = (HintPin)oneRow[i];
                        oneRow[i] = oneRow[randIndex];
                        oneRow[randIndex] = temp;

                    }
                }
            }

            return oneRow;
        }
    }
}
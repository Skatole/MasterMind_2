namespace MasterMind_Project_2
{
    public static class Sequencer
    {
        // PVC default:
        internal static Board StartingSequence()
        {
            Board defaultBoard = new Board(10, 4);
            defaultBoard.Solution = new Solution();
            defaultBoard.Guess = new Guess();
            defaultBoard.Hint = new Hint();

            return defaultBoard;
        }

        internal static Board StartingSequence((int Row, int Column) values)
        {
            Board customBoard = new Board(values.Row, values.Column);
            customBoard.Solution = new Solution(values.Row, values.Column);
            customBoard.Guess = new Guess(values.Row, values.Column);
            customBoard.Hint = new Hint(values.Row, values.Column);

            return customBoard;
        }
    }
}
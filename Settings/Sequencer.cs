namespace MasterMind_Project_2
{
    public static class Sequencer
    {
        // PVC default:
        internal static Board StartingSequence()
        {
            Board defaultBoard = new Board();
            defaultBoard.Permutations = new Permutations(false);
            defaultBoard.Solution = new Solution(false);
            defaultBoard.Guess = new Guess();
            defaultBoard.Hint = new Hint();

            return defaultBoard;
        }

        internal static Board StartingSequence( bool isNoneallowed )
        {
            Board customBoard = new Board(isNoneallowed);
            customBoard.Permutations = new Permutations(isNoneallowed);
            customBoard.Solution = new Solution(isNoneallowed);
            customBoard.Guess = new Guess();
            customBoard.Hint = new Hint();
            return customBoard;
        }

        internal static Board StartingSequence((int Row, int Column, bool isNoneAllowed) values)
        {
            Board customBoard = new Board(values.Row, values.Column, values.isNoneAllowed);
            customBoard.Permutations = new Permutations(values.Row, values.Column, values.isNoneAllowed);
            customBoard.Solution = new Solution(values.Row, values.Column, values.isNoneAllowed);
            customBoard.Guess = new Guess(values.Row, values.Column, values.isNoneAllowed);
            customBoard.Hint = new Hint(values.Row, values.Column, values.isNoneAllowed);

            return customBoard;
        }
    }
}
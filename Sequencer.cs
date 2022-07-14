namespace MasterMind_Project_2
{
    public static class Sequencer
    {
        // PVC default:
        internal static Board DefaultStartingSequence()
        {
            Board defaultBoard = new Board();
            defaultBoard.Solution = new Solution();
            defaultBoard.Guess = new Guess();
            defaultBoard.Hint = new Hint();

            return defaultBoard;
        }
    }
}
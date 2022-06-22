namespace MasterMind_Project_2
{
    class Guess : GuessPin
    {

        internal Dictionary<int, List<GuessPin>> GuessBoard;



        public Guess()
        {
            GuessBoard = new Dictionary<int, List<GuessPin>>();

        }
    }
}
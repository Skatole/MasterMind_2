namespace MasterMind_Project_2
{
    class Hint : PinMapper
    {
        Pin hintPin;
        internal Dictionary<int, HintPin[]> _hintBoard;
        private Array allPin = Enum.GetValues(typeof(PinColor));
        internal Dictionary<int, HintPin[]> HintBoard { get; set;}


        public Hint()
        {
            _hintBoard = new Dictionary<int, HintPin[]>();
            hintPin = new HintPin();
            _hintBoard = mapper((HintPin) hintPin, HintBoard);
        }

        
        
    }
}
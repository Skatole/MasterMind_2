namespace MasterMind_Project_2
{
    internal class Pin : Board
    {

        private PinColor _color;
        internal string shape { get; set; }
        internal PinColor Color { get => _color; set => _color = value; }

        internal Pin()
        {
            _color = PinColor.None;
            shape = string.Empty;
        }

        internal Pin(int Row, int Columns, bool isNoneAllowed) : base( Row, Columns, isNoneAllowed)
        {
            _color = PinColor.None;
            shape = string.Empty;
        }

        internal Pin(PinColor color)
        {
            _color = color;
            shape = string.Empty;
        }

        internal Pin(PinColor color, int Rows, int Columns, bool isNoneAllowed) : base(Rows, Columns, isNoneAllowed)
        {
            _color = color;
            shape = string.Empty;
        }


        public override string ToString()
        {
            return _color.ToString();
        }
    }

}
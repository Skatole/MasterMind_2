namespace MasterMind_Project_2
{
    internal class Pin : Board
    {

        private PinColor _color;

        internal PinColor Color { get => _color; set => _color = value; }

        internal Pin()
        {
            _color = PinColor.None;
        }

        internal Pin(PinColor color)
        {
            _color = color;
        }

        internal string shape { get; set; }

        public override string ToString()
        {
            return _color.ToString();
        }
    }

}
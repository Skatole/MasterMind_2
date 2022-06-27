namespace MasterMind_Project_2
{
    internal class Pin : Board
    {

        internal PinColor _color;

        internal Pin()
        {
            _color = PinColor.None;
        }

        internal Pin(PinColor color)
        {
            _color = color;
        }

        internal PinColor color { get; set; }
        internal string shape { get; set; }

        public override string ToString()
        {
            return color.ToString();
        }
    }

}
namespace MasterMind_Project_2
{
    internal class Pin : Board
    {

        internal PinColor _color;
        internal string _shape = "o";

        internal Pin()
        {
            _color = PinColor.None;
        }

        internal Pin(PinColor color, string shape)
        {
            _color = color;
            _shape = shape;
        }

        internal PinColor color { get; set; }
        internal string shape { get; set; }

        public override string ToString()
        {
            return color.ToString() + " : " + shape.ToString();
        }
    }

}
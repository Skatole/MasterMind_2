namespace MasterMind_Project_2
{
    internal class GuessPin : Pin
    {
        internal PinColor Color { get; set; }
        public string Shape { get; set; }





        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public GuessPin(PinColor c, string s) : base(c, s)
        {
            Color = c;
            Shape = s;
        }

        public GuessPin(PinColor c)
        {
            Color = c;
        }

        public override bool Equals(object? obj)
        {
            return obj is GuessPin pin &&
                   Color == pin.Color &&
                   Shape == pin.Shape;
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
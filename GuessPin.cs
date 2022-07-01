namespace MasterMind_Project_2
{
    internal class GuessPin : Pin
    {

        private GuessColor _color;
        internal new GuessColor Color { 
            get => _color; 
            set 
            {
                if(value.GetType() == typeof(PinColor))
                {
                    _color = (GuessColor) value;
                } else if(value.GetType() == typeof(GuessColor))
                {
                    _color = value;
                } else
                {
                    System.Console.WriteLine("Invalid Color type. Unable to cast. \n GuessPins can only be PinColor or GuessColor typed.");
                }
            }}
        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public GuessPin() : base()
        {
            _color = new GuessColor();
        }

        public GuessPin(PinColor pin) : base(pin)
        {
            Color = (GuessColor) pin;
        }        
        
        // public GuessPin(PinColor c) : base(c)
        // {
        //     Color = c;
        // }
    }
}
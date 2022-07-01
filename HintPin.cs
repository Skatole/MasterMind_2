namespace MasterMind_Project_2
{
    internal class HintPin : Pin
    {

        private HintColor _color;
        internal new HintColor Color 
        { 
            get => _color;
            set 
            {
                if(value.GetType() == typeof(PinColor))
                {
                    _color = (HintColor) value;
                } else if(value.GetType() == typeof(HintColor))
                {
                    _color = value;
                } else
                {
                    System.Console.WriteLine("Invalid Color type. Unable to cast. \n GuessPins can only be PinColor or HintColor typed.");
                }
            }
        }


        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public HintPin() : base()
        {
            _color = new HintColor();
        }

        public HintPin(PinColor pin) : base(pin)
        {
            Color = (HintColor) pin;
        }

    }
}
namespace MasterMind_Project_2
{
    internal class GuessPin : Pin
    {


        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public GuessPin() : base()
        {
        }

        public GuessPin(PinColor pin) : base(pin)
        {
        }
        
        
        // public GuessPin(PinColor c) : base(c)
        // {
        //     Color = c;
        // }
    }
}
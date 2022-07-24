using MasterMind_Project_2.Interfaces;

namespace MasterMind_Project_2
{
    internal class GuessPin : Pin
    {

        private GuessColor _color;
        internal new GuessColor Color { get =>  _color; set => _color = value; }
        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public GuessPin(IConfig config) : base(config)
        {
            _color = new GuessColor();
            Color =  GuessColor.None;

        }

        public GuessPin(IConfig config, GuessColor pin) : base(config, (PinColor) pin)
        {
            Color = pin;
        }        
        
        // public GuessPin(PinColor c) : base(c)
        // {
        //     Color = c;
        // }
    }
}
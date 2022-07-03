using System.Drawing;

namespace MasterMind_Project_2
{
    internal class HintPin : Pin
    {
        private HintColor _color;
        internal new HintColor Color { get => _color; set => _color = value; }
        


        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public HintPin () : base()
        {
            _color = new HintColor();
            Color =  HintColor.None;
        }

        public HintPin(HintColor pin) : base((PinColor) pin)
        {
            Color = pin;
        }

    }
}
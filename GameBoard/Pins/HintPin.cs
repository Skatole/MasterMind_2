using System.Drawing;

using MasterMind_Project_2.Interfaces;

namespace MasterMind_Project_2.GameBoard.Pins
{
    internal class HintPin : Pin
    {
        private HintColor _color;
        internal new HintColor Color { get => _color; set => _color = value; }
        


        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public HintPin (IConfig config) : base(config)
        {
            _color = new HintColor();
            Color =  HintColor.None;
        }

        public HintPin(IConfig config, HintColor pin) : base(config, (PinColor) pin)
        {
            Color = pin;
        }
   }
}
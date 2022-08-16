using MasterMind_Project_2.Interfaces;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public class Pin
    {

        private PinColor _color;
        internal string shape { get; set; }
        public PinColor Color { get => _color; set => _color = value; }

        public Pin(IConfig config) : base(config)
        {
            _color = PinColor.None;
            shape = string.Empty;
        }
      
        public Pin(IConfig config, PinColor color) : base(config)
        {
            _color = color;
            shape = string.Empty;
        }



        public override string ToString()
        {
            return _color.ToString();
        }
    }

}
using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public class HintPin : Pin
    {
        private HintColor _color;
        public new HintColor Color { get => _color; set => _color = value; }

        public HintPin()
        {
            _color = new HintColor();
            _color = HintColor.None;
        }

        public HintPin(PinColor pin)
        {
            try
            {
                _color = (HintColor)pin;
            } catch (InvalidCastException)
            {
                Console.WriteLine($"A {pin} colored pin can't be a Hint pin.");
                throw new InvalidCastException(); 
            }
        }

        public HintPin(HintColor pin)
        {
            _color = pin;
        }
    }
}
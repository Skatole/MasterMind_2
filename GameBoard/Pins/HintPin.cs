using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public class HintPin : Pin
    {
        private HintColor _color;
        public override PinColor Color { get => (PinColor)_color; set => _color = (HintColor)value; }

        public HintPin()
        {
            _color = new HintColor();
            Color = (PinColor)HintColor.None;
        }

        public HintPin(HintColor pin)
        {
            Color = (PinColor)pin;
        }
    }
}
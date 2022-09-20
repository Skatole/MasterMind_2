using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public class GuessPin : Pin
    {
        private GuessColor _color;
        public override PinColor Color { get => (PinColor)_color; set => _color = (GuessColor)value; }

        public GuessPin()
        {
            _color = new GuessColor();
            Color = (PinColor)GuessColor.None;

        }

        public GuessPin(GuessColor pin)
        {
            Color = (PinColor)pin;
        }
    }
}
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public class SolutionPin: Pin
    {
        private GuessColor _color;
        public override PinColor Color { get => (PinColor)_color; set => _color = (GuessColor)value; }

        public SolutionPin()
        {
            _color = new GuessColor();
            Color = (PinColor)GuessColor.None;

        }

        public SolutionPin(GuessColor pin)
        {
            Color = (PinColor)pin;
        }
    }
}
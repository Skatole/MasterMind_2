using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public class GuessPin : Pin
    {
        private GuessColor _color;
        public new GuessColor Color { get => _color; set => _color = value; }

        public GuessPin()
        {
            _color = new GuessColor();
            _color = GuessColor.None;

        }

        public GuessPin(PinColor pin)
        {
            try
            {
                _color = (GuessColor)pin;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"A {pin} colored pin can't be a Guess pin.");
                throw new InvalidCastException();

            }
        }
    }
}
using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.Interfaces.Board
{
    public interface IConvertable
    {
        public IPin[] convertedPins { get; }
        public IPin[] ConvertGuess(IValidatable validInput);
        public IPin[] ConvertHint(IValidatable validInput);
    }
}

using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.Interfaces.Board
{
    internal interface IConverter
    {
        public IPin Pin { get; set; }
        public List<IPin> Convert(string input, out bool isGuessValid);
    }
}

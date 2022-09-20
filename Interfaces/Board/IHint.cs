using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.GameBoard;

namespace MasterMind_Project_2.Interfaces.Board;
public interface IHint : IMappable
{
    public int In { get; }
    public int InPlace { get; }
    public Dictionary<int, IPin[]> Board { get; }
    public Dictionary<int, IPin[]> GenerateHint(IGuess guess, IMappable solution);
    public IPin[] AddToBoard( int In, int InPlace, IPin[] HintPins );
    public IPin[] Scramble(IPin[] HintRow);

}

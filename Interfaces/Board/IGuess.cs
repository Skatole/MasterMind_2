using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.Interfaces.Board;
public interface IGuess : IMappable
{
    public IPin[] GuessPins { get; }
    public Dictionary<int, IPin[]> GuessBoard { get; }
}

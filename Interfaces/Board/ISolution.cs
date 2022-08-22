using MasterMind_Project_2.Interfaces.Board.Pins;


namespace MasterMind_Project_2.Interfaces.Board;
public interface ISolution : IMappable
{
    public IPin[] SolutionPins { get; set; }

}

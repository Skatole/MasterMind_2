using MasterMind_Project_2.Interfaces.Board.Pins;


namespace MasterMind_Project_2.Interfaces.Board;
public interface ISolution : IMappable
{
    public Dictionary<int, IPin[]> Board { get; set; }

}

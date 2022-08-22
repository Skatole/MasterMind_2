using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.Interfaces.Board;

public interface IPermutable : IMappable
{
    public List<GuessColor[]> AllPermutations { get; }
    public GuessColor[] AllPins { get; }
    public List<GuessColor[]> StandardPermutation();
    public List<GuessColor[]> NoEmptyPinsPermutation();

}

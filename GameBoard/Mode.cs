using MasterMind_Project_2.Enums;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;

namespace MasterMind_Project_2.GameBoard;
public abstract class Mode : IMode
{
    public abstract Modes GameModes { get; set; }
    public abstract void RunGameMode(IInput userInput);
}

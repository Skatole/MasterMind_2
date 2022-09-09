using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.Interfaces;
public interface IInput
{
    public string ConsoleInput { get; set; }
    public IPin[] VerifyGuessTypeInput();
    public IPin[] VerifyHintTypeInput();
}

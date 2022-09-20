using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.Interfaces;
public interface IInput
{
    public string ConsoleInput { get; set; }
    public IPin[] convertedInput { get; set; }
    public IPin[] VerifyGuessTypeInput(string input);
    public IPin[] VerifyHintTypeInput(string input);
}

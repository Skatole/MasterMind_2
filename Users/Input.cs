using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Board.Pins;
namespace MasterMind_Project_2.Users;
internal class Input : IInput
{
    public string ConsoleInput { get; set; }
    private IValidatable _validatedInput;
    private IConvertable _convertedInput;

    public Input(string consoleInput)
    {
        ConsoleInput = consoleInput;
    }

    public IPin[] VerifyGuessTypeInput ( string input )
    {
        _validatedInput.Validate(ConsoleInput);
        return _convertedInput.ConvertGuess(_validatedInput);
    }

    public IPin[] VerifyHintTypeInput( string input )
    {
        _validatedInput.Validate(ConsoleInput);
        return _convertedInput.ConvertHint(_validatedInput);
    }
}

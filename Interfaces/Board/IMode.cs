using MasterMind_Project_2.Enums;


namespace MasterMind_Project_2.Interfaces.Board;
internal interface IMode
{
    public Modes GameModes { get; set; }
    public void RunGameMode(IInput userInput);
}
                                                                    
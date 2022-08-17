using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.Interfaces.Board.Pins
{
    public interface IPin
    {
        int Id { get => (int)Color; }
        PinColor Color { get; }
        string Shape { get; }

    }
}

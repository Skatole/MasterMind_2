using Pastel;
using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public abstract class Pin : IPin
    {
        private string _shape = "o".Pastel(System.Drawing.Color.LightGray);

        public int Id { get => (int)Color; }
        public string Shape { get => _shape; set => _shape = value; }
        public abstract PinColor Color { get; set; }

    }

}
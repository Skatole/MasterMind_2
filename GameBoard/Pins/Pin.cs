using Pastel;
using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.Enums;
using System.Drawing;

namespace MasterMind_Project_2.GameBoard.Pins
{
    public class Pin : IPin
    {
        private string _shape = "o".Pastel(System.Drawing.Color.LightGray);
        public int Id { get => (int)Color; }
        public string Shape { get => _shape; set => _shape = value; }
        public PinColor Color { get; set; }

        public Pin()
{
            Color = new PinColor();
            Color = PinColor.None;

        }

        public Pin(PinColor newPinColor)
        {
            Color = newPinColor;
        }
    }

}

}
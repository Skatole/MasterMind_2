using MasterMind_Project_2.GameBoard;
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Enums;
using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    internal static class PinShapeDefiner
    {
        internal static IMappable defineShape(IMappable mapedPins)
        {
            foreach (var item in mapedPins.Board)
            {
                foreach (var pin in item.Value.Select((value, i) => new { value, i }))
                {
                    switch (pin.value.Color)
                    {
                        case (PinColor.Black): { pin.value.Shape = "o".Pastel(System.Drawing.Color.Black); break; }
                        case (PinColor.Blue): { pin.value.Shape = "o".Pastel(System.Drawing.Color.Blue); break; }
                        case (PinColor.Cyan): { pin.value.Shape = "o".Pastel(System.Drawing.Color.Cyan); break; }
                        case (PinColor.Green): { pin.value.Shape = "o".Pastel(System.Drawing.Color.Green); break; }
                        case (PinColor.None): { pin.value.Shape = "o".Pastel(System.Drawing.Color.DarkSlateGray); break; }
                        case (PinColor.Purple): { pin.value.Shape = "o".Pastel(System.Drawing.Color.Purple); break; }
                        case (PinColor.Yellow): { pin.value.Shape = "o".Pastel(System.Drawing.Color.Yellow); break; }
                        default: { pin.value.Shape = "o".Pastel(System.Drawing.Color.DarkOliveGreen); break; }
                    }
                }
            }
            return mapedPins;
        }

        internal static IHint defineShape(IHint hint)
        {
            foreach (var item in hint.Board)
            {
                foreach (var pin in item.Value.Select((value, i) => new { value, i }))
                {
                    switch (pin.value.Color)
                    {
                        case (HintColor.In): { pin.value.shape = "o".Pastel(System.Drawing.Color.White); break; };
                        case (HintColor.InPlace): { pin.value.shape = "o".Pastel(System.Drawing.Color.Red); break; };
                        case (HintColor.None): { pin.value.shape = "o".Pastel(System.Drawing.Color.DarkSlateGray); break; };
                        default: { pin.value.shape = "o".Pastel(System.Drawing.Color.DarkOliveGreen); break; }

                    }
                }
            }
            return hint;

        }

        internal static GuessPin[] defineShape(GuessPin[] guessPin)
        {
            foreach (var pin in guessPin.Select((value, i) => new { value, i }))
            {
                switch (pin.value.Color)
                {
                    case (GuessColor.Black): { pin.value.shape = "o".Pastel(System.Drawing.Color.Black); break; }
                    case (GuessColor.Blue): { pin.value.shape = "o".Pastel(System.Drawing.Color.Blue); break; }
                    case (GuessColor.Cyan): { pin.value.shape = "o".Pastel(System.Drawing.Color.Cyan); break; }
                    case (GuessColor.Green): { pin.value.shape = "o".Pastel(System.Drawing.Color.Green); break; }
                    case (GuessColor.None): { pin.value.shape = "o".Pastel(System.Drawing.Color.DarkSlateGray); break; }
                    case (GuessColor.Purple): { pin.value.shape = "o".Pastel(System.Drawing.Color.Purple); break; }
                    case (GuessColor.Yellow): { pin.value.shape = "o".Pastel(System.Drawing.Color.Yellow); break; }
                    default: { pin.value.shape = "o".Pastel(System.Drawing.Color.DarkOliveGreen); break; }
                }
            }
            return guessPin;
        }
    }
}
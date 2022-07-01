namespace MasterMind_Project_2
{
    internal enum PinColor
    {
        None = (int) 'N',
        White = (int) 'W',
        Red = (int) 'R',
        Blue = (int) 'B',
        Green = (int) 'G',
        Yellow = (int) 'Y',
        Purple = (int) 'P',
        Cyan = (int) 'C',
        Black = (int) 'X',
    }

    internal enum HintColor
    {
        None = PinColor.None,
        White = PinColor.White,
        Red = PinColor.Red,
    }

    internal enum GuessColor
    {
        None = PinColor.None,
        Blue = PinColor.Blue,
        Green = PinColor.Green,
        Yellow = PinColor.Yellow,
        Purple = PinColor.Purple,
        Cyan = PinColor.Cyan,
        Black = PinColor.Black

    }


}
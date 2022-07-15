namespace MasterMind_Project_2
{
    internal enum PinColor
    {
        None =  'N',
        White =  'W',
        Red =  'R',
        Blue =  'B',
        Green =  'G',
        Yellow =  'Y',
        Purple =  'P',
        Cyan =  'C',
        Black =  'X',
    }

    internal enum HintColor
    {
        None = PinColor.None,
        In = PinColor.White,
        InPlace = PinColor.Red,
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
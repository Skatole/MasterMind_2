using Pastel;


namespace MasterMind_Project_2.console_display_classes
{
    internal static class PinShapeDefiner
    {
        internal static Guess defineShape ( Guess guess )
        {
            foreach (var item in guess.GuessBoard)
            {

                foreach (var pin in item.Value.Select((value,i) => new { value, i }))
                {
                    switch(pin.value.Color)
                    {
                        case (GuessColor.Black) : {pin.value.shape = "o".Pastel(System.Drawing.Color.Black); break;}
                        case (GuessColor.Blue) : {pin.value.shape = "o".Pastel(System.Drawing.Color.Blue); break;}
                        case (GuessColor.Cyan) : {pin.value.shape = "o".Pastel(System.Drawing.Color.Cyan); break;}
                        case (GuessColor.Green) : {pin.value.shape = "o".Pastel(System.Drawing.Color.Green); break;}
                        case (GuessColor.None) : {pin.value.shape = "o".Pastel(System.Drawing.Color.DarkSlateGray); break;}
                        case (GuessColor.Purple) : {pin.value.shape = "o".Pastel(System.Drawing.Color.Purple); break;}
                        case (GuessColor.Yellow) : {pin.value.shape = "o".Pastel(System.Drawing.Color.Yellow); break;}
                        default : { pin.value.shape = "o".Pastel(System.Drawing.Color.DarkOliveGreen); break;}
                    }
                }

            }
            return guess;
        }

       internal static Hint defineShape ( Hint hint )
        {
            foreach (var item in hint.HintBoard)
            {
                foreach (var pin in item.Value.Select((value,i) => new { value, i }))
                {
                    switch(pin.value.Color)
                    {
                        case (HintColor.In) : {pin.value.shape = "o".Pastel(System.Drawing.Color.White); break;};
                        case (HintColor.InPlace) : {pin.value.shape = "o".Pastel(System.Drawing.Color.Red); break;};
                        case (HintColor.None) : {pin.value.shape = "o".Pastel(System.Drawing.Color.DarkSlateGray); break;};
                        default : { pin.value.shape = "o".Pastel(System.Drawing.Color.DarkOliveGreen); break;}
                        
                    }

                }
            }
            return hint;
        }
    }
}
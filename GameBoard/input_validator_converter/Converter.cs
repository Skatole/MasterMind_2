using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.GameBoard;
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Enums;
using Pastel;

namespace MasterMind_Project_2.GameBoard.InputValidators
{
    public class Converter : IConverter
    {
        private IConfig _config;
        public IPin Pin { get; set; }

        public Converter (IConfig config)
        {
            _config = config;
            Pin = new GuessPin();
        }

        public List<IPin> Convert ( string input, out bool isGuessValid )
        {
            List<IPin> convertedPins = new List<IPin>();
            PinColor[] pinColors = (PinColor[])Enum.GetValues(typeof(PinColor));


            
            return Pin;   
        }

        internal List<GuessPin> NoneNotAllowedConverter(string[] validatedInput, ref bool isGuessValid)
        {
            List<GuessPin> convertedPins = new List<GuessPin>();
            List<bool> validatorList = new List<bool>();
            GuessColor[] Pins = (GuessColor[])Enum.GetValues(typeof(GuessColor));

            for (int i = 0; i < validatedInput.Length; i++)
            {
                for (int j = 0; j < Pins.Length; j++)
                {
                    if (validatedInput[i] == ((char)(int)Pins[j]).ToString()
                        && validatedInput[i] != ((char)GuessColor.None).ToString())
                    {
                        convertedPins.Add(new GuessPin(_config, Pins[j]));
                    }
                }
            }

            if (convertedPins.Count == Columns)
            {
                isGuessValid = true;
            }
            else
            {
                isGuessValid = false;
                Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed));
            }

            return convertedPins;

        }

        internal List<GuessPin> NoneAllowedConverter(string[] validatedInput, ref bool isGuessValid)
        {
            List<GuessPin> convertedPins = new List<GuessPin>();
            List<bool> validatorList = new List<bool>();
            GuessColor[] Pins = (GuessColor[])Enum.GetValues(typeof(GuessColor));

            for (int i = 0; i < validatedInput.Length; i++)
            {
                for (int j = 0; j < Pins.Length; j++)
                {
                    if (validatedInput[i] == ((char)(int)Pins[j]).ToString())
                    {
                        convertedPins.Add(new GuessPin(_config, Pins[j]));
                    }
                }
            }

            if (convertedPins.Count == Columns)
            {
                isGuessValid = true;
            }
            else
            {
                isGuessValid = false;
                Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed));
            }

            return convertedPins;

        }

    }
}

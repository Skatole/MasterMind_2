using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.GameBoard;
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Enums;
using Pastel;

namespace MasterMind_Project_2.GameBoard.InputValidators
{
    public class InputToPinConverter : IConvertable
    {
        private IConfig _config;
        public IPin Pin { get; set; }
        public IPin[] convertedPins { get; set; }


        public InputToPinConverter(IConfig config, IValidatable validInput)
        {
            _config = config;
            Pin = new Pin();
            convertedPins = new Pin[_config.Columns];
        }

        public IPin[] ConvertGuess(IValidatable validInput)
        {
            PinColor[] pins = (PinColor[])Enum.GetValues(typeof(PinColor));

            if (validInput.IsInputValid)
            {

                if (!_config.IsNoneAllowed)
                {
                    for (int i = 0; i < validInput.userInput.Length; i++)
                    {
                        for (int j = 0; j < pins.Length; j++)
                        {
                            if (validInput.userInput[i] == ((char)(int)pins[j]).ToString()
                                && validInput.userInput[i] != ((char)PinColor.None).ToString())
                            {
                                try
                                {
                                    convertedPins[i] = new Pin(pins[j]);
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Invalid Input. Please choose from the given input options.");
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < validInput.userInput.Length; i++)
                    {
                        for (int j = 0; j < pins.Length; j++)
                        {
                            if (validInput.userInput[i] == ((char)(int)pins[j]).ToString())
                            {
                                try
                                {
                                    convertedPins[i] = new Pin(pins[j]);
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Invalid Input. Please choose from the given input options.");
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid Input. Please choose from the given input options.");
                throw new InvalidDataException();
            }

            if (convertedPins.Length == _config.Columns)
            {
                validInput.IsInputValid = true;
            }
            else
            {
                validInput.IsInputValid = false;
                Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed));
            }




            return convertedPins;
        }

        public IPin[] ConvertHint(IValidatable validInput)
        {
            HintColor[] allHints = (HintColor[])Enum.GetValues(typeof(HintColor));

            for (int i = 0; i < validInput.userInput.Length; i++)
            {
                for (int j = 0; j < allHints.Length; j++)
                {
                    if (validInput.userInput[i] == ((char)(int)allHints[j]).ToString())
                    {
                        convertedPins[i] = new Pin((PinColor)allHints[j]);
                    }
                }
            }
            return convertedPins;
        }

        //internal List<GuessPin> NoneNotAllowedConverter(string[] validatedInput, ref bool isGuessValid)
        //{
        //    List<GuessPin> convertedPins = new List<GuessPin>();
        //    List<bool> validatorList = new List<bool>();
        //    GuessColor[] Pins = (GuessColor[])Enum.GetValues(typeof(GuessColor));

        //    for (int i = 0; i < validatedInput.Length; i++)
        //    {
        //        for (int j = 0; j < Pins.Length; j++)
        //        {
        //            if (validatedInput[i] == ((char)(int)Pins[j]).ToString()
        //                && validatedInput[i] != ((char)GuessColor.None).ToString())
        //            {
        //                convertedPins.Add(new GuessPin(_config, Pins[j]));
        //            }
        //        }
        //    }

        //    if (convertedPins.Count == Columns)
        //    {
        //        isGuessValid = true;
        //    }
        //    else
        //    {
        //        isGuessValid = false;
        //        Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed));
        //    }

        //    return convertedPins;

        //}

        //internal List<GuessPin> NoneAllowedConverter(string[] validatedInput, ref bool isGuessValid)
        //{
        //    List<GuessPin> convertedPins = new List<GuessPin>();
        //    List<bool> validatorList = new List<bool>();
        //    GuessColor[] Pins = (GuessColor[])Enum.GetValues(typeof(GuessColor));

        //    for (int i = 0; i < validatedInput.Length; i++)
        //    {
        //        for (int j = 0; j < Pins.Length; j++)
        //        {
        //            if (validatedInput[i] == ((char)(int)Pins[j]).ToString())
        //            {
        //                convertedPins.Add(new GuessPin(_config, Pins[j]));
        //            }
        //        }
        //    }

        //    if (convertedPins.Count == Columns)
        //    {
        //        isGuessValid = true;
        //    }
        //    else
        //    {
        //        isGuessValid = false;
        //        Console.WriteLine("Invalid guess input. Please Choose from the given color input options!".Pastel(System.Drawing.Color.DarkRed));
        //    }

        //    return convertedPins;

        //}

    }
}

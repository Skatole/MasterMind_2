using MasterMind_Project_2.Enums;
using System.Text.RegularExpressions;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces;

using Pastel;

namespace MasterMind_Project_2.GameBoard.InputValidators
{
    public class InputValidator : IValidatable
    {
        private IConfig _config;
        public string[] userInput { get; set; }
        public bool IsInputValid { get; set; }

        public InputValidator(IConfig config)
        {
            _config = config;
            IsInputValid = false;
        }

        private string[] inputMapper(string input)
        {
            userInput = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                userInput[i] = input[i].ToString();
            }

            return userInput;
        }

        public string[] Validate(string input)
        {

            inputMapper(input);

            if (_config.IsNoneAllowed)
            {
                if (userInput.Length <= _config.Columns)
                {
                    for (int i = 0; i < userInput.Length; i++)
                    {

                        string replacedGuess = Regex.Replace(userInput[i], @"[^0-9a-zA-Z]+", "").ToUpper().ToString();
                        userInput[i] = replacedGuess[i].ToString();
                    }
                    IsInputValid = true;
                }
                else
                {
                    Console.WriteLine($"\n Please Only Enter {_config.Columns} characters! \n".Pastel(System.Drawing.Color.DarkRed));
                }
            }
            else
            {

                if (userInput.Length == 0)
                {
                    Console.WriteLine(" \n	No guess Input! \n 	Please choose from the given color input options. \n"
                    .Pastel(System.Drawing.Color.DarkRed));
                }
                else if (userInput.Length > _config.Columns)
                {
                    Console.WriteLine($"\n Please Only Enter {_config.Columns} characters! \n".Pastel(System.Drawing.Color.DarkRed));
                }
                else if (userInput.Length < _config.Columns)
                {
                    Console.WriteLine($"\n This is less than {_config.Columns} characters".Pastel(System.Drawing.Color.DarkRed));
                }
                else if (userInput.Length == _config.Columns)
                {
                    for (int i = 0; i < userInput.Length; i++)
                    {

                        string replacedGuess = Regex.Replace(userInput[i], @"[^0-9a-zA-Z]+", "").ToUpper().ToString();
                        userInput[i] = replacedGuess[i].ToString();
                    }
                    IsInputValid = true;
                }
                else
                {
                    Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(System.Drawing.Color.DarkRed));
                }
            }

            return userInput;
        }
    }
}

using MasterMind_Project_2.Interfaces.Board;

namespace MasterMind_Project_2.GameBoard.InputValidators
{
    internal class Validator : IValidator
    {
        public string[] userInput { get; set; }
        
        public Validator(string input) 
        {
            inputMapper(input);
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

        public string[] Validate()
        {

        }

    }
}

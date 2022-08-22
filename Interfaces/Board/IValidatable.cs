using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2.Interfaces.Board
{
    public interface IValidatable
    {
        public string[] userInput { get; set; }
        public bool IsInputValid { get; set; }
        public string[] Validate(string input);
    }
}

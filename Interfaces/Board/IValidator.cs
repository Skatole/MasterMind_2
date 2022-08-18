using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2.Interfaces.Board
{
    internal interface IValidator
    {
        public string[] userInput { get; set; }
        public string[] Validate();
    }
}

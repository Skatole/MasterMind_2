using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2
{
    internal class Solution : Pin
    {

        private List<(PinColor Name, char CharValue)> _sol;
        internal List<(PinColor Name, char CharValue)> Sol { get => _sol; }



        public Solution()
        {
            _sol = RandomPin.genereateColumnSizedRandom(Columns, 1, 0);
            
        }

    }
}

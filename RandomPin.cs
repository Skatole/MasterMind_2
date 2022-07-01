using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2
{
    static class RandomPin
    {
		// (int)DateTime.Now.Ticks ==> alternate seed
		private static Random _random1 = new Random(Environment.TickCount);
		private static PinColor _rPin = new PinColor();
		private static Array _allPins = Enum.GetValues(typeof(PinColor));
		private static List<(PinColor Name, char CharValue)> _rPinList = new List<(PinColor, char)>();

        internal  static List<(PinColor Name, char CharValue)>  generateRandomPins (int min, int max, int columns)
		{
			 Dictionary< (PinColor Name, char Value), int > _counterDict = new Dictionary<(PinColor Name, char Value), int>();

			for (int i = 0; i < _allPins.Length; i++)
			{

				_rPin = (PinColor) _allPins.GetValue(_random1.Next(min, _allPins.Length - max));
				
				if(_rPin != PinColor.None)
				{
					_rPinList.Add((_rPin, (char) ((int) _rPin)));
				}
				
			}

		

			return _rPinList;
		}
	}
}

using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    static class RandomPin
    {
		// (int)DateTime.Now.Ticks ==> alternate seed
		private static Random _random1 = new Random(Environment.TickCount);
		private static GuessColor _rPin = new GuessColor();
		private static Array _allPins = Enum.GetValues(typeof(GuessColor));
		private static List<GuessColor> _rPinList = new List<GuessColor>();

        internal  static List<GuessColor> generateRandomPins (int min, int max, int columns)
		{
			for (int i = 0; i < _allPins.Length; i++)
			{
				_rPin = ( GuessColor ) _allPins.GetValue(_random1.Next(min, _allPins.Length - max));
				
				if(_rPin != GuessColor.None)
				{
					_rPinList.Add(_rPin);
				}
			}
			return _rPinList;
		}

		
	}
}

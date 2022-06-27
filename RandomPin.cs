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
		private static Random _random2 = new Random((int)DateTime.Now.Ticks);
		private static PinColor _rPin = new PinColor();
		private static Array _allPins = Enum.GetValues(typeof(PinColor));
		private static List<(PinColor, char)> _rPinList = new List<(PinColor, char)>();
		private static List<(PinColor Name, char CharValue)> _slicedList = new List<(PinColor, char)>();
		private static bool inValidPinNumber = false;
			
		private static Dictionary< PinColor, int > counterDict = new Dictionary<PinColor,int>();

        private static List<(PinColor, char)> generateRandomPins (int min, int max)
		{
			for (int i = min; i < _allPins.Length; i++)
			{

				_rPin = (PinColor) _allPins.GetValue(_random1.Next(i, _allPins.Length - max));
				if (!(_rPin.Equals(PinColor.None))) 
				{
					_rPinList.Add((_rPin, (char) ((int) _rPin)));
				}
				
			}

			return _rPinList;
			
		}

		private static void listSeeder (int columns) 
		{
			// seeding
			if (!inValidPinNumber) {
				for (int i = 0; i < columns; i++)
				{
					int indexValue = _random2.Next(_rPinList.Count);
					_slicedList.Add((_rPinList[indexValue].Item1, _rPinList[indexValue].Item2));
				} 
				inValidPinNumber = true;
				Filter(columns);
			}
			

			//checking for triplecates and duplicates




		}

		private static void Filter(int columns) 
		{
			int count = 1;

			foreach (var item in _slicedList)
			{
				
				if(!(counterDict.ContainsKey(item.Name)))
				{
					counterDict.Add(item.Name, count);
				} else
				{
					counterDict[item.Name] = count++;
				}

			
			}

			System.Console.WriteLine("\n" + "\n");

			foreach (var item in counterDict) 
			{
				if (item.Value > 2)
				{
					inValidPinNumber = false;
					listSeeder(columns);
				} 

			}

			

			System.Console.WriteLine("\n");

		}

		public static List<(PinColor Name, char CharValue)> genereateColumnSizedRandom (int columns, int min, int max) 
		{


			generateRandomPins(min, max);
			listSeeder(columns);

			foreach (var item in counterDict)
			{
				System.Console.WriteLine(item.Key + " : " + item.Value );
				
			}

			return _slicedList;

		}	
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2
{
    static class RandomPin
    {

		private static Random _random = new Random((int)DateTime.Now.Ticks);
		private static PinColor _rPin;

        internal static PinColor RPin { get => _rPin; }

        public static PinColor generateRandomPin(int min, int max)
		{
			foreach (var item in Enum.GetValues(typeof(PinColor)))
			{
				_rPin = (PinColor)_random.Next(min,Enum.GetNames(typeof(PinColor)).Length - max);
				
			}

			System.Console.WriteLine(_rPin + " CICA");

			return _rPin;
		}
	}
}

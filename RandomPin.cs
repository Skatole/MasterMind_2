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
			_rPin = (PinColor)_random.Next(min,Enum.GetValues(typeof(PinColor)).Length - max);
			return RPin;
		}
	}
}

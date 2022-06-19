using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

using Pastel;

namespace MasterMind_Project_2
{
	interface InputValidator
	{

					
        bool IsValid { get; set; }

		internal Tuple<List<string>, bool> CleanAndValidate(string guess, int columns, List<PinColor> inputOptions )
		{
			IsValid = false;

			List<string> guestList = new List<string> { };

			if (guess.Length == 0) 
			{ 
				Console.WriteLine(" \n	No guess Input! \n 	Please choose from the given color input options. \n"
				.Pastel(System.Drawing.Color.DarkRed));
			}
			else if (guess.Length != columns)
			{
				Console.WriteLine("\n" + "Please Only Enter 4 characters!".Pastel(System.Drawing.Color.DarkRed) + "\n");
				//guestList.RemoveRange(columns, guestList.Count - columns);
			}
			else
			{
				string replacedGuess = Regex.Replace(guess, @"[^0-9a-zA-Z]+", "").ToUpper();
				for (var i = 0; i < replacedGuess.Length; i++)
				{
					guestList.Add(replacedGuess[i].ToString());
				}
				for (var i = 0; i < guestList.Count; i++)
				{
					if (guestList[i].Split().Any(x => !inputOptions.Contains((PinColor) Enum.Parse(typeof(char), x, true))) 
						|| guestList[i] != "?")
					{
						Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(Color.DarkRed));

					} else
                    {
						IsValid = true;
					}
				}
			}
			return Tuple.Create(guestList, IsValid);
		}
	}
}

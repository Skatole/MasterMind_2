using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

using Pastel;

namespace MasterMind_Project_2
{
	interface IInputValidator
	{

		

		internal Tuple<List<string>, bool> CleanAndValidate(string guess, int columns, int row )
		{

		
			bool IsValid = false;


			List<string> guestList = new List<string> { };

			PinColor[] pinArray = (PinColor[]) Enum.GetValues(typeof(PinColor));

			if (guess.Length == 0) 
			{ 
				Console.WriteLine(" \n	No guess Input! \n 	Please choose from the given color input options. \n"
				.Pastel(System.Drawing.Color.DarkRed));
				IsValid = false;
			}
			else if (guess.Length > columns)
			{
				Console.WriteLine("\n" + "Please Only Enter " + columns +  "characters!".Pastel(System.Drawing.Color.DarkRed) + "\n");
				//guestList.RemoveRange(columns, guestList.Count - columns);
				IsValid = false;
			}
			else if ( guess.Length < columns)
			{
				System.Console.WriteLine("\n This is less than " + columns  + " characters");
			}
			else if ( guess.Length == columns )
			{
				string replacedGuess = Regex.Replace(guess, @"[^0-9a-zA-Z]+", "").ToUpper();
				for (var i = 0; i < replacedGuess.Length; i++)
				{
					guestList.Add(replacedGuess[i].ToString());
				}
				for(int i = 0; i < guestList.Count; i++)
				{
					foreach (var item in pinArray)
					{
						if (guestList[i] == ((char) item).ToString()
							|| guestList.Contains("?"))
						{
							IsValid = true;

						}
					} 
				}
			}
			else
            {
				Console.WriteLine(" \n	Invalid guess input! \n 	Please choose from the given color input options. \n".Pastel(Color.DarkRed));
				IsValid = false;
			}
			return Tuple.Create(guestList, IsValid);
		}
	}
}

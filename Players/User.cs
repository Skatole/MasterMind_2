using Pastel;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Settings;
using MasterMind_Project_2.Binders;
using MasterMind_Project_2.Pins;
using System.Runtime;

using MasterMind_Project_2.Players.Roles;

namespace MasterMind_Project_2.Players
{
    public class User : IUser
    {
        public int Points { get; set; }
        public int Rounds { get; set; }
        public string Name { get; set; }
        public IConfig userConfig { get; set; } = new Config();

        public User( IConfig config )
        {
            Points = 0;
            Rounds = config.Rounds;
        }
        public string GiveInput()
        {
            string? input = Console.ReadLine();
            return input;
        }

        public string Login()
        {
            System.Console.WriteLine("ENTER YOUR NAME: \n");
            string input = Console.ReadLine();
            return input;
            // Its gona be empty for now ==> When DB or mock DB is set then implement.
        }

        public void Register() 
        {
/* THis will be empty for now ==>
 * This app will have a Login Interface and Class that checks if a user exists or not.
 * If not then it will register it else it will log the user in based on the parameters.
 */
        }
        
    }
}
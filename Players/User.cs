using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Settings;

namespace MasterMind_Project_2.Players
{
    public class User : IUser
    {
        public int Points { get; set; }
        public int Rounds { get; set; }
        public string Name { get; set; }

        public Board DrawBoard(IConfig config) 
        {
            Board Board = new Board();
            return Board;
        }

        public void SetSettings()
        {
            Settings = new Settings.Settings();
            
        }

        public void Login()
        {
            // Its gona be empty for now ==> When DB or mock DB is set then implement.
        }


        
    }
}
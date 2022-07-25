using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.console_display_classes;


namespace MasterMind_Project_2.Players.Roles
{
    public class Master : User, IMaster
    {
        public Master(IConfig config) : base(config)
        {

        }
        public void GiveHint()
        {
            throw new NotImplementedException();
        }

        public void TakeGuess()
        {
            throw new NotImplementedException();
        }

    }
}
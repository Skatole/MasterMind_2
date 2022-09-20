using MasterMind_Project_2.Configuration;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Roles;

namespace MasterMind_Project_2.Users
{
    public class User : IUser, IPlayer, IMaster
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public IInput Input { get; set; }
        public IConfig UserCustomConfig { get; set; }

        public User(IConfig config)
        {                               
            Points = 0;
            Name = Login();
            UserCustomConfig = config;
        }
        /* 
         * If you wanna implement new input methods, you should implement it here ==> Also with a PLatfrom mode if statement
         */
        public IInput GiveInput()
        {
            Input.ConsoleInput = Console.ReadLine();
            return Input;
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

        /* ------------------ PLAYER ------------------*/

        public IInput MakeMoveToConsole()
        {
            GiveInput();
            Input.VerifyGuessTypeInput(Input.ConsoleInput);
            return Input;
        }

        /* ------------------ Master ------------------*/
        public IInput MakeHintToConsole()
        {
            GiveInput();
            Input.VerifyHintTypeInput(Input.ConsoleInput);
            return Input;

        }

    }
}
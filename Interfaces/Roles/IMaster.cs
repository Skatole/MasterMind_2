namespace MasterMind_Project_2.Interfaces.Roles
{
    public interface IMaster : IUser
    {
        public IInput MakeHintToConsole();
    }
}
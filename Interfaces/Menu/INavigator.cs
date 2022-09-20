namespace MasterMind_Project_2.Interfaces.Menu
{
    public interface INavigator
    {
        public IConfig Navigate(IUser user, ISettings settings, IConfig config);
    }
}
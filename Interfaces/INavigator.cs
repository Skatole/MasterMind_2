namespace MasterMind_Project_2.Interfaces
{
    public interface INavigator
    {
         public bool IsCustomGame { get; set; }
         public IConfig Navigate ( IUser user, IMenu menu, ISettings settings, IConfig config );
    }
}
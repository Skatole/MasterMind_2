

namespace MasterMind_Project_2.Interfaces
{
    public interface IUser
    {
        public int Points { get; set; }
        public int Rounds { get; set; }
        public string Name { get; set; }

        public IConfig Navigate( INavigator navigator, IMenu menu, ISettings settings, IConfig config );
        public IConfig SetSettings(ISettings settings);
        public string GiveInput();
        public void DecideRole();
        public string Login();
        public void Register();
        
    }
}
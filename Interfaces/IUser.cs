namespace MasterMind_Project_2.Interfaces
{
    public interface IUser
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public IConfig UserCustomConfig { get; set; }
        public string Input { get; set; }                                                        
        public string Login();
        public void Register();
        public string GiveInput();
        public void StartGame();

    }
}
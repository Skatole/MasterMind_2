using MasterMind_Project_2.Pins;

namespace MasterMind_Project_2.Interfaces
{
    public interface IUser
    {
        public int Points { get; set; }
        public int Rounds { get; set; }
        public string Name { get; set; }
        public IConfig userConfig { get; set; }

        public string GiveInput();
        public string Login();
        public void Register();

    }
}
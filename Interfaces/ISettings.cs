namespace MasterMind_Project_2.Interfaces
{
    public interface ISettings
    {
        public IConfig Config { get; set; }
        public void CustomConfig(string input);
        public IConfig OpenSettingSubMenu();

    }
}
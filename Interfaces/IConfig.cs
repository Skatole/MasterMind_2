namespace MasterMind_Project_2.Interfaces
{
    public interface IConfig
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Rounds { get; set; }
        public bool IsNoneAllowed { get; set; }
        public string welcomeRoute { get; }
        public string infoRoute { get; }
    }
}
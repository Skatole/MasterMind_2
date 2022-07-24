namespace MasterMind_Project_2.Interfaces
{
    public interface IUser
    {
        public int Points { get; set; }
        public int Rounds { get; set; }
        public string Name { get; set; }    
        public Board DrawBoard();
        public void SetSettings();
        public void Login();
        
    }
}
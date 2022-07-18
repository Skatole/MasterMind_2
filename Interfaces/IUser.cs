namespace MasterMind_Project_2.Interfaces
{
    public interface IUser
    {
        public int Points { get; set; }
        public void DrawBoard();
        public void SetSettings();
        public void Login();
        
    }
}
namespace MasterMind_Project_2.Interfaces
{
    public interface IMaster : IUser
    {
         internal void GiveHint();
         internal void TakeGuess();
         
    }
}
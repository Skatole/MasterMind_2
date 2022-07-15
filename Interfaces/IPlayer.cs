using MasterMind_Project_2;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2.Interfaces
{
    public interface IPlayer<T>
    {

      public void StartGame();
      public string MakeMove();
      public void TakeHint();
         
    }
}
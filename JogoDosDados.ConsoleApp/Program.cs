using JogoDosDados.ConsoleApp.Entities;
using JogoDosDados.ConsoleApp.Entities.Utils;
namespace JogoDosDados.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mainMenu = true;
            do
            {
                ViewUtils.Headers("MENU-PRINCIPAL");
                ViewWrite.MainMenuOptions();
                string option = Console.ReadLine()!.ToUpper();
                switch (option)
                {
                    case "1":
                        DiceGame.GameStart();
                        break;
                    case "2":
                        DiceGame.GameAbout();
                        break;
                    case "S":
                        mainMenu = false;
                        Console.Clear();
                        ViewWrite.GoodbyeText();
                        break;
                }
            } while (mainMenu);
        }
    }
}

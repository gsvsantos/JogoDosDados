using JogoDosDados.ConsoleApp.Entities;
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
                Console.WriteLine("1 >> Começar a Partida");
                Console.WriteLine("2 >> Sobre o Jogo");
                Console.WriteLine("S >> Fechar Jogo");
                Console.Write("\nOpção: ");
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
                        Console.WriteLine("Adeus (T_T)/");
                        break;
                }
            } while (mainMenu);
        }
    }
}

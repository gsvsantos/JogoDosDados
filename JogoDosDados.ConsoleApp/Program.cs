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
                ViewUtils.PaintWrite("1 >> Começar a Partida\n", ConsoleColor.White);
                ViewUtils.PaintWrite("2 >> Sobre o Jogo\n", ConsoleColor.White);
                ViewUtils.PaintWrite("S >> Fechar Jogo\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\nOpção: ", ConsoleColor.White);
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
                        ViewUtils.PaintWrite("Adeus (T_T)/\n", ConsoleColor.Red);
                        break;
                }
            } while (mainMenu);
        }
    }
}

namespace JogoDosDados.ConsoleApp.Entities.Utils
{
    public class ViewUtils
    {
        public static void PaintWrite(string message, ConsoleColor color = ConsoleColor.DarkGreen)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Headers(string type)
        {
            switch (type)
            {
                case "MENU-PRINCIPAL":
                    Console.Clear();
                    PaintWrite("/==--==--==--==--==--==--==--==--==--==\\\n");
                    PaintWrite("     Boas vindas ao Jogo dos Dados!\n", ConsoleColor.White);
                    PaintWrite("\\==--==--==--==--==--==--==--==--==--==/\n\n");
                    break;
                case "JOGO-DOS-DADOS":
                    Console.Clear();
                    PaintWrite("/==--==--==--==--==--==--==--==--==--==\\\n");
                    PaintWrite("             Jogo dos Dados\n", ConsoleColor.White);
                    PaintWrite("|==--==--==--==--==--==--==--==--==--==|\n");
                    break;
                case "TURNO-USUARIO":
                    PaintWrite("            Turno do Usuário\n", ConsoleColor.White);
                    PaintWrite("\\==--==--==--==--==--==--==--==--==--==/\n\n");
                    break;
                case "TURNO-CPU":
                    PaintWrite("              Turno da CPU\n", ConsoleColor.White);
                    PaintWrite("\\==--==--==--==--==--==--==--==--==--==/\n\n");
                    break;
                case "VENCEDOR":
                    Console.Clear();
                    PaintWrite("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\\n");
                    PaintWrite("                            VENCEDOR\n", ConsoleColor.White);
                    PaintWrite("|==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==|\n");
                    break;
                case "EMPATE":
                    Console.Clear();
                    PaintWrite("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\\n");
                    PaintWrite("                           EMPATE\n", ConsoleColor.White);
                    PaintWrite("|==--==--==--==--==--==--==--==--==--==--==--==--==--==--==|\n");
                    break;
                case "SOBRE":
                    Console.Clear();
                    PaintWrite("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\\n");
                    PaintWrite("                                 > Como o Jogo Funciona <\n", ConsoleColor.White);
                    PaintWrite("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\\n");
                    break;
            }
        }
        public static void PressEnter(string type)
        {
            switch (type)
            {
                case "JOGAR-DADO":
                    PaintWrite("Pressione [Enter] para lançar o dado.\n\n", ConsoleColor.White);
                    Console.ReadKey();
                    break;
                case "TURNO-CPU":
                    PaintWrite("Pressione [Enter] para ver o turno da CPU.", ConsoleColor.White);
                    Console.ReadKey();
                    break;
                case "PROXIMA-RODADA":
                    PaintWrite("Pressione [Enter] para ir à próxima rodada.", ConsoleColor.White);
                    Console.ReadKey();
                    break;
                case "VER-RESULTADO":
                    PaintWrite("Pressione [Enter] para ver o resultado.", ConsoleColor.White);
                    Console.ReadKey();
                    break;
                case "VOLTAR-MENU":
                    PaintWrite("Pressione [Enter] para voltar ao menu principal.", ConsoleColor.White);
                    Console.ReadKey();
                    break;
            }
        }
        public static bool Continue()
        {
            PaintWrite("Deseja jogar novamente? (S/N) ", ConsoleColor.Yellow);
            string optionContinue = Console.ReadLine()!.ToUpper();
            if (optionContinue != "S" && optionContinue != "SIM" && optionContinue != "SI")
            {
                return false;
            }
            return true;
        }

    }
}

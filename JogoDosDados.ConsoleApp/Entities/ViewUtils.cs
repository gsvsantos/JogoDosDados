namespace JogoDosDados.ConsoleApp.Entities
{
    public class ViewUtils
    {
        public static void Headers(string type)
        {
            switch (type)
            {
                case "MENU-PRINCIPAL":
                    Console.Clear();
                    Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
                    Console.WriteLine("     Boas vindas ao Jogo dos Dados!");
                    Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
                    break;
                case "JOGO-DOS-DADOS":
                    Console.Clear();
                    Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
                    Console.WriteLine("             Jogo dos Dados");
                    Console.WriteLine("|==--==--==--==--==--==--==--==--==--==|");
                    break;
                case "TURNO-USUARIO":
                    Console.WriteLine("            Turno do Usuário");
                    Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
                    break;
                case "TURNO-CPU":
                    Console.WriteLine("              Turno da CPU");
                    Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
                    break;
                case "VENCEDOR":
                    Console.Clear();
                    Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                    Console.WriteLine("                            VENCEDOR");
                    Console.WriteLine("|==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==|");
                    break;
                case "EMPATE":
                    Console.Clear();
                    Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                    Console.WriteLine("                           EMPATE");
                    Console.WriteLine("|==--==--==--==--==--==--==--==--==--==--==--==--==--==--==|");
                    break;
                case "SOBRE":
                    Console.Clear();
                    Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                    Console.WriteLine("                                 > Como o Jogo Funciona <");
                    Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                    break;

            }
        }
        public static void PressEnter(string type)
        {
            switch (type)
            {
                case "JOGAR-DADO":
                    Console.Write("Pressione [Enter] para lançar o dado.\n\n");
                    Console.ReadKey();
                    break;
                case "TURNO-CPU":
                    Console.Write("Pressione [Enter] para ver o turno da CPU.");
                    Console.ReadKey();
                    break;
                case "PROXIMA-RODADA":
                    Console.Write("Pressione [Enter] para ir à próxima rodada.");
                    Console.ReadKey();
                    break;
                case "VER-RESULTADO":
                    Console.Write("Pressione [Enter] para ver o resultado.");
                    Console.ReadKey();
                    break;
            }
        }
        public static bool Continue()
        {
            Console.Write("Deseja jogar novamente? (S/N) ");
            string optionContinue = Console.ReadLine()!.ToUpper();
            if (optionContinue != "S" && optionContinue != "SIM" && optionContinue != "SI")
            {
                return false;
            }
            return true;
        }
        public static void PositionStatus(int oldPosition, int result, int position)
        {
            Console.WriteLine("/==--==--==--==--==--==--==\\");
            Console.WriteLine($"  Posição anterior: {oldPosition}");
            Console.WriteLine($"  O dado caiu no número: {result}");
            Console.WriteLine($"  Posição atual: {position}");
            Console.WriteLine("\\==--==--==--==--==--==--==/\n");
        }
    }
}

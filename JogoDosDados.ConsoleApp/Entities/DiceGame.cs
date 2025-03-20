namespace JogoDosDados.ConsoleApp.Entities
{
    public class DiceGame
    {
        public const int endLine = 30;
        public static void GameStart()
        {
            do
            {
                int userPosition = 0;
                int cpuPosition = 0;
                bool hasWinner;

                do
                {
                    MainHeader();
                    userPosition = Player.Turn(userPosition);

                    Console.Write("Pressione [Enter] para ver o turno da CPU...");
                    Console.ReadKey();

                    MainHeader();
                    cpuPosition = CPU.Turn(cpuPosition);
                    hasWinner = ShowResult(userPosition, cpuPosition);
                    if (hasWinner == true)
                        continue;

                    Console.Write("Pressione [Enter] para ir à próxima rodada.");
                    Console.ReadKey();

                } while (hasWinner == false);

                Console.Write("Deseja jogar novamente? (S/N) ");
                string optionContinue = Console.ReadLine()!.ToUpper();
                if (optionContinue != "S" && optionContinue != "SIM" && optionContinue != "SI")
                {
                    Console.WriteLine("Adeus (T_T)/");
                    break;
                }

            } while (true);
        }
        public static void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("             Jogo dos Dados");
            Console.WriteLine("|==--==--==--==--==--==--==--==--==--==|");
        }
        public static int RollDice()
        {
            Random numberGenerator = new Random();
            int result = numberGenerator.Next(1, 7);
            return result;
        }
        public static bool ShowResult(int userPosition, int cpuPosition)
        {
            bool playerWin = Player.CheckWin(userPosition, cpuPosition);
            bool cpuWin = CPU.CheckWin(cpuPosition, userPosition);
            if (playerWin == true)
            {
                Console.Clear();
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine("                            VENCEDOR");
                Console.WriteLine("|==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==|");
                Console.WriteLine($"   Você alcançou a casa {userPosition} e ultrapassou a linha de chegada!!");
                Console.WriteLine("                          VOCÊ VENCEU!");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n");
                return true;
            }
            else if (cpuWin == true)
            {
                Console.Clear();
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine("                            VENCEDOR");
                Console.WriteLine("|==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==|");
                Console.WriteLine($"    CPU alcançou a casa {cpuPosition} e ultrapassou a linha de chegada!");
                Console.WriteLine("                           CPU VENCEU");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n");
                return true;
            }
            else if (userPosition == cpuPosition && userPosition >= endLine && cpuPosition >= endLine)
            {
                Console.Clear();
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine("                           EMPATE");
                Console.WriteLine("|==--==--==--==--==--==--==--==--==--==--==--==--==--==--==|");
                Console.WriteLine($"   Você e a CPU ultrapassaram a linha de chegada juntos!!");
                Console.WriteLine($"                         CPU:  ({cpuPosition})");
                Console.WriteLine($"                         Você: ({userPosition})");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n");
                return true;
            }
            else
                return false;
        }
        public static void GameAbout()
        {
            Console.Clear();
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("                                 > Como o Jogo Funciona <");
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("\n1. Inicie uma nova partida no menu principal.");
            Console.WriteLine("2. O jogo começa com você e a CPU na linha de partida (0).");
            Console.WriteLine("3. Na sua vez, você deverá jogar o dado para descobrir quantas casas você vai andar.");
            Console.WriteLine("4. A CPU jogará seu próprio dado automaticamente.");
            Console.WriteLine("5. Ganhará quem passar a linha de chegada primeiro.");
            Console.WriteLine("6. Em caso de ultrapassarem a linha juntos, ganha quem estiver na maior distância.");
            Console.WriteLine("7. Haverá empate se ambos chegarem na mesma casa superior á linha de chegada.");
            Console.WriteLine("\nRegras Especiais.");
            Console.WriteLine("- Casas especiais podem ajudar avançando casas extras, ou atrapalhar fazendo recuar casas.");
            Console.WriteLine("- Se tirar 6 no dado, o dado irá rodar novamente.");
            Console.WriteLine("\n/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");

            Console.Write("\nPressione [Enter] para voltar ao menu.");
            Console.ReadKey();
        }

    }
}

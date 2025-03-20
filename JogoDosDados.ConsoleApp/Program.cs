using System.Numerics;

namespace JogoDosDados.ConsoleApp
{
    internal class Program
    {
        const int endLine = 30;
        static void Main(string[] args)
        {
            bool mainMenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine("     Boas vindas ao Jogo dos Dados!");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
                Console.WriteLine("1 >> Começar a Partida");
                Console.WriteLine("2 >> Sobre o Jogo");
                Console.WriteLine("S >> Fechar Jogo");
                Console.Write("\nOpção: ");
                string option = Console.ReadLine()!.ToUpper();
                switch (option)
                {
                    case "1":
                        GameStart();
                        break;
                    case "2":
                        GameAbout();
                        break;
                    case "S":
                        mainMenu = false;
                        Console.WriteLine("Adeus (T_T)/");
                        break;
                }
            } while (mainMenu);
        }
        static void GameStart()
        {
            do
            {
                int userPosition = 0;
                int cpuPosition = 0;
                bool hasWinner;

                do
                {
                    MainHeader();
                    userPosition = UserTurn(userPosition);

                    Console.Write("Pressione [Enter] para ver o turno da CPU...");
                    Console.ReadKey();

                    MainHeader();
                    cpuPosition = CPUTurn(cpuPosition);
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
        static void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("             Jogo dos Dados");
            Console.WriteLine("|==--==--==--==--==--==--==--==--==--==|");
        }
        static int UserTurn(int userPosition)
        {
            Console.WriteLine("            Turno do Usuário");
            Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");

            Console.Write("Pressione [Enter] para lançar o dado...\n\n");
            Console.ReadKey();
            int userResult = RollDice();
            int userOldPosition = userPosition;
            userPosition += userResult;

            Console.WriteLine("/==--==--==--==--==--==--==\\");
            Console.WriteLine($"  Posição anterior: {userOldPosition}");
            Console.WriteLine($"  O dado caiu no número: {userResult}");
            Console.WriteLine($"  Posição atual: {userPosition}");
            Console.WriteLine("\\==--==--==--==--==--==--==/\n");

            userPosition = UserLuckyTest(userPosition);

            return userPosition;
        }
        static int UserLuckyTest(int userPosition)
        {
            if (userPosition == 6)
            {
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"     Sorte grande!! Ganho uma rodada extra!");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==/\n");

                int userResult = RollDice();
                userPosition += userResult;

                Console.WriteLine("/==--==--==--==--==--==--==\\");
                Console.WriteLine($"  O dado caiu no número: {userResult}");
                Console.WriteLine($"  Posição atual: {userPosition}");
                Console.WriteLine("\\==--==--==--==--==--==--==/\n");
            }
            if (userPosition == 5 || userPosition == 11 || userPosition == 15 || userPosition == 25)
            {
                Console.WriteLine("/==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"  Você caiu na casa de sorte {userPosition}!!");
                Console.WriteLine("  Avanço extra de 3 casas!");
                Console.WriteLine($"  Posição atual: {userPosition += 3}");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==/\n");
            }
            else if (userPosition == 7 || userPosition == 13 || userPosition == 20)
            {
                Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"  Que azar! Caiu na casa {userPosition}..");
                Console.WriteLine("  Recuo de 2 casas!!");
                Console.WriteLine($"  Posição atual: {userPosition -= 2}");
                Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
            }
            return userPosition;
        }
        static int CPUTurn(int cpuPosition)
        {
            Console.WriteLine("              Turno da CPU");
            Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");

            int cpuResult = RollDice();
            int cpuOldPosition = cpuPosition;
            cpuPosition += cpuResult;

            Console.WriteLine("/==--==--==--==--==--==--==\\");
            Console.WriteLine($"  Posição anterior: {cpuOldPosition}");
            Console.WriteLine($"  O dado caiu no número: {cpuResult}");
            Console.WriteLine($"  Posição atual: {cpuPosition}");
            Console.WriteLine("\\==--==--==--==--==--==--==/\n");

            cpuPosition = CPULuckyTest(cpuPosition);

            return cpuPosition;
        }
        static int CPULuckyTest(int cpuPosition)
        {
            if (cpuPosition == 6)
            {
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"     Sorte grande!! Ganho uma rodada extra!");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==/\n");

                int cpuResult = RollDice();
                cpuPosition += cpuResult;

                Console.WriteLine("/==--==--==--==--==--==--==\\");
                Console.WriteLine($"  O dado caiu no número: {cpuResult}");
                Console.WriteLine($"  Posição atual: {cpuPosition}");
                Console.WriteLine("\\==--==--==--==--==--==--==/\n");
            }
            if (cpuPosition == 5 || cpuPosition == 10 || cpuPosition == 15 || cpuPosition == 25)
            {
                Console.WriteLine("/==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"  CPU caiu na casa de sorte {cpuPosition}!");
                Console.WriteLine("  Avanço extra de 3 casas!");
                Console.WriteLine($"  Posição atual: {cpuPosition += 3}");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==/\n");
            }
            else if (cpuPosition == 7 || cpuPosition == 13 || cpuPosition == 20)
            {
                Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"  Que azar! Caiu na casa {cpuPosition}..");
                Console.WriteLine("  Recuo de 2 casas!!");
                Console.WriteLine($"  Posição atual: {cpuPosition -= 2}");
                Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
            }
            return cpuPosition;
        }
        static bool ShowResult(int userPosition, int cpuPosition)
        {
            bool playerWin = CheckPlayerWin(userPosition, cpuPosition);
            bool cpuWin = CheckCPUWin(cpuPosition, userPosition);
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
        static bool CheckPlayerWin(int userPosition, int cpuPosition)
        {
            if (userPosition >= endLine && userPosition > cpuPosition)
                return true;
            else
                return false;
        }
        static bool CheckCPUWin(int cpuPosition, int userPosition)
        {
            if (cpuPosition >= endLine && cpuPosition > userPosition)
                return true;
            else
                return false;
        }
        static int RollDice()
        {
            Random numberGenerator = new Random();
            int result = numberGenerator.Next(1, 7);
            return result;
        }
        static void GameAbout()
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

namespace JogoDosDados.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int endLine = 30;

            do
            {
                int userPosition = 0;
                int cpuPosition = 0;
                bool onGoing = true;

                do
                {
                    MainHeader();
                    UserTurn();
                    Console.Write("Pressione [Enter] para lançar o dado...\n\n");
                    Console.ReadKey();
                    int userResult = RollDice();
                    userPosition += userResult;
                    Console.WriteLine("/==--==--==--==--==--==--==\\");
                    Console.WriteLine($"  O dado caiu no número: {userResult}");
                    Console.WriteLine("\\==--==--==--==--==--==--==/\n");

                    if (userPosition == 5 || userPosition == 10 || userPosition == 15 || userPosition == 25)
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"  Caiu na casa de sorte {userPosition}!!\n  Avanço extra de 3 casas!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==--==/\n");
                        userPosition += 3;
                    }
                    else if (userPosition == 7 || userPosition == 13 || userPosition == 20)
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"  Que azar! Caiu na casa {userPosition}..\n  Recuo de 2 casas =/");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                        userPosition -= 2;
                    }
                    if (userPosition <= 9)
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"   Você está na casa {userPosition} de {endLine}!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                    }
                    else
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"  Você está na casa {userPosition} de {endLine}!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                    }
                    if (userPosition >= endLine)
                    {
                        MainHeader();
                        Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($" Você alcançou a casa {userPosition} e ultrapassou a linha de chegada!!");
                        Console.WriteLine(" Parabéns!!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n");
                        onGoing = false;
                        continue;
                    }
                    Console.Write("Pressione [Enter] para ver o turno da CPU...");
                    Console.ReadKey();

                    MainHeader();
                    CPUTurn(); 
                    int cpuResult = RollDice();
                    cpuPosition += cpuResult;
                    Console.WriteLine("/==--==--==--==--==--==--==\\");
                    Console.WriteLine($"  O dado caiu no número: {cpuResult}");
                    Console.WriteLine("\\==--==--==--==--==--==--==/\n");

                    if (cpuPosition == 5 || cpuPosition == 10 || cpuPosition == 15 || cpuPosition == 25)
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"   CPU na casa de sorte {cpuPosition}!!\n  Avanço extra de 3 casas!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==--==/\n");
                        cpuPosition += 3;
                    }
                    else if (cpuPosition == 7 || cpuPosition == 13 || cpuPosition == 20)
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"   Que azar! CPU na casa {cpuPosition}..\n  Recuo de 2 casas =/");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                        cpuPosition -= 2;
                    }

                    if (cpuPosition <= 9)
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"    CPU está na casa {cpuPosition} de {endLine}!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                    }
                    else
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"   CPU está na casa {cpuPosition} de {endLine}!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                    }
                    if (cpuPosition >= endLine)
                    {
                        MainHeader();
                        Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"  CPU alcançou a casa {cpuPosition} e ultrapassou a linha de chegada!!");
                        Console.WriteLine("  Parabéns!!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n");
                        onGoing = false;
                        continue;
                    }

                    Console.Write("Pressione [Enter] para ir à próxima rodada.");
                    Console.ReadKey();
                } while (onGoing);

                Console.Write("Deseja jogar novamente? (S/N) ");
                string optionContinue = Console.ReadLine()!.ToUpper();
                if (optionContinue != "S" && optionContinue != "SIM" && optionContinue != "SI")
                    break;

            } while (true);
        }
        static void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("            Jogo dos Dados");
            Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
        }
        static void UserTurn()
        {
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("            Turno do Usuário");
            Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
        }        
        static void CPUTurn()
        {
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("              Turno da CPU");
            Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
        }
        static int RollDice()
        {
            Random numberGenerator = new Random();
            int result = numberGenerator.Next(1, 7);
            return result;
        }
    }
}

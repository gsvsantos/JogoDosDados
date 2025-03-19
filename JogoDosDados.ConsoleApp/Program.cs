namespace JogoDosDados.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random numberGenerator = new Random();
            const int endLine = 30;

            do
            {
                int playerPosition = 0;
                bool onGoing = true;

                do
                {
                    Header();
                    Console.Write("Pressione [Enter] para lançar o dado...");
                    Console.ReadKey();

                    int result = numberGenerator.Next(1, 7);

                    Header();
                    Console.WriteLine("/==--==--==--==--==--==--==\\");
                    Console.WriteLine($"  O dado caiu no número: {result}");
                    Console.WriteLine("\\==--==--==--==--==--==--==/\n");

                    playerPosition += result;
                    if (playerPosition >= endLine)
                    {
                        onGoing = false;

                        Header();
                        Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($" Você alcançou a casa {playerPosition} e ultrapassou a linha de chegada!!");
                        Console.WriteLine(" Parabéns!!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n");
                    }
                    else if (playerPosition <= 9)
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"   Você está na casa {playerPosition} de {endLine}!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                        Console.Write("Pressione [Enter] para lançar o dado...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("/==--==--==--==--==--==--==--==\\");
                        Console.WriteLine($"  Você está na casa {playerPosition} de {endLine}!!");
                        Console.WriteLine("\\==--==--==--==--==--==--==--==/\n");
                        Console.Write("Pressione [Enter] para lançar o dado...");
                        Console.ReadKey();
                    }
                } while (onGoing);

                Console.Write("Deseja continuar? (S/N) ");
                string optionContinue = Console.ReadLine()!.ToUpper();
                if (optionContinue != "S" && optionContinue != "SIM" && optionContinue != "SI")
                    break;

            } while (true);
        }
        static void Header()
        {
            Console.Clear();
            Console.WriteLine("/==--==--==--==--==--==--==--==--==--==\\");
            Console.WriteLine("            Jogo dos Dados");
            Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");
        }
    }
}

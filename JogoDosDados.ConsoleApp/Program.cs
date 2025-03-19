namespace JogoDosDados.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random numberGenerator = new Random();

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

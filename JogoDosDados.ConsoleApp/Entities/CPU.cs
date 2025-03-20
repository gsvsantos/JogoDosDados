namespace JogoDosDados.ConsoleApp.Entities
{
    public class CPU
    {
        public static int Turn(int cpuPosition)
        {
            Console.WriteLine("              Turno da CPU");
            Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==/\n");

            int cpuResult = DiceGame.RollDice();
            int cpuOldPosition = cpuPosition;
            cpuPosition += cpuResult;

            Console.WriteLine("/==--==--==--==--==--==--==\\");
            Console.WriteLine($"  Posição anterior: {cpuOldPosition}");
            Console.WriteLine($"  O dado caiu no número: {cpuResult}");
            Console.WriteLine($"  Posição atual: {cpuPosition}");
            Console.WriteLine("\\==--==--==--==--==--==--==/\n");

            cpuPosition = LuckyTest(cpuPosition);

            return cpuPosition;
        }
        public static int LuckyTest(int cpuPosition)
        {
            if (cpuPosition == 6)
            {
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"     Sorte grande!! Ganho uma rodada extra!");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==/\n");

                int cpuResult = DiceGame.RollDice();
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
        public static bool CheckWin(int cpuPosition, int userPosition)
        {
            if (cpuPosition >= DiceGame.endLine && cpuPosition > userPosition)
                return true;
            else
                return false;
        }
    }
}

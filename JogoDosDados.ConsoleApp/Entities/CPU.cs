using JogoDosDados.ConsoleApp.Entities.Utils;

namespace JogoDosDados.ConsoleApp.Entities
{
    public class CPU
    {
        public static int Turn(int cpuPosition)
        {
            ViewUtils.Headers("TURNO-CPU");
            int cpuResult = DiceGame.RollDice();
            int cpuOldPosition = cpuPosition;
            cpuPosition += cpuResult;
            ViewUtils.PositionStatus(cpuOldPosition, cpuResult, cpuPosition);
            cpuPosition = LuckyTest(cpuPosition);
            return cpuPosition;
        }
        public static int LuckyTest(int cpuPosition)
        {
            if (cpuPosition == 6)
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Sorte Grande!!\n", ConsoleColor.Green);
                ViewUtils.PaintWrite($"  Ganhou uma rodada extra!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");

                int cpuResult = DiceGame.RollDice();
                cpuPosition += cpuResult;

                ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  O dado caiu no número: {cpuResult}\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {cpuPosition}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");
            }
            if (cpuPosition == 5 || cpuPosition == 10 || cpuPosition == 15 || cpuPosition == 25)
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Casa Sorteada!!\n", ConsoleColor.Green);
                ViewUtils.PaintWrite($"  CPU caiu na casa {cpuPosition}!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("  Ganhou um avanço extra de 3 casas!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {cpuPosition += 3}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==/\n\n");
            }
            else if (cpuPosition == 7 || cpuPosition == 13 || cpuPosition == 20)
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Que Azar =/\n", ConsoleColor.Red);
                ViewUtils.PaintWrite($"  CPU caiu na casa {cpuPosition}..\n", ConsoleColor.White);
                ViewUtils.PaintWrite("  Recuo de 2 casas!!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {cpuPosition -= 2}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==/\n\n");
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

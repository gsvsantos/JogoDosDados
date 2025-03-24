using System.Numerics;
using JogoDosDados.ConsoleApp.Entities.Utils;

namespace JogoDosDados.ConsoleApp.Entities
{
    public class DiceGame
    {
        public static User user = new User();
        public static CPU cpu = new CPU();
        public const int endLine = 30;

        public static void GameStart()
        {
            bool onGoing;

            do
            {
                bool hasWinner;

                do
                {
                    ViewUtils.Headers("JOGO-DOS-DADOS");
                    user.Turn();

                    ViewUtils.PressEnter("TURNO-CPU");

                    ViewUtils.Headers("JOGO-DOS-DADOS");
                    cpu.Turn();

                    hasWinner = ShowResult();
                    if (hasWinner == true)
                        continue;

                    ViewUtils.PressEnter("PROXIMA-RODADA");
                } while (hasWinner == false);

                user.actualPosition = 0;
                cpu.actualPosition = 0;

                onGoing = ViewUtils.Continue();
            } while (onGoing == true);
        }
        public static int LuckyTest(int actualPosition, int rollResult)
        {
            int rollExtra = 6;
            int[] luckySpaces = [5, 11, 15, 25];
            int[] unluckySpaces = [7, 13, 20];

            if (actualPosition == rollExtra)
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Sorte Grande!!\n", ConsoleColor.Green);
                ViewUtils.PaintWrite($"  Ganhou uma rodada extra!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");

                actualPosition += rollResult;

                ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  O dado caiu no número: {rollResult}\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {actualPosition}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");
            }

            if (luckySpaces.Contains(actualPosition))
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Casa Sorteada!!\n", ConsoleColor.Green);
                ViewUtils.PaintWrite($"  Você caiu na casa {actualPosition} e ganhou..\n", ConsoleColor.White);
                ViewUtils.PaintWrite("  Avanço extra de 3 casas!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {actualPosition += 3}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==/\n\n");
            }
            else if (unluckySpaces.Contains(actualPosition))
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Que Azar =/\n", ConsoleColor.Red);
                ViewUtils.PaintWrite($"  Caiu na casa {actualPosition}..\n", ConsoleColor.White);
                ViewUtils.PaintWrite("  Recuo de 2 casas!!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {actualPosition -= 2}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==/\n\n");
            }

            return actualPosition;
        }
        public static bool CheckWin(bool checkPlayerWin, bool checkCPUWin)
        {
            if (checkPlayerWin && user.actualPosition >= DiceGame.endLine && user.actualPosition > cpu.actualPosition)
                return true;
            if (checkCPUWin && cpu.actualPosition >= DiceGame.endLine && cpu.actualPosition > user.actualPosition)
                return true;
            else
                return false;
        }
        public static bool ShowResult()
        {
            bool playerWin = CheckWin(true, false);
            bool cpuWin = CheckWin(false, true);

            if (playerWin == true)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("VENCEDOR");
                ViewUtils.PaintWrite($"   Você alcançou a casa {user.actualPosition} e ultrapassou a linha de chegada!!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("                          VOCÊ VENCEU!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
                return true;
            }
            else if (cpuWin == true)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("VENCEDOR");
                ViewUtils.PaintWrite($"    CPU alcançou a casa {cpu.actualPosition} e ultrapassou a linha de chegada!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("                           CPU VENCEU\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
                return true;
            }
            else if (user.actualPosition == cpu.actualPosition && user.actualPosition >= endLine && cpu.actualPosition >= endLine)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("EMPATE");
                ViewUtils.PaintWrite($"   Você e a CPU ultrapassaram a linha de chegada juntos!!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"                         CPU:  ({cpu.actualPosition})\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"                         Você: ({user.actualPosition})\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
                return true;
            }
            else
                return false;
        }
        public static void GameAbout()
        {
            ViewUtils.Headers("SOBRE");
            ViewUtils.PaintWrite("\n1. Inicie uma nova partida no menu principal.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("2. O jogo começa com você e a CPU na linha de partida (0).\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("3. Na sua vez, você deverá jogar o dado para descobrir quantas casas você vai andar.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("4. A CPU jogará seu próprio dado automaticamente.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("5. Ganhará quem passar a linha de chegada primeiro.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("6. Em caso de ultrapassarem a linha juntos, ganha quem estiver na maior distância.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("7. Haverá empate se ambos chegarem na mesma casa superior a linha de chegada.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("\nRegras Especiais.\n", ConsoleColor.Red);
            ViewUtils.PaintWrite("- Casas únicas podem ajudar com avanços extras, ou atrapalhar fazendo recuar casas.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("- Se tirar 6 no dado, o dado irá rodar novamente.\n", ConsoleColor.Yellow);
            ViewUtils.PaintWrite("\n/==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==\\\n\n");

            ViewUtils.PressEnter("VOLTAR-MENU");
        }

    }
}

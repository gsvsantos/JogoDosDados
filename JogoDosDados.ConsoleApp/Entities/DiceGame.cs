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
        public static int LuckyTest(int oldPosition, int rollResult, int actualPosition)
        {
            int rollExtra = 6;
            int[] luckySpaces = [5, 11, 15, 25];
            int[] unluckySpaces = [7, 13, 20];

            if (rollResult == rollExtra)
            {
                ViewWrite.ExtraRollText();

                rollResult += Entity.RollDice();
                actualPosition += rollResult;

                ViewWrite.PositionStatus(oldPosition, rollResult, actualPosition);
            }

            if (luckySpaces.Contains(actualPosition))
            {
                ViewWrite.LuckyHouseText(actualPosition);
            }
            else if (unluckySpaces.Contains(actualPosition))
            {
                ViewWrite.UnluckyHouseText(actualPosition);
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
                ViewWrite.PlayerWinText(user.actualPosition);
                return true;
            }
            else if (cpuWin == true)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("VENCEDOR");
                ViewWrite.CPUWinText(user.actualPosition);
                return true;
            }
            else if (user.actualPosition == cpu.actualPosition && user.actualPosition >= endLine && cpu.actualPosition >= endLine)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("EMPATE");
                ViewWrite.DrawResultText(user.actualPosition, cpu.actualPosition);
                return true;
            }
            else
                return false;
        }
        public static void GameAbout()
        {
            ViewUtils.Headers("SOBRE");
            ViewWrite.GameAboutText();

            ViewUtils.PressEnter("VOLTAR-MENU");
        }

    }
}

namespace JogoDosDados.ConsoleApp.Entities
{
    public class Player
    {
        public static int Turn(int userPosition)
        {
            ViewUtils.Headers("TURNO-USUARIO");
            ViewUtils.PressEnter("JOGAR-DADO");
            int userResult = DiceGame.RollDice();
            int userOldPosition = userPosition;
            userPosition += userResult;
            ViewUtils.PositionStatus(userOldPosition, userResult, userPosition);
            userPosition = LuckyTest(userPosition);
            return userPosition;
        }
        public static int LuckyTest(int userPosition)
        {
            if (userPosition == 6)
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Sorte Grande!!\n", ConsoleColor.Green);
                ViewUtils.PaintWrite($"  Ganhou uma rodada extra!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");

                int userResult = DiceGame.RollDice();
                userPosition += userResult;

                ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  O dado caiu no número: {userResult}\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {userPosition}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");
            }
            if (userPosition == 5 || userPosition == 11 || userPosition == 15 || userPosition == 25)
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Casa Sorteada!!\n", ConsoleColor.Green);
                ViewUtils.PaintWrite($"  Você caiu na casa {userPosition} e ganhou..\n", ConsoleColor.White);
                ViewUtils.PaintWrite("  Avanço extra de 3 casas!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {userPosition += 3}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==/\n\n");
            }
            else if (userPosition == 7 || userPosition == 13 || userPosition == 20)
            {
                ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==\\\n");
                ViewUtils.PaintWrite($"  Que Azar =/\n", ConsoleColor.Red);
                ViewUtils.PaintWrite($"  Caiu na casa {userPosition}..\n", ConsoleColor.White);
                ViewUtils.PaintWrite("  Recuo de 2 casas!!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"  Posição atual: {userPosition -= 2}\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==/\n\n");
            }
            return userPosition;
        }
        public static bool CheckWin(int userPosition, int cpuPosition)
        {
            if (userPosition >= DiceGame.endLine && userPosition > cpuPosition)
                return true;
            else
                return false;
        }
    }
}

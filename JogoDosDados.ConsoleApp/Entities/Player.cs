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
                Console.WriteLine("/==--==--==--==--==--==--==--==--==--==--==--==\\");
                Console.WriteLine($"     Sorte grande!! Ganho uma rodada extra!");
                Console.WriteLine("\\==--==--==--==--==--==--==--==--==--==--==--==/\n");

                int userResult = DiceGame.RollDice();
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
        public static bool CheckWin(int userPosition, int cpuPosition)
        {
            if (userPosition >= DiceGame.endLine && userPosition > cpuPosition)
                return true;
            else
                return false;
        }
    }
}

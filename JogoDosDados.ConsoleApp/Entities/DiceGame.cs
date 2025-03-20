namespace JogoDosDados.ConsoleApp.Entities
{
    public class DiceGame
    {
        public const int endLine = 30;
        public static void GameStart()
        {
            bool onGoing;
            do
            {
                int userPosition = 0;
                int cpuPosition = 0;
                bool hasWinner;

                do
                {
                    ViewUtils.Headers("JOGO-DOS-DADOS");
                    userPosition = Player.Turn(userPosition);
                    ViewUtils.PressEnter("TURNO-CPU");
                    ViewUtils.Headers("JOGO-DOS-DADOS");
                    cpuPosition = CPU.Turn(cpuPosition);
                    hasWinner = ShowResult(userPosition, cpuPosition);
                    if (hasWinner == true)
                        continue;
                    ViewUtils.PressEnter("PROXIMA-RODADA");
                } while (hasWinner == false);
                onGoing = ViewUtils.Continue();
            } while (onGoing == true);
        }
        public static int RollDice()
        {
            Random numberGenerator = new Random();
            int result = numberGenerator.Next(1, 7);
            return result;
        }
        public static bool ShowResult(int userPosition, int cpuPosition)
        {
            bool playerWin = Player.CheckWin(userPosition, cpuPosition);
            bool cpuWin = CPU.CheckWin(cpuPosition, userPosition);
            if (playerWin == true)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("VENCEDOR");
                ViewUtils.PaintWrite($"   Você alcançou a casa {userPosition} e ultrapassou a linha de chegada!!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("                          VOCÊ VENCEU!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
                return true;
            }
            else if (cpuWin == true)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("VENCEDOR");
                ViewUtils.PaintWrite($"    CPU alcançou a casa {cpuPosition} e ultrapassou a linha de chegada!\n", ConsoleColor.White);
                ViewUtils.PaintWrite("                           CPU VENCEU\n", ConsoleColor.White);
                ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
                return true;
            }
            else if (userPosition == cpuPosition && userPosition >= endLine && cpuPosition >= endLine)
            {
                ViewUtils.PressEnter("VER-RESULTADO");
                ViewUtils.Headers("EMPATE");
                ViewUtils.PaintWrite($"   Você e a CPU ultrapassaram a linha de chegada juntos!!\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"                         CPU:  ({cpuPosition})\n", ConsoleColor.White);
                ViewUtils.PaintWrite($"                         Você: ({userPosition})\n", ConsoleColor.White);
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

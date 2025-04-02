namespace JogoDosDados.ConsoleApp.Entities.Utils;

public class ViewWrite
{
    public static void MainMenuOptions()
    {
        ViewUtils.PaintWrite("1 >> Começar a Partida\n", ConsoleColor.White);
        ViewUtils.PaintWrite("2 >> Sobre o Jogo\n", ConsoleColor.White);
        ViewUtils.PaintWrite("S >> Fechar Jogo\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\nOpção: ", ConsoleColor.White);
    }
    public static void GoodbyeText()
    {
        ViewUtils.PaintWrite("Adeus (T_T)/\n", ConsoleColor.Red);
    }
    public static void PositionStatus(int oldPosition, int rollResult, int actualPosition)
    {
        ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
        ViewUtils.PaintWrite($"  Posição anterior: {oldPosition}\n", ConsoleColor.White);
        ViewUtils.PaintWrite($"  O dado caiu no número: {rollResult}\n", ConsoleColor.White);
        ViewUtils.PaintWrite($"  Posição atual: {actualPosition}\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");
    }
    public static void ExtraRollText()
    {
        ViewUtils.PaintWrite("/==--==--==--==--==--==--==\\\n");
        ViewUtils.PaintWrite($"  Sorte Grande!!\n", ConsoleColor.Green);
        ViewUtils.PaintWrite($"  Ganhou uma rodada extra!\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\\==--==--==--==--==--==--==/\n\n");
    }
    public static void LuckyHouseText(int actualPosition)
    {
        ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==--==\\\n");
        ViewUtils.PaintWrite($"  Casa Sorteada!!\n", ConsoleColor.Green);
        ViewUtils.PaintWrite($"  Você caiu na casa {actualPosition} e ganhou..\n", ConsoleColor.White);
        ViewUtils.PaintWrite("  Avanço extra de 3 casas!\n", ConsoleColor.White);
        ViewUtils.PaintWrite($"  Posição atual: {actualPosition += 3}\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==/\n\n");
    }
    public static void UnluckyHouseText(int actualPosition)
    {
        ViewUtils.PaintWrite("/==--==--==--==--==--==--==--==\\\n");
        ViewUtils.PaintWrite($"  Que Azar =/\n", ConsoleColor.Red);
        ViewUtils.PaintWrite($"  Caiu na casa {actualPosition}..\n", ConsoleColor.White);
        ViewUtils.PaintWrite("  Recuo de 2 casas!!\n", ConsoleColor.White);
        ViewUtils.PaintWrite($"  Posição atual: {actualPosition -= 2}\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==/\n\n");
    }
    public static void PlayerWinText(int userActualPosition)
    {
        ViewUtils.PaintWrite($"   Você alcançou a casa {userActualPosition} e ultrapassou a linha de chegada!!\n", ConsoleColor.White);
        ViewUtils.PaintWrite("                          VOCÊ VENCEU!\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
    }
    public static void CPUWinText(int cpuActualPosition)
    {
        ViewUtils.PaintWrite($"    CPU alcançou a casa {cpuActualPosition} e ultrapassou a linha de chegada!\n", ConsoleColor.White);
        ViewUtils.PaintWrite("                           CPU VENCEU\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
    }
    public static void DrawResultText(int userActualPosition, int cpuActualPosition)
    {
        ViewUtils.PaintWrite($"   Você e a CPU ultrapassaram a linha de chegada juntos!!\n", ConsoleColor.White);
        ViewUtils.PaintWrite($"                         CPU:  ({cpuActualPosition})\n", ConsoleColor.White);
        ViewUtils.PaintWrite($"                         Você: ({userActualPosition})\n", ConsoleColor.White);
        ViewUtils.PaintWrite("\\==--==--==--==--==--==--==--==--==--==--==--==--==--==--==/\n\n");
    }
    public static void GameAboutText()
    {
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
    }
}

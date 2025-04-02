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
    public static void Goodbye()
    {
        ViewUtils.PaintWrite("Adeus (T_T)/\n", ConsoleColor.Red);
    }
}

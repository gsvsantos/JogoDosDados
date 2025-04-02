using JogoDosDados.ConsoleApp.Entities.Utils;

namespace JogoDosDados.ConsoleApp.Entities
{
    public class Entity
    {
        static Random numberGenerator = new Random();
        public int actualPosition = 0;
        public int oldPosition = 0;
        public int rollResult = 0;

        public static int RollDice()
        {
            return numberGenerator.Next(1, 7);
        }
        public virtual void Turn()
        {
            rollResult = RollDice();
            oldPosition = actualPosition;
            actualPosition += rollResult;

            ViewWrite.PositionStatus(oldPosition, rollResult, actualPosition);

            actualPosition = DiceGame.LuckyTest(oldPosition, rollResult, actualPosition);
        }
    }
}

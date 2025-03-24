using JogoDosDados.ConsoleApp.Entities.Utils;

namespace JogoDosDados.ConsoleApp.Entities
{
    public class User : Entity
    {
        public override void Turn()
        {
            ViewUtils.Headers("TURNO-USUARIO");
            base.Turn();
        }
    }
}

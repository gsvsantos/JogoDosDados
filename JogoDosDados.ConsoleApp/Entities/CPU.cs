﻿using JogoDosDados.ConsoleApp.Entities.Utils;

namespace JogoDosDados.ConsoleApp.Entities
{
    public class CPU : Entity
    {
        public override void Turn()
        {
            ViewUtils.Headers("TURNO-CPU");
            base.Turn();
        }
    }
}

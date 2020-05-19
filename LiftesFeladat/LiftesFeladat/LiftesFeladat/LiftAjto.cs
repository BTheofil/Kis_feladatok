using System;
using System.Collections.Generic;
using System.Text;

namespace LiftesFeladat
{
    class LiftAjto : IObserver
    {
        private int emelet;
        private Lift lift;


        public LiftAjto(Lift lift,int emelet)
        {
            this.emelet = emelet;
            this.lift = lift;
            lift.Attach(this);
            Update();
        }

        public void Update()
        {

            Console.SetCursorPosition(lift.Lepcsohaz*20, emelet);
            if (emelet == lift.Emelet)
            {
                Console.Write($"{emelet}: [*]");
            }
            else {
                Console.Write($"{emelet}: [{lift.Emelet}]");
            }
        }
    }
}

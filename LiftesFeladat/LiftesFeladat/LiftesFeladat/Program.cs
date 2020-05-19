using System;

namespace LiftesFeladat
{
    class Program
    {
        static void Main(string[] args)
        {
            Lift l1 = new Lift(1);
            Lift l2 = new Lift(2);


            for (int i = 1; i < 6; i++)
            {
                var liftAjto = new LiftAjto(l1, i);

            }
            var vezerlo = new Vezerlo(l1);

            for (int i = 1; i < 5; i++)
            {
                var liftAjto = new LiftAjto(l2, i);

            }
            var vezerlo2 = new Vezerlo(l2);

            //l2.Detach()

            l1.Hivas(5);
            l2.Hivas(4);
            l1.Hivas(2);
            l2.Hivas(1);
        }
    }
}

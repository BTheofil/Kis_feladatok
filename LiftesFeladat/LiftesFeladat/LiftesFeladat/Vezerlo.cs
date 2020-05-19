using System;
using System.Collections.Generic;
using System.Text;

namespace LiftesFeladat
{
    public class Vezerlo : IObserver
    {
        private Lift lift;

        public Vezerlo(Lift lift) {
            this.lift = lift;
            this.lift.Attach(this);
            Update();
        }

        public void Update()
        {

            Console.SetCursorPosition(0, 11);
            Console.WriteLine($"Vezerles: {lift.Emelet}->{lift.celEmelet}");
        }

        public void Start()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Hova-hova kisnyulacska?");

            var key = Console.ReadKey(true);
            while ("12345".Contains(key.KeyChar))
            {
                lift.Hivas(int.Parse(key.KeyChar.ToString()));
                key = Console.ReadKey(true);
            }
            Console.WriteLine("Bye-bye");
        }
    }
}

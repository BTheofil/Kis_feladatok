using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LiftesFeladat
{
    public class Lift : Subject
    {
        public int celEmelet
        {
            get;
            private set;
        } = 1;

        public int Emelet
        {
            get;
            private set;
        } = 1;

        public int Lepcsohaz
        {
            get;
            private set;
        } = 1;

        public void Hivas(int cel) {
            this.celEmelet = cel;
            int lepes = Emelet > cel ? -1 : 1;

            while (Emelet != cel)
            {
                Emelet += lepes;
                Notify();
                Thread.Sleep(1000);
            }
        }

        public Lift(int lepcsohaz)
        {
            this.Lepcsohaz = lepcsohaz;
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LiftesFeladat
{
    public class Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer) {
            observers.Add(observer);
        }

        public void Detach(IObserver observer) {
            observers.Remove(observer);
        }

        protected void Notify() {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }
}

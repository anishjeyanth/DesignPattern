using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
        string State { get; set; }
    }

    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string _state;
        public string State {
            get
            {
                return _state;
            }
            set { 
                _state = value;
                this.Notify();
            } 
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            Console.WriteLine("Notify");
            foreach (IObserver observer in observers)
            {
                // you can pass value via update method also
                observer.Update(this);
            }
        }
    }

    public class ConcreateObserA : IObserver
    {
        private ISubject Subject;
        public ConcreateObserA(ISubject Subject)
        {
            this.Subject = Subject;
        }
        public void Update(ISubject subject)
        {
            Console.WriteLine(this.Subject.State +" -AA");
        }
    }

    public class ConcreateObserB : IObserver
    {
        private ISubject Subject;
        public ConcreateObserB(ISubject Subject)
        {
            this.Subject = Subject;
        }
        public void Update(ISubject subject)
        {
            Console.WriteLine(this.Subject.State + " -BB");
        }
    }

    public class ConcreateObserC : IObserver
    {
        private ISubject Subject;
        public ConcreateObserC(ISubject Subject)
        {
            this.Subject = Subject;
        }
        public void Update(ISubject subject)
        {
            Console.WriteLine(this.Subject.State + " -CC");
        }
    }

    internal class Observer
    {
        public Observer()
        {
            Subject subject = new Subject();
            subject.State = "anish";
            ConcreateObserA concreateObserA = new ConcreateObserA(subject);
            subject.Attach(concreateObserA);

            ConcreateObserB concreateObserB = new ConcreateObserB(subject);
            subject.Attach(concreateObserB);           

            subject.State = "andrew";
            subject.State = "ashish";

            subject.Detach(concreateObserA);
            subject.State = "ayush";

            ConcreateObserC concreateObserC = new ConcreateObserC(subject);
            subject.Attach(concreateObserC);

            subject.State = "aravind";
        }
    }
}
/* OUTPUT
Notify
Notify
andrew -AA
andrew -BB
Notify
ashish -AA
ashish -BB
Notify
ayush -BB
Notify
aravind -BB
aravind -CC
 */
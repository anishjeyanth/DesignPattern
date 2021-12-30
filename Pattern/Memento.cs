using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public class Memento
    {
        public string Name;
        public Memento(string name)
        {
            this.Name = name;
        }
    }

    public class Originator
    {
        public string State { get; set; }

        public Memento SaveStateToMemento()
        {
            return new Memento(State);
        }

        public void getStateFromMemento(Memento memento)
        {
            State = memento.Name;
        }
    }


    public class Care
    {
        private List<Memento> mementoList=new List<Memento>();

        public void Add(Memento memento)
        {
            mementoList.Add(memento);
        }

        public Memento Get(int index)
        {
            return mementoList[index];
        }
    }

    internal class Mementos
    {
        public Mementos()
        {
            Originator originator = new Originator();
            Care care = new Care();

            originator.State = "state 1";
            originator.State = "state 2";
            care.Add(originator.SaveStateToMemento());

            originator.State = "state 3";
            originator.State = "state 4";
            originator.State = "state 5";
            care.Add(originator.SaveStateToMemento());

            originator.State = "state 6";
            Console.WriteLine(originator.State);

            originator.getStateFromMemento(care.Get(1));
            Console.WriteLine(originator.State);

            originator.getStateFromMemento(care.Get(0));
            Console.WriteLine(originator.State);
        }
    }
}

/* output
state 6
state 5
state 2
 */
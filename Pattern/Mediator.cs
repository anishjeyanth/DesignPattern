using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IMediator
    {
        void Register(Friend friend);
        void Send(Friend friend, string msg);
    }

    public class ConcreteMediator : IMediator
    {
        List<Friend> friends = new List<Friend>();
        public void Register(Friend friend)
        {
            friends.Add(friend);
        }

        public void DisplayDetails()
        {
            foreach(Friend friend in friends)
            {
                Console.WriteLine(friend.Name);
            }
        }

        public void Send(Friend friend, string msg)
        {
            Console.WriteLine($"{friend.Name}-{msg}");
        }
    }

    public abstract class Friend
    {
        protected IMediator mediator;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;  }
        }

        public Friend(IMediator mediator) 
        { 
            this.mediator = mediator; 
        }
    }

    public class Friend1 : Friend
    {
        public Friend1(IMediator mediator,string name) : base(mediator)
        {
            this.Name = name;
        }

        public void Task(string msg)
        {
            //do some other task and send a msg
            mediator.Send(this, msg + DateTime.Now.Date.ToString());
        }
    }

    public class Friend2 : Friend
    {
        public Friend2(IMediator mediator, string name) : base(mediator)
        {
            this.Name = name;
        }

        public void Task(string msg)
        {
            //do some other task and send a msg
            mediator.Send(this, msg + DateTime.Now.TimeOfDay.ToString());
        }
    }

    internal class Mediator
    {
        public Mediator()
        {
            ConcreteMediator mediator  = new ConcreteMediator();
            Friend1 anish = new Friend1(mediator, "anish");
            Friend2 andrew = new Friend2(mediator, "andrew");
            mediator.Register(anish);
            mediator.Register(andrew);
            //mediator.DisplayDetails();

            anish.Task("do christmas decoration");
            andrew.Task("buy apple product");
        }
    }
}

/*
Mediator :It defines the interface for communication between colleague objects.
ConcreteMediator : It implements the mediator interface and coordinates communication between colleague objects.
Colleague : It defines the interface for communication with other colleagues
ConcreteColleague : It implements the colleague interface and communicates with other colleagues through its mediator
 */
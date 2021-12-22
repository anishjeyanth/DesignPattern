using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface Remote
    {
        void On();
        void Off();
    }

    public class OldRemote : Remote
    {
        public void Off()
        {
            Console.WriteLine("Old remote Off");
        }
        public void On()
        {
            Console.WriteLine("Old remote On");
        }
    }

    public class NewRemote : Remote
    {
        public void Off()
        {
            Console.WriteLine("New remote Off");
        }
        public void On()
        {
            Console.WriteLine("New remote On");
        }
    }

    public abstract class TV
    {
        protected Remote remote;
        public TV(Remote remote)
        {
            this.remote = remote;
        }
        public abstract void Working();
        public abstract void NotWorking();

    }

    public class Sony : TV
    {
        public Sony(Remote remote) : base(remote)
        {
        }
        public override void NotWorking()
        {
            Console.WriteLine("Sony NotWorking");
            this.remote.Off();
        }
        public override void Working()
        {
            Console.WriteLine("Sony Working");
            this.remote.On();
        }
    }

    public class Philips : TV
    {
        public Philips(Remote remote) : base(remote)
        {
        }
        public override void NotWorking()
        {
            Console.WriteLine("Philips NotWorking");
            this.remote.Off();
        }
        public override void Working()
        {
            Console.WriteLine("Philips Working");
            this.remote.On();
        }
    }
    internal class Bridge
    {      
        public Bridge()
        {
            TV tV = new Sony(new OldRemote());
            tV.Working();
            tV.NotWorking();

            TV tV1 = new Sony(new NewRemote());
            tV1.Working();
            tV1.NotWorking();

            TV tV2 = new Philips(new OldRemote());
            tV2.Working();
            tV2.NotWorking();

            TV tV3 = new Philips(new NewRemote());
            tV3.Working();
            tV3.NotWorking();
        }
    }
}

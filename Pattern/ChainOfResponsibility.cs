namespace DesignPattern.Pattern
{
    public interface IReceiver
    {
        IReceiver NextHandler { get; set; }
        bool Process(string filename,int priority);
    }

    public class L3Support : IReceiver
    {
        public IReceiver NextHandler { get; set; }
        public bool Process(string filename, int priority)
        {
            Console.WriteLine("L3 Handler" + filename);
            if(priority == 3)
                return true;

            if (NextHandler != null)
            {
                NextHandler.Process(filename, priority);
            }

            return false;
        }
    }    

    public class L2Support : IReceiver
    {
        public IReceiver NextHandler { get; set; }
        public bool Process(string filename, int priority)
        {
            Console.WriteLine("L2 Handler" + filename);
            if (priority == 2)
                return true;

            if (NextHandler != null)
            {
                NextHandler.Process(filename, priority);
            }

            return false;
        }
    }

    public class L1Support : IReceiver
    {
        public IReceiver NextHandler { get; set; }
        public bool Process(string filename, int priority)
        {
            Console.WriteLine("L1 Handler" + filename);
            if (NextHandler != null)
            {
                NextHandler.Process(filename, priority);
            }

            return false;
        }
    }

    internal class ChainOfResponsibility
    {
        public ChainOfResponsibility()
        {
            L3Support l3handler = new L3Support();
            L2Support l2handler = new L2Support();
            L1Support l1handler = new L1Support();
            l3handler.NextHandler = l2handler;
            l2handler.NextHandler = l1handler;
            l1handler.NextHandler = null;
            l3handler.Process(" C://Temp", 3);
        }
    }
}

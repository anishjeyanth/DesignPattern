namespace DesignPattern.Pattern
{
    public class VM
    {
        public void Start()
        {
            Console.WriteLine("VM start");
        }

        public void Stop()
        {
            Console.WriteLine("VM stop");
        }
    }

    public class SQL
    {
        public void Create()
        {
            Console.WriteLine("SQL create");
        }

        public void Destory()
        {
            Console.WriteLine("SQL destroy");
        }
    }

    public class SystemFacade
    {
        private VM vm;
        private SQL sql;
        public SystemFacade()
        {
            vm = new VM();
            sql = new SQL();    
        }

        public void MountSystem()
        {
            vm.Start();
            sql.Create();
        }

        public void UnMountSystem()
        {
            sql.Destory();
            vm.Stop();
        }
    }
    internal class Facade
    {
        public Facade()
        {
            SystemFacade systemFacade = new SystemFacade();
            systemFacade.MountSystem();
            Console.WriteLine("----");
            SystemFacade systemFacade1 = new SystemFacade();
            systemFacade1.UnMountSystem();
        }
    }
}

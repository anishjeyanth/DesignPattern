using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IServer
    {
        public void Request();
    }

    public class Server : IServer
    {
        public void Request()
        {
           Console.WriteLine("Server Request.");
        }
    }

    public class ServerProxy : IServer
    {
        private Server server;
        public ServerProxy(Server server)
        {
            this.server = server;
        }   


        public void Request()
        {
            if (this.CheckAccess())
            {
                this.server.Request();
                this.LogAccess();
            }
        }

        private bool CheckAccess()
        {
            Console.WriteLine("Proxy Checking access");

            return true;
        }

        private void LogAccess()
        {
            Console.WriteLine("Proxy Log access");
        }
    }

    internal class Proxy
    {
        public Proxy()
        {
            Server server = new Server();
            ServerProxy serverProxy = new ServerProxy(server);
            serverProxy.Request();
        }
    }
}

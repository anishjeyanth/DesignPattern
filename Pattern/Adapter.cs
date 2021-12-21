using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IWebDrive
    {
        public void getElement();
        public void selectElement();
    }

    public class ChromeDriver : IWebDrive
    {
        public void getElement()
        {
            Console.WriteLine("Get Element chrome");
        }

        public void selectElement()
        {
            Console.WriteLine("Select Element chrome");
        }
    }

    public class IEDriver
    {
        public void pullElement()
        {
            Console.WriteLine("Pull Element IE");
        }

        public void captureElement()
        {
            Console.WriteLine("Capture Element IE");
        }
    }

    public class WebDriverAdapter : IWebDrive
    {
        private IEDriver iEDriver;
        public WebDriverAdapter(IEDriver iEDriver)
        {
            this.iEDriver = iEDriver;
        }

        public void getElement()
        {
            iEDriver.pullElement();
        }

        public void selectElement()
        {
            iEDriver.captureElement();
        }
    }

    internal class Adapter
    {
        public Adapter()
        {
            ChromeDriver chromeDriver = new ChromeDriver(); 
            chromeDriver.getElement();  
            chromeDriver.selectElement();

            IEDriver iEDriver = new IEDriver(); 

            WebDriverAdapter adapter = new WebDriverAdapter(iEDriver);
            adapter.getElement();   
            adapter.selectElement();
        }
    }
}

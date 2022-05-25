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
        //Object Adapter
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

            IEDriver iEDriver = new IEDriver();
            WebDriverAdapter adapter = new WebDriverAdapter(iEDriver);          

            List<IWebDrive> webDrives = new List<IWebDrive>();
            webDrives.Add(chromeDriver);
            webDrives.Add(adapter);

            foreach(IWebDrive webDrive in webDrives)
            {
                webDrive.getElement();
                webDrive.selectElement();
            }
        }
    }
}

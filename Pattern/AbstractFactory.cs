using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IInstance
    {
        void Start();
        void Stop();
        void AttachStorage(IStorage storage);
    }

    public interface IStorage
    {
        string StorageType { get; }
    }

    public class AWSInstance : IInstance
    {
        public AWSInstance(int capasity)
        {
        }
        public void AttachStorage(IStorage storage)
        {
            Console.WriteLine("AWS storage - " + storage.StorageType);
        }

        public void Start()
        {
            Console.WriteLine("AWS start");
        }

        public void Stop()
        {
            Console.WriteLine("AWS stop");
        }
    }

    public class GCPInstance : IInstance
    {
        public GCPInstance(int capasity)
        {
        }

        public void AttachStorage(IStorage storage)
        {
            Console.WriteLine("GCP storage - " + storage.StorageType);
        }

        public void Start()
        {
            Console.WriteLine("GCP start");
        }

        public void Stop()
        {
            Console.WriteLine("GCP stop");
        }
    }

    public class S3Storage : IStorage
    {
        public string StorageType { get; }

        public S3Storage(string type)
        {
            StorageType = type;
        }
    }

    public class GoogleStorage : IStorage
    {
        public string StorageType { get; }

        public GoogleStorage(string type)
        {
            StorageType = type;
        }
    }

    public interface IResourceFactory
    {
        IInstance CreateInstance(int capacity);
        IStorage CreateStorage(string type);
    }

    public class AWSResourceFactory : IResourceFactory
    {
        public IInstance CreateInstance(int capacity)
        {
            return new AWSInstance(capacity);
        }

        public IStorage CreateStorage(string type)
        {
            return new S3Storage(type);
        }
    }

    public class GCPResourceFactory : IResourceFactory
    {
        public IInstance CreateInstance(int capacity)
        {
            return new GCPInstance(capacity);
        }

        public IStorage CreateStorage(string type)
        {
            return new GoogleStorage(type);
        }
    }

    public class Client
    {
        private IResourceFactory _resourceFactory;  
        public Client(IResourceFactory resourceFactory)
        {
            _resourceFactory = resourceFactory;
        }

        public IInstance CreateCloud(int capacity, string type)
        {
            IInstance instance = _resourceFactory.CreateInstance(capacity);
            IStorage storage = _resourceFactory.CreateStorage(type);
            instance.AttachStorage(storage);
            return instance;
        }
    }



    internal class AbstractFactory
    {
        public AbstractFactory()
        {
            Client aws = new Client(new AWSResourceFactory());
            IInstance awsinstance = aws.CreateCloud(1024, "HDD");
            awsinstance.Start();
            awsinstance.Stop();

            Client gcp = new Client(new AWSResourceFactory());
            IInstance gcpinstance = aws.CreateCloud(2048, "SSD");
            gcpinstance.Start();
            gcpinstance.Stop();
        }
    }
}

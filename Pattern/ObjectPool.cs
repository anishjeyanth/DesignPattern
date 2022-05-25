namespace DesignPattern.Pattern
{
    class ObjectPool<T> where T : new()
    {
        private static List<T> Available = new List<T>();
        private List<T> InUse = new List<T>();

        private int counter = 0;
        private int MAXTotalObjects;

        private static ObjectPool<T> instance = null;

        public static ObjectPool<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new ObjectPool<T>();
            }
            else
            {
                Console.WriteLine("This is singleton!");
            }
            return instance;
        }

        public T AcquireReusable()
        {
            if (Available.Count != 0 && Available.Count < 10)
            {
                T item = Available[0];
                InUse.Add(item);
                Available.RemoveAt(0);
                counter--;
                return item;
            }
            else
            {
                T obj = new T();
                InUse.Add(obj);
                return obj;
            }
        }

        public void ReleaseReusable(T item)
        {
            if (counter <= MAXTotalObjects)
            {
                Available.Add(item);
                counter++;
                InUse.Remove(item);
            }
            else
            {
                Console.WriteLine("To much object in pool!");
            }
        }

        public void SetMaxPoolSize(int settingPoolSize)
        {
            MAXTotalObjects = settingPoolSize;
        }
    }

    class PooledObject
    {
        DateTime createdAt = DateTime.Now;

        public DateTime CreatedAt
        {
            get { return createdAt; }
        }
    }

    internal class ObjectPool
    {
        public ObjectPool()
        {
            ObjectPool<PooledObject> objPool = ObjectPool<PooledObject>.GetInstance();
            objPool.SetMaxPoolSize(10);
            PooledObject obj = objPool.AcquireReusable();
            objPool.ReleaseReusable(obj);
            Console.WriteLine(obj.CreatedAt);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IIterator
    {
        Item Next();
        bool IsDone();
    }

    public interface IAbstractCollection
    {
        IIterator CreateIterator();
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ItemCollection : IAbstractCollection
    {
        private List<Item> items;

        public ItemCollection()
        {
            items = new List<Item>();
        }
        public IIterator CreateIterator()
        {
            return new ItemIterator(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public Item this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }

    public class ItemIterator : IIterator
    {
        private ItemCollection Items;
        private int Position;

        public ItemIterator(ItemCollection items)
        {
            this.Items = items;
            Position = 0;
        }

        public Item Next()
        {
            return Items[Position++];
        }

        public bool IsDone()
        {
            if (Position < Items.Count)
                return false;
            else
                return true;
        }
    }


    internal class Iterator
    {        
        public Iterator()
        {
            ItemCollection abstractCollection = new ItemCollection();
            abstractCollection[0] = new Item { Id = 1, Name = "aa" };
            abstractCollection[1] = new Item { Id = 2, Name = "bb" };
            abstractCollection[2] = new Item { Id = 3, Name = "cc" };
            IIterator iterator = abstractCollection.CreateIterator();
            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next().Name);
            }
        }
    }
}

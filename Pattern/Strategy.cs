namespace DesignPattern.Pattern
{
    public interface ISortStrategy
    {
        void Sort(List<string> patterns);
    }

    public class QuickSort: ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();
            Console.WriteLine("QuickSort");
        }
    }

    public class ShellSort : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();
            Console.WriteLine("ShellSort");
        }
    }

    public class MergeSort : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();
            Console.WriteLine("MergeSort");
        }
    }

    public class SortedList
    {
        private List<string> list = new List<string>();
        private ISortStrategy sortStrategy;
        
        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            sortStrategy.Sort(list);
            foreach(string name in list)
            {
                Console.WriteLine(name);
            }
        }

    }

    internal class Strategy
    {
        public Strategy()
        {
            SortedList sortedList = new SortedList();
            sortedList.Add("d");
            sortedList.Add("h");
            sortedList.Add("t");
            sortedList.Add("i");
            sortedList.Add("o");
            sortedList.Add("p");

            sortedList.SetSortStrategy(new QuickSort());
            sortedList.Sort();
            sortedList.SetSortStrategy(new MergeSort());
            sortedList.Sort();
            sortedList.SetSortStrategy(new ShellSort());
            sortedList.Sort();
        }
    }
}
